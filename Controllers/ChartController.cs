using Microsoft.AspNetCore.Mvc;
using TercumanTakipWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosedXML;
using Microsoft.AspNetCore.Authorization;

namespace TercumanTakipWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChartController : ControllerBase
    {
        private readonly TercumanTakipDbContext _dbContext;

        public ChartController(TercumanTakipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getCounts")]
        public IActionResult GetTranslationCounts()
        {
            var counts = new Dictionary<string, Dictionary<string, int>>();

            // Example: Fetching counts for each category
            counts["isTakipListesi_Telefon"] = GetLanguageCountsForModel<isTakipListesi_Telefon>();
            counts["isTakipListesi_Yuzyuze"] = GetLanguageCountsForModel<isTakipListesi_Yuzyuze>();
            counts["isTakipListesi_TopluArama"] = GetLanguageCountsForModel<isTakipListesi_TopluArama>();
            counts["isTakipListesi_MigrantTV"] = GetLanguageCountsForModel<isTakipListesi_MigrantTV>();
            counts["isTakipListesi_DisGorev"] = GetLanguageCountsForModel<isTakipListesi_DisGorev>();
            counts["isTakipListesi_YaziliCeviri"] = GetLanguageCountsForModel<isTakipListesi_YaziliCeviri>();

            return Ok(counts);
        }

        private Dictionary<string, int> GetLanguageCountsForModel<T>() where T : class
        {
            var counts = _dbContext.Set<T>()
                .GroupBy(GetLanguageProperty<T>())
                .ToDictionary(g => g.Key.ToString(), g => g.Count());

            return counts;
        }

        private System.Linq.Expressions.Expression<System.Func<T, object>> GetLanguageProperty<T>()
        {
            var parameter = System.Linq.Expressions.Expression.Parameter(typeof(T));
            return System.Linq.Expressions.Expression.Lambda<System.Func<T, object>>(System.Linq.Expressions.Expression.Property(parameter, "Dil"), parameter);
        }
    }
}