using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InsMgr3.ViewModel.Services
{
    public interface IDialogService
    {
        /// <summary>
        /// Registers a dialog with the dialog service.
        /// </summary>
        void Register<TViewModel>(Func<Window> instance);

        /// <summary>
        /// Registers a dialog with the dialog service.
        /// </summary>
        void Register<TViewModel>(Window instance);

        /// <summary>
        /// Registers a dialog with the dialog service.
        /// </summary>
        void Register<TViewModel, TWindow>() where TWindow : Window;

        /// <summary>
        /// Shows a modal dialog using the specified data context.
        /// </summary>
        bool ShowDialog<T>();

        /// <summary>
        /// Shows a modal dialog using the specified data context.
        /// </summary>
        bool ShowDialog<T>(T dataContext);
    }
}