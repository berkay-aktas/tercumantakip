using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TercumanTakipWeb.Models;
using TercumanTakipWeb.Services;

namespace TercumanTakipWeb.Controllers
{
    [Authorize]
    public class OfisListesiController : Controller
    {
        private readonly TercumanTakipDbContext _context;
        public IUserService _userService { get; set; }

        public OfisListesiController(TercumanTakipDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: OfisListesi
        public async Task<IActionResult> Index()
        {
            var userInfo = _userService.GetUserClaims(User);
            var userSeviye = userInfo?.Seviye;

            if (userSeviye == "10")
            {
                return Forbid();
            }

            return _context.OfisListesi != null ? 
                          View(await _context.OfisListesi.ToListAsync()) :
                          Problem("Entity set 'TercumanTakipDbContext.OfisListesi'  is null.");
        }

        // GET: OfisListesi/Create
        public IActionResult Create()
        {
            var userInfo = _userService.GetUserClaims(User);
            var userSeviye = userInfo?.Seviye;

            if (userSeviye == "10")
            {
                return Forbid();
            }

            return View();
        }

        // POST: OfisListesi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,OfisAdi")] OfisListesi ofisListesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofisListesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ofisListesi);
        }

        // POST: OfisListesi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,OfisAdi")] OfisListesi ofisListesi)
        {
            if (id != ofisListesi.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofisListesi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfisListesiExists(ofisListesi.id))
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
            return View(ofisListesi);
        }

        // POST: OfisListesi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OfisListesi == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.OfisListesi'  is null.");
            }
            var ofisListesi = await _context.OfisListesi.FindAsync(id);
            if (ofisListesi != null)
            {
                _context.OfisListesi.Remove(ofisListesi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfisListesiExists(int id)
        {
          return (_context.OfisListesi?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
