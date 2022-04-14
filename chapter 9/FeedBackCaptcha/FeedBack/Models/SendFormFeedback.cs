using System.ComponentModel.DataAnnotations;

namespace FeedBack.Models
{
    public class SendFormFeedback
    {
        [Display(Name = "Ваше имя")]
        [Required(ErrorMessage = "Сообщите Ваше имя.")]
        [StringLength(50, ErrorMessage = "Пожайлуста внесите не более 50 символов.")]
        public string IM { get; set; } = string.Empty;

        [Display(Name = "Ваш Email")]
        [Required(ErrorMessage = "Пожайлуста внесите действующий E-mail.")]
        [EmailAddress(ErrorMessage = "Внесите правильный E-mail")]
        [StringLength(50, ErrorMessage = "Пожайлуста внесите не более 50 символов.")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Тема")]
        [Required(ErrorMessage = "Внесите тему сообщения. Пожайлуста внесите не менее 8 символов.")]
        [StringLength(50, ErrorMessage = "Пожайлуста внесите не более 50 символов.")]
        public string Sbj { get; set; } = string.Empty;

        [Display(Name = "Ваше сообщение")]
        [Required(ErrorMessage = "Внесите текст сообщения.")]
        [StringLength(2500, ErrorMessage = "Количество символов в сообщении не должно превышать 2500.")]
        public string MessageForSend { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите код безопасности.")]
        [StringLength(6)]
        public string CaptchaCode { get; set; } = string.Empty;
    }
}
