namespace WachtWoord.Logic.Abstractions
{
    internal interface IPasswordGenerator
    {
        public string GeneratePassword();
        public string GenerateCharacters();
    }
}
