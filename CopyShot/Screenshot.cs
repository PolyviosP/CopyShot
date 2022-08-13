using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tesseract;

namespace CopyShot
{
    internal class Screenshot
    {
        public Dictionary<string, string> Language = new Dictionary<string, string>()
        {
            {"Afrikaans", "afr"},
            {"Amharic", "amh"},
            {"Arabic", "ara"},
            {"Assamese", "asm"},
            {"Azerbaijani", "aze"},
            {"Belarusian", "bel"},
            {"Bengali", "ben"},
            {"Tibetan", "bod"},
            {"Bosnian", "bos"},
            {"Breton", "bre"},
            {"Bulgarian", "bul"},
            {"Catalan", "cat"},
            {"Cebuano", "ceb"},
            {"Czech", "ces"},
            {"Chinese", "chi_tra"},
            {"Cherokee", "chr"},
            {"Corsican", "cos"},
            {"Welsh", "cym"},
            {"Danish", "dan"},
            {"German", "deu"},
            {"Dzongkha", "dzo"},
            {"Greek", "grc"},
            {"English", "fra"},
            {"Esperanto", "epo"},
            {"Estonian", "est"},
            {"Basque", "eus"},
            {"Faroese", "fao"},
            {"Persian", "fas"},
            {"Filipino", "fil"},
            {"Finnish", "fin"},
            {"French", "fra"},
            {"Western", "fry"},
            {"Scottish", "gla"},
            {"Irish", "gle"},
            {"Galician", "glg"},
            {"Gujarati", "guj"},
            {"Haitian", "hat"},
            {"Hebrew", "heb"},
            {"Hindi", "hin"},
            {"Croatian", "hrv"},
            {"Hungarian", "hun"},
            {"Armenian", "hye"},
            {"Inuktitut", "iku"},
            {"Indonesian", "ind"},
            {"Icelandic", "isl"},
            {"Italian", "ita"},
            {"Javanese", "jav"},
            {"Japanese", "jpn"},
            {"Kannada", "kan"},
            {"Georgian", "kat"},
            {"Kazakh", "kaz"},
            {"Central", "khm"},
            {"Kirghiz", "kir"},
            {"Kurmanji", "kmr"},
            {"Korean", "kor"},
            {"Kurdish", "kur"},
            {"Lao", "lao"},
            {"Latin", "lat"},
            {"Latvian", "lav"},
            {"Lithuanian", "lit"},
            {"Luxembourgish", "ltz"},
            {"Malayalam", "mal"},
            {"Marathi", "mar"},
            {"Macedonian", "mkd"},
            {"Maltese", "mlt"},
            {"Mongolian", "mon"},
            {"Maori", "mri"},
            {"Malay", "msa"},
            {"Burmese", "mya"},
            {"Nepali", "nep"},
            {"Dutch", "nld"},
            {"Norwegian", "nor"},
            {"Occitan", "oci"},
            {"Oriya", "ori"},
            {"Orientation", "osd"},
            {"Panjabi", "pan"},
            {"Polish", "pol"},
            {"Portuguese", "por"},
            {"Pushto", "pus"},
            {"Quechua", "que"},
            {"Romanian", "ron"},
            {"Russian", "rus"},
            {"Sanskrit", "san"},
            {"Sinhala", "sin"},
            {"Slovak", "slk"},
            {"Slovenian", "slv"},
            {"Sindhi", "snd"},
            {"Spanish", "spa"},
            {"Albanian", "sqi"},
            {"Serbian", "srp"},
            {"Sundanese", "sun"},
            {"Swahili", "swa"},
            {"Swedish", "swe"},
            {"Syriac", "syr"},
            {"Tamil", "tam"},
            {"Tatar", "tat"},
            {"Telugu", "tel"},
            {"Tajik", "tgk"},
            {"Tagalog", "tgl"},
            {"Thai", "tha"},
            {"Tigrinya", "tir"},
            {"Tonga", "ton"},
            {"Turkish", "tur"},
            {"Uighur", "uig"},
            {"Ukrainian", "ukr"},
            {"Urdu", "urd"},
            {"Uzbek", "uzb"},
            {"Vietnamese", "vie"},
            {"Yiddish", "yid"},
            {"Yoruba", "yor"}
        };
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
                captureBitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
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
                captureBitmap.Save(@".\Screenshots\Capture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public string ConvertImageToText(string path, string lan, string lan2)
        {
            try
            {
                using (var ocrengine = new TesseractEngine(@".\tessdata", Language[lan] + "+"+ Language[lan2], EngineMode.Default))
                {
                    var img = Pix.LoadFromFile(path);
                    var res = ocrengine.Process(img);
                    return res.GetText();
                }
            }
            catch (FileNotFoundException){ return ""; }
            catch 
            {
                MessageBox.Show("We can't convert the text!", "Copyshot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
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