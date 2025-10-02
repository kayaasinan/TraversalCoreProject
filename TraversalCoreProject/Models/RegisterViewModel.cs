using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Lütfen soyadınızı giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lütfen mail adresini giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Lütfen şifreyi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Lütfen şifreyi tekrar giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil...!")]
        public string ComfirmPassword { get; set; }
    }
}
