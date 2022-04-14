using TableGroup.Models;

namespace TableGroup.Services
{
    public class Persons : IPersons
    {
        private List<Person> data;
        public Persons()
        {
            data = new List<Person>()
            {
                new Person() { Id = 1, LoginName = "bono", TimeLogin = DateTime.Parse("01.05.2022 16:30"), TimeExit = DateTime.Parse("01.05.2022 16:40"), idOffice = 1 },
                new Person() { Id = 2, LoginName = "sasha", TimeLogin = DateTime.Parse("02.07.2022 15:30"), TimeExit = DateTime.Parse("02.07.2022 15:35"), idOffice = 3 },
                new Person() { Id = 3, LoginName = "masha", TimeLogin = DateTime.Parse("05.03.2022 06:30"), TimeExit =  DateTime.Parse("05.03.2022 07:20"), idOffice = 2 },
                new Person() { Id = 4, LoginName = "katerina", TimeLogin = DateTime.Parse("12.04.2022 12:35"), TimeExit = DateTime.Parse("12.04.2022 12:55"), idOffice = 1 },
                new Person() { Id = 5, LoginName = "sveta", TimeLogin = DateTime.Parse("01.01.2022 20:00"), TimeExit = DateTime.Parse("01.01.2022 20:05"), idOffice = 2  }
            };
        }
        List<Person> IPersons.Persons => data;
    }
}
