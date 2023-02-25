using FlexiObject.Core.Config;

using System.IO;

using Xunit;

namespace FlexiObject.Tests.Core.Config
{
    public class SettingsStoreTests
    {
        private const string DefaultStr = "DefaultStr";
        private const int DefaultInt = 56;
        private class TestSettings : AJsonSettings
        {
            public TestSettings() : base()
            {

            }

            public string TestStr { get; set; } = DefaultStr;
            public int TestInt { get; set; } = DefaultInt;
        }

        [JsonSettingSubFolder("Folder1")]
        private class TestForSubfolder1Settings : TestSettings { }

        [JsonSettingSubFolder("Folder2")]
        private class TestForSubfolder2Settings : TestSettings { }
        [Fact]
        public void SettingsCreate()
        {
            File.Delete(Path.Combine(PathConfigs.GetCommongDataDirectory(), nameof(TestSettings) + ".json"));
            var jsonSettingsStore = new JsonSettingsStore();
            var defaultData = jsonSettingsStore.Load<TestSettings>();

            Assert.NotNull(defaultData);
            Assert.Equal(DefaultStr, defaultData.TestStr);
            Assert.Equal(DefaultInt, defaultData.TestInt);

            defaultData.TestStr = DefaultStr + DefaultStr;
            defaultData.TestInt = DefaultInt + DefaultInt;

            jsonSettingsStore.Save(defaultData);

            defaultData = jsonSettingsStore.Load<TestSettings>();

            Assert.Equal(DefaultStr + DefaultStr, defaultData.TestStr);
            Assert.Equal(DefaultInt + DefaultInt, defaultData.TestInt);

            File.Delete(Path.Combine(PathConfigs.GetCommongDataDirectory(), nameof(TestSettings) + ".json"));
        }
        [Fact]
        public void SettingsWithSubfolders()
        {
            var checkPath1 = Path.Combine(PathConfigs.GetCommongDataDirectory(), "Folder1");
            var checkPath2 = Path.Combine(PathConfigs.GetCommongDataDirectory(), "Folder2");

            if(Directory.Exists(checkPath1))
                Directory.Delete(checkPath1, true);
            if(Directory.Exists(checkPath2))
                Directory.Delete(checkPath2, true);

            var jsonSettingsStore = new JsonSettingsStore();
            var defaultData1 = jsonSettingsStore.Load<TestForSubfolder1Settings>();
            Assert.NotNull(defaultData1);

            var defaultData2 = jsonSettingsStore.Load<TestForSubfolder2Settings>();
            Assert.NotNull(defaultData2);


            var test1 = File.Exists(Path.Combine(checkPath1, nameof(TestForSubfolder1Settings) + ".json"));
            Assert.True(test1);
            Directory.Delete(checkPath1, true);

            var test2 = File.Exists(Path.Combine(checkPath2, nameof(TestForSubfolder2Settings) + ".json"));
            Assert.True(test2);
            Directory.Delete(checkPath2, true);
        }
    }
}
