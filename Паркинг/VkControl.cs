using System;
using System.Collections.Generic;
using System.Data;
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

            vkMessages = new VkMessages(vkAcc);
            vkBot = new VkBot(vkAcc, vkMessages);
            return true;
        }

        public bool Authorization()
        {            
            VkApi vkAcc = new VkApi();
            try
            {
                DataBaseCenter dataBase = DataBaseCenter.Create();
                DataTable dataTable = dataBase.GetDataTable("SELECT значение FROM Настройки WHERE название='vk'");
                if (dataTable.Rows.Count == 0)
                    return false;
                string[] str = dataTable.Rows[0].ItemArray[0].ToString().Split("|".ToCharArray());
                ulong.TryParse(str[0], out appId);
                login = str[1];
                pass = str[2];
                vkAcc.Authorize(new ApiAuthParams
                {
                    ApplicationId = appId,
                    Login = login,
                    Password = pass,
                    AccessToken = str[3],
                    Settings = Settings.All
                    // "11bd2df5a49177d00177106e29aa6dbed820b6c720c50f2ad28c09e189924e1f84570fff735d9f48bcd7c"
                });
            }
            catch
            {
                return false;
            }
                        
            vkMessages = new VkMessages(vkAcc);
            vkBot = new VkBot(vkAcc, vkMessages);
            return true;
        }
    }
}
