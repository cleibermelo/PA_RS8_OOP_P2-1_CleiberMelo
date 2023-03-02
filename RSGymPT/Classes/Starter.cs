using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT.Classes
{
    public class Starter : User
    {
        #region Methods

            #region Login
            public void Login()
            {
                ValidateMenuOptionsLoginAndUserCredentions();
            }
            #endregion

            #region ReadCredentions
            public void ReadCredentions()
            {
                User[] userdata = InMemoryData.Users;
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
                        dbUser.IsToLogOut = false;
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
                } while (IsToLogOut);
            }
            #endregion

            #region ValidateMenuOptionsLoginAndUserCredentions
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
            #endregion

        #endregion
    }
}
