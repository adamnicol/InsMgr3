using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Docking;
using InsMgr3.ViewModel.Base;

namespace InsMgr3.ViewModel
{
    public class VMChatWindow : ChildViewModelBase, IMVVMDockingProperties
    {
        string IMVVMDockingProperties.TargetName
        {
            get { return "DocumentsGroup"; }
            set { throw new NotImplementedException(); }
        }
    }
}