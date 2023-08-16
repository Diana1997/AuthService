using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    public class TestController : ApiBaseController
    {
        [Authorize]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hi Diana");
        }
    }
}