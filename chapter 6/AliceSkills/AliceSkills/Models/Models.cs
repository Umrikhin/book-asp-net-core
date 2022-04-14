using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//Модели из этого пространства имен можно использовать вместо Yandex.Alice.Sdk.Models
//Для отправки результата можно использовать статический метод Reply класса UtilsAlice 
namespace YandexAliceSkills
{
    public class SessionModel
    {
        [JsonProperty("new")]
        public bool New { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; } = string.Empty;

        [JsonProperty("message_id")]
        public int MessageId { get; set; }

        [JsonProperty("skill_id")]
        public string SkillId { get; set; } = string.Empty;

        [JsonProperty("user_id")]
        public string UserId { get; set; } = string.Empty;
    }
    public class ResponseModel
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("tts")]
        public string Tts { get; set; } = string.Empty;

        [JsonProperty("end_session")]
        public bool EndSession { get; set; } = false;

        [JsonProperty("buttons")]
        public ButtonModel[]? Buttons { get; set; }
    }
    public class ButtonModel
    {
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("payload")]
        public object Payload { get; set; } = null!;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("hide")]
        public bool Hide { get; set; } = false;
    }
    public class MetaModel
    {
        [JsonProperty("locale")]
        public string Locale { get; set; } = string.Empty;

        [JsonProperty("timezone")]
        public string Timezone { get; set; } = string.Empty;

        [JsonProperty("client_id")]
        public string ClientId { get; set; } = string.Empty;
    }
    public class AliceRequest
    {
        [JsonProperty("meta")]
        public MetaModel Meta { get; set; } = null!;

        [JsonProperty("request")]
        public RequestModel Request { get; set; } = null!;

        [JsonProperty("session")]
        public SessionModel Session { get; set; } = null!;

        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;
    }
    public enum RequestType
    {
        SimpleUtterance,
        ButtonPressed
    }
    public class RequestModel
    {
        [JsonProperty("command")]
        public string Command { get; set; } = string.Empty;

        [JsonProperty("type")]
        public RequestType Type { get; set; }

        [JsonProperty("original_utterance")]
        public string OriginalUtterance { get; set; } = string.Empty;

        [JsonProperty("payload")]
        public JObject Payload { get; set; } = null!;
    }
    public class AliceResponse
    {
        [JsonProperty("response")]
        public ResponseModel Response { get; set; } = null!;

        [JsonProperty("session")]
        public SessionModel Session { get; set; } = null!;

        [JsonProperty("version")]
        public string Version { get; set; } = "1.0";
    }
    public class UtilsAlice
    {
        public static AliceResponse Reply(AliceRequest req, string text, bool endSession = false, ButtonModel[]? buttons = null)
        {
            return new AliceResponse
            {
                Response = new ResponseModel
                {
                    Text = text,
                    Tts = text,
                    EndSession = endSession,
                    Buttons = buttons
                },
                Session = req.Session
            };
        }
    }
}