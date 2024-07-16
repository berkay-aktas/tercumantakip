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
    public class YuzyuzeController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public YuzyuzeController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: Yuzyuze
        public async Task<IActionResult> Index()
        {
            return View(await _context.isTakipListesi_Yuzyuze.ToListAsync());
        }

        // GET: Yuzyuze/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_Yuzyuze = await _context.isTakipListesi_Yuzyuze
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_Yuzyuze == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_Yuzyuze);
        }

        // GET: Yuzyuze/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yuzyuze/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dil,DosyaNo,KimlikNo,TalepKisi_Birim,OfisListesi,DestekTarihi,BaslangicSaati,BitisSaati,GorusmeSayisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_Yuzyuze isTakipListesi_Yuzyuze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isTakipListesi_Yuzyuze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(isTakipListesi_Yuzyuze);
        }

        // GET: Yuzyuze/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_Yuzyuze = await _context.isTakipListesi_Yuzyuze.FindAsync(id);
            if (isTakipListesi_Yuzyuze == null)
            {
                return NotFound();
            }
            return View(isTakipListesi_Yuzyuze);
        }

        // POST: Yuzyuze/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dil,DosyaNo,KimlikNo,TalepKisi_Birim,OfisListesi,DestekTarihi,BaslangicSaati,BitisSaati,GorusmeSayisi,EkBilgi,id,KullaniciAdi,KayitTarihi")] isTakipListesi_Yuzyuze isTakipListesi_Yuzyuze)
        {
            if (id != isTakipListesi_Yuzyuze.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isTakipListesi_Yuzyuze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_YuzyuzeExists(isTakipListesi_Yuzyuze.id))
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
            return View(isTakipListesi_Yuzyuze);
        }

        // GET: Yuzyuze/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isTakipListesi_Yuzyuze = await _context.isTakipListesi_Yuzyuze
                .FirstOrDefaultAsync(m => m.id == id);
            if (isTakipListesi_Yuzyuze == null)
            {
                return NotFound();
            }

            return View(isTakipListesi_Yuzyuze);
        }

        // POST: Yuzyuze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isTakipListesi_Yuzyuze = await _context.isTakipListesi_Yuzyuze.FindAsync(id);
            if (isTakipListesi_Yuzyuze != null)
            {
                _context.isTakipListesi_Yuzyuze.Remove(isTakipListesi_Yuzyuze);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool isTakipListesi_YuzyuzeExists(int id)
        {
            return _context.isTakipListesi_Yuzyuze.Any(e => e.id == id);
        }
    }
}
