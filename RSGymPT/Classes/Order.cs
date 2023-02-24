using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RSGymPT.Interfaces;

namespace RSGymPT.Classes
{
    public class Order : Personal, IOrder
    {
     #region Properties
        public int OrderId { get; set; }
        public int IdUser { get; set; }
       // public string CodPT { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartHour { get; set; }
        public string Status { get; set; }

        #endregion

     #region Constructors
        public Order() : base()
        {
            OrderId = 0;
            StartDate = DateTime.MinValue;
            StartHour = DateTime.MinValue;
            IdUser = 0;
            Status = "";
        }
        public Order(int id, string acronym, string mobile, string name, string username, string password, int orderid, int iduser, DateTime startdate, DateTime starthour, string status) : base(id, name, username, password, acronym, mobile)
        {
            OrderId = orderid;
            IdUser = iduser;
            StartDate = startdate;
            StartHour = starthour;
            Status = status;
        }
        #endregion

     #region Methods

        #region Lixo
        //public Order[] StorageOrder()
        //{
        //    User user = new User();
        //    Personal personal = new Personal();
        //    Order[] orderData = new Order[]
        //    {
        //        new Order{ Id = CreateOrderID(), IdUser = 1, CodPT = personal.Acronym, StartDate = new DateTime(2023, 3, 19, 09, 00, 00), Status = "Scheduled"},
        //        new Order{ Id = CreateOrderID(), IdUser = 1, CodPT = personal.Acronym, StartDate = new DateTime(2023, 3, 18, 15, 00, 00), Status = "Finished" },
        //        new Order{ Id = CreateOrderID(), IdUser = 1, CodPT = personal.Acronym, StartDate = new DateTime(2023, 3, 20, 21, 00, 00), Status = "Cancelled" },
        //        new Order{ Id = CreateOrderID(), IdUser = 1, CodPT = personal.Acronym, StartDate = new DateTime(2023, 4, 19, 15, 00, 00), Status = "Scheduled"},
        //        new Order{ Id = CreateOrderID(), IdUser = 2, CodPT = personal.Acronym, StartDate = new DateTime(2023, 4, 19, 09, 00, 00), Status = "Scheduled"},
        //        new Order{ Id = CreateOrderID(), IdUser = 2, CodPT = personal.Acronym, StartDate = new DateTime(2023, 3, 19, 10, 00, 00), Status = "Scheduled"},
        //    };

        //    return orderData;
        //}
        #endregion

        #region Create Order
        public Order CreateOrder()
        {
            Personal personal = new Personal();
            Order orderdate = new Order();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}"); ;
            Console.ResetColor();
            Console.Write("\nPersonal trainer acronym: ");
            string personalTrainerAcronym = Console.ReadLine();            
            Personal dbPersonal = Array.Find(InMemoryData.Personal, e => e.Acronym.Equals(personalTrainerAcronym));
            if (dbPersonal != null)
            {
                dbPersonal.Acronym = personalTrainerAcronym;
                try
                {
                    Console.Write("\nDate: ");
                    orderdate.StartDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("\nHour: ");
                    orderdate.StartHour = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid Format!");
                    return orderdate;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\nThis acronym does not exist!");
                return orderdate;
            }

            Order newOrder = new Order { OrderId = InMemoryData.Orders.Count + 1, Acronym = personal.Acronym, StartDate = orderdate.StartDate, StartHour = orderdate.StartHour };
            //var addorderlist = InMemoryData.Orders.ToList();
            //addorderlist.Add(newOrder);
            //InMemoryData.Orders.Append(newOrder);
            InMemoryData.Orders.Add(newOrder);

            //InMemoryData.Orders.Append(newOrder);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nOrder {newOrder.OrderId}, create witch success!");
            Utility.Utility.TerminateConsole();
            Utility.Utility.ShowMenuOrder();
            return newOrder;
        }
        #endregion

        #region Update
        public void Update()
        {
            int ordernumber = 0;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}"); ;
            Console.ResetColor();
            //try
            //{
            //    Console.Write("\nOrder Number: ");
            //    ordernumber = int.Parse(Console.ReadLine());
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("\nInvalid Format!");
            //    Utility.Utility.TerminateConsole();
            //    return;
            //}
            Console.Write("Order Number: ");
            if (!int.TryParse(Console.ReadLine(), out ordernumber))
            {
                Console.WriteLine("\nInvalid Format!");
                Utility.Utility.TerminateConsole();
                return;
            }
            //bool existe = false;
            //existe = InMemoryData.Orders.Any(x => x.OrderId == ordernumber);

            Order dbOrder = InMemoryData.Orders.Find(o => o.OrderId == ordernumber);

           // Order dbOrder = Array.Find(InMemoryData.Orders, e => e.OrderId.Equals(ordernumber));
            if (dbOrder != null && dbOrder.Status.Equals("Scheduled"))
            {
                try
                {
                    Console.Write($"\nNew Date: ");
                    StartDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("\nNew Hour: ");
                    StartHour = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid Format!");
                    Utility.Utility.TerminateConsole();
                    return;
                }
                Console.Write("\nPersonal Trainer Acronym: ");
                string personalTrainerAcronym = Console.ReadLine();
                Personal dbPersonal = Array.Find(InMemoryData.Personal, e => e.Acronym.Equals(personalTrainerAcronym));
                if (dbPersonal != null)
                {
                    dbPersonal.Acronym = personalTrainerAcronym;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\nThis acronym does not exist!");
                    Utility.Utility.TerminateConsole();
                    return;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"\nNew appointment for: {StartDate.ToShortDateString()} às {StartHour.ToShortTimeString()}");
                Utility.Utility.TerminateConsole();
            }
            else if (dbOrder != null && dbOrder.Status.Equals("Finished"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"This order cannot be changed. Because it is Finished!");
                Utility.Utility.TerminateConsole();
            }
            else if (dbOrder != null && dbOrder.Status.Equals("Cancelled"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"This order cannot be changed. Because it is Canceled!");
                Utility.Utility.TerminateConsole();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\nThis order does not exist!");
                Utility.Utility.TerminateConsole();
            }
        }
        #endregion

        #region Delete
        public void Delete()
        {
            int ordernumber = 0;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}"); ;
            Console.ResetColor();
            Console.Write("Order Number: ");
            if (!int.TryParse(Console.ReadLine(), out ordernumber))
            {
                Console.WriteLine("\nInvalid Format!");
                Utility.Utility.TerminateConsole();
                return;
            }
            Order dbOrder = InMemoryData.Orders.Find(e => e.OrderId.Equals(ordernumber));
            //Order dbOrder = Array.Find(InMemoryData.Orders, e => e.OrderId.Equals(ordernumber));
            if (dbOrder != null && dbOrder.Status.Equals("Scheduled"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                dbOrder.Status = "DELETE";
                Console.Write($"\nOperation {dbOrder.Status} completed successfully!");
                Utility.Utility.TerminateConsole();
            }
            else if (dbOrder != null && dbOrder.Status.Equals("Finished"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"This order cannot be deleted. Because it is Finished!");
                Utility.Utility.TerminateConsole();
            }
            else if (dbOrder != null && dbOrder.Status.Equals("Cancelled"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"This order cannot be deleted. Because it is Canceled!");
                Utility.Utility.TerminateConsole();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\nThis order does not exist!");
                Utility.Utility.TerminateConsole();
            }
        }
        #endregion

        #region Search
        public override void Search()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}"); ;
            Console.ResetColor();
            List<Order> dbOrder = InMemoryData.Orders.FindAll(e => e.IdUser.Equals(ApplicationData.LoggedUser.Id));
            //Order[] dbOrder = Array.FindAll(InMemoryData.Orders, e => e.IdUser.Equals(ApplicationData.LoggedUser.Id));
            if (dbOrder != null)
            {
                foreach (var item in dbOrder)
                {
                    Console.WriteLine($"OrderId: {item.OrderId} UserId: {item.IdUser}");
                }
                Utility.Utility.TerminateConsole();
            }
        }
        #endregion

        #region Close Order
        public void CloseOrder()
        {
            int ordernumber = 0;
            DateTime dateclose = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}"); ;
            Console.ResetColor();

            Console.Write("Order Number: ");
            if (!int.TryParse(Console.ReadLine(), out ordernumber))
            {
                Console.WriteLine("\nInvalid Format!");
                Utility.Utility.TerminateConsole();
                return;
            }
            //try
            //{
            //    Console.Write("Order Number: ");
            //    ordernumber = int.Parse(Console.ReadLine());
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("\nInvalid Format!");
            //    Utility.Utility.TerminateConsole();
            //    return;
            //}
            Order dbOrder = InMemoryData.Orders.Find(e => e.OrderId.Equals(ordernumber));
            //Order dbOrder = Array.Find(InMemoryData.Orders, e => e.OrderId.Equals(ordernumber));
            if (dbOrder != null && dbOrder.Status.Equals("Scheduled"))
            {
                dbOrder.Status = "FINISH";
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"\nOperation {dbOrder.Status} completed successfully! {dateclose}");
                Utility.Utility.TerminateConsole();
            }
            else if (dbOrder != null && dbOrder.Status.Equals("Finished"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"This order cannot be Finished. Because it is Finished!");
                Utility.Utility.TerminateConsole();
            }
            else if (dbOrder != null && dbOrder.Status.Equals("Cancelled"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"This order cannot be Finished. Because it is Canceled!");
                Utility.Utility.TerminateConsole();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\nThis order does not exist!");
                Utility.Utility.TerminateConsole();
            }
        }
        #endregion

        #region Generate Id
        public int GenerateId()
        {
            return OrderId++;
        }
        #endregion

     #endregion
    }
}
