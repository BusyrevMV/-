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
    public class Camera
    {
        private Object locker = new Object();
        private VideoCapture capture = null;
        private bool updateBitmap = false;
        private bool updateMat = false;
        private Mat _frame;
        private Mat frame;

        public string url;
        public string login;
        public string pass;
        public Rectangle rectangle = new Rectangle(0, 0, 10000, 10000);
        public bool oneNumber = true;
        public int direction = 0;
        public string camName;

        public int Connect(string url, string login = "", string pass = "")
        {
            if (url.IndexOf("://") < 1)
            {
                url = login + ":" + pass + "@" + url;
            }
            else
            {
                url = url.Insert(url.IndexOf("://") + 3, login + ":" + pass + "@");
            }

            this.url = url;
            this.login = login;
            this.pass = pass;

            try
            {
                capture = new VideoCapture(url);                
                capture.ImageGrabbed += ProcessFrame;
                _frame = new Mat();
                capture.Start();
               
            }
            catch (NullReferenceException excpt)
            {
                //MessageBox.Show(excpt.Message);
                return 0;
            }

            return 1;
        }

        public int Reconnect()
        {          
            try
            {
                capture = new VideoCapture(url);
                capture.ImageGrabbed += ProcessFrame;
                _frame = new Mat();
                capture.Start();

            }
            catch (NullReferenceException excpt)
            {
                //MessageBox.Show(excpt.Message);
                return 0;
            }

            return 1;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero)
            {                
                capture.Retrieve(frame, 0);
                SetFrame(frame);
            }
        }

        public void SetFrame(Mat value)
        {
            lock (locker)
            {
                _frame = value.Clone();
                updateBitmap = true;
                updateMat = true;
    }
        }

        public void Disconnect()
        {
            capture.Stop();
            if (capture != null)
                capture.Dispose();
        }

        public Bitmap GetBitmap()
        {
            lock (locker)
            {
                updateBitmap = false;
                return _frame.Bitmap;
            }
        }

        public Mat GetMat()
        {
            lock (locker)
            {
                updateMat = false;
                return _frame;
            }
        }

        public bool GetUpdateMat()
        {                
            return updateMat;            
        }

        public bool GetUpdateBitmap()
        {
            return updateBitmap;
        }
    }
}
