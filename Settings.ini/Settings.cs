
using System.Text.Json.Serialization;

namespace FileOperations
{
    public class Settings
    {
        [JsonPropertyName("UsedLanguage")]
        public string UsedLanguage { get; set; }

        [JsonPropertyName("UsageCounter")]
        public int UsageCounter { get; set; }

        [JsonPropertyName("LastNewsCounter")]
        public int LastNewsCounter { get; set; }
    }
}
