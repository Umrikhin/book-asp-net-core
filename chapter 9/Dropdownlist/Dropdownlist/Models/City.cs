namespace Dropdownlist.Models
{
    //Класс городов
    public class City
    {
        public int id { get; set; }
        public string nm { get; set; } = string.Empty;
        public int idLand { get; set; }
        public int PopulationSize { get; set; }
    }
}
