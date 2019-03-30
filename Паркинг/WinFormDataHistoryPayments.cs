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
    public partial class WinFormDataHistoryPayments : Form
    {
        public WinFormDataHistoryPayments()
        {
            InitializeComponent();
        }        

        private void WinFormDataHistoryPayments_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.парковки". При необходимости она может быть перемещена или удалена.
            this.парковкиTableAdapter.Fill(this.parkingDataSet.парковки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.списокклиентов". При необходимости она может быть перемещена или удалена.
            this.списокклиентовTableAdapter.Fill(this.parkingDataSet.списокклиентов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "parkingDataSet.историятранзакций". При необходимости она может быть перемещена или удалена.
            this.историятранзакцийTableAdapter.Fill(this.parkingDataSet.историятранзакций);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            историятранзакцийBindingSource.Filter = string.Format(
                "дата > '{0}' and дата < '{1}'",
                dateTimePicker1.Value.ToString(),
                dateTimePicker2.Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            историятранзакцийBindingSource.Filter = "";
        }
    }
}
