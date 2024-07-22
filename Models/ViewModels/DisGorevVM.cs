using Microsoft.AspNetCore.Mvc.Rendering;

namespace TercumanTakipWeb.Models.ViewModels
{
    public class DisGorevVM
    {
        public isTakipListesi_DisGorev? isTakipListesi_DisGorev { get; set; }
        public List<isTakipListesi_DisGorev>? isTakipListesi_DisGorevList { get; set; }
        public List<string>? DilListesi { get; set; }
        public List<DilCheckboxVM>? DilCheckbox { get; set; }
    }
}
