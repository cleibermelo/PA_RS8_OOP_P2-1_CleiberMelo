using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT.Interfaces;

namespace RSGymPT.Classes
{
    public class Personal : Person, IPersonal
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
        public override void Search()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}");
            Console.ResetColor();
            Personal[] newpersonal = InMemoryData.Personal;
            Utility.Utility.WriteTitle("List Personal Trainer");
            foreach (var item in newpersonal.OrderBy(e => e.Name))
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name}, Acronym: {item.Acronym}, Mobile: {item.Mobile}");
            }
        }
        #endregion
    }
}
