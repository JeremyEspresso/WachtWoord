using Xunit.Sdk;


namespace Tests
{
    public class PasswordGeneratorTest
    {
        /*
         * Tests with default UserSettings
         */

            /*
             * Generate Characters Tests
             */
        [Fact]
        public void GenerateCharactersDefaultSettings()
        {
            var passwordGenerator = new PasswordGenerator(32);
            var result = passwordGenerator.GenerateCharacters();
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("b")]
        [InlineData("F")]
        [InlineData("2")]
        [InlineData("$")]
        public void GenerateCharactersDefaultSettingsContains(string expected)
        {
            var passwordGenerator = new PasswordGenerator(32);
            var result = passwordGenerator.GenerateCharacters();
            Assert.Contains(expected, result);
        }

        [Theory]
        [InlineData("abcdefghijklmnopqrstuvwxyz")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("0123456789")]
        [InlineData("!@#$%^&*()_+-=[]{}|;':,./<>?`~")]
        public void GenerateCharactersDefaultSettingsIsShuffled(string expected)
        {
            var passwordGenerator = new PasswordGenerator(32);
            var result = passwordGenerator.GenerateCharacters();
            Assert.DoesNotContain(expected, result);
        }

        [Fact]
        public void GeneratePasswordDefaultSettings()
        {
            var passwordGenerator = new PasswordGenerator(32);
            var result = passwordGenerator.GenerateCharacters();
            Assert.NotNull(result);
        }

        [Fact]
        public void GeneratePasswordNoSequence()
        {
            var passwordGenerator = new PasswordGenerator(82);
            var result = passwordGenerator.GeneratePassword();
            bool containsSequence = false;
            
            for(int i = 0; i < result.Length - 1; i++)
            {
                if (result[i] == result[i + 1]) containsSequence = true;
            }
            
            Assert.False(containsSequence);
        }
        
    }
}