
using System.Text.Json.Serialization;

namespace LanguageOperations
{
    public class Text
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("MenuFile")]
        public string MenuFile { get; set; }
    }
}
