using FlexiObject.Core.Config.SettingsStore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexiObject.AppClient.Core.Settings
{
    public class LoginSettings
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public bool IsStandalone { get; set; }
    }
    public class AppSettings : AJsonSettings
    {
        public int? DefaultSetting { get; set; }
        public List<LoginSettings> LoginSettings { get; set; } = new();

        public LoginSettings GetCurrent()
        {
            if(!LoginSettings.Any())
                throw new Exception("Нет настроек подключения");

            if (DefaultSetting.HasValue)
            {
                if(DefaultSetting < LoginSettings.Count || DefaultSetting > LoginSettings.Count)
                {
                    if(LoginSettings.Count > 0)
                        DefaultSetting = 0;
                    else
                    {
                        throw new Exception("Некорректные настройки подключения");
                    }
                }
            }
            else
            {
                throw new Exception("Не выбраны настройки подключения");
            }
            return LoginSettings[DefaultSetting.Value];
        }
    }
}
