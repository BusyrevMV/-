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
    public partial class WinFormDataGroups : Form
    {
        public WinFormDataGroups()
        {
            InitializeComponent();
            группыDataGridView.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Вы ввели неверный формат данных в поле!", "Ошибка");
            anError.ThrowException = false;
        }

        private void группыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.группыBindingSource.EndEdit();
            this.tableAdapterManager.группыTableAdapter.Update(this.parkingDataSet.группы);

        }

        private void WinFormDataGroups_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.группы". При необходимости она может быть перемещена или удалена.
            this.группыTableAdapter.Fill(this.parkingDataSet.группы);

        }
    }
}
