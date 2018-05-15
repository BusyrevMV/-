using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace Паркинг
{
    public class VkControl
    {
        public VkBot vkBot { get; private set; }
        public VkMessages vkMessages { get; private set; }

        public bool Authorization(ulong AppId, string login, string pass)
        {
            VkApi vkAcc = new VkApi();
            try
            {
                vkAcc.Authorize(new ApiAuthParams
                {
                    ApplicationId = AppId,
                    Login = login,
                    Password = pass,
                    Settings = Settings.All
                });
            }
            catch
            {
                return false;
            }

            vkBot = new VkBot(vkAcc);
            vkMessages = new VkMessages(vkAcc);
            return true;
        }
    }
}
