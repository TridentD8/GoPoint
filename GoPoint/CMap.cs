using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPoint
{
    class CMap
    {
        public List<CPoint> points { get; private set; } = new List<CPoint>();
        public string fileName = "points.txt";

        public CMap()
        {
            LoadFromTextFile();
        }
        public void LoadFromTextFile()
        {
            DeleteAllPoints();
            StreamReader sr = File.OpenText(fileName);
            while (!sr.EndOfStream)
            {
                string name = sr.ReadLine();
                double x= Convert.ToDouble(sr.ReadLine());
                double y = Convert.ToDouble(sr.ReadLine());
                CPoint p = new CPoint(x, y, name);
                points.Add(p);
            }

            sr.Close();
        }
        public void AddPoint(CPoint p)
        {
            points.Add(p);
            SaveToTxt();
        }

        public void DeleteAllPoints()
        {
            points.Clear();
        }

        public void SaveToTxt()
        {
          StreamWriter sw = File.CreateText(fileName);
           foreach (var p in points)
            {
                sw.WriteLine(p.name);
                sw.WriteLine(p.x);
                sw.WriteLine(p.y);
            }
            sw.Close();

        }

    }
}
