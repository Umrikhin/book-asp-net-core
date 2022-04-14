using TableCRUD.Models;

namespace TableCRUD.Services
{
    public interface ILands
    {
        List<Country> lands { get; }
        void EditCountry(Country country);
        void DeleteCountry(Country country);
        int AddCountry(Country country);
    }
}
