using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models
{
    public class isTakipListesi_YaziliCeviri : BaseEntity
    {
        public string? Dil { get; set; }
        public string? CeviriKonusu { get; set; }
        public DateOnly CeviriTarihi { get; set; }
        public int KelimeSayisi { get; set; }
        public string? EkBilgi { get; set; }
    }
}
