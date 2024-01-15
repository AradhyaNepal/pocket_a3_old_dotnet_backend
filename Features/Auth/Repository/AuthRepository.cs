using PocketA3.Features.Auth.Model;

namespace PocketA3.Features.Auth.Repository
{
    public class AuthRepository {
        private readonly AuthApiContext _db;
        //private readonly UserManager<User> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private string secretKey;
        //private readonly IMapper _mapper;
        public AuthRepository(AuthApiContext db)
        {
            _db = db; 
        }
    }
}
