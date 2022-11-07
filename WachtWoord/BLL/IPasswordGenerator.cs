namespace WachtWoord.BLL
{
    internal interface IPasswordGenerator
    {
        public string GeneratePassword();
        public string GenerateCharacters();
    }
}
