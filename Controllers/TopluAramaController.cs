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
    public class TopluAramaController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public TopluAramaController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: TopluArama
        public async Task<IActionResult> Index(int? id)
        {
            TopluAramaVM topluAramaVM = new TopluAramaVM();
            topluAramaVM.isTakipListesi_TopluArama = await _context.isTakipListesi_TopluArama.FindAsync(id);
            topluAramaVM.isTakipListesi_TopluAramaList = await _context.isTakipListesi_TopluArama.ToListAsync();
            var dilListDB = await _context.DilListesi.ToListAsync();
            topluAramaVM.OfisListesi = GetOfisList();
            topluAramaVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();
            return View(topluAramaVM);
        }

        // GET: TopluArama/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.isTakipListesi_TopluArama == null)
            {
                return NotFound();
            }
            var isTakipListesi_TopluArama = await _context.isTakipListesi_TopluArama.FirstOrDefaultAsync(m => m.id == id);

            if (isTakipListesi_TopluArama == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            var selectedLanguages = isTakipListesi_TopluArama.Dil?.Split(',').ToList() ?? new List<string>();

            TopluAramaVM topluAramaVM = new();
            topluAramaVM.isTakipListesi_TopluArama = isTakipListesi_TopluArama;
            topluAramaVM.OfisListesi = GetOfisList();

            topluAramaVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            topluAramaVM.DilCheckbox = dilListDB.Select(x => new DilCheckboxVM
            {
                Dil = x.Dil,
                isChecked = selectedLanguages.Contains(x.Dil)
            }).ToList();

            return View(topluAramaVM);
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

        // POST: TopluArama/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TopluAramaVM topluAramaVM)
        {
            string languageList = "";

            for (int i = 0; i < topluAramaVM.DilCheckbox.Count; i++)
            {
                if (topluAramaVM.DilCheckbox[i].isChecked)
                {
                    languageList += topluAramaVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            topluAramaVM.isTakipListesi_TopluArama.Dil = languageList;

            //Kullanicilar user = _userService.GetUserClaims(User);

            string currentUser = User.Identity.Name;
            topluAramaVM.isTakipListesi_TopluArama.KullaniciAdi = currentUser;

            //if (ModelState.IsValid)

            _context.Add(topluAramaVM.isTakipListesi_TopluArama);
            await _context.SaveChangesAsync();
            TempData["success"] = "success";

            return RedirectToAction(nameof(Index));
        }

        // GET: TopluArama/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var isTakipListesi_TopluArama = await _context.isTakipListesi_TopluArama.FindAsync(id);
            if (isTakipListesi_TopluArama == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            TopluAramaVM topluAramaVM = new();
            topluAramaVM.isTakipListesi_TopluArama = isTakipListesi_TopluArama;
            topluAramaVM.OfisListesi = GetOfisList();
            topluAramaVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            return View(topluAramaVM);
        }

        // POST: TopluArama/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TopluAramaVM topluAramaVM)
        {
            if (id != topluAramaVM.isTakipListesi_TopluArama.id)
            {
                return NotFound();
            }
            string languageList = "";

            for (int i = 0; i < topluAramaVM.DilCheckbox.Count; i++)
            {
                if (topluAramaVM.DilCheckbox[i].isChecked)
                {
                    languageList += topluAramaVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            topluAramaVM.isTakipListesi_TopluArama.Dil = languageList;

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topluAramaVM.isTakipListesi_TopluArama);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_TopluAramaExists(topluAramaVM.isTakipListesi_TopluArama.id))
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
            //return View(topluAramaVM.isTakipListesi_topluArama);
        }

        // POST: TopluArama/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.isTakipListesi_TopluArama == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.isTakipListesi_TopluArama'  is null.");
            }
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
            return (_context.isTakipListesi_TopluArama?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
