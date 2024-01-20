using PocketA3.Features.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegistrationRestoreDTO
    {
        public RegisterPublicDetailsRequestDTO? PublicDetails { get; set; }
        public RegisterPrivateDetailsRequestDTO? PrivateDetails { get; set; }

        static public RegistrationRestoreDTO FromRegisteringUser(RegisteringUser registeringUser) {
            return new RegistrationRestoreDTO {
               PublicDetails=registeringUser.HaveFilledPublicDetails()?new RegisterPublicDetailsRequestDTO { 
                   FullName=registeringUser.FullName??"N/A",
                   ProfileUrl=registeringUser.ProfileUrl,
                   Gender=registeringUser.Gender??GenderType.Male,
                   NickName=registeringUser.NickName,
                   RegistrationId=registeringUser.Id,
               } :null,
               PrivateDetails=registeringUser.HaveFilledPrivateDetails()?new RegisterPrivateDetailsRequestDTO { 
                   BirthDate=registeringUser.BirthDate??DateTime.Now,
                   Country=registeringUser.Country??"N/A",
                   MBTI=registeringUser.MBTI,
                   HeightCM=registeringUser.HeightCM,
                   WeightKg=registeringUser.WeightKg,
                   FatPercentage=registeringUser.FatPercentage,
                   RegistrationId=registeringUser.Id,
               } :null,
            }; 
        }
    }
}

[Required]
public required DateTime BirthDate { get; set; }



[Required]
public required string Country { get; set; }

public MBTIType? MBTI { get; set; }

public double? HeightCM { get; set; }

public double? WeightKg { get; set; }

public double? FatPercentage { get; set; }


[Required]
public required string RegistrationId { get; set; }