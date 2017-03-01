using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InsMgr3.ViewModel.Commands
{
    public class DelegateCommand : ICommand
    {
        private Predicate<object> _canAction;
        private Action _action;

        public DelegateCommand(Predicate<object> canAction, Action action)
        {
            _canAction = canAction;
            _action = action;
        }

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canAction == null || _canAction(parameter);
        }

        public void Execute(object parameters)
        {
            _action();
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private Predicate<T> _canAction;
        private Action<T> _action;
 
        public DelegateCommand(Predicate<T> canAction, Action<T> action)
        {
            _canAction = canAction;
            _action = action;
        }

        public DelegateCommand(Action<T> action) : this(null, action)
        {
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canAction == null || _canAction((T)parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        public void Execute(T parameter)
        {
            _action(parameter);
        }
    }
}