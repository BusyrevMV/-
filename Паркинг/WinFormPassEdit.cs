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
    public partial class WinFormPassEdit : Form
    {
        private User user;
        public WinFormPassEdit(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseCenter dataBaseCenter = DataBaseCenter.Create();
            if (dataBaseCenter.Autorization(user.login, textBox1.Text) != null)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    if (0 < dataBaseCenter.RunCommand(string.Format("UPDATE пользователи SET пароль='{1}' WHERE id='{0}'", user.id, DataBaseCenter.HashPass(textBox2.Text))))
                    {
                        MessageBox.Show("Пароль изменен", "Оповещение");
                    }
                    else
                    {
                        MessageBox.Show("Пароль изменить не удалось!", "Ошибка");
                    };
                }
                else
                {
                    MessageBox.Show("Новые пароли не совпадают!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Старый пароль неверный!", "Ошибка");
            };

        }
    }
}
