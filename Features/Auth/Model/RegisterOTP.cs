using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PocketA3.Features.Auth.Model
{
    public class RegisterOTP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        //Todo: Add it as foreign key
        public int RegistrationId { get; set; } 
        public required string OTPHashed { get; set; }

        public required DateTime ExpiryDate { get; set; }


    }
}
