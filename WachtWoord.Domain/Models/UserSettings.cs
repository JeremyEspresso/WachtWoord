/*
 * <summary>
 * This class is used for the settings.json file
 * It contains the default settings for the application
 * </summary>
 */

namespace WachtWoord.Domain.Models
{
    public class UserSettings
    {
        public string lower = "abcdefghijklmnopqrstuvwxyz";
        public string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string numbers = "0123456789";
        public string specials = "!@#$%^&*()_+-=[]{}|;':,./<>?`~";
        public bool useUpper = true;
        public bool useLower = true;
        public bool useNumbers = true;
        public bool useSpecials = true;
    }
}
