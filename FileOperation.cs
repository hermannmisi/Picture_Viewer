using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace FileOperations
{
    public class FileOperation
    {
        //public static AllSettings JsonAllSettings = new();

        public static string LastPath { get; set; }

        public static string ActualFolder { get; set; }

        public static string[] ElerhetoNyelvek { get; set; }

        public static string[] ElerhetoNyelvekVerzio { get; set; }
        //public static string[] HelpFilesDB = new string[ElerhetoNyelvekMaxSzama];
        //public static string[] HelpFilesVersions = new string[ElerhetoNyelvekMaxSzama];

        public static string MainFile { get; set; }

        public static AllSettings GetDefaultSettings()
        {
            AllSettings JsonAllSettings = new();

            Settings JsSet = new()
            {
                UsedLanguage = "HU_magyar",
                UsageCounter = 0
            };

            UserSettings JsUsrSet = new()
            {
                BetaVersion = true
            };

            Interface JsIntf = new()
            {
                FullScreen = "Normal"
            };

            JsonAllSettings.JsonSettings = JsSet;
            JsonAllSettings.JsonUserSettings = JsUsrSet;
            JsonAllSettings.JsonInterface = JsIntf;

            return JsonAllSettings;
        }

        public static AllSettings ReadSettings()
        {
            string response = File.ReadAllText($@"{ActualFolder}\settings_{MainFile}.ini", System.Text.Encoding.Unicode);
            AllSettings JsonAllSettings = JsonSerializer.Deserialize<AllSettings>(response);

            return JsonAllSettings;
        }


        public static void WriteSettings(AllSettings JsonAllSettings)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                //Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            var writeJson = JsonSerializer.Serialize<AllSettings>(JsonAllSettings, options);
            File.WriteAllText($@"{ActualFolder}\settings_{MainFile}.ini", writeJson, System.Text.Encoding.Unicode);
        }
    }
}
