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
    public class YuzyuzeController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public YuzyuzeController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: Yuzyuze
        public async Task<IActionResult> Index(int? id)
        {
            YuzyuzeVM yuzyuzeVM = new YuzyuzeVM();
            yuzyuzeVM.isTakipListesi_Yuzyuze = await _context.isTakipListesi_Yuzyuze.FindAsync(id);
            yuzyuzeVM.isTakipListesi_YuzyuzeList = await _context.isTakipListesi_Yuzyuze.ToListAsync();
            var dilListDB = await _context.DilListesi.ToListAsync();
            yuzyuzeVM.OfisListesi = GetOfisList();
            yuzyuzeVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();
            return View(yuzyuzeVM);
        }

        // GET: Yuzyuze/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.isTakipListesi_Yuzyuze == null)
            {
                return NotFound();
            }
            var isTakipListesi_Yuzyuze = await _context.isTakipListesi_Yuzyuze.FirstOrDefaultAsync(m => m.id == id);

            if (isTakipListesi_Yuzyuze == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            var selectedLanguages = isTakipListesi_Yuzyuze.Dil?.Split(',').ToList() ?? new List<string>();


            YuzyuzeVM yuzyuzeVM = new();
            yuzyuzeVM.isTakipListesi_Yuzyuze = isTakipListesi_Yuzyuze;
            yuzyuzeVM.OfisListesi = GetOfisList();

            yuzyuzeVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            yuzyuzeVM.DilCheckbox = dilListDB.Select(x => new DilCheckboxVM
            {
                Dil = x.Dil,
                isChecked = selectedLanguages.Contains(x.Dil)
            }).ToList();

            return View(yuzyuzeVM);
        }

        private List<SelectListItem> GetOfisList()
        {
            var ofisList = _context.OfisListesi.Select(i => new SelectListItem
            {
                Text = i.OfisAdi,
                Value = i.OfisAdi
            }).Distinct().OrderBy(x => x.Text).ToList();

            return ofisList;
        }

        // POST: Yuzyuze/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(YuzyuzeVM yuzyuzeVM)
        {
            string languageList = "";

            for (int i = 0; i < yuzyuzeVM.DilCheckbox.Count; i++)
            {
                if (yuzyuzeVM.DilCheckbox[i].isChecked)
                {
                    languageList += yuzyuzeVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            yuzyuzeVM.isTakipListesi_Yuzyuze.Dil = languageList;

            //Kullanicilar user = _userService.GetUserClaims(User);

            string currentUser = User.Identity.Name;
            yuzyuzeVM.isTakipListesi_Yuzyuze.KullaniciAdi = currentUser;

            //if (ModelState.IsValid)

            _context.Add(yuzyuzeVM.isTakipListesi_Yuzyuze);
            await _context.SaveChangesAsync();
            TempData["success"] = "success";

            return RedirectToAction(nameof(Index));
        }

        // GET: Yuzyuze/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var isTakipListesi_Yuzyuze = await _context.isTakipListesi_Yuzyuze.FindAsync(id);
            if (isTakipListesi_Yuzyuze == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            YuzyuzeVM yuzyuzeVM = new();
            yuzyuzeVM.isTakipListesi_Yuzyuze = isTakipListesi_Yuzyuze;
            yuzyuzeVM.OfisListesi = GetOfisList();
            yuzyuzeVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            return View(yuzyuzeVM);
        }

        // POST: Yuzyuze/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, YuzyuzeVM yuzyuzeVM)
        {
            if (id != yuzyuzeVM.isTakipListesi_Yuzyuze.id)
            {
                return NotFound();
            }
            string languageList = "";

            for (int i = 0; i < yuzyuzeVM.DilCheckbox.Count; i++)
            {
                if (yuzyuzeVM.DilCheckbox[i].isChecked)
                {
                    languageList += yuzyuzeVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            yuzyuzeVM.isTakipListesi_Yuzyuze.Dil = languageList;

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yuzyuzeVM.isTakipListesi_Yuzyuze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_YuzyuzeExists(yuzyuzeVM.isTakipListesi_Yuzyuze.id))
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
            //return View(yuzyuzeVM.isTakipListesi_Yuzyuze);
        }

        // POST: Yuzyuze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.isTakipListesi_Yuzyuze == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.isTakipListesi_Yuzyuze'  is null.");
            }
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
            return (_context.isTakipListesi_Yuzyuze?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}