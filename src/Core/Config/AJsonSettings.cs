namespace FlexiObject.Core.Config
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
