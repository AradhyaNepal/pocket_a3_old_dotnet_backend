
using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model
{

    //Todo: Should you Separate enum refactor into another file?
    public enum GenderType
    {
        Male,
        Female,
        Other
    }

    public enum MBTIType
    {
        INTJ,
        ENTJ,
        ESFP,
        ISFP,

        ENFP,
        ISTJ,
        INFP,
        ESTJ,

        ENTP,
        ISFJ,
        INTP,
        ESFJ,

        ENFJ,
        ISTP,
        INFJ,
        ESTP,
    }


    public class User
    

    {
     

        [Required]
     
        public required int Id { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string FullName { get; set; }

        public string? NickName { get; set; }

        public string? ProfileUrl { get; set; }

        [Required]
        public required DateTime BirthDate { get; set; }

        [Required]
        public required GenderType Gender { get; set; }

        [Required]
        public required string Country { get; set; }

        [Required]
        public required MBTIType MBTI { get; set; }

        [Required]
        public required string PasswordHash { get; set; }




    }
}
