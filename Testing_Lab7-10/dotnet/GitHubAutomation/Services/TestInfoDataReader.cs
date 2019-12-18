using System;
using System.Configuration;

namespace Framework.Services
{
    public static class TestDataReader
    {
        static Configuration ConfigFile
        {
            get
            {
                string file = "TestInfoConfig";
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
