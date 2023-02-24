using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT.Interfaces
{
    public interface IPersonal
    {
        #region Properties
        string Acronym { get; }
        string Mobile { get; }
        #endregion
    }
}
