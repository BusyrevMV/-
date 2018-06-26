using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Паркинг
{
    public class NumberDetector
    {
        private Camera camera;
        private NumberSearch numberSearch = new NumberSearch();
        private NumberRecognition numberRecognition = new NumberRecognition();
        private bool isRun = true;
        private Thread thread;

        public delegate void NewNumbers(List<Number> numbers);
        public event NewNumbers NewNumbersDetect;
        public delegate void NewNumber(Number number);
        public event NewNumber NewNumberDetect;        

        public NumberDetector(Camera cam)
        {
            camera = cam;
        }              

        public void Start()
        {
            isRun = true;
            if (camera.oneNumber)
            {
                thread = new Thread(new ThreadStart(DetectorOneNum));
            }
            else
            {
                thread = new Thread(new ThreadStart(DetectorManyNum));
            }

            thread.Start();
        }

        public void Stop()
        {
            isRun = false;
        }

        public bool isRunning()
        {
            return isRun;
        }

        private void DetectorOneNum()
        {
            List<IInputOutputArray> licensePlateImagesList;
            List<IInputOutputArray> filteredLicensePlateImagesList;
            List<RotatedRect> licenseBoxList;
            List<string> text;
            Byte err;
            string lastNumber = "";


            while (isRun)
            {
                if (!camera.GetUpdateMat())
                {
                    err = 0;
                    while (!camera.GetUpdateMat() && err < 30)
                    {
                        Thread.Sleep(100);
                        err += 1;
                    }

                    if (!camera.GetUpdateMat())
                    {
                        camera.Reconnect();
                    }

                    continue;
                }

                licensePlateImagesList = new List<IInputOutputArray>();
                filteredLicensePlateImagesList = new List<IInputOutputArray>();
                licenseBoxList = new List<RotatedRect>();
                text = new List<string>();

                numberSearch.DetectLicensePlate(camera.GetMat(), licensePlateImagesList, filteredLicensePlateImagesList, licenseBoxList);
                for (int i = 0; i < filteredLicensePlateImagesList.Count; i++)
                {
                    text.Add(numberRecognition.Recognition((UMat)filteredLicensePlateImagesList[i]));
                }

                int j = 0;
                while (j < text.Count)
                {
                    if (text[j].Length < 3 && (
                        licenseBoxList[j].Center.X < camera.rectangle.X 
                        || licenseBoxList[j].Center.X > camera.rectangle.Width - camera.rectangle.X 
                        || licenseBoxList[j].Center.Y < camera.rectangle.Y 
                        || licenseBoxList[j].Center.Y > camera.rectangle.Height - camera.rectangle.Y))
                    {
                        licensePlateImagesList.RemoveAt(j);
                        filteredLicensePlateImagesList.RemoveAt(j);
                        licenseBoxList.RemoveAt(j);
                        text.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }

                if (text.Count == 1)
                {
                    Number number = new Number();
                    number.photo = camera.GetMat();
                    number.text = text[0];
                    number.licensePlateImages = licensePlateImagesList[0];
                    number.filteredLicensePlateImages = filteredLicensePlateImagesList[0];
                    number.licenseBox = licenseBoxList[0];
                    System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
                    // проверка передвижения
                    while (isRun && watch.ElapsedMilliseconds < 1000)
                    {
                        licensePlateImagesList = new List<IInputOutputArray>();
                        filteredLicensePlateImagesList = new List<IInputOutputArray>();
                        licenseBoxList = new List<RotatedRect>();
                        text = new List<string>();

                        numberSearch.DetectLicensePlate(camera.GetMat(), licensePlateImagesList, filteredLicensePlateImagesList, licenseBoxList);
                        for (int i = 0; i < filteredLicensePlateImagesList.Count; i++)
                        {
                            text.Add(numberRecognition.Recognition((UMat)filteredLicensePlateImagesList[i]));
                        }

                        j = 0;
                        while (j < text.Count)
                        {
                            if (text[j].Length < 5 && (
                                licenseBoxList[j].Center.X < camera.rectangle.X
                                || licenseBoxList[j].Center.X > camera.rectangle.Width - camera.rectangle.X
                                || licenseBoxList[j].Center.Y < camera.rectangle.Y
                                || licenseBoxList[j].Center.Y > camera.rectangle.Height - camera.rectangle.Y))
                            {
                                licensePlateImagesList.RemoveAt(j);
                                filteredLicensePlateImagesList.RemoveAt(j);
                                licenseBoxList.RemoveAt(j);
                                text.RemoveAt(j);
                            }
                            else
                            {
                                j++;
                            }
                        }
                        if (text.Count == 0) { break; }
                        if (number.text.Length < text[0].Length)
                        {
                            number.text = text[0];
                        }

                        number.direction = Convert.ToInt32(licenseBoxList[0].Center.X - number.licenseBox.Center.X);
                    }

                    if (lastNumber != number.text)
                    {                        
                        lastNumber = number.text;
                        if (camera.direction != 0)
                        {
                            number.direction = number.direction / Math.Abs(number.direction) * camera.direction;
                        }
                        else
                        {
                            number.direction = 0;
                        }
                        NewNumberDetect(number);
                    }

                    watch.Stop();
                    watch = null;
                }
            }                 
        }

        private void DetectorManyNum()
        {
            List<IInputOutputArray> licensePlateImagesList;
            List<IInputOutputArray> filteredLicensePlateImagesList;
            List<RotatedRect> licenseBoxList;
            List<string> text;
            Byte err;
            List<string> lastNums = new List<string>();
            List<DateTime> lastNumsTime = new List<DateTime>();
            List<Number> numbers;

            while (isRun)
            {
                if (!camera.GetUpdateMat())
                {
                    err = 0;
                    while (!camera.GetUpdateMat() || err < 30)
                    {
                        Thread.Sleep(100);
                        err += 1;
                    }

                    if (!camera.GetUpdateMat())
                    {
                        camera.Reconnect();
                    }

                    continue;
                }

                licensePlateImagesList = new List<IInputOutputArray>();
                filteredLicensePlateImagesList = new List<IInputOutputArray>();
                licenseBoxList = new List<RotatedRect>();
                text = new List<string>();

                numberSearch.DetectLicensePlate(camera.GetMat(), licensePlateImagesList, filteredLicensePlateImagesList, licenseBoxList);
                for (int i = 0; i < filteredLicensePlateImagesList.Count; i++)
                {
                    text.Add(numberRecognition.Recognition((UMat)filteredLicensePlateImagesList[i]));
                }

                int j = 0;
                while (j < text.Count)
                {
                    if (text[j].Length < 9 && (
                        licenseBoxList[j].Center.X < camera.rectangle.X
                        || licenseBoxList[j].Center.X > camera.rectangle.Width - camera.rectangle.X
                        || licenseBoxList[j].Center.Y < camera.rectangle.Y
                        || licenseBoxList[j].Center.Y > camera.rectangle.Height - camera.rectangle.Y))
                    {
                        licensePlateImagesList.RemoveAt(j);
                        filteredLicensePlateImagesList.RemoveAt(j);
                        licenseBoxList.RemoveAt(j);
                        text.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }

                if(text.Count == 0)
                {
                    lastNums.Clear();
                    lastNumsTime.Clear();
                }

                if (lastNums.Count > 50)
                {
                    lastNums.RemoveRange(0, 25);
                    lastNumsTime.RemoveRange(0, 25);
                }

                // проверка, не был ли данный номер зафиксирован в последние 5 сек
                numbers = new List<Number>();
                for (int i = 0; i < text.Count; i++)
                {
                    if (lastNums.IndexOf(text[i]) > 0)
                    {
                        if (Math.Abs((DateTime.Now.Second - lastNumsTime[lastNums.IndexOf(text[i])].Second)) < 5)
                        {
                            Number number = new Number();
                            number.photo = camera.GetMat();
                            number.text = text[i];
                            number.licensePlateImages = licensePlateImagesList[i];
                            number.filteredLicensePlateImages = filteredLicensePlateImagesList[i];
                            number.licenseBox = licenseBoxList[i];
                            numbers.Add(number);
                            lastNums.Add(text[i]);
                            lastNumsTime.Add(DateTime.Now);
                        }
                        else
                        {
                            lastNums.Add(text[i]);
                            lastNumsTime.Add(DateTime.Now);
                        }
                    }
                    else
                    {
                        Number number = new Number();
                        number.text = text[i];
                        number.licensePlateImages = licensePlateImagesList[i];
                        number.filteredLicensePlateImages = filteredLicensePlateImagesList[i];
                        number.licenseBox = licenseBoxList[i];
                        numbers.Add(number);
                        lastNums.Add(text[i]);
                        lastNumsTime.Add(DateTime.Now);
                    }
                }

                if (numbers.Count > 0)
                {
                    NewNumbersDetect(numbers);
                }                
            }
        }
    }
}
