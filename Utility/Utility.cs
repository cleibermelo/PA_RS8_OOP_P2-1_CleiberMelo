using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Utility
    {
        public static void WriteTitle(string title)
        {
            DateTime data = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"RSGymPT - {data} \n");
            Console.ResetColor();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(title.ToUpper());
            Console.WriteLine(new string('-', 50));
        }
        public static void TerminateConsole()
        {
            Console.ReadKey();
            Console.Clear();
        }

        public static void EnvironmentExit()
        {
            Environment.Exit(0);
        }
        public static void ShowMenuStart()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            DateTime data = DateTime.Now;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Welcome to RSGymPT - {data} \n");
            Console.ResetColor();
            string[] menu = new string[] { "| 0 | Login\n", "| 9 | Exit"};
            //Console.WriteLine($"Login:\n");
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
            Console.Write("\nSelecione Opção: ");
        }

        public static void ShowMenuMain()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            DateTime data = DateTime.Now;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Menu Main - {data} \n");
            Console.ResetColor();
            string[] menu = new string[] { "| 1 | Order", "| 2 | Personal Trainer", "| 3 | User"};           
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
          // Console.Write("\nOption: ");
        }
        public static void ShowMenuOrder()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string[] menuOrder = new string[] { "| 1 | Create", "| 2 | Update", "| 3 | Delete", "| 4 | Search", "| 5 | Close", "| 6 | Back"};
            DateTime data = DateTime.Now;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Menu Order - {data}");
            Console.ResetColor();
            foreach (var item in menuOrder)
            {
                Console.WriteLine(item);
            }
           Console.Write("\nOption: ");
        }

        public static void ShowMenuPersonal()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string[] menuPersonal = new string[] { "| 1 | Consult", "| 2 | Back" };
            DateTime data = DateTime.Now;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Menu Personal Trainer - {data}");
            Console.ResetColor();
            foreach (var item in menuPersonal)
            {
                Console.WriteLine(item);
            }
            Console.Write("\nOption: ");
        }
        public static void ShowMenuUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            string[] menuUser = new string[] { "| 1 | Consult", "| 2 | Back", "| 9 | Logout" };
            DateTime data = DateTime.Now;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Menu User - {data}");
            Console.ResetColor();
            foreach (var item in menuUser)
            {
                Console.WriteLine(item);
            }
            Console.Write("\nOption: ");
        }
    }
}
