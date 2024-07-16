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
    public class YaziliCeviriController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public YaziliCeviriController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: YaziliCeviri
        public async Task<IActionResult> Index()
        {
            return View(await _context.isTakipListesi_YaziliCeviri.ToListAsync());
        }

        // GET: YaziliCeviri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_YaziliCeviri = await _context.isTakipListesi_YaziliCeviri
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_YaziliCeviri == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_YaziliCeviri);
        }

        // GET: YaziliCeviri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YaziliCeviri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dil,CeviriKonusu,CeviriTarihi,KelimeSayisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_YaziliCeviri isTakipListesi_YaziliCeviri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isTakipListesi_YaziliCeviri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(isTakipListesi_YaziliCeviri);
        }

        // GET: YaziliCeviri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_YaziliCeviri = await _context.isTakipListesi_YaziliCeviri.FindAsync(id);
            if (isTakipListesi_YaziliCeviri == null)
            {
                return NotFound();
            }
            return View(isTakipListesi_YaziliCeviri);
        }

        // POST: YaziliCeviri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dil,CeviriKonusu,CeviriTarihi,KelimeSayisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_YaziliCeviri isTakipListesi_YaziliCeviri)
        {
            if (id != isTakipListesi_YaziliCeviri.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isTakipListesi_YaziliCeviri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_YaziliCeviriExists(isTakipListesi_YaziliCeviri.id))
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
            return View(isTakipListesi_YaziliCeviri);
        }

        // GET: YaziliCeviri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_YaziliCeviri = await _context.isTakipListesi_YaziliCeviri
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_YaziliCeviri == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_YaziliCeviri);
        }

        // POST: YaziliCeviri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isTakipListesi_YaziliCeviri = await _context.isTakipListesi_YaziliCeviri.FindAsync(id);
            if (isTakipListesi_YaziliCeviri != null)
            {
                _context.isTakipListesi_YaziliCeviri.Remove(isTakipListesi_YaziliCeviri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool isTakipListesi_YaziliCeviriExists(int id)
        {
            return _context.isTakipListesi_YaziliCeviri.Any(e => e.id == id);
        }
    }
}
