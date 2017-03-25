using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InsMgr3.ViewModel;
using InsMgr3.ViewModel.EventArguments;

namespace InsMgr3
{
    /// <summary>
    /// Interaction logic for ChatWindowView.xaml
    /// </summary>
    public partial class ChatWindow : UserControl
    {
        public ChatWindow()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var context = e.NewValue as VMChatWindow;
                context.InsertEmoticon += OnInsertEmoticon;
            }
        }

        private void OnInsertEmoticon(object sender, EmoticonEventArgs e)
        {
            messageWindow.CaretPosition.InsertTextInRun(e.Shortcut);
        }
    }
}