using System.ComponentModel.DataAnnotations;

namespace SiteProduct.Models
{
    public class Product
    {
        //Идентификатор
        public int Id { get; set; }
        //Наименование
        [Required, MinLength(3), MaxLength(50), Display(Name = "Наименование")]
        //[DataType(DataType.Password)]
        public string Name { get; set; } = string.Empty;
        //Цена
        [Required, Range(0.01d, 1000.0d), Display(Name = "Цена")]
        public decimal Price { get; set; }
        //Дата изготовления
        [Required, Display(Name = "Дата изготовления")]
        public DateTime ProductionDate { get; set; }
        //Идентификатор категории товара
        [Required, Display(Name = "Категория")]
        public int CategoryId { get; set; }

    }
}
