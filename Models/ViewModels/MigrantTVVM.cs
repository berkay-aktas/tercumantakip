using Microsoft.AspNetCore.Mvc.Rendering;

namespace TercumanTakipWeb.Models.ViewModels
{
    public class MigrantTVVM
    {
        public isTakipListesi_MigrantTV? isTakipListesi_MigrantTV { get; set; }
        public List<isTakipListesi_MigrantTV>? isTakipListesi_MigrantTVList { get; set; }
        public List<string>? DilListesi { get; set; }
        public List<DilCheckboxVM>? DilCheckbox { get; set; }
    }
}
