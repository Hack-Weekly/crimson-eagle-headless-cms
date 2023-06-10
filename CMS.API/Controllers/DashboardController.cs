using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediaService _IMS;
        private IAuthManager _IAM;
        private ILogger<DashboardController> _LOGS;

        public DashboardController(IMediaService IMS, IAuthManager IAM, ILogger<DashboardController> LOGS)
        {
            this._IMS = IMS;
            this._IAM = IAM;
            this._LOGS = LOGS;
        }

        // GET: api/<AccountController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<string> Get()
        {
            return "Project Dashboard";
        }
        /*
        // GET api/<DashboardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DashboardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DashboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DashboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
