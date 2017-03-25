using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
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
                RichText = GetText();
                updating = false;
            }
        }

        private Dictionary<string, Bitmap> emoticons = new Dictionary<string, Bitmap>()
        {
            { ":D",  Properties.Resources.Emoticon_BigSmile },
            { ":s",  Properties.Resources.Emoticon_Confused },
            { ":&",  Properties.Resources.Emoticon_Cool },
            { ":'(", Properties.Resources.Emoticon_Cry },
            { ":$",  Properties.Resources.Emoticon_Embarrassed },
            { "(l)", Properties.Resources.Emoticon_Laugh },
            { ":@",  Properties.Resources.Emoticon_Mad },
            { "(n)", Properties.Resources.Emoticon_Nuts },
            { ":|",  Properties.Resources.Emoticon_Oh },
            { ":(",  Properties.Resources.Emoticon_Sad },
            { ":x",  Properties.Resources.Emoticon_Sick },
            { ":)",  Properties.Resources.Emoticon_Smile },
            { ":^",  Properties.Resources.Emoticon_Suspicious },
            { ":p",  Properties.Resources.Emoticon_Tongue },
            { ":/",  Properties.Resources.Emoticon_Unsure },
            { ":%",  Properties.Resources.Emoticon_Weird },
            { ";)",  Properties.Resources.Emoticon_Wink },
        };

        private void UpdateEmoticons()
        {
            foreach (var emote in emoticons)
            {
                TextRange range;
                while ((range = FindMatch(Document.ContentStart, emote.Key)) != null)
                {
                    BitmapImage bitmap = emote.Value.ToBitmapImage();
                    var image = new Image()
                    {
                        Source = bitmap,
                        Width = bitmap.Width,
                        Tag = emote.Key,
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

        private string GetText()
        {
            var builder = new StringBuilder();

            foreach (Block block in Document.Blocks)
            {
                if (block is Paragraph p)
                {
                    foreach (Inline inline in p.Inlines)
                    {
                        if (inline is Run run)
                            builder.Append(run.Text);

                        else if (inline is InlineUIContainer container)
                        {
                            var image = container.Child as Image;
                            var emoticon = image.Tag?.ToString();
                            builder.Append(emoticon);
                        }
                    }
                }
            }

            return builder.ToString();
        }
    }
}