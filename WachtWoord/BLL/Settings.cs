using Newtonsoft.Json;
using System.Text;
using WachtWoord.Models;

namespace WachtWoord.BLL
{
    public class Settings
    {
        public static readonly string path = Environment.CurrentDirectory + "settings.json";
        public void Create()
        {
            if (File.Exists(path)) return;
            using (FileStream fs = File.Create(path))
            {
                string JSONres = JsonConvert.SerializeObject(new UserSettings(), Formatting.Indented);
                byte[] info = new UTF8Encoding(true).GetBytes(JSONres);
                fs.Write(info, 0, info.Length);
            };
        }
        public void Update(UserSettings userSettings)
        {
            string JSONres = JsonConvert.SerializeObject(userSettings, Formatting.Indented);
            File.WriteAllText(path, JSONres);
        }

        public void Delete()
        {

            File.Delete(path);
        }

        public UserSettings Read()
        {
            string JSONres = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<UserSettings>(JSONres);
        }
        
    }
}
