namespace HelloRazor.Services
{
    public class AlertService : IAlert
    {
        public string GetMessage()
        {
            return "Внимание, Вы получили сообщение!";
        }
    }
}
