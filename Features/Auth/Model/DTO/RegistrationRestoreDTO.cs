using PocketA3.Features.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegistrationRestoreDTO
    {
        public bool isNewlyCreated { get; set; }
        public required int RegitrationId { get; set; }
        public required bool FilledPublicDetails { get; set; }

        public required bool FilledPrivateDetails { get; set; }

        public required RegisterPublicDetailsRequestDTO PublicDetails { get; set; }
        public required RegisterPrivateDetailsRequestDTO PrivateDetails { get; set; }

        static public RegistrationRestoreDTO FromRegisteringUser(RegisteringUser registeringUser,bool isNewlyCreated) {
            return new RegistrationRestoreDTO {
                isNewlyCreated=isNewlyCreated,
                RegitrationId=registeringUser.Id,
                FilledPublicDetails= registeringUser.HaveFilledPublicDetails(),
               PublicDetails =new RegisterPublicDetailsRequestDTO { 
                   FullName=registeringUser.FullName,
                   ProfileUrl=registeringUser.ProfileUrl,
                   Gender=registeringUser.Gender,
                   NickName=registeringUser.NickName,
                   RegistrationId=registeringUser.Id,
               },
                FilledPrivateDetails = registeringUser.HaveFilledPrivateDetails(),
                PrivateDetails =new RegisterPrivateDetailsRequestDTO { 
                   BirthDate=registeringUser.BirthDate,
                   Country=registeringUser.Country,
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
