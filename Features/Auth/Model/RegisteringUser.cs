using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketA3.Features.Auth.Model
{
    public class RegisteringUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public string? NickName { get; set; }

        public string? ProfileUrl { get; set; }

        public GenderType? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Country { get; set; }

        public MBTIType? MBTI { get; set; }
        public double? HeightCM { get; set; }

        public double? WeightKg { get; set; }

        public double? FatPercentage { get; set; }

        public bool HaveFilledAllPublic() {
            return FullName != null && NickName != null && ProfileUrl != null && Gender != null;
        }

        public bool HaveFilledAllPrivate() {
            return BirthDate != null && Country != null && MBTI != null && HeightCM != null && WeightKg != null && FatPercentage != null;
        }



    }

}
