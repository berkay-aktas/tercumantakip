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
    public class DilListesiController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public DilListesiController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: DilListesi
        public async Task<IActionResult> Index()
        {
              return _context.DilListesi != null ? 
                          View(await _context.DilListesi.ToListAsync()) :
                          Problem("Entity set 'TercumanTakipDbContext.DilListesi'  is null.");
        }

        // GET: DilListesi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DilListesi == null)
            {
                return NotFound();
            }

            var dilListesi = await _context.DilListesi
                .FirstOrDefaultAsync(m => m.id == id);
            if (dilListesi == null)
            {
                return NotFound();
            }

            return View(dilListesi);
        }

        // GET: DilListesi/Create
        public IActionResult Create()
        {
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

        // GET: DilListesi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DilListesi == null)
            {
                return NotFound();
            }

            var dilListesi = await _context.DilListesi.FindAsync(id);
            if (dilListesi == null)
            {
                return NotFound();
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

        // GET: DilListesi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DilListesi == null)
            {
                return NotFound();
            }

            var dilListesi = await _context.DilListesi
                .FirstOrDefaultAsync(m => m.id == id);
            if (dilListesi == null)
            {
                return NotFound();
            }

            return View(dilListesi);
        }

        // POST: DilListesi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
