using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterPrivateDetailsResponseDTO
    {
        [Required]
        public DateTime? BirthDate { get; set; }



        [Required]
        public string? Country { get; set; }

        public MBTIType? MBTI { get; set; }

        public double? HeightCM { get; set; }

        public double? WeightKg { get; set; }

        public double? FatPercentage { get; set; }


        [Required]
        public required int RegistrationId { get; set; }
    }
}
