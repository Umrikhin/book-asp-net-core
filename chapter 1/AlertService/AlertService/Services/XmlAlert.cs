namespace AlertService.Services
{
    public class XmlAlert : IAlert
    {
        IConfiguration _config;

        public XmlAlert(IWebHostEnvironment env)
        {
            //Определяем объект построителя конфигурации
            var configurationBinder = new ConfigurationBuilder();
            //Устанавливаем путь, по которому будет осуществляться поиск файла конфигурации
            configurationBinder.SetBasePath(env.ContentRootPath);
            //Задаем имя файла конфигурации
            configurationBinder.AddXmlFile("settings.xml");
            //Создаем конфигурацию
            _config = configurationBinder.Build();
        }

        public string GetMessage()
        {
            return _config.GetSection("Alert")["Msg"];
        }
    }
}
