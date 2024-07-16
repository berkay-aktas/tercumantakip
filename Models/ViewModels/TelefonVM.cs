using Microsoft.AspNetCore.Mvc.Rendering;

namespace TercumanTakipWeb.Models.ViewModels
{
    public class TelefonVM
    {
        public isTakipListesi_Telefon? isTakipListesi_Telefon { get; set; }
        public List<isTakipListesi_Telefon>? isTakipListesi_TelefonList { get; set; }
        public List<SelectListItem>? OfisListesi { get; set; }
        public List<string>? DilListesi { get; set; }
        public List<DilCheckboxVM>? DilCheckbox { get; set; }
    }
}
