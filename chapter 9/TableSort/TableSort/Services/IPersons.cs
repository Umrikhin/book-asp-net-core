using TableSort.Models;

namespace TableSort.Services
{
    public interface IPersons
    {
        IEnumerable<Person> GetAll();
    }
}
