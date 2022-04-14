namespace AlertService.Services
{
    public class JsonAlert : IAlert
    {
        IConfiguration _config;

        public JsonAlert(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GetMessage()
        {
            return _config.GetSection("Alert")["Msg"];
        }
    }
}
