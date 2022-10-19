using Xunit.Sdk;


namespace Tests
{
    public class PasswordGeneratorTest
    {
        /*
         * Result of characters is not NULL
         */
        [Fact]
        public void CharactersAreCreated()
        {
            PasswordGenerator gen = new(1, true, true, true, true);
            var result = gen.GenerateCharacters();
            Assert.False(string.IsNullOrEmpty(result));
        }

        /*
         * Result of characters meets the users requirements
        */
        [Theory]
        [InlineData("$")]
        [InlineData("8")]
        [InlineData("A")]
        [InlineData("a")]
        public void CharactersContainsRequirements(string character)
        {
            PasswordGenerator gen = new(12, true, true, true, true);
            var result = gen.GenerateCharacters();
            Assert.Contains(character, result);
        }

        /*
         * Password length should be the exact length as the length parameter
        */
        [Theory]
        [InlineData(83)]
        [InlineData(13)]
        [InlineData(102)]
        [InlineData(107)]
        public void PasswordLength(int length)
        {
            PasswordGenerator gen = new(length, true, true, true, true);
            var result = gen.GeneratePassword();
            Assert.Equal(length, result.Length);
        }
    }
}