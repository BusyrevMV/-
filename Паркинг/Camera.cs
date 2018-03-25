using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace Паркинг
{    
    class Camera
    {
        static string magaz = "http://95.161.181.204:80/mjpg/video.mjpg?COUNTER";
        private Object locker = new Object();
        private VideoCapture capture = null;
        private bool updateFrame = false;
        private Mat _frame;
        private Mat frame;

        public int Connect(string url, string login = "", string pass = "")
        {
            if (url.IndexOf("://") < 1)
            {
                return 1;
            }

            url = url.Insert(url.IndexOf("://") + 3, login + ":" + pass + "@"); 
            try
            {
                capture = new VideoCapture(url);
                capture.ImageGrabbed += ProcessFrame;
                _frame = new Mat();
                capture.Start();
               
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return 0;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero)
            {                
                capture.Retrieve(_frame, 0);
                SetFrame(_frame);
            }
        }

        public void SetFrame(Mat value)
        {
            lock (locker)
            {
                frame = value.Clone();
                updateFrame = true;
            }
        }

        public void Disconnect()
        {
            capture.Stop();
            if (capture != null)
                capture.Dispose();
        }

        public Bitmap GetFrame()
        {
            lock (locker)
            {
                updateFrame = false;
                return _frame.Bitmap;
            }
        }
    }
}
