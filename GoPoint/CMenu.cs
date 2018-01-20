using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPoint
{
    class CConsoleMenu
    {
        string menuHeader;
        string [] menuItms;
        int menuCounter;

        public CConsoleMenu(string header, string[] items)
        {
            this.menuHeader = header;
            this.menuItms = items;
        }

        public CConsoleMenu(string header, string[] items, int current)
        {
            this.menuHeader = header;
            this.menuItms = items;
            menuCounter = current;
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(menuHeader);
            Console.WriteLine("-----------------------------------");
            for (int i = 0; i < menuItms.Length; i++)
            {
                if (i == menuCounter)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(menuItms[i]);
                    Console.ResetColor();
                   
                } else
                Console.WriteLine(menuItms[i]);
            }
            Console.WriteLine("-----------------------------------");
        }

        public int GetUserChoice()
        {
            ConsoleKeyInfo key;
            do
            {
                PrintMenu();
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    menuCounter--;
                    if (menuCounter == -1)
                    {
                        menuCounter = menuItms.Length - 1;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    menuCounter++;
                    if (menuCounter == menuItms.Length)
                    {
                        menuCounter = 0;
                    }
                }

            } while (key.Key != ConsoleKey.Enter);
            return menuCounter;
        }
    }
}
