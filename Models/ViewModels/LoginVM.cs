using System.ComponentModel.DataAnnotations;

namespace TercumanTakipWeb.Models.ViewModels
{
    public class LoginVM
    {
        public string Id { get; set; }
        [Display(Name = "Kullanıcı İsmi")]
        public string? UserName { get; set; }
        [Display(Name = "Şifre")]
        public string? Password { get; set; }
    }
}
