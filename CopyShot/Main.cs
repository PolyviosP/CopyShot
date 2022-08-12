using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
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

        private Dictionary<string, object> Shorcut = new Dictionary<string, object>()
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
        };


        

        //#151719
        public Main()
        {
            InitializeComponent();
            mainform = this;
            rtb = richTextBox;
            ptB = pictureBox;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                StartCapture();
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                StartCapture();
            }
        }
        private void StartCapture()
        {
            ReturnShorcutKey();

            File.Delete(@".\Screenshots\Capture.jpg");
            File.Delete(@".\Screenshots\FinalCapture.jpg");
            //Photo.CaptureScreenshot();
            //DisplayImage FormImage = new DisplayImage();
            //FormImage.Show();
            
        }
        private void Main_Activated(object sender, EventArgs e)
        {
             
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
            pictureBox.Show();
            await Task.Run(() => Photo.ConvertImageToText(@".\Screenshots\FinalCapture.jpg"));
            pictureBox.Hide();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(@".\Screenshots\Capture.jpg");
            File.Delete(@".\Screenshots\FinalCapture.jpg");
        }
        
        private object ReturnShorcutKey()
        {
            Console.WriteLine(ShorcutComboBox.Text);
            Console.WriteLine(Shorcut[ShorcutComboBox.Text]);
            return Shorcut[ShorcutComboBox.Text];
        }
    }
}
