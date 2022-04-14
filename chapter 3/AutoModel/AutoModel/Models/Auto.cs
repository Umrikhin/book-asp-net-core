namespace AutoModel.Models
{
    public class Auto
    {
        //Наименование автопроизводителя
        public string Brand { get; set; } = string.Empty;
        //Название модели
        public string ModelAuto { get; set; } = string.Empty;
        //Объем двигателя
        public int EngineCapacity { get; set; }
    }
}
