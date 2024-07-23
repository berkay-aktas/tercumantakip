using System.Security.Claims;
using TercumanTakipWeb.Models;
using TercumanTakipWeb.Models.ViewModels;

namespace TercumanTakipWeb.Services
{
    public interface IUserService
    {
        public CookieDto GetUserClaims(ClaimsPrincipal User);
        public List<Claim> SetUserClaims(CookieDto cookieUserVM);
        CookieDto Validate(LoginVM loginDto);
    }
}
