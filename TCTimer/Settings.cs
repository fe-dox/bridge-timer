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

        internal const string SettingsCustomCssFileRegister = "APPEARANCE_FILE_NAME";
        internal const string SettingsCustomCssStringRegister = "APPEARANCE_CUSTOM_CSS_STRING";
        internal const string SettingsLastFtpPathRegister = "LAST_FTP_PATH";
        internal const string SettingsLastFtpUsernameRegister = "LAST_FTP_USERNAME";
        internal const string SettingsLastFtpPasswordRegister = "LAST_FTP_PASSWORD";
        internal const string SettingsLanguageRegister = "PROGRAM_LANGUAGE";
    }
}