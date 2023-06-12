using CloudinaryDotNet.Actions;
using CMS.API.DataAccessLayer.DTOs.APIUser;
using CMS.API.DataAccessLayer.DTOs.UserFile;
using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Models;
using CMS.API.DataAccessLayer.Pagination;
using CMS.API.DataAccessLayer.Services;
using CMS.API.Exceptions;
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
        private IAuthManager _IAM;
        private ILogger<DashboardController> _LOGS;
        private IProjectFileRepository _IUF;
        private VideoUploadResult _newVideo;
        private ImageUploadResult _newImage;

        public DashboardController(IMediaService IMS, IAuthManager IAM, ILogger<DashboardController> LOGS, IProjectFileRepository IUF)
        {
            this._IMS = IMS;
            this._IAM = IAM;
            this._LOGS = LOGS;
            this._IUF = IUF;
        }

        // GET: <DashboardController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<ActionResult<PagedResult<ProjectFileDTO>>> GetPagedFiles(int projectId, [FromQuery] QueryParams QP)
        {
           var paged_Project_Files = await _IUF.GetProjectFilesAsync<ProjectFileDTO>(projectId, QP);

            return Ok(paged_Project_Files);
        }

        // GET: <DashboardController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        //public async Task<ActionResult<ProjectFile>> AddProjectFile(UploadProjectFileDTO DTO)
        public async Task<ActionResult> AddProjectFile(UploadProjectFileDTO DTO)
        {
            var isVideo = await IsNewFileVideo(DTO.NewFile);

            if (isVideo == 3) _newVideo = await _IMS.AddVideoAsync(DTO.NewFile);
            else _newImage = await _IMS.AddPhotoAsync(DTO.NewFile);

            var newProjectFile = new ProjectFile
            {
                cmsProjectId = DTO.cmsProjectId,
                Title = DTO.Title,
                Category = DTO.Category,
                Description = DTO.Description,
                UploadedById = DTO.UploadedById,
                UploadedAt = DateTime.Now,
            };

            await _IUF.AddAsync(newProjectFile);
            
            // Debug
            return Ok();
            // Here we want to send back to the dashboard
            // return Redirect("");
        }

        // DELETE: /5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectFile(int id)
        {

            var countrySearchedFor = await _IUF.GetAsync(id);

            if (countrySearchedFor == null) throw new NotFoundException(nameof(DeleteProjectFile), id);

            await _IUF.DeleteAsync(id);

            return NoContent();
        }

        private Task<bool> ProjectFileExists(int id)
        {
            return _IUF.Exists(id);
        }

        private async Task<int> IsNewFileVideo(IFormFile uploadedFile)
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
