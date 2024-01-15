using Microsoft.AspNetCore.Mvc;

namespace PocketA3.Features.Auth.Controller
{
    [ApiController]
    [Route("api/v1/auth/register")]//Todo: Refactor
    public class RegisterController : ControllerBase
    {

        [HttpPost("s1-email")]
        public IActionResult RegisterEmail() {

            return Ok();
        }

        [HttpPost("s2-public-details")]
        public IActionResult PublicDetails()
        {

            return Ok();
        }

        [HttpPost("s3-private-details")]
        public IActionResult PrivateDetails()
        {

            return Ok();
        }

        [HttpPost("s4-validate-otp")]
        public IActionResult ValidateOTP() {
            return Ok();
        }

        [HttpPost("s4-resend-otp")]
        public IActionResult ResendOTP()
        {
            return Ok();
        }


        [HttpPost("s5-set-password")]
        public IActionResult SetPassword()
        {
            return Ok();
        }


    }
}
