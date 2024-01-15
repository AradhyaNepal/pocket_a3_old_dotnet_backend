using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketA3.Features.Auth.Model;

namespace PocketA3.Features.Auth.Controller
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpGet]
        public IActionResult Login() {
           

            return Ok();
        }
    }
}
