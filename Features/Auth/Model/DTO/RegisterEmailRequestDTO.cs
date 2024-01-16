using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegisterEmailRequestDTO
    {
        [Required]
        public required string Email { get; set; }
    }
}
