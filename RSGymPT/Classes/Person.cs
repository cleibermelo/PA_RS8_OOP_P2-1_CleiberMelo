using System;
using Utility;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT.Interfaces;

namespace RSGymPT.Classes
{
    public abstract class Person : IPerson
    {

        #region Properties
        public int Id { get; set; } 
        public string Name { get; set; }
        public string UserName { get; set; }    
        public string Password { get; set; }
        #endregion

        #region Constructors
        public Person()
        {
            Id = 0;
            Name = "";
            UserName = "";
            Password = "";
        }

        public Person(int id, string name, string username, string password)
        {
            Id = id;
            Name = name;
            UserName = username;
            Password = password;
        }
        #endregion

        #region Methods
        public virtual void Search()
        {

        }

        public virtual void Logout()
        {

        }       

        #endregion
    }
}
