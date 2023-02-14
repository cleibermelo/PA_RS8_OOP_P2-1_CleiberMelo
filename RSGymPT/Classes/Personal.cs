using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT.Interfaces;

namespace RSGymPT.Classes
{
    public class Personal : Person
    {
        #region Properties
        public string Acronym { get; set; }
        public string Mobile { get; set; }
        #endregion

        #region Constructors
        public Personal() : base() 
        { 
            Acronym = "";
            Mobile = "";
        }

        public Personal(int id, string name, string username, string password, string acronym, string mobile) : base(id, name, username, password) 
        { 
            Acronym = acronym;
            Mobile = mobile;    
        }
        #endregion

        #region Methods
        public Personal[] StoragePersonal()
        {
            Personal[] personalData = new Personal[]
            {
                new Personal{ Id = 1, Acronym = "VM", Name = "Vitoria Melo", Mobile = "999999998" },
                new Personal{ Id = 2, Acronym = "CM", Name = "Cleiber Melo", Mobile = "999999996" },
                new Personal{ Id = 2, Acronym = "DM", Name = "Davi Melo", Mobile = "999999997" },
            };
            return personalData;
        }
        public override void Search()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(ApplicationData.LoggedUser.Name);
            Console.ResetColor();
            Personal[] storageDataPersonal = StoragePersonal();
            Utility.Utility.WriteTitle("List Personal Trainer");
            foreach (var item in storageDataPersonal.OrderBy(e => e.Name))
            {
                Console.WriteLine($"Name: {item.Name}, Acronym: {item.Acronym}, Mobile: {item.Mobile}");
            }
        }
        #endregion
    }
}
