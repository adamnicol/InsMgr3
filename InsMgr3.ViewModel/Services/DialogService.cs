using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InsMgr3.ViewModel.Services
{
    public class DialogService : IDialogService
    {
        private readonly Dictionary<Type, Func<Window>> dialogs;

        public DialogService()
        {
            dialogs = new Dictionary<Type, Func<Window>>();
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

        public bool? ShowDialog<T>(T dataContext)
        {
            Mouse.SetCursor(Cursors.Wait);

            Window window = dialogs[typeof(T)]();
            window.DataContext = dataContext;
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowInTaskbar = false;

            return window.ShowDialog();
        }
    }
}