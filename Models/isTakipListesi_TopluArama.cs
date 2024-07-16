using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class isTakipListesi_TopluArama:BaseEntity
    {

        public string? Dil { get; set; }
        public string? AramaBasligi { get; set; }
        public string? OfisListesi { get; set; }
        public DateOnly DestekTarihi { get; set; }
      
        public int AramaSayisi { get; set; }
        public string? EkBilgi { get; set; }

    }
}
