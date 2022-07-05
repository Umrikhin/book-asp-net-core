using Microsoft.AspNetCore.Mvc;
using Yandex.Alice.Sdk.Models;

namespace AliceSkills.Controllers
{
    [Route("api/[controller]")]
    public class AliceController:Controller
    {
        // GET api/alice
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>() { "value1", "value2" };
        }
        [HttpPost]
        public IActionResult Post([FromBody] AliceRequest aliceRequest)
        {
            if (!string.IsNullOrEmpty(aliceRequest.Request.Command))
            {
                string req = aliceRequest.Request.Command;
                var replyRegion = SayRegion(req);
                if (string.IsNullOrEmpty(replyRegion))
                {
                    switch (req.ToLower())
                    {
                        case "помощь":
                            return Ok(new AliceResponse(aliceRequest, SayHelp()));
                        default:
                            return Ok(new AliceResponse(aliceRequest, SayDefault()));
                    }
                }
                else
                {
                    return Ok(new AliceResponse(aliceRequest, replyRegion));
                }
            }
            else
            {
                var reply = SayStart();
                return Ok(new AliceResponse(aliceRequest, reply));
            }
        }
        //Стартовая фраза
        private string SayStart()
        {
            return "Привет! Это справочник регионов.";
        }
        //Фраза помощи
        private string SayHelp()
        {
            return "Называйте числовой код региона страны и вы узнаете его наименование.";
        }
        //Фраза по умолчанию
        private string SayDefault()
        {
            return "Я не знаю, что ответить на эту команду. Вызовите помощь.";
        }
        //Получение кода региона
        private string SayRegion(string code)
        {
            string result = string.Empty;
            if (code.IndexOf("77") > -1) result = "Москва";
            if (code.IndexOf("78") > -1) result = "Санкт-Петербург";
            if (code.IndexOf("50") > -1) result = "Московская область";
            if (code.IndexOf("23") > -1 || code.IndexOf("93")> -1) result = "Краснодарский край";
            return result;
        }
    }
}
