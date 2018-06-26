using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Паркинг
{
    public partial class WinFormSettings : Form
    {
        private List<Camera> cameras = new List<Camera>();
        private List<Camera> activCams = new List<Camera>();
        private Camera camera;
        private Bitmap bitmap = new Bitmap(300, 300);

        public WinFormSettings(List<Camera> cams)
        {
            InitializeComponent();
            activCams = cams;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            groupBox1.Enabled = checkBox1.Checked;          
        }

        private void WinFormSettings_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream stream = new FileStream("Настройки\\Камеры.cfg", FileMode.Open);
                byte[] byte_buff = new byte[(int)stream.Length];
                stream.Read(byte_buff, 0, (int)stream.Length);
                string str_buff = Encoding.Default.GetString(byte_buff);
                cameras = JsonConvert.DeserializeObject<List<Camera>>(str_buff);
                stream.Close();
            }
            catch { }

            for(int i = 0; i < cameras.Count; i++)
            {
                listBox1.Items.Add(cameras[i].camName + " // " + cameras[i].url);
                listBox2.Items.Add(cameras[i].camName + " // " + cameras[i].url);
            }

            if (cameras.Count != 0)
            {
                listBox1.SelectedIndex = 0;
                listBox2.SelectedIndex = 0;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }

            camera = cameras[listBox1.SelectedIndex];
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            textBox1.Text = camera.camName;
            textBox2.Text = camera.url;
            textBox3.Text = camera.login;
            textBox4.Text = camera.pass;
            checkBox1.Checked = camera.oneNumber;
            switch (camera.direction)
            {
                case 1:
                    {
                        radioButton1.Checked = true;
                        break;
                    }

                case -1:
                    {
                        radioButton2.Checked = true;
                        break;
                    }

                default:
                    {
                        radioButton3.Checked = true;
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cameras.Remove(camera);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            if (cameras.Count != 0)
            {
                listBox1.SelectedIndex = 0;
                listBox2.SelectedIndex = 0;
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            camera = new Camera();
            cameras.Add(camera);            
            camera.camName = textBox1.Text;
            camera.url = textBox2.Text;
            listBox1.Items.Add(camera.camName + " // " + camera.url);
            listBox2.Items.Add(camera.camName + " // " + camera.url);
            camera.login = textBox3.Text;
            camera.pass = textBox4.Text;
            camera.oneNumber = checkBox1.Checked;
            if (checkBox1.Checked && radioButton1.Checked)
            {
                camera.direction = 1;
            }

            if (checkBox1.Checked && radioButton2.Checked)
            {
                camera.direction = -1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            camera.camName = textBox1.Text;
            camera.url = textBox2.Text;
            camera.login = textBox3.Text;
            camera.pass = textBox4.Text;
            camera.oneNumber = checkBox1.Checked;
            if (checkBox1.Checked && radioButton1.Checked)
            {
                camera.direction = 1;
            }

            if (checkBox1.Checked && radioButton2.Checked)
            {
                camera.direction = -1;
            }

            if (checkBox1.Checked && radioButton3.Checked)
            {
                camera.direction = 0;
            }

            Directory.CreateDirectory("Настройки\\");
            byte[] buff = Encoding.Default.GetBytes(JsonConvert.SerializeObject(cameras));
            FileStream stream = new FileStream("Настройки\\Камеры.cfg", FileMode.Create);
            stream.Write(buff, 0, buff.Length);
            stream.Close();
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            int x;
            int y;
            int w;
            int h;

            if(!Int32.TryParse(textBox5.Text, out x))
            {
                MessageBox.Show("Вы ввели неверно значение координаты Х!", "Ошибка!");
                return;
            }

            if (!Int32.TryParse(textBox6.Text, out y))
            {
                MessageBox.Show("Вы ввели неверно значение координаты Y!", "Ошибка!");
                return;
            }

            if (!Int32.TryParse(textBox8.Text, out w))
            {
                MessageBox.Show("Вы ввели неверно значение ширины!", "Ошибка!");
                return;
            }

            if (!Int32.TryParse(textBox7.Text, out h))
            {
                MessageBox.Show("Вы ввели неверно значение высоты!", "Ошибка!");
                return;
            }

            Bitmap bmp = new Bitmap(bitmap);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Red, 2);
            g.DrawRectangle(pen, x, y, w, h);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
            camera = cameras[listBox2.SelectedIndex];
            try
            {
                bitmap = activCams[listBox2.SelectedIndex].GetBitmap();
            }
            catch
            {
                MessageBox.Show("Неудалось загрузить изображение с камеры", "Ошибка!");
                return;
            }
            if (bitmap == null)
            {
                bitmap = new Bitmap(500, 300);
            }
            Bitmap bmp = new Bitmap(bitmap);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Red, 2);
            g.DrawRectangle(pen, camera.rectangle);
            textBox5.Text = camera.rectangle.X.ToString();
            textBox6.Text = camera.rectangle.Y.ToString();
            textBox7.Text = camera.rectangle.Height.ToString();
            textBox8.Text = camera.rectangle.Width.ToString();
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            int w;
            int h;

            if (!Int32.TryParse(textBox5.Text, out x))
            {
                MessageBox.Show("Вы ввели неверно значение координаты Х!", "Ошибка!");
                return;
            }

            if (!Int32.TryParse(textBox6.Text, out y))
            {
                MessageBox.Show("Вы ввели неверно значение координаты Y!", "Ошибка!");
                return;
            }

            if (!Int32.TryParse(textBox8.Text, out w))
            {
                MessageBox.Show("Вы ввели неверно значение ширины!", "Ошибка!");
                return;
            }

            if (!Int32.TryParse(textBox7.Text, out h))
            {
                MessageBox.Show("Вы ввели неверно значение высоты!", "Ошибка!");
                return;
            }

            camera.rectangle = new Rectangle(x, y, w, h);

            Directory.CreateDirectory("Настройки\\");
            byte[] buff = Encoding.Default.GetBytes(JsonConvert.SerializeObject(cameras));
            FileStream stream = new FileStream("Настройки\\Камеры.cfg", FileMode.Create);
            stream.Write(buff, 0, buff.Length);
            stream.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ulong id;
            if (ulong.TryParse(textBox9.Text, out id))
            {
                MessageBox.Show("Некорректный индентификатор приложения!", "Ошибка!");
                return;
            }

            DataBaseCenter dataBase = DataBaseCenter.Create();
            dataBase.RunCommand("UPDATE Настройки SET значение='" + 
                textBox9.Text + " | " + 
                textBox10.Text + " | " + 
                textBox11.Text + "' WHERE название='vk'");                        
        }
    }
}
