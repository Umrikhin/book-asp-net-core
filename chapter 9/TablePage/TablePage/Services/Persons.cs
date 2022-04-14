using TablePage.Models;

namespace TablePage.Services
{
    public class Persons : IPersons
    {
        private List<Person> data;
        public Persons()
        {
            data = new List<Person>()
            {
                new Person() { Id = 1, FirstName = "Александр", LastName = "Кузнецов", DateOfBirth = DateTime.Parse("01.02.1978"), Country="Россия" },
                new Person() { Id = 2, FirstName = "Ирина", LastName = "Соколова", DateOfBirth = DateTime.Parse("02.02.1987"), Country="Казахстан" },
                new Person() { Id = 3, FirstName = "Иван", LastName = "Петров", DateOfBirth =  DateTime.Parse("05.03.1986"), Country="Франция" },
                new Person() { Id = 4, FirstName = "Влад", LastName = "Семенов", DateOfBirth = DateTime.Parse("12.02.1995"), Country="Россия" },
                new Person() { Id = 5, FirstName = "Максим", LastName ="Андреев", DateOfBirth = DateTime.Parse("01.01.2001"), Country="Германия" },
                new Person() { Id = 6, FirstName = "Василий", LastName ="Иванов", DateOfBirth = DateTime.Parse("07.12.1976"), Country="Россия" },
                new Person() { Id = 7, FirstName = "Петр", LastName ="Сергеев", DateOfBirth = DateTime.Parse("15.11.1980"), Country="Германия" },
                new Person() { Id = 8, FirstName = "Борис", LastName ="Еремин", DateOfBirth = DateTime.Parse("06.07.1956"), Country="Турция" },
                new Person() { Id = 9, FirstName = "Елена", LastName ="Новикова", DateOfBirth = DateTime.Parse("12.08.1967"), Country="Франция" },
                new Person() { Id = 10, FirstName = "Татьяна", LastName ="Короткова", DateOfBirth = DateTime.Parse("03.08.1986"), Country="Греция" },
                new Person() { Id = 11, FirstName = "Владимир", LastName ="Комаров", DateOfBirth = DateTime.Parse("14.09.1978"), Country="Германия" },
                new Person() { Id = 12, FirstName = "Андрей", LastName ="Волков", DateOfBirth = DateTime.Parse("15.05.1989"), Country="Болгария" }
            };
        }
        List<Person> IPersons.Persons => data;
    }
}
