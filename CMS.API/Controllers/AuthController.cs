using CMS.API.DataAccessLayer.DTOs.APIUser;
using CMS.API.DataAccessLayer.DTOs.AuthResponse;
using CMS.API.DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthManager _iAuthManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthManager iAuthManager, ILogger<AuthController> logger)
        {
            this._iAuthManager = iAuthManager;
            //this._soleManager = roleMgr;
            this._logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status201Created)] // if okay
        public async Task<ActionResult> Register([FromBody] APIUserRegisterDTO DTO)
        {
            _logger.LogInformation($"Failed Register Attempt for {DTO.Email}");

            var result = await _iAuthManager.RegisterNewUser(DTO);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] APIUserLoginDTO DTO)
        {
            _logger.LogInformation($"Failed Login Attempt for {DTO.Email}");

            var authenticatedUser = await _iAuthManager.LoginUser(DTO);

            if (authenticatedUser == null) return Unauthorized();

            return Ok(authenticatedUser);
        }

        [HttpPost]
        [Route("refreshToken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<ActionResult<AuthResponseDTO>> RefreshToken([FromBody] AuthResponseDTO DTO)
        {
            _logger.LogInformation($"Failed Refresh Token Attempt for {DTO.UserId}");

            var authenticatedUser = await _iAuthManager.VerifyRefreshToken(DTO);

            if (authenticatedUser == null) return Unauthorized();

            return Ok(authenticatedUser);
        }

        // TODO forgotten password routes
        // needs e-mail service

    }
}
