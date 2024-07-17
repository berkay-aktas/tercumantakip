using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class isTakipListesi_YaziliCeviri : BaseEntity
    {
        public string? Dil { get; set; }
        [Display(Name = "Çeviri Konusu")]
        public string? CeviriKonusu { get; set; }
        [Display(Name = "Çeviri Tarihi")]
        public DateOnly CeviriTarihi { get; set; }
        [Display(Name = "Kelime Sayısı")]
        public int KelimeSayisi { get; set; }
        [Display(Name = "Ek Bilgi")]
        public string? EkBilgi { get; set; }
    }
}
