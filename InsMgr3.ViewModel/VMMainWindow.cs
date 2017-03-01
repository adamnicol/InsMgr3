using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using InsMgr3.ViewModel.Base;
using InsMgr3.ViewModel.Services;
using InsMgr3.ViewModel.Commands;
using DryIoc;

namespace InsMgr3.ViewModel
{
    public class VMMainWindow : ViewModelBase
    {
        private IResolver resolver;
        private IDialogService dialogService;

        public ObservableCollection<IChildViewModel> Views { get; set; }

        public ICommand ConnectCommand => resolver.Resolve<ConnectCommand>();
        public ICommand DisconnectCommand => resolver.Resolve<DisconnectCommand>();
        public ICommand CloseCommand => resolver.Resolve<CloseCommand>();

        public VMMainWindow(IResolver resolver, IDialogService ds)
        {
            this.resolver = resolver;
            this.dialogService = ds;

            Views = new ObservableCollection<IChildViewModel>();

            AddChildWindow(new VMChatWindow() { Caption = "Tab 1" });
            AddChildWindow(new VMChatWindow() { Caption = "Tab 2" });
            AddChildWindow(new VMChatWindow() { Caption = "Tab 3" });
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