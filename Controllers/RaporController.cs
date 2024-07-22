
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TercumanTakipWeb.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;

namespace TercumanTakipWeb.Controllers
{
    [Authorize]
    public class RaporController : Controller
    {
        private readonly TercumanTakipDbContext _context;

        public RaporController(TercumanTakipDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel(string reportType)
        {
            var stream = new MemoryStream();

            switch (reportType)
            {
                case "Telefon":
                    var telefonData = await _context.isTakipListesi_Telefon.ToListAsync();
                    stream = GenerateExcelReport(telefonData, "Telefon");
                    break;

                case "Yuzyuze":
                    var yuzyuzeData = await _context.isTakipListesi_Yuzyuze.ToListAsync();
                    stream = GenerateExcelReport(yuzyuzeData, "Yuzyuze");
                    break;

                case "TopluArama":
                    var topluAramaData = await _context.isTakipListesi_TopluArama.ToListAsync();
                    stream = GenerateExcelReport(topluAramaData, "TopluArama");
                    break;

                case "MigrantTV":
                    var migrantTVData = await _context.isTakipListesi_MigrantTV.ToListAsync();
                    stream = GenerateExcelReport(migrantTVData, "MigrantTV");
                    break;

                case "DisGorev":
                    var disGorevData = await _context.isTakipListesi_DisGorev.ToListAsync();
                    stream = GenerateExcelReport(disGorevData, "DisGorev");
                    break;

                case "YaziliCeviri":
                    var yaziliCeviriData = await _context.isTakipListesi_YaziliCeviri.ToListAsync();
                    stream = GenerateExcelReport(yaziliCeviriData, "YaziliCeviri");
                    break;

                default:
                    return BadRequest("Geçersiz rapor türü.");
            }

            stream.Position = 0;
            string excelName = $"{reportType}-{DateTime.Now:yyyyMMddHHmmssfff}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

        public MemoryStream GenerateExcelReport<T>(List<T> data, string sheetName)
        {
            var stream = new MemoryStream();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(sheetName);
                worksheet.Cell(1, 1).InsertTable(data);
                workbook.SaveAs(stream);
            }
            stream.Position = 0;
            return stream;
        }

    }
}
