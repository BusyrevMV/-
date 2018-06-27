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
    public partial class WinFormAuth : Form
    {
        public WinFormAuth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseCenter dataBaseCenter = DataBaseCenter.Create();
            User user = null;
            user = dataBaseCenter.Autorization(textBox1.Text, textBox2.Text);
            if (user != null)
            {
                (new WinFormMain(user)).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка");
            }
        }
    }
}
