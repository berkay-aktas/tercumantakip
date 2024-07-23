using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class Users
    {
        public int id { get; set; }
        [Display(Name = "Ad Soyad")]
        public string? AdSoyad { get; set; }
        [Display(Name = "E-mail Adres")]
        public string? EmailAdres { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? KullaniciAdi { get; set; }
        [Display(Name = "Kullanıcı Tipi")]
        public string? KullaniciTipi { get; set; }
        public int Seviye { get; set; }
        public string? Parola { get; set; }
        [Display(Name = "Kullanıcı Durumu")]
        public string? KullaniciDurumu { get; set; }
    }
}
