using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WachtWoord.BLL
{
    internal class PasswordGenerator : IPasswordGenerator
    {
        private const string lower = "abcdefghijklmnopqrstuvwxyz";
        private const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string numbers = "0123456789";
        private const string specials = "!@#$%^&*()_+-=[]{}|;':,./<>?`~";
        private int length { get; set; }


        public PasswordGenerator(int length)
        {
            this.length = length;
        }

        // <summary>
        // Function checks the password generator requirements set by the user
        // Creates a string of chars based on the requirements
        // This string is then shuffled and returned
        // </summary>
        public string GenerateCharacters()
        {
            StringBuilder chars = new();
            //Placeholders, these will be replaced by values from config file.
            bool lowerChecked = true;
            bool upperChecked = true;
            bool specialsChecked = true;
            bool numbersChecked = true;
            if (lowerChecked) chars.Append(lower);
            if (upperChecked) chars.Append(upper);
            if (specialsChecked) chars.Append(numbers);
            if (numbersChecked) chars.Append(specials);
            
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

            //use RandomNumberGenerator
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] oneByte = new byte[1];
                for (int i = 0; i < length; i++)
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
