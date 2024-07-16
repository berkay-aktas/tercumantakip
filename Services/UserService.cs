using System.Security.Claims;
using TercumanTakipWeb.Models;

namespace TercumanTakipWeb.Services
{
    public class UserService : IUserService
    {
        private TercumanTakipDbContext _context;
        public UserService(TercumanTakipDbContext context)
        {
            _context = context;
        }

        public Users GetUserClaims(ClaimsPrincipal user)
        {
            var getUser = new Users
            {
                id=Convert.ToInt32(user.FindFirstValue(ClaimTypes.NameIdentifier)),
                KullaniciAdi = user.FindFirstValue(ClaimTypes.Name)
            };
            return getUser;
        }

        public List<Claim> SetUserClaims(Users user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.KullaniciAdi)
            };
            return claims;
        }
    }
}
