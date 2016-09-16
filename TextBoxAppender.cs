using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CameraTest
{
    public class TextBoxAppender : AppenderSkeleton
    {
        private RichTextBox _textBox;
        public RichTextBox AppenderTextBox
        {
            get
            {
                return _textBox;
            }
            set
            {
                _textBox = value;
            }
        }
        public string FormName { get; set; }
        public string TextBoxName { get; set; }

        private Control FindControlRecursive(Control root, string textBoxName)
        {
            if (root.Name == textBoxName) return root;
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, textBoxName);
                if (t != null) return t;
            }
            return null;
        }

        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            if (_textBox == null)
            {
                if (String.IsNullOrEmpty(FormName) ||
                    String.IsNullOrEmpty(TextBoxName))
                    return;

                Form form = Application.OpenForms[FormName];
                if (form == null)
                    return;

                _textBox = (RichTextBox)FindControlRecursive(form, TextBoxName);
                if (_textBox == null)
                    return;

                form.FormClosing += (s, e) => _textBox = null;
            }

            System.Drawing.Color text_color;
            switch (loggingEvent.Level.DisplayName.ToUpper())
            {
                case "FATAL":
                    text_color = System.Drawing.Color.DarkRed;
                    break;

                case "ERROR":
                    text_color = System.Drawing.Color.Red;
                    break;

                case "WARN":
                    text_color = System.Drawing.Color.DarkOrange;
                    break;

                case "INFO":
                    text_color = System.Drawing.Color.Teal;
                    break;

                case "DEBUG":
                    text_color = System.Drawing.Color.Green;
                    break;

                default:
                    text_color = System.Drawing.Color.Black;
                    break;
            }

            _textBox.BeginInvoke((MethodInvoker)delegate
            {
                _textBox.SelectionColor = text_color;
                _textBox.AppendText(RenderLoggingEvent(loggingEvent));
            });
        }
    }

}
