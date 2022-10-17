using Xunit.Sdk;


namespace Tests
{
    public class PasswordGeneratorTest
    {
        [Fact]
        public void CharacterLength()
        {
            PasswordGenerator gen = new(1);
            var result = gen.GenerateCharacters();
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(83)]
        [InlineData(13)]
        [InlineData(102)]
        [InlineData(107)]
        public void PasswordLength(int length)
        {
            PasswordGenerator gen = new(length);
            var result = gen.GeneratePassword();
            Assert.Equal(length, result.Length);
        }
    }
}