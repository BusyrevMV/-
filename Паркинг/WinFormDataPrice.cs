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
    public partial class WinFormDataPrice : Form
    {
        public WinFormDataPrice()
        {
            InitializeComponent();
        }

        private void настройкиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.настройкиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.parkingDataSet);

        }

        private void тарифыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.тарифыBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.parkingDataSet);

        }

        private void WinFormDataPrice_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.тарифы". При необходимости она может быть перемещена или удалена.
            this.тарифыTableAdapter.Fill(this.parkingDataSet.тарифы);

        }
    }
}
