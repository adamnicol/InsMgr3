using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InsMgr3.ViewModel.Services;
using InsMgr3.ViewModel.Dialogs;
using DryIoc;

namespace InsMgr3.ViewModel.Commands
{
    public class ConnectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private VMMainWindow mainWindow;
        private IResolver resolver;
        private IDialogService dialogService;
        private IWaitService waitService;

        public ConnectCommand(VMMainWindow mw, IResolver rs, IDialogService ds, IWaitService ws)
        {
            mainWindow = mw;
            resolver = rs;
            dialogService = ds;
            waitService = ws;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var vm = resolver.Resolve<VMConnectionWindow>();

            if (dialogService.ShowDialog(vm))
            {
                waitService.SetBusyState();
                mainWindow.AddChildWindow(new VMChatWindow() { Caption = "Chat Window" });
            }
        }
    }
}