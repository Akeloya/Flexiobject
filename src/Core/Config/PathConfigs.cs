using System;
using System.IO;

using static System.Environment;

namespace FlexiObject.Core.Config
{
    public class PathConfigs
    {
        public const string AppFolder = "FlexiObject";
        public static string GetCommongDataDirectory()
        {
            if(EnviromentInformation.IsWindows || EnviromentInformation.IsLinux)
                return Path.Combine(GetFolderPath(SpecialFolder.CommonApplicationData), AppFolder);

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppFolder);
        }

        public static string GetDataDirectory()
        {
            if(EnviromentInformation.IsWindows || EnviromentInformation.IsLinux)
                return Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), AppFolder);

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppFolder);
        }
    }
}
