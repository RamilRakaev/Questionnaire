using System.Text.Json.Serialization;

namespace Questionnaire.Infrastructure.Models
{
    public class NotificationToQrlk
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }

        [JsonPropertyName("tags")]
        public string[] Tags { get; set; }
    }
}
