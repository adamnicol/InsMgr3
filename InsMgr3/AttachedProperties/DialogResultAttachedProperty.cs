using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InsMgr3.AttachedProperties
{
    /// <summary>
    /// Enables binding of a window's DialogResult to a property in the view model.
    /// </summary>
    public static class DialogResultProperty
    {
        public static readonly DependencyProperty DialogResult =
            DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(DialogResultProperty),
            new FrameworkPropertyMetadata(OnPropertyChanged));

        public static bool? GetDialogResult(DependencyObject obj)
        {
            return (bool?)obj.GetValue(DialogResult);
        }

        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResult, value);
        }

        private static void OnPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is Window window)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }
    }
}