using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocketA3.Common.Services;
using PocketA3.Features.Auth.Model;
using PocketA3.Features.Auth.Model.DTO;
using static System.Net.WebRequestMethods;
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
        public IActionResult RegisterEmail([FromBody]RegisterEmailRequestDTO registerEmailRequest) {
            var isRegistered = _db.User.AsNoTracking().Any(e=>e.Email==registerEmailRequest.Email);
            if (isRegistered) {
                return Conflict("User Already Registered To The System");
            }
            var user = ExtractOrCreateRegisteringUser(registerEmailRequest.Email);
            GenerateAndSendOTP(user);
            return Ok(user.Id);
        }

        private RegisteringUser ExtractOrCreateRegisteringUser(string email) {
            var registeringUser = _db.RegisteringUser.FirstOrDefault(e => e.Email == email);
            if (registeringUser == null)
            {
                var user=_db.RegisteringUser.Add(new RegisteringUser() { Email = email });
                _db.SaveChanges();
                return user.Entity;
            }
            else {
                return registeringUser;
            }
        }

        [HttpPost("s2-validate-otp")]
        public IActionResult ValidateOTP([FromBody] RegisterOTPValidateRequestDTO otpValidateRequest)
        {
            var invalidMessage = "Invalid OTP";
            var user = _db.RegisteringUser.AsNoTracking().FirstOrDefault(e=>e.Id.ToString()==otpValidateRequest.RegistrationId);
            if (user==null)
            {
                return Conflict(invalidMessage);
            }
            var possibleOTP = user.RegisterOTP.LastOrDefault(e=>e.OTPHashed== HashAndSalt.HashInput(input: otpValidateRequest.OTP, salt: e.OTPSalt));
            if (possibleOTP == null)
            {
                return Conflict(invalidMessage);
            }
            else if (possibleOTP.ExpiryDate < DateTime.Now)
            {
                return Conflict("OTP Expired");
            }
            else {
                return Ok(user);
            }
        }

        [HttpPost("s2-resend-otp")]
        public IActionResult ResendOTP(RegisterEmailRequestDTO emailRequestRequest)
        {
            return Ok();
        }

        private  void GenerateAndSendOTP(RegisteringUser user) {
            Random random = new();
            var otp = random.Next(100000, 999999);
            (new SendEmailService()).SendMail(toMail: user.Email??"", body: otp.ToString(), subject: "OTP");
            var oldOTP= _db.RegisterOTP.Where(e => e.RegisteringUser.Email == user.Email);
            if (oldOTP.Count()>0) {
                for (int i = 0; i < oldOTP.Count(); i++) {
                    oldOTP.ElementAt(i).ExpiryDate = DateTime.Now;
                }
            }
           
            var otpSalt = HashAndSalt.GenerateSalt();
            var hashedOTP = HashAndSalt.HashInput(input:otp.ToString(),salt:otpSalt);
            //Todo: Check registering user is null
            //Todo: Save duration in seperate place
            _db.RegisterOTP.Add(new RegisterOTP() { ExpiryDate=DateTime.Now.AddMinutes(10), RegistrationId=user.Id,OTPHashed=hashedOTP,OTPSalt=otpSalt,});
            _db.SaveChanges();
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
