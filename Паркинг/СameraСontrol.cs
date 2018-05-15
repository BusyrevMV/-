using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Паркинг
{
    class СameraСontrol
    {
        private List<NumberDetector> numberDetectors;
        private List<Camera> cameras;

        public delegate void NewNotyf(Number number);
        public event NewNotyf NewNotyfNumber;
    }
}
