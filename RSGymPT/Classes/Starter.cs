﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT.Classes
{
    public class Starter : User
    {
        public void Login()
        {
            ValidateMenuOptionsLoginAndUserCredentions();
        }
        public void ReadCredentions()
        {
            User user = new User();
            User[] userdata = user.StorageUser();
            do
            {
                Console.Write("UserName: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                User dbUser = Array.Find(userdata, e => e.UserName.Equals(username) && e.Password.Equals(password));
                if (dbUser != null && dbUser.Password.Equals(password))
                {
                    // Login success
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\nLogin Success! Welcome {dbUser.Name}\n");
                    Utility.Utility.TerminateConsole();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    ApplicationData.LoggedUser = dbUser;
                    Menu menu = new Menu();
                    menu.ShowOptionsMenuMain();
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\nLogin Error! \n");
                    Utility.Utility.TerminateConsole();
                }

                //if (ApplicationData.LoggedUser.LogOut)
                //{
                //    break;
                //}

            } while (UserName == null || Password == null);
        }

        public void ValidateMenuOptionsLoginAndUserCredentions()
        {
            string opcao;
            do
            {
                Utility.Utility.ShowMenuStart();
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        {
                            Console.Clear();
                            ReadCredentions();
                            break;
                        };
                    case "9":
                        {
                            Utility.Utility.EnvironmentExit();
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nInvalid Option!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                }
            } while (opcao != "9");
        }
    }
}