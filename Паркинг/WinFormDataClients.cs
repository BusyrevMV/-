using MySql.Data.MySqlClient;
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
    public partial class WinFormDataClients : Form
    {
        public WinFormDataClients(User user)
        {
            InitializeComponent();
            клиентыDataGridView.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            контактыклиентовDataGridView.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            DataBaseCenter dataBase = DataBaseCenter.Create();
            if (dataBase.CheckRigth(user, Rights.редКлиенты))
            {
                клиентыDataGridView.ReadOnly = false;
                bindingNavigatorDeleteItem.Enabled = true;
                toolStripButton2.Enabled = true;
                контактыклиентовDataGridView.ReadOnly = false;
            }
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Вы ввели неверный формат данных в поле!", "Ошибка");
            anError.ThrowException = false;
        }

        private void клиентыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.клиентыBindingSource.EndEdit();
            this.tableAdapterManager.клиентыTableAdapter.Update(this.parkingDataSet.клиенты);
            this.клиентыTableAdapter.Fill(this.parkingDataSet.клиенты);
        }

        private void WinFormDataClients_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.списоквидовавто". При необходимости она может быть перемещена или удалена.
            this.списоквидовавтоTableAdapter.Fill(this.parkingDataSet.списоквидовавто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.parkingDataSet.авто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.контактыклиентов". При необходимости она может быть перемещена или удалена.
            this.контактыклиентовTableAdapter.Fill(this.parkingDataSet.контактыклиентов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.parkingDataSet.клиенты);

            контактыклиентовBindingSource.Filter = "клиент='-1'";
            автоBindingSource.Filter = "клиент='-1'";
        }        

        private void toolStripButton7_Click(object sender, EventArgs e)
        {           
            this.Validate();
            this.контактыклиентовBindingSource.EndEdit();
            this.tableAdapterManager.контактыклиентовTableAdapter.Update(this.parkingDataSet.контактыклиентов);
        }

        private void клиентыDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            контактыклиентовBindingSource.Filter = string.Format("клиент='{0}'", клиентыDataGridView.CurrentRow.Cells[0].Value.ToString());
            автоBindingSource.Filter = string.Format("клиент='{0}'", клиентыDataGridView.CurrentRow.Cells[0].Value.ToString());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int indx = -1;
            if (int.TryParse(клиентыDataGridView.CurrentRow.Cells[0].Value.ToString(), out indx))
            {
                if (indx >= 0)
                {
                    контактыклиентовDataGridView.CurrentRow.Cells[1].Value = indx;
                    контактыклиентовDataGridView.CurrentRow.Cells[4].Value = 0;
                    return;
                }
            }

            контактыклиентовDataGridView.Rows.Remove(контактыклиентовDataGridView.CurrentRow);
            MessageBox.Show("Выберите клиента, для которого необходимо добавить контакт!", "Ошибка");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клиентыBindingSource.Filter = string.Format("ФИО LIKE '%{0}%' and серияНомер_ВУ LIKE '%{1}%'", textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            клиентыBindingSource.Filter = "";
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            клиентыDataGridView.CurrentRow.Cells[3].Value = 0;
        }
    }
}
