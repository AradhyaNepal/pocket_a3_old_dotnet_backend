using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocketA3.Common.Services;
using PocketA3.Features.Auth.Model;
using PocketA3.Features.Auth.Model.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PocketA3.Features.Auth.Controller
{
    [ApiController]
    [Route("api/v1/auth/register")]//Todo: Refactor
    public class RegisterController : ControllerBase
    {
        private readonly AuthApiContext _db;
        public RegisterController(AuthApiContext db) {
            _db = db;
        }

        [HttpPost("s1-email")]
        async public Task<IActionResult> RegisterEmail([FromBody]RegisterEmailRequestDTO registerEmailRequest) {
      
            Random random = new();
            var otp = random.Next(100000, 999999);
            await(new SendEmailService()).SendEmailAsync(email:registerEmailRequest.Email,message:"OTP",subject:otp.ToString());
            return Ok(otp);
            //Todo: OTP is required in all process else registering user data is sensitive
            var isRegistered = _db.User.AsNoTracking().Any(e=>e.Email==registerEmailRequest.Email);
            if (isRegistered) {
                return Conflict("User Already Registered To The System");
            }
            return GenerateAndSendOTP();

         
        }

        [HttpPost("s2-validate-otp")]
        public IActionResult ValidateOTP([FromBody] RegisterEmailRequestDTO registerEmailRequest)
        {
           
            var registeringUser = _db.RegisteringUser.FirstOrDefault(e => e.Email == registerEmailRequest.Email);
            if (registeringUser == null)
            {
                var newRegisteringUser = _db.RegisteringUser.Add(new RegisteringUser { Email = registerEmailRequest.Email });
                _db.SaveChanges();
                return Ok(RegistrationRestoreDTO.FromRegisteringUser(newRegisteringUser.Entity, true));
            }
            else
            {
                return Ok(RegistrationRestoreDTO.FromRegisteringUser(registeringUser, false));

            }
        }

        [HttpPost("s2-resend-otp")]
        public IActionResult ResendOTP(RegisterEmailRequestDTO emailRequestRequest)
        {
            return Ok();
        }

        private  IActionResult GenerateAndSendOTP() {
     
            //Todo: Send this otp to email of the user

            return Ok();
        }

      


        [HttpPost("s2-public-details")]
        public IActionResult PublicDetails(RegisterPublicDetailsRequestDTO publicDetailsRequest )
        {

            return Ok();
        }

        [HttpPost("s3-private-details")]
        public IActionResult PrivateDetails(RegisterPrivateDetailsRequestDTO privateDetailsRequest)
        {

            return Ok();
        }

     


        [HttpPost("s5-set-password")]
        public IActionResult SetPassword(RegisterSetPasswordRequestDTO setPasswordRequest)
        {
            return Ok();
        }

        [HttpGet("country-list")]
        public IActionResult CountryList() {
            //Todo: Better try catch. First learn how to manage, there must be error log and for user there must be simple message
            using (StreamReader r = new StreamReader("JsonClass/countries.json"))
            {
                string json = r.ReadToEnd();
                return Ok(json);
            }
        }

        [HttpGet("gender-list")]
        public IActionResult GenderList()
        {
            return Ok(EnumMapper.GetValues<GenderType>());
        }

        [HttpGet("mbti-list")]
        public IActionResult MBTI()
        {
            return Ok(EnumMapper.GetValues<MBTIType>());
        }


    }
    public static class EnumMapper
    {
        public static IEnumerable<Dictionary<string, object>> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(x => new Dictionary<string, object>
        {
            { "id", Convert.ChangeType(x, Enum.GetUnderlyingType(typeof(T))) },
            { "value", x.ToString() }
        });
        }
    }
}
