namespace HelloConfig
{
    public class Settings
    {
        //Свойство, хранящее набор значений параметров сервера
        public IConfiguration config { get; set; }

        public Settings()
        {
            //Определяем объект построителя конфигурации
            var configurationBinder = new ConfigurationBuilder();
            //Добавлем в коллекцию набор значений
            configurationBinder.AddInMemoryCollection(new Dictionary<string, string> { { "Country", "Россия" }, { "City", "Москва" } });
            //Создаем конфигурацию
            config = configurationBinder.Build();
        }

        public Settings(string rootPath)
        {
            //Определяем объект построителя конфигурации
            var configurationBinder = new ConfigurationBuilder();
            //Устанавливаем путь, по которому будет осуществляться поиск файла конфигурации
            configurationBinder.SetBasePath(rootPath);
            //Задаем имя файла конфигурации
            configurationBinder.AddJsonFile("appsettings.json");
            //Создаем конфигурацию
            config = configurationBinder.Build();
        }

    }
}
