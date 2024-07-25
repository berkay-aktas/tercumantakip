using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class BaseEntity
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? KullaniciAdi { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }=DateTime.Now;
    }
}
