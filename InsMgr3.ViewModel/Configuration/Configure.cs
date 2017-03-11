using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using InsMgr3.ViewModel.Dialogs;
using InsMgr3.ViewModel.Commands;
using InsMgr3.ViewModel.Services;

namespace InsMgr3.ViewModel.Configuration
{
    public static class Configure
    {
        public static void Resolver(IContainer container)
        {
            container.Register<VMConnectionWindow>();

            container.Register<ConnectCommand>(Reuse.Singleton);
            container.Register<DisconnectCommand>(Reuse.Singleton);
            container.Register<CloseCommand>(Reuse.Singleton);

            container.Register<IWaitService, WaitService>();

            Model.Configuration.Configure.Resolver(container);
        }
    }
}