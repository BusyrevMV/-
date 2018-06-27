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
    public partial class WinFormDataParkings : Form
    {
        public WinFormDataParkings(User user)
        {
            InitializeComponent();
            парковкиDataGridView.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            DataBaseCenter dataBase = DataBaseCenter.Create();
            if (dataBase.CheckRigth(user, Rights.редПольз))
            {
                парковкиDataGridView.ReadOnly = false;
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;
                парковкиBindingNavigatorSaveItem.Enabled = true;
            }
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Вы ввели неверный формат данных в поле!", "Ошибка");
            anError.ThrowException = false;
        }

        private void парковкиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.парковкиBindingSource.EndEdit();
            this.tableAdapterManager.парковкиTableAdapter.Update(this.parkingDataSet.парковки);

        }

        private void WinFormDataParkings_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.тарифы". При необходимости она может быть перемещена или удалена.
            this.тарифыTableAdapter.Fill(this.parkingDataSet.тарифы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.парковки". При необходимости она может быть перемещена или удалена.
            this.парковкиTableAdapter.Fill(this.parkingDataSet.парковки);

        }
    }
}
