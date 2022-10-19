using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WachtWoord.Models;

namespace WachtWoord.BLL
{
    public class JSONCreate
    {
        //public static readonly string path = Environment.CurrentDirectory + "settings.json";\
        public static readonly string path = "C:\\Users\\duane\\source\\repos\\WachtWoord\\WachtWoord\\WachtWoord.json";
        public static void Initialize()
        {
            if (File.Exists(path)) return;
            using (FileStream fs = File.Create(path))
            {
                string JSONres = JsonConvert.SerializeObject(new UserSettings(), Formatting.Indented);
                byte[] info = new UTF8Encoding(true).GetBytes(JSONres);
                fs.Write(info, 0, info.Length);
            };
        }
    }
}
