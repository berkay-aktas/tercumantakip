namespace TercumanTakipWeb.Models
{
    public class Users
    {
        public int id { get; set; }
        public string? AdSoyad { get; set; }
        public string? EmailAdres { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? KullaniciTipi { get; set; }
        public int Seviye { get; set; }
        public string? Parola { get; set; }
        public string? KullaniciDurumu { get; set; }
    }
}
