using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsMgr3.ViewModel.EventArguments
{
    public class EmoticonEventArgs : EventArgs
    {
        public string Shortcut { get; private set; }

        public EmoticonEventArgs(string shortcut)
        {
            Shortcut = shortcut;
        }
    }
}