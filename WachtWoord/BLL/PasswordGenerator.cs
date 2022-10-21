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
        private int Length { get; set; }
        public PasswordGenerator(int length)
        {
            this.UserSettings = Settings.Read() ?? new UserSettings();
            this.Length = length;
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
                byte[] prev = new byte[1];
                byte[] next = new byte[1];
                rng.GetBytes(prev);
                for (int i = 0; i < Length; i++)
                {
                    rng.GetBytes(next);
                    while (prev[0] == next[0])
                    {
                        rng.GetBytes(next);
                    }
                    byte b = next[0];
                    password.Append(chars[b % (chars.Length)]);
                    prev[0] = next[0];
                }
            }

            return password.ToString();
        }
    }
}
