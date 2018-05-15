using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Паркинг
{
    public class Number
    {
        public IInputOutputArray licensePlateImages;
        public IInputOutputArray filteredLicensePlateImages;
        public RotatedRect licenseBox;
        public string text;
        /// <summary>
        /// -1 едет от камеры, 1 едет к камере, 0 не известно
        /// </summary>
        public int direction = 0;
    }
}
