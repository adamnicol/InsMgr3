using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InsMgr3.ViewModel.Commands;

namespace InsMgr3.ViewModel.Base
{
    public abstract class ChildViewModelBase : ViewModelBase, IChildViewModel
    {
        #region IChildViewModel Members

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set { SetField(ref _caption, value); }
        }

        public event EventHandler RequestClose;

        public ICommand CloseCommand => new DelegateCommand(OnRequestClose);

        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}