using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class DilListesi
    {
        public int id { get; set; }
        [Display(Name = "Dil Adı")]
        public string? Dil { get; set; }
    }
}
