using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InsMgr3.ViewModel.Base;
using InsMgr3.ViewModel.Commands;
using InsMgr3.Model.Settings;
using PropertyChanged;

namespace InsMgr3.ViewModel.Dialogs
{
    [ImplementPropertyChanged]
    public class VMConnectionWindow : ViewModelBase
    {
        private VMMainWindow mainWindow;

        public string AddressOrHostname { get; set; }
        public string PortNumber { get; set; }
        public string Password { get; set; }
        public string ChatName { get; set; }
        public bool? DialogResult { get; set; }

        public ICommand ConnectCommand => new DelegateCommand(Connect);

        public VMConnectionWindow(VMMainWindow mainWindow, ISettingsModel sm)
        {
            this.mainWindow = mainWindow;

            ChatName = sm.Settings.ChatName;
        }

        private void Connect()
        {
            mainWindow.AddChildWindow(new VMChatWindow() { Caption = "Chat Window" });

            DialogResult = true;
        }
    }
}