using System.Security.Cryptography;
using System.Text;
using WachtWoord.Domain.Models;
using WachtWoord.Logic.Abstractions;

namespace WachtWoord.Logic.PasswordGenerator
{
    public class PWGenerator : IPasswordGenerator
    {
        UserSettings UserSettings { get; set; }
        private int Length { get; set; }
        public PWGenerator(int length, UserSettings userSettings)
        {
            UserSettings = userSettings;
            Length = length;
        }

        public PWGenerator(int length)
        {
            UserSettings = new UserSettings();
            Length = length;
        }
        // <summary>
        // Function checks the password generator requirements set by the user
        // Creates a string of chars based on the requirements
        // This string is then shuffled and returned
        // </summary>
        public string GenerateCharacters()
        {
            StringBuilder chars = new();

            //Get the chars from the settings based on the requirements set by user.
            if (UserSettings.useLower) chars.Append(UserSettings.lower);
            if (UserSettings.useUpper) chars.Append(UserSettings.upper);
            if (UserSettings.useNumbers) chars.Append(UserSettings.numbers);
            if (UserSettings.useSpecials) chars.Append(UserSettings.specials);

            //Fisher-Yates shuffle
            Random random = new();
            int n = chars.Length;
            for (int i = 0; i < n - 1; i++)
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

            //Generate a random password based on the chars
            //Random number generator no sequence
            int prev, next;
            prev = -1;
            for (int i = 0; i < Length; i++)
            {
                next = RandomNumberGenerator.GetInt32(0, chars.Length - 1);
                while (next == prev) next = RandomNumberGenerator.GetInt32(0, chars.Length - 1);
                password.Append(chars[next % chars.Length]);
                prev = next;

            }
            return password.ToString();
        }
    }
}
