
using System.Text.Json.Serialization;

namespace LanguageOperations
{
    public class Messages
    {
        [JsonPropertyName("ErrChangePath")]
        public string ErrChangePath { get; set; }

        [JsonPropertyName("ErrEmptyRoot")]
        public string ErrEmptyRoot { get; set; }
    }
}
