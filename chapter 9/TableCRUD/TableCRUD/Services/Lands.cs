using TableCRUD.Models;

namespace TableCRUD.Services
{
    public class Lands : ILands
    {
        private List<Country> data;
        public Lands()
        {
            data = new List<Country>()
            {
                new Country() { Id = 1, CountryName = "Россия" },
                new Country() { Id = 2, CountryName = "Франция" },
                new Country() { Id = 3, CountryName = "Норвегия" }
            };
        }
        List<Country> ILands.lands => data;
        public int AddCountry(Country country)
        {
            if (data.Where(x => x.CountryName == country.CountryName).Count() > 0) throw new Exception("Элемент уже существует в списке.");
            country.Id = data.Max(p => p.Id) + 1;
            data.Add(country);
            return country.Id;
        }
        public void DeleteCountry(Country country)
        {
            data.RemoveAll(x => x.Id == country.Id);
        }
        public void EditCountry(Country country)
        {
            data.Where(p => p.Id == country.Id).ToList().ForEach(x => { x.CountryName = country.CountryName; });
        }
    }
}
