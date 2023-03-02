using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT.Interfaces;
using Utility;

namespace RSGymPT.Classes
{
    public class User : Person
    {
        #region Methods
        public override void Search()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
            Console.ResetColor();
            User[] newuser = InMemoryData.Users;
            Utility.Utility.WriteTitle("List User");
            foreach (var item in newuser.OrderBy(e => e.Name))
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, UserName: {item.UserName}");
            }
        }
        #endregion
    }
}
