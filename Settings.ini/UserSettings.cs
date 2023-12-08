
using System.Text.Json.Serialization;

namespace FileOperations
{
    public class UserSettings
    {

        [JsonPropertyName("FlatButton")]
        public bool FlatButton { get; set; }

        [JsonPropertyName("BetaVersion")]
        public bool BetaVersion { get; set; }

        [JsonPropertyName("ShowNews")]
        public bool ShowNews { get; set; }

        [JsonPropertyName("ReceiveNews")]
        public bool ReceiveNews { get; set; }

        [JsonPropertyName("LastNewsCounter")]
        public int LastNewsCounter { get; set; }

        [JsonPropertyName("NewsCategories")]
        public string NewsCategories { get; set; } //main,beta,news

        [JsonPropertyName("AutoUpdate")]
        public bool AutoUpdate { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }
    }
}