using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterPublicDetailsRequestDTO
    {
        [Required]
        public required string FullName { get; set; }

        public string? NickName { get; set; }

        public string? ProfileUrl { get; set; }

        [Required]
        public required string Email { get; set; }


    }
}
