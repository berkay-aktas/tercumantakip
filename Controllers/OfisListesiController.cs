using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TercumanTakipWeb.Models;

namespace TercumanTakipWeb.Controllers
{
    public class OfisListesiController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public OfisListesiController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: OfisListesi
        public async Task<IActionResult> Index()
        {
              return _context.OfisListesi != null ? 
                          View(await _context.OfisListesi.ToListAsync()) :
                          Problem("Entity set 'TercumanTakipDbContext.OfisListesi'  is null.");
        }

        // GET: OfisListesi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OfisListesi == null)
            {
                return NotFound();
            }

            var ofisListesi = await _context.OfisListesi
                .FirstOrDefaultAsync(m => m.id == id);
            if (ofisListesi == null)
            {
                return NotFound();
            }

            return View(ofisListesi);
        }

        // GET: OfisListesi/Create
        public IActionResult Create()
        {
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

        // GET: OfisListesi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OfisListesi == null)
            {
                return NotFound();
            }

            var ofisListesi = await _context.OfisListesi.FindAsync(id);
            if (ofisListesi == null)
            {
                return NotFound();
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

        // GET: OfisListesi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OfisListesi == null)
            {
                return NotFound();
            }

            var ofisListesi = await _context.OfisListesi
                .FirstOrDefaultAsync(m => m.id == id);
            if (ofisListesi == null)
            {
                return NotFound();
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
