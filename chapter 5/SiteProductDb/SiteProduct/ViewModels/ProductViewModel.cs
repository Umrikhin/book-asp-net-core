namespace SiteProduct.ViewModels
{
    public class ProductViewModel
    {
        //Идентификатор
        public int Id { get; set; }
        //Наименование
        public string Name { get; set; } = string.Empty;
        //Цена
        public decimal Price { get; set; }
        //Дата изготовления
        public DateTime ProductionDate { get; set; }
        //Категория товара
        public string Category { get; set; } = string.Empty;
    }
}
