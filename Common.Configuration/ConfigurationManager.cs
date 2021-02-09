using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Common.Configuration
{
    public static class ConfigurationManager
    {
        public static AppSettingsContainer AppSettings { get; private set; }

        static ConfigurationManager()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                AppSettings = new AppSettingsContainer(builder.Build());
            }
            catch (Exception exception)
            {
                throw new ApplicationException("Не удалось прочитать appsettings.json", exception);
            }
        }
    }
}
