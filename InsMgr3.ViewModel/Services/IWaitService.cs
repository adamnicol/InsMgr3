using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsMgr3.ViewModel.Services
{
    public interface IWaitService
    {
        /// <summary>
        /// Indicates the start of a long running operation.
        /// </summary>
        void SetBusyState();

        /// <summary>
        /// Indicates whether the program is in the busy state.
        /// </summary>
        bool IsBusy { get; }
    }
}