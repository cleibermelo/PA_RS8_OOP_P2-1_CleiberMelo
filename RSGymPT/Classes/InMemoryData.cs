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
            //Personal personal = new Personal();
            //Order[] orderData = new Order[]
            //{
            //    new Order{ OrderId = 1, IdUser = 1, Acronym = "VSM", StartDate = new DateTime(2023, 3, 19, 09, 00, 00), Status = "Scheduled"},
            //    new Order{ OrderId = 2, IdUser = 1, Acronym = "VSM", StartDate = new DateTime(2023, 3, 18, 15, 00, 00), Status = "Finished" },
            //    new Order{ OrderId = 3, IdUser = 1, Acronym = "VSM", StartDate = new DateTime(2023, 3, 20, 21, 00, 00), Status = "Cancelled" },
            //    new Order{ OrderId = 4, IdUser = 1, Acronym = "DSM", StartDate = new DateTime(2023, 4, 19, 15, 00, 00), Status = "Scheduled"},
            //    new Order{ OrderId = 5, IdUser = 2, Acronym = "DSM", StartDate = new DateTime(2023, 4, 19, 09, 00, 00), Status = "Scheduled"},
            //    new Order{ OrderId = 6, IdUser = 2, Acronym = "DSM", StartDate = new DateTime(2023, 3, 19, 10, 00, 00), Status = "Scheduled"},
            //    new Order{ OrderId = 7, IdUser = 1, Acronym = "CNM", StartDate = new DateTime(2023, 3, 18, 15, 00, 00), Status = "Finished" },
            //    new Order{ OrderId = 8, IdUser = 2, Acronym = "VSM", StartDate = new DateTime(2023, 3, 20, 21, 00, 00), Status = "Cancelled" },
            //};
            //return orderData;

                    List<Order> orderData1 = new List<Order>
                    {
                        new Order(){ OrderId = 1, IdUser = 1, Acronym = "VSM", StartDate = new DateTime(2023, 3, 19, 09, 00, 00), Status = "Scheduled"},
                        new Order(){ OrderId = 2, IdUser = 1, Acronym = "VSM", StartDate = new DateTime(2023, 3, 18, 15, 00, 00), Status = "Finished" },
                        new Order(){ OrderId = 3, IdUser = 1, Acronym = "VSM", StartDate = new DateTime(2023, 3, 20, 21, 00, 00), Status = "Cancelled" },
                        new Order(){ OrderId = 4, IdUser = 1, Acronym = "DSM", StartDate = new DateTime(2023, 4, 19, 15, 00, 00), Status = "Scheduled"},
                        new Order(){ OrderId = 5, IdUser = 2, Acronym = "DSM", StartDate = new DateTime(2023, 4, 19, 09, 00, 00), Status = "Scheduled"},
                        new Order(){ OrderId = 6, IdUser = 2, Acronym = "DSM", StartDate = new DateTime(2023, 3, 19, 10, 00, 00), Status = "Scheduled"},
                        new Order(){ OrderId = 7, IdUser = 1, Acronym = "CNM", StartDate = new DateTime(2023, 3, 18, 15, 00, 00), Status = "Finished" },
                        new Order(){ OrderId = 8, IdUser = 2, Acronym = "VSM", StartDate = new DateTime(2023, 3, 20, 21, 00, 00), Status = "Cancelled" },
                    };
                     return orderData1;
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
