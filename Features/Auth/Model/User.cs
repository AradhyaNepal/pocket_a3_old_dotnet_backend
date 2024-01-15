
namespace PocketA3.Features.Auth.Model
{
    public class User
    {
      public int Id { get; set; }
      public string FullName { get; set; }

      public string Email { get; set; }

      public string PasswordHash { get; set; }

      public string ProfileUrl { get; set; }

      public string NickName { get; set; }


    }
}
