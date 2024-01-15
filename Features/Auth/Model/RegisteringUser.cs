using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model
{
    public class RegisteringUser
    {
        [Required]
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public string? NickName { get; set; }

        public string? ProfileUrl { get; set; }

        public DateTime? BirthDate { get; set; }

        public GenderType? Gender { get; set; }

        public string? Country { get; set; }

        public MBTIType? MBTI { get; set; }

    }

}
