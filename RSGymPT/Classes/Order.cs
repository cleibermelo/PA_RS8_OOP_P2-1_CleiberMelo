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
        public DateTime StartDate { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Status { get; set; }

        #endregion

     #region Constructors
        public Order() : base()
        {
            OrderId = 0;
            StartDate = DateTime.MinValue;
            StartHour = DateTime.MinValue;
            FinishedDate = DateTime.MinValue;
            IdUser = 0;
            Status = "";
        }
        public Order(int id, string acronym, string mobile, string name, string username, string password, int orderid, int iduser, DateTime startdate, DateTime starthour, DateTime finishedDate,  string status) : base(id, name, username, password, acronym, mobile)
        {
            OrderId = orderid;
            IdUser = iduser;
            StartDate = startdate;
            StartHour = starthour;
            FinishedDate = finishedDate;
            Status = status;
        }
        #endregion

     #region Methods

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

            Order newOrder = new Order { OrderId = InMemoryData.Orders.Count + 1, Acronym = personal.Acronym, StartDate = orderdate.StartDate, StartHour = orderdate.StartHour, Status = "Scheduled", IdUser = ApplicationData.LoggedUser.Id };
            InMemoryData.Orders.Add(newOrder);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nOrder {newOrder.OrderId}, {newOrder.Status} successfully!");
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
            Console.Write("\nOrder Number: ");
            if (!int.TryParse(Console.ReadLine(), out ordernumber))
            {
                Console.WriteLine("\nInvalid Format!");
                Utility.Utility.TerminateConsole();
                return;
            }

            Order dbOrder = InMemoryData.Orders.Find(o => o.OrderId == ordernumber);

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
            else if (dbOrder != null && dbOrder.Status.Equals("Canceled"))
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
            Console.Write("\nOrder Number: ");
            if (!int.TryParse(Console.ReadLine(), out ordernumber))
            {
                Console.WriteLine("\nInvalid Format!");
                Utility.Utility.TerminateConsole();
                return;
            }
            Order dbOrder = InMemoryData.Orders.Find(e => e.OrderId.Equals(ordernumber));

            if (dbOrder != null && dbOrder.Status.Equals("Scheduled"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                dbOrder.Status = "Canceled";
                //InMemoryData.Orders.Remove(dbOrder);
                Console.Write($"\nOperation {dbOrder.Status} completed successfully!");
                Utility.Utility.TerminateConsole();
            }
            else if (dbOrder != null && dbOrder.Status.Equals("Finished"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"This order cannot be canceled. Because it is Finished!");
                Utility.Utility.TerminateConsole();
            }
            else if (dbOrder != null && dbOrder.Status.Equals("Canceled"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"This order cannot be Canceled. Because it is Canceled!");
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
            Console.WriteLine($"Id: {ApplicationData.LoggedUser.Id} User: {ApplicationData.LoggedUser.Name}"); 
            Console.ResetColor();
            List<Order> dbOrder = InMemoryData.Orders.FindAll(e => e.IdUser.Equals(ApplicationData.LoggedUser.Id));
            if (dbOrder != null)
            {
                foreach (var item in dbOrder)
                {
                    Console.WriteLine($"\nOrderId: {item.OrderId} UserId: {item.IdUser} Status: {item.Status}");
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

            Console.Write("\nOrder Number: ");
            if (!int.TryParse(Console.ReadLine(), out ordernumber))
            {
                Console.WriteLine("\nInvalid Format!");
                Utility.Utility.TerminateConsole();
                return;
            }
            Order dbOrder = InMemoryData.Orders.Find(e => e.OrderId.Equals(ordernumber));
            if (dbOrder != null && dbOrder.Status.Equals("Scheduled"))
            {
                dbOrder.Status = "Finished";
                dbOrder.FinishedDate = dateclose;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"\nOperation {dbOrder.Status} completed successfully! {dbOrder.FinishedDate}");
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

     #endregion
    }
}
