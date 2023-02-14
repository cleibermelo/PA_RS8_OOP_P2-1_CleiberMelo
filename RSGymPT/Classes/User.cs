using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT.Classes
{
    public class User : Person
    {

        #region Properties
        public bool LogOut { get; set; }
        #endregion

        #region Constructors

        #endregion

        #region Methods
        public User[] StorageUser()
        {
            User[] credentionsData = new User[]
            {
                new User{ Id = 1, Name = "Dora Nery", UserName = "dora", Password = "dora1234" },
                new User{ Id = 2, Name = "Antonio Melo", UserName = "antonio", Password = "antonio123" }
            };

            //credentionsData.FirstOrDefault(x => x.Id == 2);

            return credentionsData;
        }

        public override void Search()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(ApplicationData.LoggedUser.Name);
            Console.ResetColor();
            User[] storageDataUser = StorageUser();
            Utility.Utility.WriteTitle("List User");
            foreach (var item in storageDataUser.OrderBy(e => e.Name))
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, UserName: {item.UserName}");
            }
        }

        public override void Logout()
        {
            // clear user data
            this.Name = string.Empty;
            this.UserName = string.Empty;
            this.LogOut = true;

            Utility.Utility.ShowMenuStart();
        }
        #endregion
    }
}
