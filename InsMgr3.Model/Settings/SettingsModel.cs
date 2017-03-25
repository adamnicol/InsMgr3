using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace InsMgr3.Model.Settings
{
    public class SettingsModel : ISettingsModel
    {
        private FileInfo ConfigFile => new FileInfo(
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
                    settings = LoadSettings();

                return settings;
            }
        }

        private ISettings LoadSettings()
        {
            if (ConfigFile.Exists)
            {
                try
                {
                    var json = File.ReadAllText(ConfigFile.FullName);
                    return JsonConvert.DeserializeObject<Settings>(json);
                }

                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }

            return new Settings();
        }

        public void SaveSettings()
        {
            if (settings != null)
            {
                try
                {
                    if (!ConfigFile.Directory.Exists)
                        ConfigFile.Directory.Create();

                    using (StreamWriter sw = ConfigFile.CreateText())
                    {
                        var json = JsonConvert.SerializeObject(settings);
                        sw.Write(json);
                    }
                }

                catch (Exception ex)
                {
                    log.Error(ex);
                }
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