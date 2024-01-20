﻿using Microsoft.AspNetCore.Mvc;
using PocketA3.Features.Auth.Model;
using PocketA3.Features.Auth.Model.DTO;

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
            //Todo: Scneario when even already exists
            //var data = _db.RegisteringUser.Add(new RegisteringUser { Id = 1 ,Email=registerEmailRequest.Email});
            //_db.SaveChanges();
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

        [HttpPost("s4-validate-otp")]
        public IActionResult ValidateOTP(RegisterOTPValidateRequestDTO otpValidateRequest) {
            return Ok();
        }

        [HttpPost("s4-resend-otp")]
        public IActionResult ResendOTP(RegisterEmailRequestDTO emailRequestRequest)
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
