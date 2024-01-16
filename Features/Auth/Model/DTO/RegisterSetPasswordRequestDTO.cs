using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterSetPasswordRequestDTO
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string OTP { get; set; }

        [Required]
        public required string Password { get; set; }

    }
}
