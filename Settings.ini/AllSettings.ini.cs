
using System.Text.Json.Serialization;

namespace FileOperations
{
    public class AllSettings
    {
        [JsonInclude]
        [JsonPropertyName("Settings")]
        public Settings? JsonSettings { get; set; }

        [JsonInclude]
        [JsonPropertyName("UserSettings")]
        public UserSettings? JsonUserSettings { get; set; }

        [JsonInclude]
        [JsonPropertyName("Interface")]
        public Interface? JsonInterface { get; set; }
    }
}
