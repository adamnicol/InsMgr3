using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using InsMgr3.ViewModel.Interfaces;
using DevExpress.Mvvm;

namespace InsMgr3.ViewModel.Commands
{
    public class CloseCommand : CommandBase<IClosable>
    {
        public override void Execute(IClosable closeable)
        {
            closeable.Close();
        }
    }
}