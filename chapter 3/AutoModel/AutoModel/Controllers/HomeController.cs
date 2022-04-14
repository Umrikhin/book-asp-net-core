using AutoModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoModel.Controllers
{
    public class HomeController: Controller
    {
        public string Index()
        {
            Auto auto = new Auto()
            {
                Brand = "Audi",
                ModelAuto = "A6",
                EngineCapacity = 2393
            };
            string result = $"Наименование: {auto.Brand}, Модель: {auto.ModelAuto}, Объем двигателя, куб. см: {auto.EngineCapacity}";
            return result;
        }
        public string Hello()
        {
            ThickAuto audio = new ThickAuto("Audi", "A6", 2393);
            return audio.GetInfo();
        }
    }
}
