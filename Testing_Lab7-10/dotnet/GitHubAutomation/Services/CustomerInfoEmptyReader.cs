using System;
using System.Configuration;

namespace Framework.Services
{
    class CustomerInfoEmptyReader
    {
        static Configuration ConfigFile
        {
            get
            {
                string file = "CustomerInfoEmpty";
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

        public static KeyValueConfigurationElement GetData(string key)
        {
            return ConfigFile.AppSettings.Settings[key];

        }


    }
}
