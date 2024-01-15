
using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model
{
    
   
   
    public class User
    
    {
        //Todo: Separate class refactor
        public enum Gender
        {
            Male,
            Female,
            Other
        }

        [Required]
     
        public int Id { get; set; }
        
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender gender { get; set; }
        public string ProfileUrl { get; set; }

        public string NickName { get; set; }

     

    }
}
