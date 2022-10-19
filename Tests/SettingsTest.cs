using System.Reflection;

using Xunit.Sdk;


namespace Tests
{
    public class SettingsTest : IDisposable
    {
        public SettingsTest()
        {
            Settings.Create();
        }
        public void Dispose()
        {
            Settings.Delete();
        }

        [Fact]
        public void Create()
        {
            Settings.Create();
            Assert.True(File.Exists(Settings.path));
        }

        [Fact]
        public void Delete()
        {
            Settings.Delete();
            Assert.False(File.Exists(Settings.path));
        }

        [Fact]
        public void ReadNotNull()
        {
            UserSettings? userSettings = Settings.Read();
            Assert.NotNull(userSettings);
        }

        [Fact]
        public void ReadNull()
        {
            Settings.Delete(); 
            UserSettings? userSettings = Settings.Read();
            
            Assert.Null(userSettings);
        }

        [Fact]
        public void Update()
        {
            Settings.Update(new UserSettings() { lower = "test" });
            UserSettings? userSettings = Settings.Read();
            Assert.Equal("test", userSettings.lower);
        }
    }
}