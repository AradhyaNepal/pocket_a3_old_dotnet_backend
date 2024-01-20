using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterOTPResendRequestDTO
    {
        [Required]
        public required string RegistrationId { get; set; }
    }
}
