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

            Starter starter = new Starter();
            //Starter user2 = new Starter();

            starter.Login();
            //user2.Login();

            Console.ReadKey();
        }
    }
}
