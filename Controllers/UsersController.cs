using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TercumanTakipWeb.Models;
using TercumanTakipWeb.Services;
using System.DirectoryServices;
using TercumanTakipWeb.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace TercumanTakipWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly TercumanTakipDbContext _context;
        private readonly IUserService _userService;

        public UsersController(TercumanTakipDbContext dbContext = null, IUserService userService = null)
        {
            _context = dbContext;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(Users user)
        {
            //using var hmac = new HMACSHA512();
            if (await _context.Users.AnyAsync(x => x.KullaniciAdi == user.KullaniciAdi))
            {
                return BadRequest("Username or Email is exist");
            }
            user.KullaniciAdi = user.KullaniciAdi.ToLower();
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //GET
        [AllowAnonymous]
        public ActionResult<Users> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Users>> Login(LoginVM loginDto)
        {
            if (AuthenticateUser("sgdd", loginDto.UserName, loginDto.Password))
            {

                Users? user = _context.Users.Where(x => x.KullaniciAdi == loginDto.UserName).SingleOrDefault();

                if (user == null)
                {
                    return View(loginDto);
                }
                var kullanici = _userService.Validate(loginDto);
                var claims = _userService.SetUserClaims(kullanici);
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.UtcNow.AddDays(1);
                Response.Cookies.Append("UserName", loginDto.UserName, option); // Cookie to save user's name

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("LoginError", "*Kullanıcı Adı Veya Şifre Hatalı!");
                return View(loginDto);
            }
        }

        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            //await _service.SignOut(this.HttpContext);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Users");
        }

        public bool AuthenticateUser(string domainName, string userName, string password)
        {
            SearchResult sResults;
            try
            {
                System.DirectoryServices.DirectoryEntry de = new System.DirectoryServices.DirectoryEntry("LDAP://" + domainName, userName, password);
                DirectorySearcher dsearch = new DirectorySearcher(de);
                sResults = dsearch.FindOne();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
