using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InsMgr3.ViewModel.Base
{
    public abstract class ViewModelBase : IViewModel
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void FirePropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected void SetField<T>(ref T field, T value, [CallerMemberName] string property = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                FirePropertyChanged(property);
            }
        }
    }
}