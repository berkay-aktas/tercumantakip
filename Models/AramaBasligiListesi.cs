using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class AramaBasligiListesi
    {
        public int id { get; set; }
        [Display(Name = "Arama Başlığı")]
        public string? AramaBasligi { get; set; }
    }
}
