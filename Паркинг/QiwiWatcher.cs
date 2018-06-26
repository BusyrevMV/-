using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Паркинг
{
    public class QiwiWatcher
    {
        private string qiwiUrl = "https://edge.qiwi.com/payment-history/v2/persons/{0}/payments?startDate={1}&endDate={2}&operation=IN&rows=50";
        private string phone;
        private string token;
        private readonly WebClient webClient = new WebClient
        {
            Encoding = Encoding.UTF8
        };
        public delegate void QiwiHistoryDelegate(QiwiHistory history);
        public bool Active { get; private set; }
        private Timer watchTimer;
        public event QiwiHistoryDelegate NewPayment;

        public QiwiWatcher()
        {
            DataBaseCenter dataBase = DataBaseCenter.Create();
            DataTable dataTable = dataBase.GetDataTable("SELECT значение FROM Настройки WHERE название='qiwi'");
            string[] str = dataTable.Rows[0].ItemArray[0].ToString().Split("|".ToCharArray());            
            phone = str[0];
            token = str[1];
        }

        private QiwiHistory GetQiwiHistory(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }

            webClient.Headers["Authorization"] = $"Bearer {token}";
            string url = string.Format(
            qiwiUrl,
            phone,
            dateTime.Value.AddMinutes(-2).ToString("yyyy-MM-ddTHH:mm:sszzz").Replace(":", "%3A").Replace("+", "%2B"),
            DateTime.Now.AddMinutes(-0.5).ToString("yyyy-MM-ddTHH:mm:sszzz").Replace(":", "%3A").Replace("+", "%2B"));
            var response = webClient.DownloadStringTaskAsync(url);
            response.Wait();
            return JsonConvert.DeserializeObject<QiwiHistory>(response.Result);
        }

        private Task<QiwiHistory> GetQiwiHistoryyAsync(DateTime? dateTime = null)
        {
            return Task.Run(() => { return GetQiwiHistory(dateTime); });
        }

        private async void watchAsync(object state)
        {
            var qiwiHistory = await GetQiwiHistoryyAsync();
            if (qiwiHistory.history.Count > 0)
            {
                NewPayment(qiwiHistory);
            }
        }

        public async void StartAsync()
        {
            if (Active)
            {
                return;
            }

            DataBaseCenter dataBase = DataBaseCenter.Create();
            DataTable dataTable = dataBase.GetDataTable("SELECT дата FROM ИсторияТранзакций WHERE номерТранзакции is not null and операция='приход' ORDER BY дата DESC LIMIT 1");
            if (dataTable.Rows.Count > 0)
            {
                DateTime dateTime = DateTime.ParseExact(dataTable.Rows[0].ItemArray[0].ToString(), "yyyy-MM-dd HH:mm:ss", null);
                var qiwiHistory = await GetQiwiHistoryyAsync(dateTime);
                if (qiwiHistory.history.Count > 0)
                {
                    NewPayment(qiwiHistory);
                }
            }            

            Active = true;
            watchTimer = new Timer(new TimerCallback(watchAsync), null, 1000, Timeout.Infinite);
        }

        public void Stop()
        {
            if (watchTimer != null)
                watchTimer.Dispose();
            Active = false;
            watchTimer = null;
        }
    }
}
