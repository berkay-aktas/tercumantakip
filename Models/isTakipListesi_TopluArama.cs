using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class isTakipListesi_TopluArama:BaseEntity
    {
        public string? Dil { get; set; }
        [Display(Name = "Arama Başlığı")]
        public string? AramaBasligi { get; set; }
        [Display(Name = "Ofis Adı")]
        public string? OfisListesi { get; set; }
        [Display(Name = "Destek Tarihi")]
        public DateOnly DestekTarihi { get; set; }
        [Display(Name = "Arama Sayısı")]
        public int AramaSayisi { get; set; }
        [Display(Name = "Ek Bilgi")]
        public string? EkBilgi { get; set; }
    }
}
