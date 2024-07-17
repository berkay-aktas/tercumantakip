using Microsoft.AspNetCore.Mvc.Rendering;

namespace TercumanTakipWeb.Models.ViewModels
{
    public class YuzyuzeVM
    {
        public isTakipListesi_Yuzyuze? isTakipListesi_Yuzyuze { get; set; }
        public List<isTakipListesi_Yuzyuze>? isTakipListesi_YuzyuzeList { get; set; }
        public List<SelectListItem>? OfisListesi { get; set; }
        public List<string>? DilListesi { get; set; }
        public List<DilCheckboxVM>? DilCheckbox { get; set; }
    }
}
