using Zxcvbn;

namespace WachtWoord.BLL
{
    public class PasswordStrength
    {
        public static double GetPasswordStrength(string password)
        {
            var result = Core.EvaluatePassword(password);
            return result.Guesses;
        }
    }
}
