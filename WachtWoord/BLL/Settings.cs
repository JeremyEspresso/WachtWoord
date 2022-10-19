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
        public static void UpdateSettings(UserSettings userSettings) 
        {
            string JSONres = JsonConvert.SerializeObject(userSettings, Formatting.Indented);
            File.WriteAllText(JSONCreate.path, JSONres);
        }
        
    }
}
