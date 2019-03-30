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
    public partial class WinFormDataMenu : Form
    {
        private User user;

        public WinFormDataMenu(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                (new WinFormDataClients(user)).Show();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                (new WinFormDataAvto()).Show();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                (new WinFormDataHistoryTransit()).Show();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                (new WinFormDataHistoryPayments()).Show();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                (new WinFormDataParkings(user)).Show();
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                (new WinFormDataPrice(user)).Show();
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataBaseCenter dataBase = DataBaseCenter.Create();
            if (!dataBase.CheckRigth(user, Rights.чтениеПольз))
            {
                MessageBox.Show("Недостаточно прав!", "Предупреждение");
                return;
            }

            try
            {
                (new WinFormDataUsers(user)).Show();
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataBaseCenter dataBase = DataBaseCenter.Create();
            if (!dataBase.CheckRigth(user, Rights.группы))
            {
                MessageBox.Show("Недостаточно прав!", "Предупреждение");
                return;
            }

            try
            {
                (new WinFormDataGroups()).Show();
            }
            catch { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                (new WinFormPassEdit(user)).Show();
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataBaseCenter dataBase = DataBaseCenter.Create();
            if (!dataBase.CheckRigth(user, Rights.приемПлатежей))
            {
                MessageBox.Show("Недостаточно прав!", "Предупреждение");
                return;
            }

            try
            {
                (new WinFormAddPay()).Show();
            }
            catch { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataBaseCenter dataBase = DataBaseCenter.Create();
            if (!dataBase.CheckRigth(user, Rights.настройки))
            {
                MessageBox.Show("Недостаточно прав!", "Предупреждение");
                return;
            }

            try
            {
                (new WinFormQiwiSetting()).Show();
            }
            catch { }
        }
    }
}
