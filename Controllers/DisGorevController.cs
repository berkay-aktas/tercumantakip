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
    public class DisGorevController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public DisGorevController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: DisGorev
        public async Task<IActionResult> Index()
        {
            return View(await _context.isTakipListesi_DisGorev.ToListAsync());
        }

        // GET: DisGorev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_DisGorev = await _context.isTakipListesi_DisGorev
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_DisGorev == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_DisGorev);
        }

        // GET: DisGorev/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisGorev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dil,DosyaNo,DanisanAdSoyad,KurumHastaneAdi,GidisTarihi,GidisSaati,DonusSaati,YonlendirenKisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_DisGorev isTakipListesi_DisGorev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isTakipListesi_DisGorev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(isTakipListesi_DisGorev);
        }

        // GET: DisGorev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_DisGorev = await _context.isTakipListesi_DisGorev.FindAsync(id);
            if (isTakipListesi_DisGorev == null)
            {
                return NotFound();
            }
            return View(isTakipListesi_DisGorev);
        }

        // POST: DisGorev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dil,DosyaNo,DanisanAdSoyad,KurumHastaneAdi,GidisTarihi,GidisSaati,DonusSaati,YonlendirenKisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_DisGorev isTakipListesi_DisGorev)
        {
            if (id != isTakipListesi_DisGorev.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isTakipListesi_DisGorev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_DisGorevExists(isTakipListesi_DisGorev.id))
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
            return View(isTakipListesi_DisGorev);
        }

        // GET: DisGorev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_DisGorev = await _context.isTakipListesi_DisGorev
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_DisGorev == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_DisGorev);
        }

        // POST: DisGorev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isTakipListesi_DisGorev = await _context.isTakipListesi_DisGorev.FindAsync(id);
            if (isTakipListesi_DisGorev != null)
            {
                _context.isTakipListesi_DisGorev.Remove(isTakipListesi_DisGorev);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool isTakipListesi_DisGorevExists(int id)
        {
            return _context.isTakipListesi_DisGorev.Any(e => e.id == id);
        }
    }
}
