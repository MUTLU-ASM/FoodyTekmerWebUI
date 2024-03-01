using System.ComponentModel.DataAnnotations;

namespace FoodyTekmerWebUI.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Mail Adresinizi Giriniz!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz!")]
        public string Password { get; set; }
    }
}
