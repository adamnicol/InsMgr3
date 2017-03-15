using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using InsMgr3.Common.Extensions;
using Image = System.Windows.Controls.Image;

namespace InsMgr3.Controls
{
    public class RichTextBoxEx : RichTextBox
    {
        private bool updating;

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
            if (!updating)
            {
                updating = true;
                UpdateEmoticons();
                RichText = new TextRange(Document.ContentStart, Document.ContentEnd).Text;
                updating = false;
            }
        }

        private Dictionary<string, Bitmap> emoticons = new Dictionary<string, Bitmap>()
        {
            { ":)", Properties.Resources.Emoticon_Smile },
            { ":(", Properties.Resources.Emoticon_Sad },
        };

        private void UpdateEmoticons()
        {
            foreach (var shortcut in emoticons.Keys)
            {
                TextRange range;
                while ((range = FindMatch(Document.ContentStart, shortcut)) != null)
                {
                    BitmapImage bitmap = emoticons[shortcut].ToBitmapImage();
                    var image = new Image()
                    {
                        Source = bitmap,
                        Width = bitmap.Width,
                    };

                    InsertEmoticon(range, image);
                }
            }
        }

        private TextRange FindMatch(TextPointer position, string text)
        {
            while (position != null)
            {
                if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = position.GetTextInRun(LogicalDirection.Forward);

                    int index = textRun.IndexOf(text);
                    if (index >= 0)
                    {
                        TextPointer start = position.GetPositionAtOffset(index);
                        TextPointer end = start.GetPositionAtOffset(text.Length);
                        return new TextRange(start, end);
                    }
                }

                position = position.GetNextContextPosition(LogicalDirection.Forward);
            }

            return null;
        }

        private void InsertEmoticon(TextRange range, Image image)
        {
            if (range.Start.Parent is Run)
            {
                var run = range.Start.Parent as Run;

                var runBefore = new Run(new TextRange(run.ContentStart, range.Start).Text);
                var runAfter = new Run(new TextRange(range.End, run.ContentEnd).Text);

                Inline container = new InlineUIContainer(image);

                range.Start.Paragraph.Inlines.InsertAfter(run, runBefore);
                range.Start.Paragraph.Inlines.InsertAfter(runBefore, container);
                range.Start.Paragraph.Inlines.InsertAfter(container, runAfter);
                range.Start.Paragraph.Inlines.Remove(run);

                CaretPosition = runAfter.ContentStart;
            }
        }
    }
}