using System.Security.Claims;
using TercumanTakipWeb.Models;

namespace TercumanTakipWeb.Services
{
    public interface IUserService
    {
        public Users GetUserClaims(ClaimsPrincipal user);
        public List<Claim> SetUserClaims(Users user);
    }
}
