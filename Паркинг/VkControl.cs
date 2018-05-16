using System;
using System.Collections.Generic;
using System.IO;
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
        private ulong appId;
        private string login;
        private string pass;


        public bool Authorization(ulong appId, string login, string pass)
        {
            this.appId = appId;
            this.login = login;
            this.pass = pass;
            VkApi vkAcc = new VkApi();
            try
            {
                vkAcc.Authorize(new ApiAuthParams
                {
                    ApplicationId = appId,
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

        public bool Authorization()
        {
            StreamReader reader = new StreamReader("Настройки\\ВкБот.cfg");
            while (!reader.EndOfStream)
            {
                string[] str = reader.ReadLine().Split("=".ToCharArray());
                switch (str[0].ToLower())
                {
                    case "applicationid":
                        {
                            ulong x;
                            if (ulong.TryParse(str[1], out x)) appId = x;
                            break;
                        }
                    case "login":
                        {
                            login = str[1];
                            break;
                        }

                    case "password":
                        {
                            pass = str[1];
                            break;
                        }                    
                }
            }

            reader.Close();
            VkApi vkAcc = new VkApi();
            try
            {
                vkAcc.Authorize(new ApiAuthParams
                {
                    ApplicationId = appId,
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
