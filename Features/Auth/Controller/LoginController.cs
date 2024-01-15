using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PocketA3.Features.Auth.Controller
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public OkResult getValue() {
            return Ok();
        }
    }
}
