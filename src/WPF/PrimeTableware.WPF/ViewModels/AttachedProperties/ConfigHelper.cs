using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTableware.WPF.ViewModels.AttachedProperties
{
    using System;
    using System.Configuration;

    public static class ConfigHelper
    {
        public static string GetConfigValue(string key)
        {
            try
            {
                var value = ConfigurationManager.AppSettings[key];
                return value ?? string.Empty;
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine($"Ошибка распознавания настройки приложения: {ex.Message}");
                return string.Empty;
            }
        }

        public static void SaveConfigValue(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        public static void DeleteConfigValue(string key)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove(key);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine($"Ошибка удаления настройки приложения: {ex.Message}");
            }
        }
    }
}