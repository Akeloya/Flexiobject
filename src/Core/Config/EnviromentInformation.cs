using System.Runtime.InteropServices;

namespace FlexiObject.Core.Config
{
    public static class EnviromentInformation
    {
        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}
