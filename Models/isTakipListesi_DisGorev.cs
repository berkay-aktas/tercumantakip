using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class isTakipListesi_DisGorev : BaseEntity
    {
        public string? Dil { get; set; }
        [Display(Name = "Dosya No")]
        public string? DosyaNo { get; set; }
        [Display(Name = "Danışan Ad Soyad")]
        public string? DanisanAdSoyad { get; set; }
        [Display(Name = "Kurum Hastane Adı")]
        public string? KurumHastaneAdi { get; set; }
        [Display(Name = "Gidiş Tarihi")]
        public DateOnly GidisTarihi { get; set; }
        [Display(Name = "Gidiş Saati")]
        public TimeSpan GidisSaati { get; set; }
        [Display(Name = "Dönüş Saati")]
        public TimeSpan DonusSaati { get; set; }
        [Display(Name = "Yönlendiren Kişi")]
        public string? YonlendirenKisi { get; set; }
        [Display(Name = "Ek Bilgi")]
        public string? EkBilgi { get; set; }
    }
}
