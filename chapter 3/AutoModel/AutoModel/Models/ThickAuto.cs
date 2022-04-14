namespace AutoModel.Models
{
    public class ThickAuto
    {
        public string Brand { get; set; } = string.Empty;
        public string ModelAuto { get; set; } = string.Empty;
        public int EngineCapacity { get; set; }
        public ThickAuto(string brand, string modelAuto, int engineCapacity)
        {
            Brand = brand;
            ModelAuto = modelAuto;
            EngineCapacity = engineCapacity;
        }
        public string GetInfo()
        {
            return $"Наименование: {Brand}, Модель: {ModelAuto}, Объем двигателя, куб. см: {EngineCapacity}";
        }
    }
}
