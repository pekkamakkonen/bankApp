using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace bankApp
{
    class Account
    {
        //Fields
        private string _accountNumber;
        private List<Transaction> _transactions;
        private double _balance;

        //Constuctors
        public Account(string accountNumber)
        {
            _accountNumber = accountNumber;
            _transactions = new List<Transaction>();
        }

        public Account(string accountNumber, double balance, List<Transaction> transactions)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _transactions = transactions;
        }

        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public double Balance { get => _balance; set => _balance = value; }

        //Methods
        public static void PrintTransactions(List<Transaction> _transactions, Customer customer)
        {
            Console.WriteLine($"Tilitapahtumat {customer.ToString()}");

            for (int i = 0; i < _transactions.Count(); i++)
            {
                Console.WriteLine("{0}\t{1}{2:0.00}",
                    _transactions[i].Date.ToShortDateString(),
                    _transactions[i].Amount >= 0 ? "+" : "",
                    _transactions[i].Amount);
            }
            Console.WriteLine("\n");
        }

        public List<Transaction> GetTransactionsBetween(DateTime startTime, DateTime endTime)
        {
            List<Transaction> res = (from transaction in _transactions
                                     where transaction.Date >= startTime && transaction.Date <= endTime
                                     orderby transaction.Date
                                     select transaction).ToList();
            return res;
        }

        public static void PrintBalance(Bank bank, Customer customer)
        {
            var balance = bank.GetBalance(customer.AccountNumber);

            if (balance >= 0)
            {
                Console.WriteLine($"{customer.ToString()} - balance: + {balance:C}");
            }
            else
            {
                Console.WriteLine($"{customer.ToString()} - balance: {balance:C}");
            }
        }

        public bool AddTransaction(Transaction transaction)
        {
            bool res = false;

            _transactions.Add(transaction);
            double balanceBeforeTransaction = Balance;
            if (_transactions.Last().Equals(transaction))
            {
                Balance += transaction.Amount;
            }
            if (Balance - transaction.Amount == balanceBeforeTransaction)
            {
                res = true;
            }
            return res;
        }
    }
}
