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
    public partial class WinFormDataUsers : Form
    {
        public WinFormDataUsers(User user)
        {
            InitializeComponent();
            пользователиDataGridView.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            DataBaseCenter dataBase = DataBaseCenter.Create();
            if (dataBase.CheckRigth(user, Rights.редПольз))
            {
                пользователиDataGridView.ReadOnly = false;
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;
                пользователиBindingNavigatorSaveItem.Enabled = true;
            }
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Вы ввели неверный формат данных в поле!", "Ошибка");
            anError.ThrowException = false;
        }

        private void пользователиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.пользователиBindingSource.EndEdit();
            this.tableAdapterManager.пользователиTableAdapter.Update(this.parkingDataSet.пользователи);

        }

        private void WinFormDataUsers_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.парковки". При необходимости она может быть перемещена или удалена.
            this.парковкиTableAdapter.Fill(this.parkingDataSet.парковки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.парковки". При необходимости она может быть перемещена или удалена.
            this.парковкиTableAdapter.Fill(this.parkingDataSet.парковки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.группы". При необходимости она может быть перемещена или удалена.
            this.группыTableAdapter.Fill(this.parkingDataSet.группы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.группы". При необходимости она может быть перемещена или удалена.
            this.группыTableAdapter.Fill(this.parkingDataSet.группы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.группы". При необходимости она может быть перемещена или удалена.
            this.группыTableAdapter.Fill(this.parkingDataSet.группы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.парковки". При необходимости она может быть перемещена или удалена.
            this.парковкиTableAdapter.Fill(this.parkingDataSet.парковки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.parkingDataSet.пользователи);

        }

        private void пользователиDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void пользователиDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void сброситьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string alhp = "qwertyuiopasdfghjklzxcvbnm";
            Random random = new Random();
            string pass = alhp[random.Next(25)].ToString() +
                alhp[random.Next(25)].ToString() +
                alhp[random.Next(25)].ToString() +
                alhp[random.Next(25)].ToString() +
                alhp[random.Next(25)].ToString();
            пользователиDataGridView.CurrentRow.Cells[3].Value = DataBaseCenter.HashPass(pass);
            MessageBox.Show("Новый пароль " + pass, "Оповещение");
        }
    }
}
