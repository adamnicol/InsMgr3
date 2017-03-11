using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Xpf.Docking;
using InsMgr3.ViewModel.Commands;

namespace InsMgr3.ViewModel.Base
{
    public abstract class ChildViewModelBase : ViewModelBase, IChildViewModel, IMVVMDockingProperties
    {
        public string Caption { get; set; }

        public event EventHandler RequestClose;

        public ICommand CloseCommand => new DelegateCommand(OnRequestClose);

        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        string IMVVMDockingProperties.TargetName
        {
            get { return "DocumentsGroup"; }
            set { throw new NotImplementedException(); }
        }
    }
}