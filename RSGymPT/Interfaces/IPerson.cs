using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT.Classes;

namespace RSGymPT.Interfaces
{
    interface IPerson
    {

        #region Properties
        int Id { get; }
        string Name { get; }
        string UserName { get; }
        string Password { get; }

        #endregion

        #region Constructors

        #endregion

        #region Methods
        void Search();
        //void Login();
        void Logout();
        #endregion
    }
}
