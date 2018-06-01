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
        private LongPoolWatcher longPoolWatcher;

        private void MessagesRecievedDelegate(VkApi owner, ReadOnlyCollection<Message> messages)
        {
            foreach (Message msg in messages)
            {
                if (msg.FromId != vkAcc.UserId)
                {
                    string[] cmd = msg.Body.Split(Convert.ToChar(" "));
                    switch (cmd[0])
                    {
                        case "инфо":
                            {
                                break;
                            }
                        case "свободно":
                            {
                                break;
                            }
                        case "отчет":
                            {
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

        public VkBot(VkApi value)
        {
            vkAcc = value;
        }

        public bool BotStart()
        {
            try
            {
                if (longPoolWatcher == null)
                {
                    LongPoolWatcher longPoolWatcher = new LongPoolWatcher(vkAcc);
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
