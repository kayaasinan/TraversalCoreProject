using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string? userName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string? password { get; set; }
    }
}
