using System;
using Utility;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT.Interfaces;
using Microsoft.SqlServer.Server;

namespace RSGymPT.Classes
{
    public class Menu
    {

        #region Properties
        public string Option { get; set; }
        #endregion

        #region Methods

        #region ShowOptionsMenuMain
        public void ShowOptionsMenuMain()
        {
            while (!ApplicationData.LoggedUser.IsToLogOut)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                Utility.Utility.ShowMenuMain();
                Console.Write("\nSelect Option: ");
                Option = Console.ReadLine();
                if ((Option == "1") || (Option == "2") || (Option == "3"))
                {
                    Console.Clear();
                    ShowMenuRun();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nInvalid Option!");
                    Utility.Utility.TerminateConsole();
                }
            }
        }
        #endregion

        #region ShowMenuRun
        public void ShowMenuRun()
        {

            switch (Option)
            {
                case "1":
                    {
                        string option;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                        Utility.Utility.ShowMenuOrder();
                        do
                        {
                            option = Console.ReadLine();
                            switch (option)
                            {
                                case "1":
                                    {
                                        Console.Clear();
                                        Order order = new Order();
                                        order.CreateOrder();
                                        break;
                                    }
                                case "2":
                                    {
                                        Console.Clear();
                                        Order order = new Order();
                                        order.Update();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                        Utility.Utility.ShowMenuOrder();
                                        break;
                                    }
                                case "3":
                                    {
                                        Console.Clear();
                                        Order order = new Order();
                                        order.Delete();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                        Utility.Utility.ShowMenuOrder();
                                        break;
                                    }
                                case "4":
                                    {
                                        Console.Clear();
                                        Order order = new Order();
                                        order.Search();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                        Utility.Utility.ShowMenuOrder();
                                        break;
                                    }
                                case "5":
                                    {
                                        Console.Clear();
                                        Order order = new Order();
                                        order.CloseOrder();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                        Utility.Utility.ShowMenuOrder();
                                        break;
                                    }
                                case "6":
                                    {
                                        break;
                                    }
                                default:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\nInvalid Option!");
                                    Utility.Utility.TerminateConsole();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                    Utility.Utility.ShowMenuOrder();
                                    break;
                            }
                        } while (option != "6");
                        Console.Clear();
                        break;
                    };
                case "2":
                    {
                        string option;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                        Utility.Utility.ShowMenuPersonal();

                        do
                        {
                            option = Console.ReadLine();
                            if (option == "1")
                            {
                                Console.Clear();
                                Personal personal = new Personal();
                                personal.Search();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("\nType 1 to return: ");
                                string backMenu = Console.ReadLine();

                                if (backMenu == "1")
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                    Utility.Utility.ShowMenuPersonal();
                                }
                                else if (backMenu != "1")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\nInvalid Option!");
                                    Utility.Utility.TerminateConsole();
                                    break;
                                }
                            }
                            else if (option == "2")
                            {
                                break;
                            }
                            else if (option != "2")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nInvalid Option!");
                                Utility.Utility.TerminateConsole();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                Utility.Utility.ShowMenuPersonal();
                            }
                        } while (option != "2");
                        Console.Clear();
                        break;
                    }
                case "3":
                    {
                        string option;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                        Utility.Utility.ShowMenuUser();

                        do
                        {
                            option = Console.ReadLine();
                            if (option == "1")
                            {
                                Console.Clear();
                                User user = new User();
                                user.Search();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("\nType 1 to return: ");
                                string backMenu = Console.ReadLine();
                                if (backMenu == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                    Utility.Utility.ShowMenuUser();
                                }
                                else if (backMenu != "1")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\nInvalid Option!");
                                    Utility.Utility.TerminateConsole();
                                    break;
                                }
                            }
                            else if (option == "9")
                            {
                                ApplicationData.LoggedUser.Logout();
                                break;
                            }
                            else if (option == "2")
                            {
                                break;
                            }
                            else if (option != "2")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nInvalid Option!");
                                Utility.Utility.TerminateConsole();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
                                Utility.Utility.ShowMenuUser();
                            }
                        }
                        while (option != "2");
                        Console.Clear();
                        break;
                    }
            }
            #endregion

            #endregion
        }
    }
}
