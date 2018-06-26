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
    public partial class WinFormDataHistoryTransit : Form
    {
        public WinFormDataHistoryTransit()
        {
            InitializeComponent();
        }        

        private void WinFormHistoryTransit_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.парковки". При необходимости она может быть перемещена или удалена.
            this.парковкиTableAdapter.Fill(this.parkingDataSet.парковки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.parkingDataSet.авто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.историяпроездов". При необходимости она может быть перемещена или удалена.
            this.историяпроездовTableAdapter.Fill(this.parkingDataSet.историяпроездов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.parkingDataSet.авто);            
        }

        private void историяпроездовBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.историяпроездовBindingSource.EndEdit();
            this.tableAdapterManager.историяпроездовTableAdapter.Update(this.parkingDataSet.историяпроездов);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            историяпроездовBindingSource.Filter = string.Format(
                "въехалДата between '{0}' and '{1}' or выехалДата between '{2}' and '{3}'",
                dateTimePicker1.Value.ToString("yyyy-mm-dd HH:mm"),
                dateTimePicker2.Value.ToString("yyyy-mm-dd HH:mm"),
                dateTimePicker1.Value.ToString("yyyy-mm-dd HH:mm"),
                dateTimePicker2.Value.ToString("yyyy-mm-dd HH:mm"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            историяпроездовBindingSource.Filter = "";
        }
    }
}
