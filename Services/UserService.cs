using System.Security.Claims;
using TercumanTakipWeb.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.DirectoryServices;
using System.Security.Claims;
using TercumanTakipWeb.Models.ViewModels;

namespace TercumanTakipWeb.Services
{
    public class UserService : IUserService
    {
        private TercumanTakipDbContext _context;
        public UserService(TercumanTakipDbContext context)
        {
            _context = context;
        }
        public CookieDto GetUserClaims(ClaimsPrincipal User)
        {
            var cookieVM = new CookieDto
            {
                Id = User.FindFirstValue(ClaimTypes.NameIdentifier),
                UserName = User.FindFirstValue(ClaimTypes.Name),
                Email = User.FindFirstValue(ClaimTypes.Email),
                Role = User.FindFirstValue(ClaimTypes.Role),
                Seviye = User.FindFirstValue("Seviye"),
                Name = User.FindFirstValue(ClaimTypes.GivenName),
            };

            return cookieVM;
        }

        public List<Claim> SetUserClaims(CookieDto cookieUserVM)
        {
            List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, cookieUserVM.Id),
            new Claim(ClaimTypes.Name, cookieUserVM.UserName),
            new Claim(ClaimTypes.GivenName, cookieUserVM.Name),
            new Claim(ClaimTypes.Email, cookieUserVM.Email),
            new Claim(ClaimTypes.Role, cookieUserVM.Role),
            new Claim("Seviye", cookieUserVM.Seviye),
        };
            return claims;
        }
        public CookieDto Validate(LoginVM loginDto)
        {
            var userName = _context.Users.Where(x => x.KullaniciAdi == loginDto.UserName);
            if (userName.FirstOrDefault() != null)
            {
                var result = userName.ToList().Select(m => new CookieDto
                {
                    Id = m.id.ToString(),
                    UserName = m.KullaniciAdi,
                    Email = m.EmailAdres,
                    Role = m.KullaniciTipi,
                    Name = m.AdSoyad,
                    Seviye = m.Seviye.ToString()
                });
                return result.FirstOrDefault();
            }
            else
            {

                return null;
            }
        }
        //public Users GetUserClaims(ClaimsPrincipal user)
        //{
        //    var userId = Convert.ToInt32(user.FindFirstValue(ClaimTypes.NameIdentifier));
        //    var userName = user.FindFirstValue(ClaimTypes.Name);

        //    // Fetch the user from the database
        //    var getUser = _context.Users.FirstOrDefault(u => u.id == userId);

        //    if (getUser == null)
        //    {
        //        throw new Exception("User not found");
        //    }

        //    return new Users
        //    {
        //        id = getUser.id,
        //        KullaniciAdi = getUser.KullaniciAdi,
        //        Seviye = getUser.Seviye
        //    };
        //}

        //public List<Claim> SetUserClaims(Users user)
        //{
        //    List<Claim> claims = new()
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
        //        new Claim(ClaimTypes.Name, user.KullaniciAdi),
        //        new Claim("Seviye", user.Seviye.ToString())
        //    };
        //    return claims;
        //}
    }
}
