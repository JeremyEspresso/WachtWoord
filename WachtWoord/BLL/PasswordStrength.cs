using Zxcvbn;

namespace WachtWoord.BLL
{
    public class PasswordStrength
    {
        public static int GetPasswordStrength(string password)
        {
            var result = Core.EvaluatePassword(password);
            return (int)result.Score * 20;
        }
    }
}
