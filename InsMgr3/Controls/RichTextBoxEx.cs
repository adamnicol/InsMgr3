using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace InsMgr3.Controls
{
    public class RichTextBoxEx : RichTextBox
    {
        public static readonly DependencyProperty RichTextProperty = 
            DependencyProperty.Register(
                nameof(RichText), 
                typeof(string), 
                typeof(RichTextBoxEx),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string RichText
        {
            get { return (string)GetValue(RichTextProperty); }
            set { SetValue(RichTextProperty, value); }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            RichText = new TextRange(Document.ContentStart, Document.ContentEnd).Text;
        }
    }
}