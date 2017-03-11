using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InsMgr3.ViewModel.Base
{
    /// <summary>
    /// View model for MDI child windows.
    /// </summary>
    public interface IChildViewModel : IViewModel
    {        
        /// <summary>
        /// The caption displayed in the tab page header.
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// Whether the child window currently has focus.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Allows binding of the tab page close button.
        /// </summary>
        ICommand CloseCommand { get; }

        /// <summary>
        /// Event that gets fired when the child window is closed.
        /// </summary>
        event EventHandler RequestClose;
    }
}