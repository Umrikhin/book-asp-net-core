using Microsoft.AspNetCore.Mvc;

namespace HelloRouting.Controllers
{
    
    [Route("Lk/[controller]/[action]")] 
    public class PersonController
    {
        //[Route("[action]")] 
        public string Login()
        {
            return "temp@mail.ru";
        }

        //[Route("[action]")] 
        public string Name()
        {
            return "Иванов И.П.";
        }

        //[Route("")] 
        //[Route("[action]")] 
        public string Index()
        {
            return "Привет из личного кабинета";
        }
    }
}
