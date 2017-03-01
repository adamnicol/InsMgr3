using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using InsMgr3.Model.Settings;

namespace InsMgr3.Model.Configuration
{
    public static class Configure
    {
        public static void Resolver(IContainer container)
        {
            container.Register<ISettingsModel, SettingsModel>(Reuse.Singleton);
        }
    }
}