using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WachtWoord.Models;

namespace WachtWoord.BLL
{
    public class PasswordGenerator : IPasswordGenerator
    {
        UserSettings UserSettings { get; set; }
        public PasswordGenerator()
        {
            this.UserSettings = Settings.Read() ?? new UserSettings();
        }
        // <summary>
        // Function checks the password generator requirements set by the user
        // Creates a string of chars based on the requirements
        // This string is then shuffled and returned
        // </summary>
        public string GenerateCharacters()
        {

            StringBuilder chars = new();

            if (UserSettings.useLower) chars.Append(UserSettings.lower);
            if (UserSettings.useUpper) chars.Append(UserSettings.upper);
            if (UserSettings.useNumbers) chars.Append(UserSettings.numbers);
            if (UserSettings.useSpecials) chars.Append(UserSettings.specials);
            
            Random random = new();
            //Fisher-Yates shuffle on string
            int n = chars.Length;
            for(int i = 0; i < (n - 1); i++)
            {
                int r = i + random.Next(n - i);
                (chars[i], chars[r]) = (chars[r], chars[i]);
            }
            return chars.ToString();
        }
        
        //<summary>
        //Generates a password
        //</summary>
        public string GeneratePassword()
        {
            StringBuilder password = new();
            string chars = GenerateCharacters();

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] oneByte = new byte[1];
                for (int i = 0; i < UserSettings.length; i++)
                {
                    rng.GetBytes(oneByte);
                    byte b = oneByte[0];
                    password.Append(chars[b % (chars.Length)]);
                }
            }

            return password.ToString();
        }
    }
}
