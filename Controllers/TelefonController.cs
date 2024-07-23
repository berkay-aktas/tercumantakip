using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TercumanTakipWeb.Models;
using TercumanTakipWeb.Models.ViewModels;
using TercumanTakipWeb.Services;


namespace TercumanTakipWeb.Controllers
{
    [Authorize]
    public class TelefonController : Controller
    {
        private readonly TercumanTakipDbContext _context;
        public IUserService _userService { get; set; }

        public TelefonController(TercumanTakipDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: Telefon
        public async Task<IActionResult> Index(int? id)
        {
            var userInfo = _userService.GetUserClaims(User);

            TelefonVM telefonVM = new TelefonVM();
            telefonVM.isTakipListesi_Telefon = await _context.isTakipListesi_Telefon.FindAsync(id);
            telefonVM.isTakipListesi_TelefonList = await _context.isTakipListesi_Telefon.ToListAsync();
            var dilListDB = await _context.DilListesi.ToListAsync();
            telefonVM.OfisListesi = GetOfisList();
            telefonVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();
            return View(telefonVM);
        }

        // GET: Telefon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.isTakipListesi_Telefon == null)
            {
                return NotFound();
            }
            var isTakipListesi_Telefon = await _context.isTakipListesi_Telefon.FirstOrDefaultAsync(m => m.id == id);

            if (isTakipListesi_Telefon == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            var selectedLanguages = isTakipListesi_Telefon.Dil?.Split(',').ToList() ?? new List<string>();

            TelefonVM telefonVM = new();
            telefonVM.isTakipListesi_Telefon = isTakipListesi_Telefon;
            telefonVM.OfisListesi = GetOfisList();

            telefonVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            telefonVM.DilCheckbox = dilListDB.Select(x => new DilCheckboxVM
            {
                Dil = x.Dil,
                isChecked = selectedLanguages.Contains(x.Dil)
            }).ToList();

            return View(telefonVM);
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

        // POST: Telefon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TelefonVM telefonVM)
        {
            string languageList = "";

            for (int i = 0; i < telefonVM.DilCheckbox.Count; i++)
            {
                if (telefonVM.DilCheckbox[i].isChecked)
                {
                    languageList += telefonVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            telefonVM.isTakipListesi_Telefon.Dil = languageList;

            //Kullanicilar user = _userService.GetUserClaims(User);

            string currentUser = User.Identity.Name;
            telefonVM.isTakipListesi_Telefon.KullaniciAdi = currentUser;

            //if (ModelState.IsValid)

            _context.Add(telefonVM.isTakipListesi_Telefon);
            await _context.SaveChangesAsync();
            TempData["success"] = "success";

            return RedirectToAction(nameof(Index));
        }

        // GET: Telefon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var isTakipListesi_Telefon = await _context.isTakipListesi_Telefon.FindAsync(id);
            if (isTakipListesi_Telefon == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            TelefonVM telefonVM = new();
            telefonVM.isTakipListesi_Telefon = isTakipListesi_Telefon;
            telefonVM.OfisListesi = GetOfisList();
            telefonVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            return View(telefonVM);
        }

        // POST: Telefon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TelefonVM telefonVM)
        {
            if (id != telefonVM.isTakipListesi_Telefon.id)
            {
                return NotFound();
            }
            string languageList = "";

            for (int i = 0; i < telefonVM.DilCheckbox.Count; i++)
            {
                if (telefonVM.DilCheckbox[i].isChecked)
                {
                    languageList += telefonVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            telefonVM.isTakipListesi_Telefon.Dil = languageList;


            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonVM.isTakipListesi_Telefon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_TelefonExists(telefonVM.isTakipListesi_Telefon.id))
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
            //return View(telefonVM.isTakipListesi_Telefon);
        }

        // POST: Telefon/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.isTakipListesi_Telefon == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.isTakipListesi_Telefon'  is null.");
            }
            var isTakipListesi_Telefon = await _context.isTakipListesi_Telefon.FindAsync(id);
            if (isTakipListesi_Telefon != null)
            {
                _context.isTakipListesi_Telefon.Remove(isTakipListesi_Telefon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool isTakipListesi_TelefonExists(int id)
        {
            return (_context.isTakipListesi_Telefon?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
