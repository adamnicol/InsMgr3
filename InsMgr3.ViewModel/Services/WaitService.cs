using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace InsMgr3.ViewModel.Services
{
    public class WaitService : IWaitService
    {
        public bool IsBusy { get; private set; }

        public void SetBusyState()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Mouse.OverrideCursor = Cursors.Wait;

                new DispatcherTimer(
                    TimeSpan.FromSeconds(0), 
                    DispatcherPriority.ApplicationIdle, 
                    DispatcherTimer_Tick, 
                    Application.Current.Dispatcher);
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            var timer = sender as DispatcherTimer;

            if (timer != null)
            {
                IsBusy = false;
                Mouse.OverrideCursor = null;
                timer.Stop();
            }
        }
    }
}