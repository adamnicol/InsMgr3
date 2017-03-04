using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsMgr3.Model.Helpers;
using NLog;

namespace InsMgr3.Model.Settings
{
    public class SettingsModel : ISettingsModel
    {
        private FileInfo ConfigPath => new FileInfo(
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\InsMgr3\settings.json");

        private ILogger log;

        public SettingsModel(ILogger logger)
        {
            log = logger;
        }

        private ISettings settings = null;

        public ISettings Settings
        {
            get
            {
                if (settings == null)
                    settings = GetSettings();

                return settings;
            }
        }

        private ISettings GetSettings()
        {
            try
            {
                return Serializer.Deserialize<Settings>(ConfigPath) ?? new Settings();
            }

            catch (Exception ex)
            {
                log.Error(ex);
                return new Settings();
            }
        }

        public void SaveSettings()
        {
            try
            {
                Serializer.Serialize(Settings, ConfigPath);
            }

            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void ResetDefaults()
        {
            settings = new Settings();
            SaveSettings();
            log.Info("Restored default settings.");
        }
    }
}