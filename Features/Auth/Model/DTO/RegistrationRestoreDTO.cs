using PocketA3.Features.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegistrationRestoreDTO
    {
        public required int RegitrationId;
        public required bool FilledPublicDetails { get; set; }

        public required bool FilledPrivateDetails { get; set; }

        public required RegisterPublicDetailsRequestDTO PublicDetails { get; set; }
        public required RegisterPrivateDetailsRequestDTO PrivateDetails { get; set; }

        static public RegistrationRestoreDTO FromRegisteringUser(RegisteringUser registeringUser) {
            return new RegistrationRestoreDTO {
                RegitrationId=registeringUser.Id,
                FilledPublicDetails= registeringUser.HaveFilledPublicDetails(),
               PublicDetails =new RegisterPublicDetailsRequestDTO { 
                   FullName=registeringUser.FullName??"N/A",
                   ProfileUrl=registeringUser.ProfileUrl,
                   Gender=registeringUser.Gender??GenderType.Male,
                   NickName=registeringUser.NickName,
                   RegistrationId=registeringUser.Id,
               },
                FilledPrivateDetails = registeringUser.HaveFilledPrivateDetails(),
                PrivateDetails =new RegisterPrivateDetailsRequestDTO { 
                   BirthDate=registeringUser.BirthDate??DateTime.Now,
                   Country=registeringUser.Country??"N/A",
                   MBTI=registeringUser.MBTI,
                   HeightCM=registeringUser.HeightCM,
                   WeightKg=registeringUser.WeightKg,
                   FatPercentage=registeringUser.FatPercentage,
                   RegistrationId=registeringUser.Id,
               },

               
            }; 
        }
    }
}
