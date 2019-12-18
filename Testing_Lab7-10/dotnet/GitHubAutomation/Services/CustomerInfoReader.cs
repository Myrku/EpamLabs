using System;
using System.Configuration;

namespace Framework.Services
{
    class CustomerInfoReader
    {
        static Configuration ConfigFile
        {
            get
            {
                string file = "CustomerInfo";
                int index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var configeMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index) +
                    @"ConfigFiles\" + file + ".config"
                };
                Logger.Log.Debug("CardInfoReader get data");
                return ConfigurationManager.OpenMappedExeConfiguration(configeMap, ConfigurationUserLevel.None);
            }
        }

        public static string GetData(string key)
        {
            return ConfigFile.AppSettings.Settings[key]?.Value;
        }
    }
}
