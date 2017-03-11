using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using InsMgr3.ViewModel.Base;
using InsMgr3.ViewModel.Commands;
using DryIoc;

namespace InsMgr3.ViewModel
{
    public class VMMainWindow : ViewModelBase
    {
        private IResolver resolver;

        public ObservableCollection<IChildViewModel> Views { get; private set; }

        public ICommand ConnectCommand => resolver.Resolve<ConnectCommand>();
        public ICommand DisconnectCommand => resolver.Resolve<DisconnectCommand>();
        public ICommand CloseCommand => resolver.Resolve<CloseCommand>();

        public VMMainWindow(IResolver resolver)
        {
            this.resolver = resolver;

            Views = new ObservableCollection<IChildViewModel>();
        }

        public void AddChildWindow(IChildViewModel window)
        {
            window.RequestClose += OnChildRequestClose;
           
            Views.Add(window);
        }

        private void OnChildRequestClose(object sender, EventArgs e)
        {
            Views.Remove((IChildViewModel)sender);
        }
    }
}