using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InsMgr3.ViewModel.Commands
{
    public class DisconnectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
        }
    }
}