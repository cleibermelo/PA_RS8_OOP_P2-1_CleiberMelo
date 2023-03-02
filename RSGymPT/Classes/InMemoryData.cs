using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT.Classes
{
    internal static class InMemoryData
    {
        #region Properties
        //public static Order[] Orders { get; set; }
        public static List<Order> Orders { get; set; }
        public static User[] Users { get; set; }
        public static Personal[] Personal { get; set; }
        #endregion

        //TODO: não implementei id automatico para os users e personal trainers.

        #region Methods

            #region Initialize
                public static void Initialize()
                {
                    Orders = GetStorageOrder();
                    Users = GetStorageUser();
                    Personal = GetStoragePersonal();
                }
            #endregion

            #region GetStorageOrder
                private static List<Order> GetStorageOrder()
                {
                    List<Order> orderData = new List<Order>
                    {

                    };
                     return orderData;
                 }
            #endregion

            #region GetStorageUser
                private static User[] GetStorageUser()
                {
                    User[] credentionsData = new User[]
                    {
                        new User{ Id = 1, Name = "Dora Nery", UserName = "dora", Password = "dora1234" },
                        new User{ Id = 2, Name = "Antonio Melo", UserName = "antonio", Password = "antonio123" }
                    };
                    return credentionsData;
                }
            #endregion

            #region GetStoragePersonal
            private static Personal[] GetStoragePersonal()
            {
                Personal[] personalData = new Personal[]
                {
                    new Personal{ Id = 1, Acronym = "VSM", Name = "Vitoria Silveira Melo", Mobile = "999999998" },
                    new Personal{ Id = 2, Acronym = "CNM", Name = "Cleiber Nery Melo", Mobile = "999999996" },
                    new Personal{ Id = 3, Acronym = "DSM", Name = "Davi Silveira Melo", Mobile = "999999997" },
                };
                return personalData;
            }
            #endregion

        #endregion
    }
}
