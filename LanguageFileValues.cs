
using System.Text.Json.Serialization;

namespace LanguageOperations
{
    public class LanguageFileValues
    {
        [JsonInclude]
        [JsonPropertyName("Header")]
        public Header JsonHeader = new();

        [JsonInclude]
        [JsonPropertyName("Text")]
        public Text JsonText = new();

        [JsonInclude]
        [JsonPropertyName("Messages")]
        public Messages JsonMessages = new();
    }
}
