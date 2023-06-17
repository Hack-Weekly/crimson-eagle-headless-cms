using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.DTOs.APIUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.API.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUsersManager _usersManager;

        public UserController(ILogger<UserController> logger, IUsersManager usersManager)
        {
            this._logger = logger;
            this._usersManager = usersManager;
        }

        // GET: /account
        [HttpGet]
        [Authorize(Roles = "ProjectUser, ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<APIUserDTO>>> GetUsers()
        {
            return Ok(await _usersManager.ListUsers());
        }

        // GET: /account/[id]
        [HttpGet("{id}")]
        [Authorize(Roles = "ProjectUser, ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIUserDTO>> GetUser(string id)
        {
            var user = await _usersManager.GetUserById(id);

            if (user == null)
            {
                _logger.LogInformation($"Couldn't get user by id {id}.");
                return NotFound();
            }
            return Ok(user);
        }

        // POST: /account create user wth the same project than the logged in user
        [HttpPost]
        [Authorize(Roles = "ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIUserDTO>> AddUser([FromBody] APIUserCreateDTO DTO)
        {
            var result = await _usersManager.CreateNewUser(DTO);

            if (!result.Succeeded && result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                _logger.LogInformation($"Couldn't create new user, with errors {ModelState}.");
                return BadRequest(ModelState);
            }

            if (result.Payload == null)
            {
                _logger.LogInformation($"No Payload in CreateNewUser result.");
                return Problem("User was not created.");
            }

            return Created($"/user/{result.Payload.Id}", result.Payload);
        }

        // PUT: /account/[id]
        [HttpPut("{id}")]
        [Authorize(Roles = "ProjectEditor, ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIUserDTO>> UpdateUser(string id, [FromBody] APIUserUpdateDTO DTO)
        {
            var result = await _usersManager.UpdateUser(id, DTO);

            if (!result.Succeeded && result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code == "404")
                    {
                        _logger.LogInformation($"Couldn't find user with id {id}.");
                        return NotFound();
                    }
                    ModelState.AddModelError(error.Code, error.Description);
                }

                _logger.LogInformation($"Couldn't update user, with errors {ModelState}.");
                return BadRequest(ModelState);
            }

            if (result.Payload == null)
            {
                _logger.LogInformation($"No Payload in UpdateUser result.");
                return Problem("User was not created.");
            }

            return Ok(result.Payload);
        }

        // DELETE: /account/[id]
        [HttpDelete("{id}")]
        [Authorize(Roles = "ProjectOwner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var result = await _usersManager.DeleteUser(id);

            if (!result.Succeeded && result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code == "404")
                    {
                        _logger.LogInformation($"Couldn't find user with id {id}.");
                        return NotFound();
                    }
                    ModelState.AddModelError(error.Code, error.Description);
                }

                _logger.LogInformation($"Couldn't update user, with errors {ModelState}.");
                return BadRequest(ModelState);
            }

            return Ok();
        }

    }
}
