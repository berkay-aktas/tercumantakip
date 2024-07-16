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
    public class TopluAramaController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public TopluAramaController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: TopluArama
        public async Task<IActionResult> Index()
        {
            return View(await _context.isTakipListesi_TopluArama.ToListAsync());
        }

        // GET: TopluArama/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_TopluArama = await _context.isTakipListesi_TopluArama
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_TopluArama == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_TopluArama);
        }

        // GET: TopluArama/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopluArama/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dil,AramaBasligi,OfisListesi,DestekTarihi,AramaSayisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_TopluArama isTakipListesi_TopluArama)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isTakipListesi_TopluArama);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(isTakipListesi_TopluArama);
        }

        // GET: TopluArama/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_TopluArama = await _context.isTakipListesi_TopluArama.FindAsync(id);
            if (isTakipListesi_TopluArama == null)
            {
                return NotFound();
            }
            return View(isTakipListesi_TopluArama);
        }

        // POST: TopluArama/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dil,AramaBasligi,OfisListesi,DestekTarihi,AramaSayisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_TopluArama isTakipListesi_TopluArama)
        {
            if (id != isTakipListesi_TopluArama.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isTakipListesi_TopluArama);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_TopluAramaExists(isTakipListesi_TopluArama.id))
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
            return View(isTakipListesi_TopluArama);
        }

        // GET: TopluArama/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_TopluArama = await _context.isTakipListesi_TopluArama
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_TopluArama == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_TopluArama);
        }

        // POST: TopluArama/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isTakipListesi_TopluArama = await _context.isTakipListesi_TopluArama.FindAsync(id);
            if (isTakipListesi_TopluArama != null)
            {
                _context.isTakipListesi_TopluArama.Remove(isTakipListesi_TopluArama);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool isTakipListesi_TopluAramaExists(int id)
        {
            return _context.isTakipListesi_TopluArama.Any(e => e.id == id);
        }
    }
}
