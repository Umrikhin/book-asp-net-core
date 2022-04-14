namespace HelloRazor.Services
{
    public class HelloService : IHello
    {
        public string GetMsg()
        {
            return "Добро пожаловать, уважаемый пользователь!";
        }
    }
}
