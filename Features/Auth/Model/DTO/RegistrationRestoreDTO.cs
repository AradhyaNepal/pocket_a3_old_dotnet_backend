using PocketA3.Features.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model.DTO
{
    public class RegistrationRestoreDTO
    {
        public required int RegitrationId { get; set; }
        public required bool FilledAllPublic { get; set; }

        public required bool FilledAllPrivate { get; set; }

        public required RegisterPublicDetailsResponseDTO? PublicDetails { get; set; }
        public required RegisterPrivateDetailsResponseDTO? PrivateDetails { get; set; }

        static public RegistrationRestoreDTO FromRegisteringUser(RegisteringUser registeringUser) {
            return new RegistrationRestoreDTO {
                RegitrationId = registeringUser.Id,
                FilledAllPublic= registeringUser.HaveFilledAllPublic(),
                FilledAllPrivate = registeringUser.HaveFilledAllPrivate(),
                PublicDetails = new RegisterPublicDetailsResponseDTO { 
                   FullName=registeringUser.FullName,
                   ProfileUrl=registeringUser.ProfileUrl,
                   Gender=registeringUser.Gender,
                   NickName=registeringUser.NickName,
               },
                PrivateDetails = new RegisterPrivateDetailsResponseDTO { 
                   BirthDate=registeringUser.BirthDate,
                   Country=registeringUser.Country,
                   MBTI=registeringUser.MBTI,
                   HeightCM=registeringUser.HeightCM,
                   WeightKg=registeringUser.WeightKg,
                   FatPercentage=registeringUser.FatPercentage,
               },
            }; 
        }
    }
}
