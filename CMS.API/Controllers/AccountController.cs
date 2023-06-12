using CMS.API.DataAccessLayer.DTOs.APIUser;
using CMS.API.DataAccessLayer.DTOs.AuthResponse;
using CMS.API.DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAuthManager _iAuthManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAuthManager iAuthManager, ILogger<AccountController> logger)
        {
            this._iAuthManager = iAuthManager;
            this._logger = logger;
        }
        // GET: api/<AccountController>/user
        [HttpGet]
        [Route("user")]
        [Authorize(Roles = "ProjectUser, ProjectEditor, ProjectOwner")]
        public async Task<string> Get()
        {
            return "User Dashboard";
        }

        /* POST: api/<AccountController>/register */
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay

        public async Task<ActionResult> Register([FromBody] APIUserDTO DTO)
        {
            var errors = await _iAuthManager.RegisterNewUser(DTO);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                _logger.LogInformation($"Failed Register Attempt for {DTO.Email}");

                return BadRequest(ModelState);
            }

            return Ok();
        }

        /* POST: api/Account/login */
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay

        public async Task<ActionResult> Login([FromBody] APIUserLoginDTO DTO)
        {
            

            var authenticatedUser = await _iAuthManager.LoginUser(DTO);

            if (authenticatedUser == null)
            {
                _logger.LogInformation($"Failed Login Attempt for {DTO.Email}");
                return Unauthorized();
            }

            return Ok(authenticatedUser);
        }

        /* POST: api/Account/registeradmin */
        [HttpPost]
        [Route("registerdmin")]
        [Authorize(Roles = ("ProjectEditor, ProjectOwner"))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<ActionResult> RegisterAdmin([FromBody] APIUserDTO DTO)
        {
            _logger.LogInformation($"Failed Register Admin Attempt for {DTO.Email}");

            var errors = await _iAuthManager.RegisterNewAdmin(DTO);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        /* POST: api/Account/refreshToken */
        [HttpPost]
        [Route("refreshToken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay

        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDTO DTO)
        {
            var authenticatedUser = await _iAuthManager.VerifyRefreshToken(DTO);

            if (authenticatedUser == null)
            {
                _logger.LogInformation($"Failed Refresh Token Attempt for {DTO.UserId}");
                return Unauthorized();
            }

            return Ok(authenticatedUser);
        }

    }
}
