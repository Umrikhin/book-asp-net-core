using Dropdownlist.Models;

namespace Dropdownlist.Services
{
    public class Regions : IRegions
    {
        private List<Land> dataCountrys;
        private List<City> dataTowns;
        public Regions()
        {
            dataTowns = new List<City>()
            {
                new City() { id = 1, nm = "Москва", idLand = 1, PopulationSize = 11920000 },
                new City() { id = 2, nm = "Ростов-на-Дону", idLand = 1, PopulationSize = 1100000 },
                new City() { id = 3, nm = "Ставрополь", idLand = 1, PopulationSize = 408000  },
                new City() { id = 4, nm = "Краснодар", idLand = 1, PopulationSize = 773000  },
                new City() { id = 5, nm = "Минск", idLand = 2, PopulationSize = 2009786  },
                new City() { id = 6, nm = "Париж", idLand = 3, PopulationSize = 2160000 },
                new City() {id = 7, nm = "Марсель", idLand = 3, PopulationSize = 861635 }
            };
            dataCountrys = new List<Land>()
            {
                new Land() { id = 1, nm = "Россия" },
                new Land() { id = 2, nm = "Белоруссия" },
                new Land() { id = 3, nm = "Франция"  }
            };
        }
        List<Land> IRegions.countrys => dataCountrys;
        List<City> IRegions.towns => dataTowns;
    }
}
