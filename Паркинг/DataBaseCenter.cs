using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Паркинг
{
    public class DataBaseCenter
    {
        private static DataBaseCenter dataBaseCenter;
        private MySqlConnection sqlConnector;

        public static DataBaseCenter Create()
        {
            if (dataBaseCenter == null)
            {
                dataBaseCenter = new DataBaseCenter();
            }

            return dataBaseCenter;
        }

        private DataBaseCenter()
        {
            sqlConnector = new MySqlConnection(
                (new AppSettingsReader()).GetValue("connectionString", typeof(System.String)).ToString());
            sqlConnector.Open();
        }

        public DataTable GetDataTable(string sql)
        {
            lock (dataBaseCenter)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, sqlConnector);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public int RunCommand(string sql)
        {
            lock (dataBaseCenter)
            {
                MySqlCommand sqlCommand = new MySqlCommand();
                sqlCommand.Connection = sqlConnector;
                sqlCommand.CommandText = sql;
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int RunCommand(string sql, Bitmap bitmap)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if (bitmap != null)
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }            
            
            lock (dataBaseCenter)
            {
                MySqlCommand sqlCommand = new MySqlCommand();
                sqlCommand.Connection = sqlConnector;
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("@image", ms.ToArray());
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public string StatusAvto(long idVk)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dataTable = GetDataTable(string.Format(@"Select госНомер, 
(SELECT ИсторияПроездов.въехалДата FROM ИсторияПроездов WHERE ИсторияПроездов.авто=Авто.id ORDER BY ИсторияПроездов.въехалДата DESC LIMIT 1),
(SELECT ИсторияПроездов.выехалДата FROM ИсторияПроездов WHERE ИсторияПроездов.авто=Авто.id ORDER BY ИсторияПроездов.въехалДата DESC LIMIT 1)
From Клиенты
    JOIN КонтактыКлиентов ON КонтактыКлиентов.клиент=Клиенты.id
    join Авто ON Авто.клиент=Клиенты.id
WHERE
	КонтактыКлиентов.контакт='{0}'", idVk));
            if (dataTable.Rows.Count == 0)
                throw new Exception();            

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].ItemArray[2].ToString() == "" && dataTable.Rows[i].ItemArray[1].ToString() != "")
                {
                    sb.AppendLine(string.Format(
                        "Авто {0} на парковке с {1}",
                        dataTable.Rows[i].ItemArray[0],
                        dataTable.Rows[i].ItemArray[1]));
                }

                if (dataTable.Rows[i].ItemArray[1].ToString() == "" &&
                dataTable.Rows[i].ItemArray[2].ToString() == "")
                {
                    sb.AppendLine(string.Format(
                            "Авто {0} еще никогда не парковалось",
                            dataTable.Rows[i].ItemArray[0]));
                }

                if (dataTable.Rows[i].ItemArray[2].ToString() != "" && dataTable.Rows[i].ItemArray[1].ToString() != "")
                {
                    sb.AppendLine(string.Format(
                        "Авто {0} уехало {1}",
                        dataTable.Rows[i].ItemArray[0],
                        dataTable.Rows[i].ItemArray[2]));
                }
            }

            return sb.ToString();
        }

        public User Autorization(string login, string pass)
        {
            pass = HashPass(pass);
            lock (dataBaseCenter)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(
                    "SELECT пароль, id, парковка FROM Пользователи WHERE логин='" + login + "'", 
                    sqlConnector);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count < 1 || dataTable.Rows[0].ItemArray[0].ToString() != pass)
                {
                    return null;
                }

                int p = -1;
                int.TryParse(dataTable.Rows[0].ItemArray[2].ToString(), out p);
                return new User((int)dataTable.Rows[0].ItemArray[1], p, login);
            }
        }

        public List<int> GetContacts(string number)
        {
            List<int> contacts = new List<int>();
            DataTable dataTable = GetDataTable(string.Format("SELECT контакт FROM Авто Join Клиенты ON Клиенты.id = Авто.клиент Join КонтактыКлиентов ON КонтактыКлиентов.клиент = Клиенты.id WHERE госНомер = '{0}' and типКонтакта = 'ВКонтакте'", number));
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                contacts.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0].ToString()));
            }

            return contacts;
        }

        public bool CheckRigth(User user, Rights right)
        {
            lock (dataBaseCenter)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(
                    string.Format(
                        "SELECT {0} FROM Группы WHERE id=(SELECT группа FROM Пользователи WHERE id='{1}')", 
                        right, 
                        user.id), 
                    sqlConnector);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0 && dataTable.Rows[0].ItemArray[0].ToString() == "1")
                {
                    return true;
                }

                return false;
            }
        }

        public string BusyParking()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dataTable = new DataTable();
            lock (dataBaseCenter)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(
                    "SELECT CONCAT(название, ' ', адрес), вместимость-занято FROM Парковки", 
                    sqlConnector);
                
                dataAdapter.Fill(dataTable);
            }

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                sb.AppendLine(
                    dataTable.Rows[0].ItemArray[0].ToString() 
                    + ", ост. мест: " 
                    + dataTable.Rows[0].ItemArray[1].ToString());
            }

            return sb.ToString();
        }

        public int? SearchClient(long idVk)
        {
            lock (dataBaseCenter)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(
                    string.Format("SELECT клиент FROM КонтактыКлиентов WHERE контакт='{0}'", idVk),
                    sqlConnector);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    return (int)dataTable.Rows[0].ItemArray[0];
                }

                return null;
            }
        }

        public int CheckDirection(Number number, User user)
        {
            DataTable dataTable = GetDataTable(string.Format("SELECT id FROM Авто WHERE госНомер='{0}'", number.text));
            if (dataTable.Rows.Count < 1)
            {
                return -1;
            }

            dataTable = GetDataTable(string.Format("SELECT id FROM Авто WHERE госНомер='{0}'", number.text));
            int avto = (int)dataTable.Rows[0].ItemArray[0];
            dataTable = GetDataTable(
                string.Format(
                    "SELECT выехалДата, id FROM ИсторияПроездов WHERE авто='{0}' and парковка='{1}' order by выехалДата ASC LIMIT 1",
                    avto,
                    user.parking));
            if (dataTable.Rows.Count < 1)
            {
                return -1;
            }

            if (dataTable.Rows[0].ItemArray[0].ToString() != "")
            {
                return -1;
            }

            return 1;
        }

        public HistoryTransit NumberToHistory(Number number, User user)
        {
            HistoryTransit transit;
            DataTable dataTable = GetDataTable(string.Format("SELECT id, черныйСписок FROM Авто WHERE госНомер='{0}'", number.text));
            if (dataTable.Rows.Count < 1)
            {
                RunCommand(string.Format("INSERT INTO Авто (госНомер) VALUES('{0}')", number.text));
                dataTable = GetDataTable(string.Format("SELECT id, черныйСписок FROM Авто WHERE госНомер='{0}'", number.text));
            }

            int avto = (int)dataTable.Rows[0].ItemArray[0];
            bool black = dataTable.Rows[0].ItemArray[1].ToString() == "1" ? true : false;
            if (black)
            {
                dataTable = GetDataTable(
                string.Format(
                    @"SELECT фио, серияНомер_ВУ, балансСчета, списокВидовАвто.авто, госНомер, черныйСписок, комментарий, въехалДата, выехалДата, стоимость
FROM ИсторияПроездов 
	FULL JOIN Авто ON Авто.id=ИсторияПроездов.авто
    FULL JOIN Клиенты ON Клиенты.id=Авто.клиент
    FULL JOIN списокВидовАвто ON списокВидовАвто.id=Авто.авто
WHERE госНомер='{0}'
order by въехалДата DESC
LIMIT 1",
                    number.text,
                    user.parking));
                transit = new HistoryTransit
                {
                    fio = dataTable.Rows[0].ItemArray[0].ToString(),
                    serialNum = dataTable.Rows[0].ItemArray[1].ToString(),
                    balance = dataTable.Rows[0].ItemArray[2].ToString(),
                    avto = dataTable.Rows[0].ItemArray[3].ToString(),
                    LicenseNum = dataTable.Rows[0].ItemArray[04].ToString(),
                    blackList = (bool)dataTable.Rows[0].ItemArray[5],
                    comment = dataTable.Rows[0].ItemArray[6].ToString(),
                    added = false
                };

                return transit;
            }

            dataTable = GetDataTable(
                string.Format(
                    "SELECT выехалДата, id FROM ИсторияПроездов WHERE авто='{0}' and парковка='{1}' order by выехалДата ASC LIMIT 1",
                    avto,
                    user.parking));
            DateTime dateTime = DateTime.Now;
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0].ItemArray[0].ToString() == "")
                {
                    decimal price = CalcCost(avto, user, dateTime);
                    RunCommand(
                        string.Format(
                            "UPDATE ИсторияПроездов SET выехалДата='{0}', стоимость='{1}', выехалФото=@image WHERE id='{2}'",
                            dateTime.ToString("yyyy-MM-dd HH:mm"),
                            string.Format("{0:F2} ", price).Replace(",", "."),
                            dataTable.Rows[0].ItemArray[1].ToString()),
                        number.photo == null ? null : number.photo.Bitmap);
                    RunCommand(
                        string.Format(
                            "UPDATE Парковки SET занято = Парковки.занято - 1 WHERE Парковки.id = '{0}'",
                            user.parking));
                }
                else
                {
                    RunCommand(
                        string.Format(
                            "INSERT INTO ИсторияПроездов (въехалДата, авто, парковка, въехалФото) VALUES('{0}', '{1}', '{2}', @image)",
                            dateTime.ToString("yyyy-MM-dd HH:mm"),
                            avto,
                            user.parking),
                        number.photo == null ? null : number.photo.Bitmap);
                    RunCommand(
                        string.Format(
                            "UPDATE Парковки SET занято = Парковки.занято + 1 WHERE Парковки.id = '{0}'",
                            user.parking));
                }
            }
            else
            {
                RunCommand(
                    string.Format(
                        "INSERT INTO ИсторияПроездов (въехалДата, авто, парковка, въехалФото) VALUES('{0}', '{1}', '{2}', @image)",
                        dateTime.ToString("yyyy-MM-dd HH:mm"),
                        avto,
                        user.parking),
                    number.photo.Bitmap);
                RunCommand(
                        string.Format(
                            "UPDATE Парковки SET занято = Парковки.занято + 1 WHERE Парковки.id = '{0}'", 
                            user.parking));
            }

            dataTable = GetDataTable(
                string.Format(
                    @"SELECT фио, серияНомер_ВУ, балансСчета, списокВидовАвто.авто, госНомер, черныйСписок, комментарий, въехалДата, выехалДата, стоимость
FROM ИсторияПроездов 
	JOIN Авто ON Авто.id=ИсторияПроездов.авто
    JOIN Клиенты ON Клиенты.id=Авто.клиент
    JOIN списокВидовАвто ON списокВидовАвто.id=Авто.авто
WHERE госНомер='{0}' and парковка='{1}'
order by въехалДата DESC
LIMIT 1",
                    number.text,
                    user.parking));
            transit = new HistoryTransit
            {
                fio = dataTable.Rows[0].ItemArray[0].ToString(),
                serialNum = dataTable.Rows[0].ItemArray[1].ToString(),
                balance = dataTable.Rows[0].ItemArray[2].ToString(),
                avto = dataTable.Rows[0].ItemArray[3].ToString(),
                LicenseNum = dataTable.Rows[0].ItemArray[04].ToString(),
                blackList = dataTable.Rows[0].ItemArray[5].ToString() == "1" ? true : false,
                comment = dataTable.Rows[0].ItemArray[6].ToString(),
                dateEnter = dataTable.Rows[0].ItemArray[7].ToString(),
                dateExit = dataTable.Rows[0].ItemArray[8].ToString(),
                cost = dataTable.Rows[0].ItemArray[8].ToString() == "" ? "0" : dataTable.Rows[0].ItemArray[8].ToString()
            };

            return transit;
        }

        /*public HistoryTransit NumberToHistory(Number number, User user, int direction)
        {
            HistoryTransit transit;
            DataTable dataTable = GetDataTable(string.Format("SELECT id FROM Авто WHERE госНомер='{0}'", number.text));
            if (dataTable.Rows.Count < 1)
            {
                RunCommand(string.Format("INSERT INTO Авто (госНомер) VALUES('{0}')", number.text));
                dataTable = GetDataTable(string.Format("SELECT id FROM Авто WHERE госНомер='{0}'", number.text));
            }

            int avto = (int)dataTable.Rows[0].ItemArray[0];
            bool black = (bool)dataTable.Rows[0].ItemArray[1];
            if (black)
            {
                dataTable = GetDataTable(
                string.Format(
                    @"SELECT фио, серияНомер_ВУ, балансСчета, списокВидовАвто.авто, госНомер, черныйСписок, комментарий, въехалДата, выехалДата, стоимость
FROM ИсторияПроездов 
	FULL JOIN Авто ON Авто.id=ИсторияПроездов.авто
    FULL JOIN Клиенты ON Клиенты.id=Авто.клиент
    FULL JOIN списокВидовАвто ON списокВидовАвто.id=Авто.авто
WHERE госНомер='{0}'
order by въехалДата DESC
LIMIT 1",
                    number.text,
                    user.parking));
                transit = new HistoryTransit
                {
                    fio = dataTable.Rows[0].ItemArray[0].ToString(),
                    serialNum = dataTable.Rows[0].ItemArray[1].ToString(),
                    balance = dataTable.Rows[0].ItemArray[2].ToString(),
                    avto = dataTable.Rows[0].ItemArray[3].ToString(),
                    LicenseNum = dataTable.Rows[0].ItemArray[04].ToString(),
                    blackList = (bool)dataTable.Rows[0].ItemArray[5],
                    comment = dataTable.Rows[0].ItemArray[6].ToString(),
                    added = false
                };

                return transit;
            }
            dataTable = GetDataTable(
                string.Format(
                    "SELECT выехалДата, id FROM ИсторияПроездов WHERE авто='{0}' and парковка='{1}' order by выехалДата DESC LIMIT 1",
                    avto,
                    user.parking));
            if (dataTable.Rows.Count > 0)
            {
                DateTime dateTime = DateTime.Now;
                if (direction == 1)
                {
                    decimal price = CalcCost(avto, user, dateTime);
                    RunCommand(
                        string.Format(
                            "UPDATE ИсторияПроездов SET выехалДата={0}, стоимость='{1}', выехалФото='@image' WHERE id='{2}'",
                            dateTime.ToString("yyyy-MM-dd HH:mm"),
                            string.Format("0:F2", price),
                            dataTable.Rows[0].ItemArray[1]),
                        number.photo.Bitmap);
                    RunCommand(
                        string.Format("UPDATE Парковки SET занято = Парковки.занято - 1 WHERE Парковки.id = '{0}'", user.parking));
                }
                else
                {
                    RunCommand(
                        string.Format(
                            "INSERT INTO ИсторияПроездов (въехалДата, авто, парковка, въехалФото) VALUES('{0}', '{1}', '{2}', '@image')",
                            dateTime.ToString("yyyy-MM-dd HH:mm"),
                            avto,
                            user.parking),
                        number.photo.Bitmap);
                    RunCommand(
                        string.Format("UPDATE Парковки SET занято = Парковки.занято + 1 WHERE Парковки.id = '{0}'", user.parking));
                }
            }

            dataTable = GetDataTable(
                string.Format(
                    @"SELECT фио, серияНомер_ВУ, балансСчета, списокВидовАвто.авто, госНомер, черныйСписок, комментарий, въехалДата, выехалДата, стоимость
FROM ИсторияПроездов 
	JOIN Авто ON Авто.id=ИсторияПроездов.авто
    JOIN Клиенты ON Клиенты.id=Авто.клиент
    JOIN списокВидовАвто ON списокВидовАвто.id=Авто.авто
WHERE госНомер='{0}' and парковка='{1}'
order by въехалДата DESC
LIMIT 1",
                    number.text,
                    user.parking));
            transit = new HistoryTransit
            {
                fio = dataTable.Rows[0].ItemArray[0].ToString(),
                serialNum = dataTable.Rows[0].ItemArray[1].ToString(),
                balance = dataTable.Rows[0].ItemArray[2].ToString(),
                avto = dataTable.Rows[0].ItemArray[3].ToString(),
                LicenseNum = dataTable.Rows[0].ItemArray[04].ToString(),
                blackList = (bool)dataTable.Rows[0].ItemArray[5],
                comment = dataTable.Rows[0].ItemArray[6].ToString(),
                dateEnter = dataTable.Rows[0].ItemArray[7].ToString(),
                dateExit = dataTable.Rows[0].ItemArray[8].ToString(),
                cost = dataTable.Rows[0].ItemArray[8].ToString() == "" ? "0" : dataTable.Rows[0].ItemArray[0].ToString()
            };

            return transit;
        }*/

        public static string HashPass(string pass)
        {
            if (string.IsNullOrEmpty(pass))
            {
                return "";
            }

            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }
        
        private decimal CalcCost(int avto, User user, DateTime dateTimeOut)
        {
            int free = 0;
            decimal cost = 0;
            decimal price = 0;
            int minits = 0;
            DataTable dataTable = GetDataTable(
                string.Format(
                    "SELECT бесплатныеМинуты, ценаРубВЧас FROM Тарифы JOIN Парковки ON Парковки.тариф=Тарифы.id WHERE Парковки.id='{0}'", 
                    user.parking));
            if (dataTable.Rows.Count == 0)
            {
                return 0;
            }

            free = (int)dataTable.Rows[0].ItemArray[0];
            cost = (decimal)dataTable.Rows[0].ItemArray[1];

            dataTable = GetDataTable(
                string.Format(
                    "SELECT въехалДата FROM ИсторияПроездов WHERE авто='{0}' order by выехалДата DESC LIMIT 1",
                    avto));
            DateTime dateTimeIn;
            try
            {
                dateTimeIn = DateTime.ParseExact(dataTable.Rows[0].ItemArray[0].ToString(), "dd.MM.yyyy HH:mm:ss", null);
            }
            catch
            {
                dateTimeIn = DateTime.ParseExact(dataTable.Rows[0].ItemArray[0].ToString(), "dd.MM.yyyy H:mm:ss", null);
            }

            minits = Convert.ToInt32(dateTimeOut.Subtract(dateTimeIn).TotalMinutes);
            if (free <= minits)
            {
                price = (cost * (minits - free)) / 60.00M;
            }
            else
            {
                return 0;
            }

            return price;
        }

        public void AddPayment(string id, string money)
        {
            RunCommand(string.Format(
                        "INSERT INTO ИсторияТранзакций (клиент, операция, сумма) VALUES('{0}', 'приход', '{1}')",
                        id,
                        money));
        }        
    }
}
