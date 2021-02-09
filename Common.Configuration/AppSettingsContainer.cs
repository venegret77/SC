using Microsoft.Extensions.Configuration;
using System;

namespace Common.Configuration
{
    public class AppSettingsContainer
    {
        private IConfigurationRoot appSettings { get; set; }

        public AppSettingsContainer(IConfigurationRoot appSettings)
        {
            this.appSettings = appSettings;
        }

        public string this[string key]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentNullException(nameof(key));

                var value = appSettings[key];
                if (value == null)
                    throw new ApplicationException($"Значение '{key}' не найдено в файле конфигурации");

                return value;
            }
        }

        public bool Contains(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return false;
            }

            return appSettings[key] != null;
        }
    }
}
