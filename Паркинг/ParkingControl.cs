using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Паркинг
{
    public class ParkingControl
    {
        private List<NumberDetector> numberDetectors = new List<NumberDetector>();
        private List<Camera> cameras = new List<Camera>();
        private VkControl vkControl = new VkControl();
        private DataBaseCenter dataBase = DataBaseCenter.Create();
        private User user;

        public delegate void NewNotyf(Number number, HistoryTransit info);
        public event NewNotyf NewNotyfNumber;
        private List<string> numTemplate = new List<string>();        

        public int CameraControlCreate(User user)
        {
            this.user = user;
            int result = 0;
            try
            {
                FileStream stream = new FileStream("Настройки\\Камеры.cfg", FileMode.Open);
                byte[] byte_buff = new byte[(int)stream.Length];
                stream.Read(byte_buff, 0, (int)stream.Length);
                string str_buff = Encoding.Default.GetString(byte_buff);
                cameras = JsonConvert.DeserializeObject<List<Camera>>(str_buff);
                stream.Close();
            }
            catch { result += 2; }

            try
            {
                StreamReader reader = new StreamReader("Настройки\\ШаблоныНомеров.cfg");                
                while (!reader.EndOfStream)
                {
                    numTemplate.Add(reader.ReadLine());
                }

                reader.Close();
            }
            catch { result += 4; }

            if (!vkControl.Authorization())
            {
                result += 8;
            }
            else
            {
                DataBaseCenter dataBase = DataBaseCenter.Create();
                if (dataBase.CheckRigth(user, Rights.чатБот))
                    vkControl.vkBot.BotStart();
            }

            Task.Run(() => 
            { 
                for (int i = 0; i < cameras.Count; i++)
                {
                    cameras[i].Reconnect();
                    numberDetectors.Add(new NumberDetector(cameras[i]));
                    numberDetectors.Last().NewNumberDetect += NewNumberDetected;
                    //numberDetectors.Last().NewNumbersDetect += NewNumbersDetected;
                    numberDetectors.Last().Start(); // добавить также обработчики
                }
            });

            return result;
        }

        public void Close()
        {
            for (int i = 0; i < numberDetectors.Count; i++)
            {
                numberDetectors[i].Stop();
            }
            Thread.Sleep(1000);
            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].Disconnect();
            }
            Thread.Sleep(1000);
        }

        public List<Camera> GetCameras()
        {
            return cameras;
        }

        public List<NumberDetector> GetNumberDetector()
        {
            return numberDetectors;
        }

        private void NewNumberDetected(Number number)
        {            
            string numeral = "0123456789";
            string num = "";
            if (number.text.Length < 3) { return; }
            for (int i = 0; i < number.text.Length; i++)
            {
                if(numeral.IndexOf(number.text[i]) < 0)
                {
                    num += "A";
                }
                else
                {
                    num += "0";
                }
            }

            if (numTemplate.IndexOf(num) < 0)
            {
                number.accuracy = -1;
            }
            else
            {
                number.accuracy = 1;
            }

            HistoryTransit historyTransit = null;
            if (number.accuracy != -1)
            {
                if (number.direction == dataBase.CheckDirection(number, user))
                {
                    historyTransit = dataBase.NumberToHistory(number, user);
                }
                else
                {
                    number.accuracy = -1;
                    NewNotyfNumber(number, null);
                    return;
                }
            }

            NewNotyfNumber(number, historyTransit);
            VkNotyf(number, historyTransit);            
        }

        private void NewNumbersDetected(List<Number> number)
        {            
            string numeral = "0123456789";
            string num = "";
            for (int j = 0; j < number.Count; j++)
            {
                for (int i = 0; i < number[j].text.Length; i++)
                {
                    if (numeral.IndexOf(number[j].text[i]) < 0)
                    {
                        num += "A";
                    }
                    else
                    {
                        num += "0";
                    }
                }

                if (numTemplate.IndexOf(num) < 0)
                {
                    HistoryTransit historyTransit = null;
                    historyTransit = dataBase.NumberToHistory(number[j], user);
                    NewNotyfNumber(number[j], historyTransit);
                    VkNotyf(number[j], historyTransit);
                }                
            }
        }

        /*public async Task<HistoryTransit> AddTransit(string num, int direction, int camera)
        {
            Number number = new Number();
            number.text = num;
            if (number.direction == dataBase.CheckDirection(number, user))
            {
                number.photo = cameras[camera].GetMat();
                HistoryTransit historyTransit = null;
                historyTransit = dataBase.NumberToHistory(number, user, direction);
                NewNotyfNumber(number, historyTransit);
                VkNotyf(number, historyTransit);
                return historyTransit;
            }

            return null;
        }*/

        public void VkNotyf(Number number, HistoryTransit historyTransit)
        {
            if (vkControl.vkMessages == null)
                return;
            List<int> contacts = dataBase.GetContacts(number.text);
            foreach (int id in contacts)
            {
                vkControl.vkMessages.SendMsg(
                    id,
                    string.Format(
                        "Гос. номер <{0}>, совершен {1}{2}",
                        number.text,
                        number.direction == 1 ? "выезд" : (number.direction == -1 ? "въезд" : "проезд"),
                        (historyTransit != null && historyTransit.dateExit != "") ? ". Стоимость составила " + historyTransit.cost : ""),
                    number.photo.Bitmap);
            }
        }
    }
}
