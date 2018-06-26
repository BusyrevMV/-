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
        public Mat photo;
        /// <summary>
        /// -1 на парковку, 1 из парковки, 0 не известно
        /// </summary>
        public int direction = 0;
        /// <summary>
        /// -1 не точно, 1 точно, 0 не известно
        /// </summary>
        public int accuracy = 0;
    }
}
