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
    public class AramaBasligiListesiController : Controller
    {
        private readonly TercumanTakipDbContext _context;
        public IUserService _userService { get; set; }

        public AramaBasligiListesiController(TercumanTakipDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: AramaBasligiListesi
        public async Task<IActionResult> Index()
        {
            var userInfo = _userService.GetUserClaims(User);
            var userSeviye = userInfo?.Seviye;

            if (userSeviye == "10")
            {
                return Forbid();
            }

            return _context.AramaBasligiListesi != null ?
                          View(await _context.AramaBasligiListesi.ToListAsync()) :
                          Problem("Entity set 'TercumanTakipDbContext.AramaBasligiListesi'  is null.");
        }

        // GET: AramaBasligiListesi/Create
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

        // POST: AramaBasligiListesi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,OfisAdi")] AramaBasligiListesi ofisListesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofisListesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ofisListesi);
        }

        // POST: AramaBasligiListesi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,OfisAdi")] AramaBasligiListesi ofisListesi)
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
                    if (!AramaBasligiListesiExists(ofisListesi.id))
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

        // POST: AramaBasligiListesi/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AramaBasligiListesi == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.AramaBasligiListesi'  is null.");
            }
            var ofisListesi = await _context.AramaBasligiListesi.FindAsync(id);
            if (ofisListesi != null)
            {
                _context.AramaBasligiListesi.Remove(ofisListesi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AramaBasligiListesiExists(int id)
        {
            return (_context.AramaBasligiListesi?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
