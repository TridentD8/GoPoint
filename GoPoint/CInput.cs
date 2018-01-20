using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPoint
{
    public static class CInput
    {
        public static int ReadInt(string message)
        {

            int result = -1;

            Console.WriteLine(message);

            try
            {
                result = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка ввода. Повторите ввод целого числа.");
                Console.WriteLine();
                ReadInt(message);
            }

            return result;

        }
        public static double ReadDouble(string message)
        {

            double result = -1;

            Console.WriteLine(message);

            try
            {
                result = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка ввода. Повторите ввод вещественного числа.");
                Console.WriteLine();
                ReadDouble(message);
            }

            return result;

        }
        public static List<double> ReadList(string message, string stop)
        {

            List<double> numbers = new List<double>();
            string word;

            do
            {
                Console.WriteLine(message);
                word = Console.ReadLine();
                if (word != stop)
                {
                    try
                    {
                        numbers.Add(Convert.ToDouble(word));
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ошибка ввода. Повторите ввод вещественного числа.");
                        Console.WriteLine();
                    }
                }
            } while (word != stop);

            return numbers;

        }
    }
}
