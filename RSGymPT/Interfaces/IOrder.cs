using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT.Classes;

namespace RSGymPT.Interfaces
{
    public interface IOrder
    {
        #region Properties
        int OrderId { get; set; }
        int IdUser { get; set; }
        //string CodPT { get; set; }
        DateTime StartDate { get; set; }
        string Status { get; set; }
        #endregion

        #region Methods
        Order CreateOrder();
        void Update();
        void Delete();
        void Search();
        void CloseOrder();
        #endregion
    }
}
