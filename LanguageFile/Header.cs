
using System.Text.Json.Serialization;

namespace LanguageOperations
{
    public class Header
    {
        [JsonPropertyName("Version")]
        public int Version { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Lang")]
        public string Lang { get; set; }

        [JsonPropertyName("Translator")]
        public string Translator { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }
    }
}
