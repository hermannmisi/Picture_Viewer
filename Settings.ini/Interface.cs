
using System.Text.Json.Serialization;

namespace FileOperations
{
    public class Interface
    {
        [JsonPropertyName("StartPositionX")]
        public int StartPositionX { get; set; }

        [JsonPropertyName("StartPositionY")]
        public int StartPositionY { get; set; }

        [JsonPropertyName("WindowWith")]
        public int WindowWith { get; set; }

        [JsonPropertyName("WindowHeight")]
        public int WindowHeight { get; set; }

        [JsonPropertyName("FullScreen")]
        public string FullScreen { get; set; }

        [JsonPropertyName("HelpStartPositionX")]
        public string HelpStartPositionX { get; set; }

        [JsonPropertyName("HelpStartPositionY")]
        public string HelpStartPositionY { get; set; }

        [JsonPropertyName("HelpWindowWith")]
        public string HelpWindowWith { get; set; }

        [JsonPropertyName("HelpWindowHeight")]
        public string HelpWindowHeight { get; set; }

        [JsonPropertyName("HelpFullScreen")]
        public string HelpFullScreen { get; set; }
    }
}