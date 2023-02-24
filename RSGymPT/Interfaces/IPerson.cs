using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT.Interfaces
{
    public interface IPerson
    {
        #region Properties
        int Id { get; }
        string Name { get; }
        string UserName { get; }
        string Password { get; }
        bool IsToLogOut { get; }
        #endregion

        #region Methods
        void Search();
        void Logout();
        #endregion

    }
}
