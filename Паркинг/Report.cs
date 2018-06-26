using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;

namespace Паркинг
{
    class Report
    {
        public string CreateReportTransaction(long idvk, string leftDate, string rightDate)
        {
            DataBaseCenter dataBase = DataBaseCenter.Create();
            DataTable dataTable = dataBase.GetDataTable(string.Format(
                @"Select ИсторияТранзакций.операция, 
ИсторияТранзакций.сумма, ИсторияТранзакций.дата, 
concat(въехалДата, ' - ', выехалДата, ' ',госНомер)   
From ИсторияТранзакций 
	JOIN Клиенты ON Клиенты.id=ИсторияТранзакций.клиент
    JOIN КонтактыКлиентов ON КонтактыКлиентов.клиент=Клиенты.id    
    LEFT JOIN ИсторияПроездов ON ИсторияПроездов.id=ИсторияТранзакций.стоянка
    JOIN Авто ON Авто.id=ИсторияПроездов.авто
WHERE
	КонтактыКлиентов.контакт='{0}' and ИсторияТранзакций.дата between '{1}' and '{2}' 
ORDER BY ИсторияТранзакций.дата DESC", idvk, leftDate, rightDate));
            DataRow[] data_arr = dataTable.Select();
            dataTable = dataBase.GetDataTable(@"Select ФИО, серияНомер_ВУ
From Клиенты
    JOIN КонтактыКлиентов ON КонтактыКлиентов.клиент=Клиенты.id    
WHERE
	КонтактыКлиентов.контакт='{0}'
LIMIT 1");
            string path = string.Format("report {0} {1}.docx", idvk, DateTime.Now.ToString("yyyy-MM-dd HH-mm"));
            DocX document = DocX.Create(path);
            document.InsertParagraph(string.Format("История операций по счету за период '{0}' - '{1}'", leftDate, rightDate)).Font(new FontFamily("Times New Roman")).FontSize(16).Bold().Alignment = Alignment.center;
            document.InsertParagraph(string.Format("Для {0}, вод. удост. {1}", dataTable.Rows[0].ItemArray[0].ToString(), dataTable.Rows[0].ItemArray[1].ToString())).Font(new FontFamily("Times New Roman")).FontSize(16).Bold().Alignment = Alignment.center;            
            document.InsertParagraph();
            Table table = document.AddTable(1, 4);
            for (int i = 0; i < 4; i++)
            {
                table.Rows[0].Cells[i].RemoveParagraphAt(0);
                table.Rows[0].Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }

            table.Alignment = Alignment.center;
            table.Rows[0].Cells[0].Width = 100;
            table.Rows[0].Cells[1].Width = 50;
            table.Rows[0].Cells[2].Width = 100;
            table.Rows[0].Cells[3].Width = 400;
            table.Rows[0].Cells[0].InsertParagraph("Операция").Font(new FontFamily("Times New Roman")).FontSize(14).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].InsertParagraph("Сумма").Font(new FontFamily("Times New Roman")).FontSize(14).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[2].InsertParagraph("Дата").Font(new FontFamily("Times New Roman")).FontSize(14).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[3].InsertParagraph("Стоянка").Font(new FontFamily("Times New Roman")).FontSize(14).Bold().Alignment = Alignment.center;
            for (int i = 0; i < data_arr.Length; i++)
            {
                table.InsertRow();
                for (int j = 0; j < 4; j++)
                {
                    table.Rows[i + 1].Cells[j].RemoveParagraphAt(0);
                    table.Rows[i + 1].Cells[j].InsertParagraph(data_arr[i].ItemArray[j].ToString()).Font(new FontFamily("Times New Roman")).FontSize(14).Alignment = Alignment.left;
                    table.Rows[i + 1].Cells[j].VerticalAlignment = VerticalAlignment.Center;
                }
            }

            document.InsertTable(table);
            document.Save();
            return path;
        }

        public string CreateReportTransit(long idvk, string leftDate, string rightDate)
        {
            DataBaseCenter dataBase = DataBaseCenter.Create();
            DataTable dataTable = dataBase.GetDataTable(string.Format(
                @"Select concat(Парковки.название, ' ', Парковки.адрес),
concat(въехалДата, ' - ', выехалДата), госНомер, ИсторияПроездов.стоимость   
From ИсторияПроездов 
	JOIN Авто ON Авто.id=ИсторияПроездов.авто
	JOIN Клиенты ON Клиенты.id=Авто.клиент
    JOIN КонтактыКлиентов ON КонтактыКлиентов.клиент=Клиенты.id 
    JOIN Парковки ON Парковки.id=ИсторияПроездов.парковка
WHERE
	КонтактыКлиентов.контакт='{0}' and (ИсторияПроездов.въехалДата between '{1}' and '{2}' or ИсторияПроездов.выехалДата between '{1}' and '{2}')
ORDER BY ИсторияПроездов.въехалДата DESC", idvk, leftDate, rightDate));
            DataRow[] data_arr = dataTable.Select();
            dataTable = dataBase.GetDataTable(@"Select ФИО, серияНомер_ВУ
From Клиенты
    JOIN КонтактыКлиентов ON КонтактыКлиентов.клиент=Клиенты.id    
WHERE
	КонтактыКлиентов.контакт='{0}'
LIMIT 1");
            string path = string.Format("report {0} {1}.docx", idvk, DateTime.Now.ToString("yyyy-MM-dd HH-mm"));
            DocX document = DocX.Create(path);
            document.InsertParagraph(string.Format("История парковки за период '{0}' - '{1}'", leftDate, rightDate)).Font(new FontFamily("Times New Roman")).FontSize(16).Bold().Alignment = Alignment.center;
            document.InsertParagraph(string.Format("Для {0}, вод. удост. {1}", dataTable.Rows[0].ItemArray[0].ToString(), dataTable.Rows[0].ItemArray[1].ToString())).Font(new FontFamily("Times New Roman")).FontSize(16).Bold().Alignment = Alignment.center;
            document.InsertParagraph();
            Table table = document.AddTable(1, 4);
            for (int i = 0; i < 4; i++)
            {
                table.Rows[0].Cells[i].RemoveParagraphAt(0);
                table.Rows[0].Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }

            table.Alignment = Alignment.center;
            table.Rows[0].Cells[0].Width = 250;
            table.Rows[0].Cells[1].Width = 250;
            table.Rows[0].Cells[2].Width = 100;
            table.Rows[0].Cells[3].Width = 50;
            table.Rows[0].Cells[0].InsertParagraph("Парковка").Font(new FontFamily("Times New Roman")).FontSize(14).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].InsertParagraph("Дата").Font(new FontFamily("Times New Roman")).FontSize(14).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[2].InsertParagraph("Гос. номер").Font(new FontFamily("Times New Roman")).FontSize(14).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[3].InsertParagraph("Стоимость").Font(new FontFamily("Times New Roman")).FontSize(14).Bold().Alignment = Alignment.center;
            for (int i = 0; i < data_arr.Length; i++)
            {
                table.InsertRow();
                for (int j = 0; j < 4; j++)
                {
                    table.Rows[i + 1].Cells[j].RemoveParagraphAt(0);
                    table.Rows[i + 1].Cells[j].InsertParagraph(data_arr[i].ItemArray[j].ToString()).Font(new FontFamily("Times New Roman")).FontSize(14).Alignment = Alignment.left;
                    table.Rows[i + 1].Cells[j].VerticalAlignment = VerticalAlignment.Center;
                }
            }

            document.InsertTable(table);
            document.Save();
            return path;
        }
    }
}
