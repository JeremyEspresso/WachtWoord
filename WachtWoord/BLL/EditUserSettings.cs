using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WachtWoord.Models;

namespace WachtWoord.BLL
{
    public class EditUserSettings
    {
        public static void EditSettings(string lower,
                                        string upper,
                                        string symbols,
                                        string numbers,
                                        bool useLower,
                                        bool useUpper,
                                        bool useNumbers,
                                        bool useSpecials)
        {
            if (!File.Exists(JSONCreate.path)) throw new FileNotFoundException("settings.json not found");

            string JSON = File.ReadAllText(JSONCreate.path);
            UserSettings settings = JsonConvert.DeserializeObject<UserSettings>(JSON);
            settings.useLower = useLower;
            settings.useUpper = useUpper;
            settings.useNumbers = useNumbers;
            settings.useSpecials = useSpecials;
            settings.lower = lower;
            settings.upper = upper;
            settings.numbers = numbers;
            settings.specials = symbols;
            string JSONres = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(JSONCreate.path, JSONres);
        }
    }
}
