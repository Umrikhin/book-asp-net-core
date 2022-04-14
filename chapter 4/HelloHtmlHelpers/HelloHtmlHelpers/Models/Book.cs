using System.ComponentModel.DataAnnotations;

namespace HelloHtmlHelpers.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Title { get; set; } = String.Empty;
        [Display(Name = "Количество копий")]
        public int Copies { get; set; }

    }
}
