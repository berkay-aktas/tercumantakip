using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class isTakipListesi_DisGorev : BaseEntity
    {
        public string? Dil { get; set; }
        [Display(Name = "Dosya No")]
        public string? DosyaNo { get; set; }
        public string? DanisanAdSoyad { get; set; }
        public string? KurumHastaneAdi { get; set; }
        public DateOnly GidisTarihi { get; set; }
        public TimeSpan GidisSaati { get; set; }
        public TimeSpan DonusSaati { get; set; }
        public string? YonlendirenKisi { get; set; }
        public string? EkBilgi { get; set; }
    }
}
