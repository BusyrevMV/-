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
    public class CameraControl
    {
        private List<NumberDetector> numberDetectors = new List<NumberDetector>();
        private List<Camera> cameras = new List<Camera>();
        private VkControl vkControl = new VkControl();

        public delegate void NewNotyf(Number number, InfoOfNumber info);
        public event NewNotyf NewNotyfNumber;
        private List<string> numTemplate = new List<string>();        

        public int CameraControlCreate()
        {
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

            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].Reconnect();
                numberDetectors.Add(new NumberDetector(cameras[i]));
                numberDetectors.Last().NewNumberDetect += NewNumberDetected;
                numberDetectors.Last().NewNumbersDetect += NewNumbersDetected;
                numberDetectors.Last().Start(); // добавить также обработчики
            }

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
            // добавить поиск по базе и уведомление через вк
            NewNotyfNumber(number, null);
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
                    // добавить поиск по базе
                    NewNotyfNumber(number[j], null);
                }                
            }
        }
    }
}
