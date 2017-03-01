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

        private IResolver resolver;
        private IDialogService dialogService;        

        public ConnectCommand(IResolver resolver, IDialogService ds)
        {
            this.resolver = resolver;
            this.dialogService = ds;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var viewModel = resolver.Resolve<VMConnectionWindow>();

            if (dialogService.ShowDialog(viewModel) == true)
            {

            }
        }
    }
}