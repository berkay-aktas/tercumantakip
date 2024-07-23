using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TercumanTakipWeb.Models;
using TercumanTakipWeb.Models.ViewModels;

namespace TercumanTakipWeb.Controllers
{
    [Authorize]
    public class YaziliCeviriController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public YaziliCeviriController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: YaziliCeviri
        public async Task<IActionResult> Index(int? id)
        {
            YaziliCeviriVM yaziliCeviriVM = new YaziliCeviriVM();
            yaziliCeviriVM.isTakipListesi_YaziliCeviri = await _context.isTakipListesi_YaziliCeviri.FindAsync(id);
            yaziliCeviriVM.isTakipListesi_YaziliCeviriList = await _context.isTakipListesi_YaziliCeviri.ToListAsync();
            var dilListDB = await _context.DilListesi.ToListAsync();
            yaziliCeviriVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();
            return View(yaziliCeviriVM);
        }

        // GET: YaziliCeviri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.isTakipListesi_YaziliCeviri == null)
            {
                return NotFound();
            }
            var isTakipListesi_YaziliCeviri = await _context.isTakipListesi_YaziliCeviri.FirstOrDefaultAsync(m => m.id == id);

            if (isTakipListesi_YaziliCeviri == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            var selectedLanguages = isTakipListesi_YaziliCeviri.Dil?.Split(',').ToList() ?? new List<string>();

            YaziliCeviriVM yaziliCeviriVM = new();
            yaziliCeviriVM.isTakipListesi_YaziliCeviri = isTakipListesi_YaziliCeviri;

            yaziliCeviriVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            yaziliCeviriVM.DilCheckbox = dilListDB.Select(x => new DilCheckboxVM
            {
                Dil = x.Dil,
                isChecked = selectedLanguages.Contains(x.Dil)
            }).ToList();

            return View(yaziliCeviriVM);
        }

        // POST: YaziliCeviri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(YaziliCeviriVM yaziliCeviriVM)
        {
            string languageList = "";

            for (int i = 0; i < yaziliCeviriVM.DilCheckbox.Count; i++)
            {
                if (yaziliCeviriVM.DilCheckbox[i].isChecked)
                {
                    languageList += yaziliCeviriVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            yaziliCeviriVM.isTakipListesi_YaziliCeviri.Dil = languageList;

            //Kullanicilar user = _userService.GetUserClaims(User);

            string currentUser = User.Identity.Name;
            yaziliCeviriVM.isTakipListesi_YaziliCeviri.KullaniciAdi = currentUser;

            //if (ModelState.IsValid)

            _context.Add(yaziliCeviriVM.isTakipListesi_YaziliCeviri);
            await _context.SaveChangesAsync();
            TempData["success"] = "success";

            return RedirectToAction(nameof(Index));
        }

        // GET: YaziliCeviri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var isTakipListesi_YaziliCeviri = await _context.isTakipListesi_YaziliCeviri.FindAsync(id);
            if (isTakipListesi_YaziliCeviri == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            YaziliCeviriVM yaziliCeviriVM = new();
            yaziliCeviriVM.isTakipListesi_YaziliCeviri = isTakipListesi_YaziliCeviri;
            yaziliCeviriVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            return View(yaziliCeviriVM);
        }

        // POST: YaziliCeviri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, YaziliCeviriVM yaziliCeviriVM)
        {
            if (id != yaziliCeviriVM.isTakipListesi_YaziliCeviri.id)
            {
                return NotFound();
            }
            string languageList = "";

            for (int i = 0; i < yaziliCeviriVM.DilCheckbox.Count; i++)
            {
                if (yaziliCeviriVM.DilCheckbox[i].isChecked)
                {
                    languageList += yaziliCeviriVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            yaziliCeviriVM.isTakipListesi_YaziliCeviri.Dil = languageList;

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yaziliCeviriVM.isTakipListesi_YaziliCeviri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_YaziliCeviriExists(yaziliCeviriVM.isTakipListesi_YaziliCeviri.id))
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
            //return View(yaziliCeviriVM.isTakipListesi_yaziliCeviri);
        }

        // POST: YaziliCeviri/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.isTakipListesi_YaziliCeviri == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.isTakipListesi_YaziliCeviri'  is null.");
            }
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
            return (_context.isTakipListesi_YaziliCeviri?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
