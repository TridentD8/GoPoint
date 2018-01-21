using GoPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPoint
{
    class Program
    {
        static CMap map = new CMap();

        static void AddPoint()
        {
            
            double x = CInput.ReadDouble("Введите X");     
            double y = CInput.ReadDouble("Введите Y");

            Console.WriteLine("Введите имя точки");
            string name = Console.ReadLine();
            CPoint point = new CPoint(x, y, name);
            map.AddPoint(point);
        }
        static void CalcRoute()
        {
            Console.WriteLine("Выберете начальную точку маршрута");
            ShowAll();
            string namePoint = Console.ReadLine();
            CPoint startPoint = map.points.Find(i => i.name == namePoint);
            var optimalRout=map.GetOptimalRout(startPoint);
            Console.WriteLine("Оптимальный маршрут: ");
            foreach (var t in optimalRout)
                Console.WriteLine(t.name);
        }
        static void RemovePoint()
        {
            ShowAll();
            Console.WriteLine("Вы хотите удалить точку");
            string pname = Console.ReadLine();
            map.points.RemoveAll(e => e.name == pname);
        }
        static void RemoveAllPoints()
        {
            map.DeleteAllPoints();
            map.SaveToTxt();
            Console.WriteLine("Все точки удалены");
        }
        static void ShowAll()
        {
            if (map.points.Count > 0)
            {
                foreach (var p in map.points)
                    Console.WriteLine(p.name + " (" + p.x + ";" + p.y + ")");
            }
            else
            {
                Console.WriteLine("Список пуст");
            }
        }
        static void Exit()
        {
            Console.WriteLine("Пока, пока..");
            Console.WriteLine("Нажмите любую кнопку.");
        }
        static void Main(string[] args)
        {

            //TODO Сделать пункт меню -сохранения в текст
            string[] items = { "Добавить точку", "Вывести все точки","Проложить маршрут", "Удалить точку", "Очистить список" ,"Выход" };
            Action[] methods = { AddPoint, ShowAll, CalcRoute, RemovePoint, RemoveAllPoints, Exit };
            CConsoleMenu myMenu = new CConsoleMenu("Выберите пункт меню", items, 0);
            int choice;


              do
              {
                  choice = myMenu.GetUserChoice();
                  methods[choice]();
                  Console.ReadKey();
              } while (choice != 5);
        }
    }
}
