using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsMgr3.Model.Helpers;

namespace InsMgr3.Model.Settings
{
    public class SettingsModel : ISettingsModel
    {
        private string MyDocuments => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string ConfigPath => $@"{MyDocuments}\InsMgr3\settings.json";

        private Settings settings = null;

        public Settings GetSettings()
        {
            try
            {
                if (settings == null)
                    settings = SerializationHelper.Deserialize<Settings>(ConfigPath) ?? new Settings();

                return settings;
            }
            catch (Exception ex)
            {
                settings = new Settings();
                return settings;
            }
        }

        public void SaveSettings()
        {
            try
            {
                SerializationHelper.Serialize(settings ?? new Settings(), ConfigPath);
            }
            catch (Exception)
            {
                //Write to error log.
            }
        }

        public void ResetDefaults()
        {
            settings = new Settings();
        }
    }
}