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
    public partial class WinFormMain : Form
    {
        private ParkingControl cameraControl;

        private List<Camera> camList = new List<Camera>();
        private List<PictureBox> pictureList = new List<PictureBox>();
        private List<Label> labelList = new List<Label>();
        private List<Number> numList = new List<Number>();
        private User user;
        
        public WinFormMain(User user)
        {
            InitializeComponent();
            pictureList.Add(pictureBox1);
            this.user = user;
        }                

        private void WinFormMain_Load(object sender, EventArgs e)
        {
            cameraControl = new ParkingControl();
            int err = cameraControl.CameraControlCreate(user);
            cameraControl.NewNotyfNumber += NewNotyfNumber;
            if (err >= 8)
            {
                err -= 8;
                MessageBox.Show("Уведомления через ВКонтакте недоступно, авторизоваться не удалось!", "Предупреждение!");
            }

            if (err >= 4)
            {
                err -= 4;
                MessageBox.Show("Шаблоны номерных знаков не найдены!", "Предупреждение!");
            }

            if (err == 2)
            {                
                MessageBox.Show("Настройки камер отсутствуют!", "Предупреждение!");
            }

            for (int i = 0; i < cameraControl.GetCameras().Count; i++)
            {
                camList.Add(cameraControl.GetCameras()[i]);
            }

            for (int i = 0; i < camList.Count - 1; i++)
            {
                pictureList.Add(new PictureBox());
                pictureList.Last().Location = new Point(3 + 352 * i, 23);
                pictureList.Last().Name = "PictureBox" + (i + 1).ToString();
                pictureList.Last().Size = new Size(352, 198);
                pictureList.Last().SizeMode = PictureBoxSizeMode.StretchImage;
                pictureList.Last().DoubleClick += pictureBox_DoubleClick;
                panel3.Controls.Add(pictureList.Last());

                labelList.Add(new Label());
                labelList.Last().Location = new Point(3 + 352 * i, 7);
                labelList.Last().Name = "Label" + (i + 1).ToString();
                labelList.Last().Size = new Size(35, 13);
                labelList.Last().AutoSize = true;
                labelList.Last().Text = camList[i + 1].camName;
                panel3.Controls.Add(labelList.Last());
            }

            timer1.Enabled = true;
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            int indx = pictureList.IndexOf((PictureBox)sender);
            if (indx <= 0)
            {
                return;
            }

            lock (camList)
            {
                Camera cam = camList[indx];
                camList[indx] = camList[0];
                camList[0] = cam;
                labelList[indx - 1].Text = cam.camName;
            }            
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new WinFormSettings(camList)).Show();
        }

        private async void UpdateCam(PictureBox pictureBox, Camera camera)
        {
            if (camera.GetUpdateBitmap())
            {
                pictureBox.Image = camera.GetBitmap();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < pictureList.Count; i++)
            {
                lock (camList)
                {
                    UpdateCam(pictureList[i], camList[i]);
                }
            }
        }

        private void NewNotyfNumber(Number number, HistoryTransit info)
        {
            numList.Add(number);
            if (numList.Count > 30)
            {
                numList.RemoveAt(0);
                listBox1.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.RemoveAt(0);
                });
            }

            listBox1.Invoke((MethodInvoker)delegate
            {                                
                switch (number.direction)
                {
                    case 1:
                        {
                            listBox1.Items.Add(number.accuracy < 1 ? "Требуется подтверждение! " : "" +  number.text + " / Выъезд / " + DateTime.Now.ToShortTimeString());
                            break;
                        }
                    case -1:
                        {
                            listBox1.Items.Add(number.accuracy < 1 ? "Требуется подтверждение! " : "" + number.text + " / Въезд / " + DateTime.Now.ToShortTimeString());
                            break;
                        }
                    default:
                        {
                            listBox1.Items.Add(number.accuracy < 1 ? "Требуется подтверждение! " : "" + number.text + " / " + DateTime.Now.ToShortTimeString());
                            break;
                        }
                }                
            });

            richTextBox1.Invoke((MethodInvoker)delegate
            {
                if (info != null)
                {
                    string str = "";
                    str += number.text + ":\n";
                    if (info.blackList)
                    {
                        str += "Данный гос. номер в черном списке! \n";
                    }

                    if (info.comment.Length > 0)
                    {
                        str += "Комментарий " + info.comment + "\n";
                    }

                    if (info.blackList || info.comment.Length > 0)
                    {
                        richTextBox1.Text = richTextBox1.Text + "\n" + str;
                    }
                }
            });
        }

        private void WinFormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            cameraControl.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // показать форму где надо внести доп данные
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                try
                {
                    pictureBoxN.Image = ((UMat)numList[listBox1.SelectedIndex].licensePlateImages).Bitmap;
                }
                catch { }
            }
        }
    }
}
