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
    public partial class WinFormAddTransit : Form
    {
        private Number number;
        private HistoryTransit historyTransit;
        private List<Camera> cameras;
        private User user;

        public delegate void VkNotyfDelegate(Number number, HistoryTransit historyTransit);
        public event VkNotyfDelegate VkNotyf;

        public WinFormAddTransit(Number number, HistoryTransit historyTransit, List<Camera> cameras, User user)
        {
            InitializeComponent();
            this.number = number;
            this.historyTransit = historyTransit;
            this.cameras = cameras;
            this.user = user;
            if (number != null)
            {
                pictureBox1.Image = number.licensePlateImages.GetOutputArray().GetMat().Bitmap;
                textBox1.Text = number.text;
                if (number.direction == -1)
                    comboBox1.SelectedText = "Въезд";
                if (number.direction == 1)
                    comboBox1.SelectedText = "Выезд";
            }

            if (historyTransit != null)
            {
                checkBox1.Checked = historyTransit.added;
                button1.Enabled = !historyTransit.added;
                richTextBox1.AppendText((historyTransit.blackList ? "В ЧЕРНОМ СПИСКЕ! \n" : ""));
                richTextBox1.AppendText("ФИО: " + historyTransit.fio + "\n");
                richTextBox1.AppendText("Серия/номер ВУ: " + historyTransit.serialNum + "\n");
                richTextBox1.AppendText("Баланс: " + historyTransit.balance + "\n");
                richTextBox1.AppendText("Авто: " + historyTransit.avto + "\n");
                richTextBox1.AppendText("Дата въезда: " + historyTransit.dateEnter + "\n");
                richTextBox1.AppendText("Дата выезда: " + historyTransit.dateExit + "\n");
                richTextBox1.AppendText("Стоимость стоянки: " + historyTransit.cost + "\n");
                richTextBox1.AppendText("Комментарий: " + historyTransit.comment + "\n");
            }

            foreach(Camera cam in cameras)
            {
                comboBox2.Items.Add(cam.camName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Введены не все данные!", "Ошибка");
                return;
            }

            if (number == null)
            {
                number = new Number();
                if (comboBox2.SelectedIndex >= 0)
                {
                    number.photo = cameras[comboBox2.SelectedIndex].GetMat();
                }
            }

            number.text = textBox1.Text;
            number.direction = comboBox1.Text == "Въезд" ? -1 : 1;

            DataBaseCenter dataBase = DataBaseCenter.Create();
            if (number.direction == dataBase.CheckDirection(number, user))
            {
                historyTransit = dataBase.NumberToHistory(number, user);

                if (historyTransit != null)
                {
                    richTextBox1.AppendText((historyTransit.blackList ? "В ЧЕРНОМ СПИСКЕ! \n" : ""));
                    richTextBox1.AppendText("ФИО: " + historyTransit.fio + "\n");
                    richTextBox1.AppendText("Серия/номер ВУ: " + historyTransit.serialNum + "\n");
                    richTextBox1.AppendText("Баланс: " + historyTransit.balance + "\n");
                    richTextBox1.AppendText("Авто: " + historyTransit.avto + "\n");
                    richTextBox1.AppendText("Дата въезда: " + historyTransit.dateEnter + "\n");
                    richTextBox1.AppendText("Дата выезда: " + historyTransit.dateExit + "\n");
                    richTextBox1.AppendText("Стоимость стоянки: " + historyTransit.cost + "\n");
                    richTextBox1.AppendText("Комментарий: " + historyTransit.comment + "\n");
                    if (VkNotyf != null && historyTransit.added)
                        Task.Run(() => { VkNotyf(number, historyTransit); });
                    if (historyTransit.added)
                    {
                        MessageBox.Show("Добавлено!", "Оповещение");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить!", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось добавить!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Направление движения не совпадает с ожидаемым!", "Ошибка");
                return;
            }

        }
    }
}
