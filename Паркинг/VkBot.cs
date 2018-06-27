using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace Паркинг
{
    public class VkBot
    {
        private VkApi vkAcc;
        private VkMessages vkMessages;
        private LongPoolWatcher longPoolWatcher;

        private void MessagesRecievedDelegate(VkApi owner, ReadOnlyCollection<Message> messages)
        {
            foreach (Message msg in messages)
            {
                if (msg.FromId != vkAcc.UserId)
                {
                    string[] cmd = msg.Body.ToLower().Split(Convert.ToChar(" "));
                    switch (cmd[0])
                    {
                        case "инфо":
                            {
                                DataBaseCenter dataBase = DataBaseCenter.Create();
                                try
                                {
                                    string str = dataBase.StatusAvto(msg.FromId.Value);
                                    vkMessages.SendMsg(msg.FromId.Value, str);
                                }
                                catch
                                {
                                    vkMessages.SendMsg(msg.FromId.Value, "Необходимо зарегистрировать ваш ID в системе, обратитесь к оператору!");
                                }
                                
                                break;
                            }
                        case "парковка":
                            {
                                DataBaseCenter dataBase = DataBaseCenter.Create();
                                string str = dataBase.BusyParking();
                                vkMessages.SendMsg(msg.FromId.Value, str);
                                break;
                            }
                        case "счет":
                            {
                                DataBaseCenter dataBase = DataBaseCenter.Create();
                                System.Data.DataTable dt = dataBase.GetDataTable(
                                    string.Format(
                                        "Select Клиенты.id, балансСчета FROM Клиенты JOIN КонтактыКлиентов ON КонтактыКлиентов.клиент=Клиенты.id WHERE КонтактыКлиентов.контакт='{0}'",
                                        msg.FromId.Value));
                                if (dt.Rows.Count > 0)
                                {
                                    vkMessages.SendMsg(
                                        msg.FromId.Value, 
                                        string.Format(
                                            @"Номер вашего счета: ЛС{0}
Баланс вашего счета: {1}", 
                                            dt.Rows[0].ItemArray[0].ToString(), 
                                            dt.Rows[0].ItemArray[1].ToString()));
                                }
                                else
                                {
                                    vkMessages.SendMsg(msg.FromId.Value, "Необходимо зарегистрировать ваш ID в системе, обратитесь к оператору!");
                                }

                                break;
                            }
                        case "отчет":
                            {
                                try
                                {
                                    switch (cmd[1])
                                    {
                                        case "платежи":
                                            {
                                                Report report = new Report();
                                                string path = report.CreateReportTransaction(msg.FromId.Value, cmd[2], cmd[3]);
                                                vkMessages.SendMsg(msg.FromId.Value, "Отчет готов", path);
                                                System.IO.File.Delete(path);
                                                break;
                                            }
                                        case "парковка":
                                            {
                                                Report report = new Report();
                                                string path = report.CreateReportTransit(msg.FromId.Value, cmd[2], cmd[3]);
                                                vkMessages.SendMsg(msg.FromId.Value, "Отчет готов", path);
                                                System.IO.File.Delete(path);
                                                break;
                                            }
                                        default:
                                            {
                                                ErrMsg(msg.FromId.Value, msg.Id.Value);
                                                break;
                                            }
                                    }
                                }
                                catch
                                {
                                    vkMessages.SendMsg(msg.FromId.Value, "Необходимо зарегистрировать ваш ID в системе, обратитесь к оператору!");
                                }

                                break;
                            }                        
                        default:
                            {
                                ErrMsg(msg.FromId.Value, msg.Id.Value);                                
                                break;
                            }
                    }
                }
            }
        }

        public VkBot(VkApi vkAcc, VkMessages vkMessages)
        {
            this.vkAcc = vkAcc;
            this.vkMessages = vkMessages;
        }

        public bool BotStart()
        {
            try
            {
                if (longPoolWatcher == null)
                {
                    longPoolWatcher = new LongPoolWatcher(vkAcc);
                    longPoolWatcher.NewMessages += MessagesRecievedDelegate;
                }

                longPoolWatcher.StartAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool BotStop()
        {
            try
            {
                longPoolWatcher.Stop();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void ErrMsg(long id, long answer)
        {
            vkAcc.Messages.SendAsync(new MessagesSendParams
            {
                UserId = id,
                Message = "Ваша команда не распознаная",
                ForwardMessages = new long[] { answer }
            });
        }
    }
}
