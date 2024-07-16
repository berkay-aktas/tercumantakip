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
    public class MigrantTVController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public MigrantTVController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: MigrantTV
        public async Task<IActionResult> Index()
        {
            return View(await _context.isTakipListesi_MigrantTV.ToListAsync());
        }

        // GET: MigrantTV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_MigrantTV = await _context.isTakipListesi_MigrantTV
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_MigrantTV == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_MigrantTV);
        }

        // GET: MigrantTV/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MigrantTV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dil,CeviriKonusu,CeviriTarihi,KelimeSayisi,SeslendirmeSayisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_MigrantTV isTakipListesi_MigrantTV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isTakipListesi_MigrantTV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(isTakipListesi_MigrantTV);
        }

        // GET: MigrantTV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_MigrantTV = await _context.isTakipListesi_MigrantTV.FindAsync(id);
            if (isTakipListesi_MigrantTV == null)
            {
                return NotFound();
            }
            return View(isTakipListesi_MigrantTV);
        }

        // POST: MigrantTV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dil,CeviriKonusu,CeviriTarihi,KelimeSayisi,SeslendirmeSayisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_MigrantTV isTakipListesi_MigrantTV)
        {
            if (id != isTakipListesi_MigrantTV.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isTakipListesi_MigrantTV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_MigrantTVExists(isTakipListesi_MigrantTV.id))
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
            return View(isTakipListesi_MigrantTV);
        }

        // GET: MigrantTV/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_MigrantTV = await _context.isTakipListesi_MigrantTV
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_MigrantTV == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_MigrantTV);
        }

        // POST: MigrantTV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isTakipListesi_MigrantTV = await _context.isTakipListesi_MigrantTV.FindAsync(id);
            if (isTakipListesi_MigrantTV != null)
            {
                _context.isTakipListesi_MigrantTV.Remove(isTakipListesi_MigrantTV);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool isTakipListesi_MigrantTVExists(int id)
        {
            return _context.isTakipListesi_MigrantTV.Any(e => e.id == id);
        }
    }
}
