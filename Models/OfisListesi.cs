using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class OfisListesi
    {
        public int id { get; set; }
        [Display(Name ="Ofis Adı")]
        public string? OfisAdi { get; set; }
    }
}
