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
        private static VkApi vkAcc;
        private LongPoolWatcher longPoolWatcher;

        private static void MessagesRecievedDelegate(VkApi owner, ReadOnlyCollection<Message> messages)
        {
            foreach (Message msg in messages)
            {
                if (msg.FromId != vkAcc.UserId)
                {
                    //обработка входящих
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
    }
}
