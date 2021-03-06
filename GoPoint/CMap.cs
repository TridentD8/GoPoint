﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace GoPoint
{
    [Serializable]
    class CMap
    {
        public List<CPoint> points { get; private set; } = new List<CPoint>();
        public string fileName = "points";

        public CMap()
        {
            Load();
        }

        private double GetDistance(CPoint p1, CPoint p2)
        {
            return Math.Sqrt(Math.Pow((p2.x - p1.x), 2.0) + Math.Pow((p2.y - p1.y), 2.0));
        }

        public CPoint GetNearestPoint(CPoint p, List<CPoint> targets)
        {
            
            double[] Distances = new double[targets.Count];

            for (int i = 0; i < targets.Count; i++)
            {
                Distances[i] = GetDistance(p, targets[i]);
            }
            double minVal = Distances.Min();
            int indexMin = Array.IndexOf(Distances, minVal);

            return targets[indexMin];
        }

        public List<CPoint> GetOptimalRout(CPoint p)
        {
            List<CPoint> data = new List<CPoint>(points);
            List<CPoint> result = new List<CPoint>();
            CPoint vp = p;      
            result.Add(vp);
            data.RemoveAll(tp => tp.name == vp.name);
            do
            {  
                vp = GetNearestPoint(result.Last(),data);
                result.Add(vp);
                data.RemoveAll(tp => tp.name == vp.name);

            } while (data.Count != 0);

            return result;
        }

        public void AddPoint(CPoint p)
        {
            points.Add(p);
            Save();
        }

        public void DeleteAllPoints()
        {
            points.Clear();
            Save();
        }
        public void Save()
        {
            Serialization();
        }
        public void Load()
        {
            LoadFromDeserialization();
        }


        public void SaveToTxt()
        {
          StreamWriter sw = File.CreateText(fileName+".txt");
           foreach (var p in points)
            {
                sw.WriteLine(p.name);
                sw.WriteLine(p.x);
                sw.WriteLine(p.y);
            }
            sw.Close();

        }
        public void LoadFromTextFile()
        {
            DeleteAllPoints();
            StreamReader sr = File.OpenText(fileName+ ".txt");
            while (!sr.EndOfStream)
            {
                string name = sr.ReadLine();
                double x = Convert.ToDouble(sr.ReadLine());
                double y = Convert.ToDouble(sr.ReadLine());
                CPoint p = new CPoint(x, y, name);
                points.Add(p);
            }

            sr.Close();
        }
        private void SaveToBinary()
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(fileName + ".bin", FileMode.OpenOrCreate)))
            {
                foreach (var p in points)
                {
                    bw.Write(p.name);
                    bw.Write(p.x);
                    bw.Write(p.y);
                }
            }
        }
        private void LoadFromBinary()
        {
            using (BinaryReader br = new BinaryReader(File.Open(fileName + ".bin", FileMode.Open)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    string name = br.ReadString();
                    double x = br.ReadDouble();
                    double y = br.ReadDouble();
                    CPoint p = new CPoint(x, y, name);
                    points.Add(p);
                }
            }
        }
        private void Serialization()
        {
            BinaryFormatter binFormat = new BinaryFormatter();  
            
            using (Stream fStream = new FileStream(fileName+".dat",
               FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, points);
            }
        }

        void LoadFromDeserialization()
        {
            string fname = fileName + ".dat";         
            if (File.Exists(fname))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = File.OpenRead(fname))
                {
                    points = (List<CPoint>)binFormat.Deserialize(fStream);
                }
            }
        }
    }
}
