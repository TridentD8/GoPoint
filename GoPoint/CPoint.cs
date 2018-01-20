using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace GoPoint
{
    [Serializable]
    class CPoint
    {
        public double x;
        public double y;
        public string name;

        public CPoint(double x, double y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }
}
