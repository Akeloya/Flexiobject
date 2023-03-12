namespace FlexiObject.Core.Config.SettingsStore
{
    public abstract class AJsonSettings
    {
        public AJsonSettings()
        {
            ConfigName = GetType().Name;
        }

        public string ConfigName { get; }
    }
}
