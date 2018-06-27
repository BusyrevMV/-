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
    public partial class WinFormAddPay : Form
    {
        public WinFormAddPay()
        {
            InitializeComponent();
        }

        private void WinFormAddPay_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.parkingDataSet.клиенты);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            клиентыBindingSource.Filter = string.Format("ФИО LIKE '%{0}%' and серияНомер_ВУ LIKE '%{1}%'", textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            клиентыBindingSource.Filter = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            клиентыDataGridView.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            if (double.TryParse(textBox3.Text, out double d))
            {
                DataBaseCenter dataBaseCenter = DataBaseCenter.Create();
                dataBaseCenter.AddPayment(textBox6.Text, textBox3.Text);
                MessageBox.Show("Выполнено!", "Оповещение");
                panel2.Visible = false;
                клиентыDataGridView.Enabled = true;
                this.клиентыTableAdapter.Fill(this.parkingDataSet.клиенты);

            }
            else
            {
                MessageBox.Show("Введена некорректная сумма!", "Ошибка");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void клиентыDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            клиентыDataGridView.Enabled = false;
        }
    }
}
