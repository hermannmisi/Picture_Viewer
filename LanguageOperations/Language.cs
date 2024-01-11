using FileOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageOperations
{
    public class Language
    {
        public static AllLanguageItems allLanguageItems = new();

        public static void ReadLanguage(string language)
        {
            if (File.Exists($@"{FileOperation.ActualFolder}\lang\{language}.lng"))
            {
                string strJson = File.ReadAllText($@"{FileOperation.ActualFolder}\lang\{language}.lng", System.Text.Encoding.Unicode);
                Json json = new();
                json.FromJson(allLanguageItems, strJson);
            }
        }
    }
}
