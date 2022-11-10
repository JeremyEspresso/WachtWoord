using Newtonsoft.Json;
using System.Text;
using WachtWoord.Domain.Models;

namespace WachtWoord.Logic.Utils
{
    public static class SettingsUtil
    {
        public static readonly string path = Environment.CurrentDirectory + "settings.json";
        public static void Create()
        {
            if (File.Exists(path)) return;
            using (FileStream fs = File.Create(path))
            {
                string JSONres = JsonConvert.SerializeObject(new UserSettings(), Formatting.Indented);
                byte[] info = new UTF8Encoding(true).GetBytes(JSONres);
                fs.Write(info, 0, info.Length);
            };
        }
        public static void Update(UserSettings userSettings)
        {
            string JSONres = JsonConvert.SerializeObject(userSettings, Formatting.Indented);
            File.WriteAllText(path, JSONres);
        }

        public static void Delete()
        {
            if (File.Exists(path)) File.Delete(path);
        }

        public static UserSettings? Read()
        {
            if (!File.Exists(path)) return null;
            string JSONres = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<UserSettings>(JSONres);
        }

    }
}
