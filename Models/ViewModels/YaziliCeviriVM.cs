using Microsoft.AspNetCore.Mvc.Rendering;

namespace TercumanTakipWeb.Models.ViewModels
{
    public class YaziliCeviriVM
    {
        public isTakipListesi_YaziliCeviri? isTakipListesi_YaziliCeviri { get; set; }
        public List<isTakipListesi_YaziliCeviri>? isTakipListesi_YaziliCeviriList { get; set; }
        public List<string>? DilListesi { get; set; }
        public List<DilCheckboxVM>? DilCheckbox { get; set; }
    }
}
