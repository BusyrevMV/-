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
    public partial class WinFormQiwiSetting : Form
    {
        private DataBaseCenter dataBase = DataBaseCenter.Create();
        public WinFormQiwiSetting()
        {
            InitializeComponent();            
            DataTable dataTable = dataBase.GetDataTable("SELECT значение FROM Настройки WHERE название='qiwi'");
            string[] str = dataTable.Rows[0].ItemArray[0].ToString().Split("|".ToCharArray());
            textBox1.Text = str[0];
            textBox2.Text = str[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.RunCommand(string.Format(
                "UPDATE Настройки SET значение='{0}|{1}' WHERE название='qiwi'", 
                textBox1.Text, 
                textBox2.Text));
        }
    }
}
