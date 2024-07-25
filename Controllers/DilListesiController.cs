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
    public class DilListesiController : Controller
    {
        private readonly TercumanTakipDbContext _context;
        public IUserService _userService { get; set; }

        public DilListesiController(TercumanTakipDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: DilListesi
        public async Task<IActionResult> Index()
        {
            var userInfo = _userService.GetUserClaims(User);
            var userSeviye = userInfo?.Seviye;

            if (userSeviye == "10")
            {
                return Forbid();
            }

            return _context.DilListesi != null ? 
                          View(await _context.DilListesi.ToListAsync()) :
                          Problem("Entity set 'TercumanTakipDbContext.DilListesi'  is null.");
        }

        // GET: DilListesi/Create
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

        // POST: DilListesi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Dil")] DilListesi dilListesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dilListesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dilListesi);
        }

        // POST: DilListesi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Dil")] DilListesi dilListesi)
        {
            if (id != dilListesi.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dilListesi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DilListesiExists(dilListesi.id))
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
            return View(dilListesi);
        }

        // POST: DilListesi/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DilListesi == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.DilListesi'  is null.");
            }
            var dilListesi = await _context.DilListesi.FindAsync(id);
            if (dilListesi != null)
            {
                _context.DilListesi.Remove(dilListesi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DilListesiExists(int id)
        {
          return (_context.DilListesi?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
