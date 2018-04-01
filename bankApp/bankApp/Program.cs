using System;
using System.Collections.Generic;
using System.Linq;

namespace bankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("BankApp");

            //Create Bank-object
            Bank bank1 = new Bank("Bank Pihlajakatu");

            //Create Customer-objects
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Seppo", "Taalasmaa", bank1.CreateAccount()));
            customers.Add(new Customer("Ismo", "Laitela", bank1.CreateAccount()));
            customers.Add(new Customer("Kari", "Taalasmaa", bank1.CreateAccount()));

            //Generate Transactions
            for (int i = 0; i < 20; i++)
            {
                int c = rnd.Next(0, customers.Count);
                int day = rnd.Next(1, 29);
                int month = rnd.Next(1, 13);
                int year = rnd.Next(2017, 2019);
                double amount = rnd.Next(-5000, 5000);

                bank1.AddTransaction(customers[c].AccountNumber,
                    new Transaction(new DateTime(year, month, day), amount));
            }

            for (int i = 0; i < customers.Count; i++)
            {
                    Account.PrintBalance(bank1, customers[i]);
            }

            //Print Transactions between timespan

            var endTime = DateTime.Today;
            var time = new TimeSpan(24 * 30 * 6, 0, 0);
            var startTime = endTime.Date - time;

            Console.WriteLine($"Tilitapahtumat ajalta: {startTime.ToShortDateString()}- {endTime.ToShortDateString()}");

            for (int i = 0; i < customers.Count; i++)
            {
                Account.PrintTransactions(bank1.GetTransactionsBetween(customers[i].AccountNumber,
                startTime, endTime), customers[i]);
            }

            Console.WriteLine("<Enter> lopettaa!");
            Console.ReadLine();
        }
    }
}
