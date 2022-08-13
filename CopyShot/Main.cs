using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyShot
{
    public partial class Main : Form
    {
        Screenshot Photo = new Screenshot();
        public static Main mainform;
        public RichTextBox rtb;
        public PictureBox ptB;
        public ComboBox lan;
        public ComboBox lan2;

        /*private Dictionary<string, object> Shorcut = new Dictionary<string, object>()
        {
            {"F1", Keys.F1},
            {"F2", Keys.F2},
            {"F3", Keys.F3},
            {"F4", Keys.F4},
            {"F5", Keys.F5},
            {"F6", Keys.F6},
            {"F7", Keys.F7},
            {"F8", Keys.F8},
            {"F9", Keys.F9},
            {"F10", Keys.F10},
            {"F11", Keys.F11},
            {"F12", Keys.F12},
            {"Tab", Keys.Tab},
            {"Caps lock", Keys.CapsLock},
            {"Shift", Keys.Shift},
            {"Ctrl", Keys.Control},
            {"Alt", Keys.Alt},
            {"Spacebar", Keys.Space},
            {"Delete", Keys.Delete},
            {"Prt Scrn", Keys.PrintScreen},
            {"Scroll Lock", Keys.F12},
            {"Pause", Keys.Pause},
            {"Insert", Keys.Insert},
            {"Home", Keys.Home},
            {"Page up", Keys.PageUp},
            {"Page down", Keys.PageDown},
            {"End", Keys.End}
        };*/

        private Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //#151719
        public Main()
        {
            InitializeComponent();
            mainform = this;
            rtb = richTextBox;
            ptB = pictureBox;
            lan = LanguageComboBox;
            lan2 = SecondLanguageComboBox;

            LanguageComboBox.Text = config.AppSettings.Settings["FirstLanguage"].Value;
            SecondLanguageComboBox.Text = config.AppSettings.Settings["SecondLanguage"].Value;
            ShorcutComboBox.Text = config.AppSettings.Settings["ShorcutKey"].Value;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == ConvertToEnum<Keys>(ShorcutComboBox.Text))
                {
                    StartCapture();
                }
            }
            catch { }
        }

        private void StartCapture()
        {
            Photo.CaptureScreenshot();
            DisplayImage FormImage = new DisplayImage();
            FormImage.Show();
        }

        private void TakeShotButton_Click(object sender, EventArgs e)
        {
            StartCapture();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (richTextBox.Text != "")
            {
                Clipboard.SetText(richTextBox.Text);
                MessageBox.Show("Τext copied to clipboard!", "Copyshot", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void ReadButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(@".\Screenshots\FinalCapture.jpg"))
            {
                string l = LanguageComboBox.Text;
                string l2 = SecondLanguageComboBox.Text;
                string text = "";

                pictureBox.Show();
                await Task.Run(() => text = Photo.ConvertImageToText(@".\Screenshots\FinalCapture.jpg", l, l2));
                pictureBox.Hide();
                richTextBox.Text = text;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            config.AppSettings.Settings.Remove("FirstLanguage");
            config.AppSettings.Settings.Remove("SecondLanguage");
            config.AppSettings.Settings.Remove("ShorcutKey");

            config.AppSettings.Settings.Add("FirstLanguage", LanguageComboBox.Text);
            config.AppSettings.Settings.Add("SecondLanguage", SecondLanguageComboBox.Text);
            config.AppSettings.Settings.Add("ShorcutKey", ShorcutComboBox.Text);

            config.Save(ConfigurationSaveMode.Modified);

            File.Delete(@".\Screenshots\Capture.jpg");
            File.Delete(@".\Screenshots\FinalCapture.jpg");
        }
        public T ConvertToEnum<T>(object o)
        {
            T enumVal = (T)Enum.Parse(typeof(T), o.ToString());
            return enumVal;
        }
    }
}
