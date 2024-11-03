using System.Text.Json.Serialization;

namespace OpenAILib.Dto
{
    public class ChatMessage
    {
        public string role { get; set; }
        public string content { get; set; }
    }
    public class ChatResponse
    {
        public string text { get; set; } = string.Empty;
    }
    


}
