using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterPrivateDetailsRequestDTO
    {
        [Required]
        public required DateTime BirthDate { get; set; }



        [Required]
        public required string Country { get; set; }

        public MBTIType? MBTI { get; set; }

        public double? heightCM { get; set; }

        public double? weightKg { get; set; }

        public double? fatPercentage { get; set; }


        [Required]
        public required string RegistrationId { get; set; }
    }
}
