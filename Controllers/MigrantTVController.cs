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
    public class MigrantTVController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public MigrantTVController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        // GET: MigrantTV
        public async Task<IActionResult> Index(int? id)
        {
            MigrantTVVM migrantTVVM = new MigrantTVVM();
            migrantTVVM.isTakipListesi_MigrantTV = await _context.isTakipListesi_MigrantTV.FindAsync(id);
            migrantTVVM.isTakipListesi_MigrantTVList = await _context.isTakipListesi_MigrantTV.ToListAsync();
            var dilListDB = await _context.DilListesi.ToListAsync();
            migrantTVVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();
            return View(migrantTVVM);
        }

        // GET: MigrantTV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.isTakipListesi_MigrantTV == null)
            {
                return NotFound();
            }
            var isTakipListesi_MigrantTV = await _context.isTakipListesi_MigrantTV.FirstOrDefaultAsync(m => m.id == id);

            var dilListDB = await _context.DilListesi.ToListAsync();
            MigrantTVVM migrantTVVM = new();
            migrantTVVM.isTakipListesi_MigrantTV = isTakipListesi_MigrantTV;
            migrantTVVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();


            if (isTakipListesi_MigrantTV == null)
            {
                return NotFound();
            }

            return View(migrantTVVM);
        }

        // POST: MigrantTV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MigrantTVVM migrantTVVM)
        {
            string languageList = "";

            for (int i = 0; i < migrantTVVM.DilCheckbox.Count; i++)
            {
                if (migrantTVVM.DilCheckbox[i].isChecked)
                {
                    languageList += migrantTVVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            migrantTVVM.isTakipListesi_MigrantTV.Dil = languageList;

            //Kullanicilar user = _userService.GetUserClaims(User);

            string currentUser = User.Identity.Name;
            migrantTVVM.isTakipListesi_MigrantTV.KullaniciAdi = currentUser;

            //if (ModelState.IsValid)

            _context.Add(migrantTVVM.isTakipListesi_MigrantTV);
            await _context.SaveChangesAsync();
            TempData["success"] = "success";

            return RedirectToAction(nameof(Index));
        }

        // GET: MigrantTV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var isTakipListesi_MigrantTV = await _context.isTakipListesi_MigrantTV.FindAsync(id);
            if (isTakipListesi_MigrantTV == null)
            {
                return NotFound();
            }

            var dilListDB = await _context.DilListesi.ToListAsync();
            MigrantTVVM migrantTVVM = new();
            migrantTVVM.isTakipListesi_MigrantTV = isTakipListesi_MigrantTV;
            migrantTVVM.DilListesi = dilListDB.Select(x => x.Dil).ToList();

            return View(migrantTVVM);
        }

        // POST: MigrantTV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MigrantTVVM migrantTVVM)
        {
            if (id != migrantTVVM.isTakipListesi_MigrantTV.id)
            {
                return NotFound();
            }
            string languageList = "";

            for (int i = 0; i < migrantTVVM.DilCheckbox.Count; i++)
            {
                if (migrantTVVM.DilCheckbox[i].isChecked)
                {
                    languageList += migrantTVVM.DilCheckbox[i].Dil + ",";
                }
            }
            if (languageList.EndsWith(","))
            {
                languageList = languageList.Remove(languageList.Length - 1);
            }
            migrantTVVM.isTakipListesi_MigrantTV.Dil = languageList;

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(migrantTVVM.isTakipListesi_MigrantTV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isTakipListesi_MigrantTVExists(migrantTVVM.isTakipListesi_MigrantTV.id))
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
            //return View(migrantTVVM.isTakipListesi_migrantTV);
        }

        // POST: MigrantTV/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.isTakipListesi_MigrantTV == null)
            {
                return Problem("Entity set 'TercumanTakipDbContext.isTakipListesi_MigrantTV'  is null.");
            }
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
            return (_context.isTakipListesi_MigrantTV?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
