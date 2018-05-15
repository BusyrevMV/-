using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using System.IO;

namespace Паркинг
{
    public class NumberRecognition
    {        
        private Tesseract _ocr;
        private string whiteList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public NumberRecognition()
        {
            try
            {
                if (_ocr != null)
                {
                    _ocr.Dispose();
                    _ocr = null;
                }                

                _ocr = new Tesseract(".\\", "eng", OcrEngineMode.TesseractLstmCombined);
                _ocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");

            }
            catch (System.Net.WebException e)
            {
                _ocr = null;
                throw new Exception("Unable to download tesseract lang file. Please check internet connection.", e);
            }
            catch (Exception e)
            {
                _ocr = null;
                throw e;
            }
        }

        public string Recognition(UMat image)
        {            
            _ocr.SetImage(image);
            _ocr.Recognize();
            string text = (_ocr.GetUTF8Text()).ToUpper();
            for(int i = 0; i < text.Length; i++)
            {
                if (whiteList.IndexOf(text[i]) < 0)
                {
                    text.Remove(i, 1);
                }
            }

            return text;
        }
    }
}
