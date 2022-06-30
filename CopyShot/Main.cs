using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CopyShot
{
    public partial class Main : Form
    {
        Screenshot photo = new Screenshot();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {  
                photo.CaptureScreenshot();
                DisplayImage FormImage = new DisplayImage();
                FormImage.Show();
            }
        }
    }
}
