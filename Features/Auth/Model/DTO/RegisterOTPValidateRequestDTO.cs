using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterOTPValidateRequestDTO
    {
        [Required]
       public required string OTP { get; set; }

        [Required]
        public required string RegistrationId { get; set; }
    }
}
