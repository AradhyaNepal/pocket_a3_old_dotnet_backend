using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterPublicDetailsRequestDTO
    {
        [Required]
        public string? FullName { get; set; }

        [Required]
        public GenderType? Gender { get; set; }

        public string? NickName { get; set; }

        public string? ProfileUrl { get; set; }

        [Required]
        public required int RegistrationId { get; set; }


    }
}
