using AutoComplete.Models;

namespace AutoComplete.Services
{
    public class Persons : IPersons
    {
        private List<Person> data;
        public Persons()
        {
            data = new List<Person>()
            {
                new Person() { Id = 1, FIO = "Фриман С.А.", DR = DateTime.Parse("01.12.1994"), Country = "Россия" },
                new Person() { Id = 2, FIO = "Новикова А.Е.", DR = DateTime.Parse("15.02.1991"), Country = "Белоруссия" },
                new Person() { Id = 3, FIO = "Николаев И.А.", DR = DateTime.Parse("23.08.1993"), Country = "Россия" },
                new Person() { Id = 4, FIO = "Кузнецов В.М", DR = DateTime.Parse("10.11.1998"), Country = "Казахстан" },
                new Person() { Id = 5, FIO = "Григорьева Д.С.", DR = DateTime.Parse("04.12.2001"), Country = "Болгария" },
                new Person() { Id = 6, FIO = "Фридт А.С.", DR = DateTime.Parse("05.06.1987"), Country = "Германия" }
            };
        }
        List<Person> IPersons.people => data;
    }
}
