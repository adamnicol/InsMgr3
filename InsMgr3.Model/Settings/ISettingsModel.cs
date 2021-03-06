﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsMgr3.Model.Settings
{
    public interface ISettingsModel
    {
        ISettings Settings { get; }

        void SaveSettings();
        void ResetDefaults();
    }
}