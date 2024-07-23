using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TercumanTakipWeb.Models;
using TercumanTakipWeb.Models.ViewModels;

namespace TercumanTakipWeb.Controllers
{
    [Authorize]
    public class DisGorevController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public DisGorevController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: DisGorev
        public async Task<IActionResult> Index(int? id)
        {
            DisGorevVM disGorevVM = new DisGorevVM();
            disGorevVM.isTakipListesi_DisGorev = await _context.isTakipListesi_DisGorev.FindAsync(id);
            disGorevVM.isTakipListesi_DisGorevList = await _context.isTakipListesi_DisGorev.ToListAsync();
            var dilListDB = await _context.DilListesi.ToListAsync();
            disGorevVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();
            return View(disGorevVM);
        }

        // GET: DisGorev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.isTakipListesi_DisGorev == null)
            {
                return NotFound();
            }
            var isTakipListesi_DisGorev = await _context.isTakipListesi_DisGorev.FirstOrDefaultAsync(m => m.id == id);


            if (isTakipListesi_DisGorev == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            var selectedLanguages = isTakipListesi_DisGorev.Dil?.Split(',').ToList() ?? new List<string>();

            DisGorevVM disGorevVM = new();
            disGorevVM.isTakipListesi_DisGorev = isTakipListesi_DisGorev;

            disGorevVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            disGorevVM.DilCheckbox = dilListDB.Select(x => new DilCheckboxVM
            {
                Dil = x.Dil,
                isChecked = selectedLanguages.Contains(x.Dil)
            }).ToList();

            return View(disGorevVM);
        }

        // POST: DisGorev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DisGorevVM disGorevVM)
        {
            string languageList = "";

            for (int i = 0; i < disGorevVM.DilCheckbox.Count; i++)
            {
                if (disGorevVM.DilCheckbox[i].isChecked)
                {
                    languageList += disGorevVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            disGorevVM.isTakipListesi_DisGorev.Dil = languageList;

            //Kullanicilar user = _userService.GetUserClaims(User);

            string currentUser = User.Identity.Name;
            disGorevVM.isTakipListesi_DisGorev.KullaniciAdi = currentUser;

            //if (ModelState.IsValid)

            _context.Add(disGorevVM.isTakipListesi_DisGorev);
            await _context.SaveChangesAsync();
            TempData["success"] = "success";

            return RedirectToAction(nameof(Index));
        }

        // GET: DisGorev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var isTakipListesi_DisGorev = await _context.isTakipListesi_DisGorev.FindAsync(id);
            if (isTakipListesi_DisGorev == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            DisGorevVM disGorevVM = new();
            disGorevVM.isTakipListesi_DisGorev = isTakipListesi_DisGorev;
            disGorevVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            return View(disGorevVM);
        }

        // POST: DisGorev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DisGorevVM disGorevVM)
        {
            if (id != disGorevVM.isTakipListesi_DisGorev.id)
            {
                return NotFound();
            }
            string languageList = "";

            for (int i = 0; i < disGorevVM.DilCheckbox.Count; i++)
            {
                if (disGorevVM.DilCheckbox[i].isChecked)
                {
                    languageList += disGorevVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            disGorevVM.isTakipListesi_DisGorev.Dil = languageList;

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disGorevVM.isTakipListesi_DisGorev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_DisGorevExists(disGorevVM.isTakipListesi_DisGorev.id))
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
            //return View(disGorevVM.isTakipListesi_DisGorev);
        }

        // POST: DisGorev/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.isTakipListesi_DisGorev == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.isTakipListesi_DisGorev'  is null.");
            }
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
            return (_context.isTakipListesi_DisGorev?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
