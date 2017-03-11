using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using NLog;
using InsMgr3.Dialogs;
using InsMgr3.ViewModel;
using InsMgr3.ViewModel.Services;
using InsMgr3.ViewModel.Dialogs;

namespace InsMgr3.Configuration
{
    public static class Configure
    {
        public static IResolver CreateResolver()
        {
            var container = new Container();

            container.Register<VMMainWindow>(Reuse.Singleton);

            container.RegisterInstance<IResolver>(container);
            container.RegisterInstance<ILogger>(LogManager.GetCurrentClassLogger());
            container.RegisterInstance(CreateDialogService(container));

            ViewModel.Configuration.Configure.Resolver(container);

            return container;
        }

        private static IDialogService CreateDialogService(IResolver resolver)
        {
            var service = new DialogService(resolver);

            service.Register<VMConnectionWindow, ConnectionWindow>();

            return service;
        }
    }
}