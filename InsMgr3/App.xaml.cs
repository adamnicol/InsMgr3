using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DryIoc;
using InsMgr3.ViewModel;
using InsMgr3.Configuration;

namespace InsMgr3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IResolver resolver = Configure.CreateResolver();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.DataContext = resolver.Resolve<VMMainWindow>();
            Current.MainWindow.Show();
        }
    }
}