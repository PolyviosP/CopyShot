using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyShot
{
    public partial class DisplayImage : Form
    {

        Screenshot Photo = new Screenshot();

        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));//128, 72, 145, 220
        private Brush FilterBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));

        public DisplayImage()
        {
            InitializeComponent();
        }

        private void DisplayImage_Activated(object sender, EventArgs e)
        {
            pictureBox.Image = Image.FromFile(@".\Screenshots\Capture.jpg");
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            RectStartPoint = e.Location;
            Invalidate();
        }
        
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));

            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {  
            EnableFilter(sender, e);
            if (pictureBox.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillRectangle(selectionBrush, Rect); 
                }
            }
        }

        private void EnableFilter(object sender, PaintEventArgs e)
        {
            var size = Photo.GetResolution();
            Rectangle Filter = new Rectangle(0, 0, size.Width, size.Height);
            e.Graphics.FillRectangle(FilterBrush, Filter);
            
            pictureBox.Invalidate();
        }

        private async void DisplayImage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Hide();
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
                //File.Delete(@".\Screenshots\Capture.jpg");
                this.Dispose();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                string text = "";
                string lan = Main.mainform.lan.Text;
                string lan2 = Main.mainform.lan2.Text;
                Main.mainform.ptB.Show();
                this.Hide();

                await Task.Run(() => 
                { 
                    Photo.CaptureScreenshotBox(@".\Screenshots\FinalCapture.jpg", Rect.Location.X, Rect.Location.Y, Rect.Size.Width, Rect.Size.Height);
                    text = Photo.ConvertImageToText(@".\Screenshots\FinalCapture.jpg", lan, lan2);
                });

                //File.Delete(@".\Screenshots\Capture.jpg");
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
                this.Dispose();
                Main.mainform.rtb.Text = text;
                Main.mainform.ptB.Hide();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Rect.Contains(e.Location))
                {
                    //Console.WriteLine("Right click");
                }
                
            }
        }
    }
}
