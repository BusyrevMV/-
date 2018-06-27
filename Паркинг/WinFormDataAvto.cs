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
    public partial class WinFormDataAvto : Form
    {
        public WinFormDataAvto()
        {
            InitializeComponent();
            автоDataGridView.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            моделиавтоDataGridView.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            маркиавтоDataGridView.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Вы ввели неверный формат данных в поле!", "Ошибка");
            anError.ThrowException = false;
        }

        private void автоBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.автоBindingSource.EndEdit();
            this.tableAdapterManager.автоTableAdapter.Update(this.parkingDataSet.авто);

        }

        private void WinFormAvto_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.списоквидовавто". При необходимости она может быть перемещена или удалена.
            this.списоквидовавтоTableAdapter.Fill(this.parkingDataSet.списоквидовавто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.списокклиентов". При необходимости она может быть перемещена или удалена.
            this.списокклиентовTableAdapter.Fill(this.parkingDataSet.списокклиентов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.моделиавто". При необходимости она может быть перемещена или удалена.
            this.моделиавтоTableAdapter.Fill(this.parkingDataSet.моделиавто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.маркиавто". При необходимости она может быть перемещена или удалена.
            this.маркиавтоTableAdapter.Fill(this.parkingDataSet.маркиавто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.маркиавто". При необходимости она может быть перемещена или удалена.
            this.маркиавтоTableAdapter.Fill(this.parkingDataSet.маркиавто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.parkingDataSet.авто);

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.автоBindingSource.EndEdit();
            this.tableAdapterManager.маркиавтоTableAdapter.Update(this.parkingDataSet.маркиавто);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.автоBindingSource.EndEdit();
            try { this.tableAdapterManager.моделиавтоTableAdapter.Update(this.parkingDataSet.моделиавто); }
            catch { MessageBox.Show("Перезапустите окно!", "Ошибка"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            автоBindingSource.Filter = string.Format("госномер LIKE '%{0}%'", textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            автоBindingSource.Filter = "";
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            автоDataGridView.CurrentRow.Cells[4].Value = 0;
        }
    }
}
