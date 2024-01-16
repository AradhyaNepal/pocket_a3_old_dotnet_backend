using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterPrivateDetailsRequestDTO
    {
        [Required]
        public required DateTime BirthDate { get; set; }

        [Required]
        public required GenderType Gender { get; set; }

        [Required]
        public required string Country { get; set; }

        public MBTIType? MBTI { get; set; }

        [Required]
        public required string Email { get; set; }
    }
}
