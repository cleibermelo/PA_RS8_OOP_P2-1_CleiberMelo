using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT.Classes;
using Utility;

namespace RSGymPT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InMemoryData.Initialize();

            Starter starter = new Starter();

            starter.Login();

            Console.ReadKey();
        }
    }
}
