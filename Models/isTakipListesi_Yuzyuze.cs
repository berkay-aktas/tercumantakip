using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class isTakipListesi_Yuzyuze:BaseEntity
    {
        public string? Dil { get; set; }
        [Display(Name = "Dosya No")]
        public string? DosyaNo { get; set; }
        [Display(Name = "Kimlik No")]
        public string? KimlikNo { get; set; }
        [Display(Name = "Talep Kişi")]
        public string? TalepKisi_Birim { get; set; }
        [Display(Name = "Ofis Adı")]
        public string? OfisListesi { get; set; }
        [Display(Name = "Destek Tarihi")]
        public DateOnly DestekTarihi { get; set; }
        [Display(Name = "Başlangıç Saati")]
        public TimeSpan BaslangicSaati { get; set; }
        [Display(Name = "Bitiş Saati")]
        public TimeSpan BitisSaati { get; set; }
        [Display(Name = "Görüşme Sayısı")]
        public int? GorusmeSayisi { get; set; } = 0;
        [Display(Name = "Ek Bilgi")]
        public string? EkBilgi { get; set; }
    }
}
