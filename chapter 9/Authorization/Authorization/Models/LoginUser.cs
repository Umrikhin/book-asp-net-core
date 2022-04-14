using System.ComponentModel.DataAnnotations;

namespace Authorization.Models
{
    public class LoginUser
    {
        [Display(Name = "Ваше имя")]
        [Required(ErrorMessage = "Введите Ваше имя!")]
        [StringLength(50, ErrorMessage = "Введите не более 50 символов!")]
        public string User { get; set; } = string.Empty;

        [Display(Name = "Ваш пароль")]
        [Required(ErrorMessage = "Введите свой пароль!")]
        [StringLength(50, ErrorMessage = "Введите не более 50 символов!")]
        public string Password { get; set; } = string.Empty;
    }
}
