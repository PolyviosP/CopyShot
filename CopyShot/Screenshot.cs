using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IronOcr;

namespace CopyShot
{
    internal class Screenshot
    {
        public void CaptureScreenshotBox(string path, int x, int y, int width, int height)
        {
            try
            {
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(width, height, PixelFormat.Format64bppArgb);
                //capture our Current Screen
                Rectangle captureRectangle = new Rectangle(x, y, width, height);
                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                //Saving the Image File (I am here Saving it in My E drive).
                captureBitmap.Save(path, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public Size GetResolution()
        {
            return GetDisplayResolution();
        }

        public void CaptureScreenshot()
        {
            try
            {
                var size = GetDisplayResolution();
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format64bppArgb);
                //capture our Current Screen
                Rectangle captureRectangle = new Rectangle(0, 0, size.Width, size.Height);
                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                //Saving the Image File (I am here Saving it in My E drive).
                captureBitmap.Save(@".\Screenshots\Capture.jpg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public string ConvertImageToText(string path)
        {
            string ImgText = "";
            try
            {
                var Ocr = new IronTesseract();
                using (var Input = new OcrInput(path))
                {
                    //Input.Deskew();
                    Ocr.Language = OcrLanguage.GreekBest;
                    Ocr.AddSecondaryLanguage(OcrLanguage.EnglishBest);
                    var Text = Ocr.Read(Input);
                    ImgText = Text.Text;
                    return ImgText;
                }
            }
            catch (FileNotFoundException){ return ImgText; }
            catch 
            {
                MessageBox.Show("We can't convert the text!", "Copyshot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ImgText;
            }
        }


        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117
        }

        public static double GetWindowsScreenScalingFactor(bool percentage = true)
        {
            //Create Graphics object from the current windows handle
            Graphics GraphicsObject = Graphics.FromHwnd(IntPtr.Zero);
            //Get Handle to the device context associated with this Graphics object
            IntPtr DeviceContextHandle = GraphicsObject.GetHdc();
            //Call GetDeviceCaps with the Handle to retrieve the Screen Height
            int LogicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.DESKTOPVERTRES);
            //Divide the Screen Heights to get the scaling factor and round it to two decimals
            double ScreenScalingFactor = Math.Round(PhysicalScreenHeight / (double)LogicalScreenHeight, 2);
            //If requested as percentage - convert it
            if (percentage)
            {
                ScreenScalingFactor *= 100.0;
            }
            //Release the Handle and Dispose of the GraphicsObject object
            GraphicsObject.ReleaseHdc(DeviceContextHandle);
            GraphicsObject.Dispose();
            //Return the Scaling Factor
            return ScreenScalingFactor;
        }

        public static Size GetDisplayResolution()
        {
            var sf = GetWindowsScreenScalingFactor(false);
            var screenWidth = Screen.PrimaryScreen.Bounds.Width * sf;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height * sf;
            return new Size((int)screenWidth, (int)screenHeight);
        }
    }    
}

