using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TercumanTakipWeb.Models;
using TercumanTakipWeb.Services;

namespace TercumanTakipWeb.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly TercumanTakipDbContext _context;
        public IUserService _userService { get; set; }

        public KullanicilarController(TercumanTakipDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;

        }

        // GET: Kullanicilar
        public async Task<IActionResult> Index()
        {
            var userInfo = _userService.GetUserClaims(User);
            var userSeviye = userInfo?.Seviye;

            if (userSeviye != "100")
            {
                return Forbid();
            }

            return View(await _context.Users.ToListAsync());
        }

        // GET: Kullanicilar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var userInfo = _userService.GetUserClaims(User);
            var userSeviye = userInfo?.Seviye;

            if (userSeviye != "100")
            {
                return Forbid();
            }

            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Kullanicilar/Create
        public IActionResult Create()
        {
            var userInfo = _userService.GetUserClaims(User);
            var userSeviye = userInfo?.Seviye;

            if (userSeviye != "100")
            {
                return Forbid();
            }

            return View();
        }

        // POST: Kullanicilar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,AdSoyad,EmailAdres,KullaniciAdi,KullaniciTipi,Seviye,Parola,KullaniciDurumu")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Kullanicilar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var userInfo = _userService.GetUserClaims(User);
            var userSeviye = userInfo?.Seviye;

            if (userSeviye != "100")
            {
                return Forbid();
            }

            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Kullanicilar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,AdSoyad,EmailAdres,KullaniciAdi,KullaniciTipi,Seviye,Parola,KullaniciDurumu")] Users users)
        {
            if (id != users.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // POST: Kullanicilar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Users.Remove(users);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
