using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InsMgr3.ViewModel.Base;
using InsMgr3.ViewModel.Commands;
using InsMgr3.ViewModel.EventArguments;

namespace InsMgr3.ViewModel
{
    public class VMChatWindow : ChildViewModelBase
    {
        public string Message { get; set; }

        public ICommand SendCommand => new DelegateCommand(OnSendMessage);
        public ICommand EmoticonCommand => new DelegateCommand<string>(OnInsertEmoticon);

        public event EventHandler<EmoticonEventArgs> InsertEmoticon;

        private void OnSendMessage()
        {
        }

        private void OnInsertEmoticon(string shortcut)
        {
            InsertEmoticon?.Invoke(this, new EmoticonEventArgs(shortcut));
        }
    }
}