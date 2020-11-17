using Microsoft.Win32;
using Utils.Annotations;

namespace TCTimer
{
    public static class Settings
    {
        private const string SettingsKey = "SOFTWARE\\TC_TIMER\\SETTINGS";
        private static readonly RegistryKey BaseKey = Registry.CurrentUser;

        public static void Write(string key, string value)
        {
            var keyHandle = BaseKey.CreateSubKey(SettingsKey);
            keyHandle?.SetValue(key, value);
        }

        [CanBeNull]
        public static string Read(string key)
        {
            var keyHandle = BaseKey.OpenSubKey(SettingsKey);
            try
            {
                return keyHandle?.GetValue(key).ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}