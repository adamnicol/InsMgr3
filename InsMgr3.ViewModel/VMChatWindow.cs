using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InsMgr3.ViewModel.Base;
using InsMgr3.ViewModel.Commands;

namespace InsMgr3.ViewModel
{
    public class VMChatWindow : ChildViewModelBase
    {
        public string Message { get; set; }

        public ICommand SendCommand => new DelegateCommand(OnSendMessage);

        private void OnSendMessage()
        {
        }
    }
}