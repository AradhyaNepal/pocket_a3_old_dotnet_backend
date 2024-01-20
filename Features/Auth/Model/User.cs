
using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model
{

    //Todo: Should you Separate enum refactor into another file?
    public enum GenderType
    {
        Male=1,
        Female=2,
        Other=3
    }

    public enum MBTIType
    {
        INTJ=1,
        ENTJ=2,
        ESFP = 3,
        ISFP=4,

        ENFP=5,
        ISTJ=6,
        INFP=7,
        ESTJ=8,

        ENTP=9,
        ISFJ=10,
        INTP=11,
        ESFJ=12,

        ENFJ=13,
        ISTP=14,
        INFJ=15,
        ESTP=16,
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

        public double? HeightCM { get; set; }

        public double? WeightKg { get; set; }

        public double? FatPercentage { get; set; }

        [Required]
        public required string PasswordHash { get; set; }




    }
}
