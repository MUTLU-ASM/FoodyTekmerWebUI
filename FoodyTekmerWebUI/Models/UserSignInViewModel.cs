using System.ComponentModel.DataAnnotations;

namespace FoodyTekmerWebUI.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Mail Adresinizi Giriniz!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz!")]
        public string password { get; set; }
    }
}
