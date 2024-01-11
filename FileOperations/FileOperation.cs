using System.Text;
using System.Text.Unicode;

namespace FileOperations
{
    public class FileOperation
    {
        public static AllSettings allSettings = new();

        public static string LastPath { get; set; } = string.Empty;

        public static string ActualFolder { get; set; } = string.Empty;

        public static string[] ElerhetoNyelvek { get; set; } = [];

        public static string[] ElerhetoNyelvekVerzio { get; set; } = [];

        public static string MainFile { get; set; } = string.Empty;

        public static void ReadSettings()
        {
            if (File.Exists($@"{ActualFolder}\settings_{MainFile}.ini"))
            {
                string strJson = File.ReadAllText($@"{ActualFolder}\settings_{MainFile}.ini", System.Text.Encoding.Unicode);
                Json json = new();
                json.FromJson(allSettings, strJson);
            }
        }


        public static void WriteSettings()
        {
            Json saveJson = new();
            string writeJson = saveJson.ToJson(allSettings);
            File.WriteAllText($@"{ActualFolder}\settings_{MainFile}.ini", writeJson, System.Text.Encoding.Unicode);
        }
    }
}
