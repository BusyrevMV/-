using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Паркинг
{
    public partial class Form1 : Form
    {
        private Camera camera;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            camera = new Camera();
            camera.Connect(textBox1.Text, textBox2.Text, textBox3.Text);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = camera.GetBitmap();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberDetector num = new NumberDetector(null);
            Mat img = CvInvoke.Imread("C:\\Users\\Caxap\\Desktop\\Новая папка\\0.jpg");
            UMat uImg = img.GetUMat(AccessType.ReadWrite);
            //num.Detector(uImg);
        }
    }
}
