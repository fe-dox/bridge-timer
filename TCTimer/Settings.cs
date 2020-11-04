using System;
using Microsoft.Win32;
using Utils.Annotations;

namespace TCTimer
{
    public class Settings
    {
        private static readonly RegistryKey BaseKey = Registry.CurrentUser;
        private const string SettingsKey = "SOFTWARE\\TC_TIMER\\SETTINGS";

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