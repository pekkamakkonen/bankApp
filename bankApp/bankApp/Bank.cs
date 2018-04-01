using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace bankApp
{
    class Bank
    {
        //Fields
        private string _name;
        private List<Account> _accounts;

        //Constructors
        public Bank(string name)
        {
            _name = name;
            _accounts = new List<Account>();
        }

        public Bank(string name, List<Account> accounts)
        {
            _name = name;
            _accounts = accounts;
        }

        //Methods
        public string CreateAccount()
        {
            Random rnd = new Random();
            string accountNumber = "FI";

            for(int i = 0; i < 16; i++)
            {
                accountNumber += rnd.Next(0, 10);
            }

            _accounts.Add(new Account(accountNumber));
            return accountNumber;
        }

        public List<Transaction> GetTransactionsBetween(string accountNumber,
            DateTime startTime, DateTime endTime)
        {
            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).FirstOrDefault().GetTransactionsBetween(startTime, endTime);
        }

        public double GetBalance(string accountNumber)
        {
            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).FirstOrDefault().Balance;
        }

        public bool AddTransaction(string accountNumber, Transaction transaction)
        {
            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).First().AddTransaction(transaction);
        }
    }
}
