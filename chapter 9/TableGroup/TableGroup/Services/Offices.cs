using TableGroup.Models;

namespace TableGroup.Services
{
    public class Offices: IOffices
    {
        private List<Office> data;
        public Offices()
        {
            data = new List<Office>()
            {
                new Office() { Id = 1, Country = "Болгария", OfficeName = "Офис в Софии" },
                new Office() { Id = 2, Country = "Россия", OfficeName = "Офис в Краснодаре" },
                new Office() { Id = 3, Country = "Канада", OfficeName = "Офис в Торонто" }
            };
        }
        List<Office> IOffices.Offices => data;
    }
}
