using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DryIoc;

namespace InsMgr3.ViewModel.Services
{
    public class DialogService : IDialogService
    {
        private Dictionary<Type, Func<Window>> dialogs;
        private IResolver resolver;

        public DialogService(IResolver resolver)
        {
            this.dialogs = new Dictionary<Type, Func<Window>>();
            this.resolver = resolver;
        }

        public void Register<TViewModel>(Func<Window> instance)
        {
            dialogs.Add(typeof(TViewModel), instance);
        }

        public void Register<TViewModel>(Window instance)
        {
            dialogs.Add(typeof(TViewModel), () => instance);
        }

        public void Register<TViewModel, TWindow>() where TWindow : Window
        {
            dialogs.Add(typeof(TViewModel), Activator.CreateInstance<TWindow>);
        }

        public bool ShowDialog<T>(T dataContext)
        {
            Mouse.SetCursor(Cursors.Wait);

            Window window = dialogs[typeof(T)]();
            window.DataContext = dataContext;
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowInTaskbar = false;

            return window.ShowDialog() ?? false;
        }

        public bool ShowDialog<T>()
        {
            return ShowDialog(resolver.Resolve<T>());
        }
    }
}