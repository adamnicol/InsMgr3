using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InsMgr3.ViewModel.Base;
using InsMgr3.ViewModel.Commands;
using PropertyChanged;
using InsMgr3.Model.Settings;

namespace InsMgr3.ViewModel.Dialogs
{
    [ImplementPropertyChanged]
    public class VMConnectionWindow : ViewModelBase
    {
        public string AddressOrHostname { get; set; }
        public string PortNumber { get; set; }
        public string Password { get; set; }
        public string ChatName { get; set; }
        public bool? DialogResult { get; set; }

        public ICommand ConnectCommand => new DelegateCommand(Connect);

        public VMConnectionWindow(ISettingsModel sm)
        {
            ChatName = sm.Settings.ChatName;
        }

        private void Connect()
        {
            DialogResult = true;
        }
    }
}