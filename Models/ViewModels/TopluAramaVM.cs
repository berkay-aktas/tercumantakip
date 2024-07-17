using Microsoft.AspNetCore.Mvc.Rendering;

namespace TercumanTakipWeb.Models.ViewModels
{
    public class TopluAramaVM
    {
        public isTakipListesi_TopluArama? isTakipListesi_TopluArama { get; set; }
        public List<isTakipListesi_TopluArama>? isTakipListesi_TopluAramaList { get; set; }
        public List<SelectListItem>? OfisListesi { get; set; }
        public List<string>? DilListesi { get; set; }
        public List<DilCheckboxVM>? DilCheckbox { get; set; }
    }
}
