using TableSort.Models;

namespace TableSort.Services
{
    public class Persons : IPersons
    {
        private List<Person> _rows = new List<Person>();
        public Persons()
        {
            _rows.Add(new Person() { Id = 1, FirstName = "Алексей", LastName = "Никитин", DateOfBirth = DateTime.Parse("01.02.1978") });
            _rows.Add(new Person() { Id = 2, FirstName = "Ирина", LastName = "Кузнецова", DateOfBirth = DateTime.Parse("02.02.1987") });
            _rows.Add(new Person() { Id = 3, FirstName = "Иван", LastName = "Петров", DateOfBirth = DateTime.Parse("05.03.1986") });
            _rows.Add(new Person() { Id = 4, FirstName = "Влад", LastName = "Иванов", DateOfBirth = DateTime.Parse("12.02.1995") });
            _rows.Add(new Person() { Id = 5, FirstName = "Максим", LastName = "Тарасов", DateOfBirth = DateTime.Parse("05.01.2001") });
        }
        public IEnumerable<Person> GetAll()
        {
            return _rows;
        }
    }
}
