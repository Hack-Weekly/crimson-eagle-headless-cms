using AutoMapper;
using CloudinaryDotNet.Actions;
using CMS.API.DataAccessLayer.DTOs.UserFile;
using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Models;
using CMS.API.DataAccessLayer.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediaService _IMS;
        private IUsersManager _usersManager;
        private ILogger<DashboardController> _LOGS;
        private IProjectFileRepository _IUF;
        private IMediaRepository _mediaRepository;
        private IMapper _mapper;
        private VideoUploadResult? _newVideo;
        private ImageUploadResult? _newImage;

        public DashboardController(
            IMediaService IMS,
            IUsersManager usersManager,
            ILogger<DashboardController> LOGS,
            IProjectFileRepository IUF,
            IMapper mapper,
            IMediaRepository mediaRepository
        )
        {
            this._IMS = IMS;
            this._usersManager = usersManager;
            this._LOGS = LOGS;
            this._IUF = IUF;
            this._mediaRepository = mediaRepository;
            this._mapper = mapper;
        }

        // GET: <DashboardController>
        [HttpGet]
        [Authorize(Roles = "ProjectUser, ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<ActionResult<PagedResult<ProjectFileDTO>>> GetPagedFiles([FromQuery] QueryParams QP)
        {
            var projectId = await _usersManager.GetProjectFromLoggedInUser();
            if (projectId == null)
            {
                _LOGS.LogInformation($"Couldn't get logged in user's project id.");
                return Problem("Project not found.");
            }

            var paged_Project_Files = await _IUF.GetProjectFilesAsync<ProjectFileDTO>(projectId, QP);

            return Ok(paged_Project_Files);
        }

        // GET: <DashboardController>
        [HttpGet("{id}")]
        [Authorize(Roles = "ProjectUser, ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // missing or malformed id
        [ProducesResponseType(StatusCodes.Status404NotFound)] // file not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<ActionResult<ProjectFileDTO>> GetProjectFile(int id)
        {
            string? projectId = await _usersManager.GetProjectFromLoggedInUser();
            if (projectId == null)
            {
                _LOGS.LogInformation($"Couldn't get logged in user's project id.");
                return Problem("Project not found.");
            }

            ProjectFile? projectFile = await _IUF.GetAsync(id);

            if (projectFile == null)
            {
                _LOGS.LogInformation($"Couldn't find media with id {id}.");
                return NotFound();
            }

            if (projectFile.cmsProjectId != projectId)
            {
                _LOGS.LogInformation($"Logged in user doesn't have the same project id as media {id}.");
                return Problem("You don't have access to this file.");
            }

            return Ok(_mapper.Map<ProjectFile, ProjectFileDTO>(projectFile));
        }

        // POST: <DashboardController>
        // watch out! Not application/json
        [HttpPost]
        [Authorize(Roles = "ProjectUser, ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status201Created)] // if okay        
        public async Task<ActionResult<ProjectFileDTO>> AddProjectFile([FromForm] UploadProjectFileDTO DTO)
        {
            var projectId = await _usersManager.GetProjectFromLoggedInUser();
            if (projectId == null)
            {
                _LOGS.LogInformation($"Couldn't get logged in user's project id.");
                return Problem("Project not found.");
            }

            var currentUserId = _usersManager.GetUserId();
            if (currentUserId == null)
            {
                _LOGS.LogInformation($"Couldn't get logged in user.");
                return Problem("Logged in user not found.");
            }

            var isVideo = IsNewFileVideo(DTO.NewFile);

            DataAccessLayer.Models.UploadResult uploadResult;
            if (isVideo == 3)
            {
                _newVideo = await _IMS.AddVideoAsync(DTO.NewFile);
                if (_newVideo.Error != null)
                {
                    _LOGS.LogInformation($"Cloudinary upload error: {_newVideo.Error.Message}.");
                    return Problem(_newVideo.Error.Message);
                }
                uploadResult = _mapper.Map<VideoUploadResult, DataAccessLayer.Models.UploadResult>(_newVideo);
            }
            else
            {
                _newImage = await _IMS.AddPhotoAsync(DTO.NewFile);
                if (_newImage.Error != null)
                {
                    _LOGS.LogInformation($"Cloudinary upload error: {_newImage.Error.Message}.");
                    return Problem(_newImage.Error.Message);
                }
                uploadResult = _mapper.Map<ImageUploadResult, DataAccessLayer.Models.UploadResult>(_newImage);
            }
            await _mediaRepository.AddAsync(uploadResult);

            var newProjectFile = new ProjectFile
            {
                Title = DTO.NewFile.FileName,
                ImageId = uploadResult.PublicId,
                UploadedAt = DateTime.Now,
                UploadedById = currentUserId,
                cmsProjectId = projectId,
            };

            await _IUF.AddAsync(newProjectFile);

            return Created(uploadResult.SecureUrl, _mapper.Map<ProjectFile, ProjectFileDTO>(newProjectFile));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ProjectUser, ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<ActionResult<ProjectFileDTO>> UpdateProjectFile(int id, [FromBody] UpdateProjectFileDTO DTO)
        {
            string? projectId = await _usersManager.GetProjectFromLoggedInUser();
            if (projectId == null)
            {
                _LOGS.LogInformation($"Couldn't get logged in user's project id.");
                return Problem("Project not found.");
            }

            ProjectFile? projectFile = await _IUF.GetAsync(id);

            if (projectFile == null)
            {
                _LOGS.LogInformation($"Couldn't find media with id {id}.");
                return NotFound();
            }

            if (projectFile.cmsProjectId != projectId)
            {
                _LOGS.LogInformation($"Logged in user doesn't have the same project id as media {id}.");
                return Problem("You don't have access to this file.");
            }

            projectFile = _mapper.Map<UpdateProjectFileDTO, ProjectFile>(DTO, projectFile);

            await _IUF.UpdateAsync(projectFile);

            return Ok(_mapper.Map<ProjectFile, ProjectFileDTO>(projectFile));
        }

        // DELETE: /5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ProjectUser, ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status204NoContent)] // if okay
        public async Task<IActionResult> DeleteProjectFile(int id)
        {
            var projectId = await _usersManager.GetProjectFromLoggedInUser();
            if (projectId == null)
            {
                _LOGS.LogInformation($"Couldn't get logged in user's project id.");
                return Problem("Project not found.");
            }

            var projectFileSearchingFor = await _IUF.GetAsync(id);

            if (projectFileSearchingFor == null)
            {
                _LOGS.LogInformation($"Couldn't find media with id {id}.");
                return NotFound();
            }

            if (projectFileSearchingFor.cmsProjectId != projectId)
            {
                _LOGS.LogInformation($"Logged in user doesn't have the same project id as media {id}.");
                return Problem("You don't have access to this file.");
            }

            DeletionResult result = await _IMS.DeleteMediaAsync(projectFileSearchingFor.Image.PublicId);
            if (result.Result != "ok")
            {
                _LOGS.LogInformation($"Cloudinary delete result was not 'ok' for media {id}: {result.Result}.");
                return Problem("The media could not be deleted on Cloudinary.");
            }

            await _IUF.DeleteAsync(id);

            return NoContent();
        }

        private Task<bool> ProjectFileExists(int id)
        {
            return _IUF.Exists(id);
        }

        private int IsNewFileVideo(IFormFile uploadedFile)
        {
            int fileIsVideo;
            // 3 = video;
            // 2 = image mime type;
            // 1 image extension;
            // 0 = image
            // 3 = video


            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (!string.Equals(uploadedFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(uploadedFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(uploadedFile.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(uploadedFile.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(uploadedFile.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(uploadedFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase)
                ) fileIsVideo = 3;
            else fileIsVideo = 2;

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var uploadedFileExtension = Path.GetExtension(uploadedFile.FileName);
            if (!string.Equals(uploadedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(uploadedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(uploadedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(uploadedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                ) fileIsVideo = 3;
            else fileIsVideo--;

            return fileIsVideo;
        }
    }
}
