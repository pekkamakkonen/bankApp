using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace bankApp
{
    class Transaction
    {
        //Fields
        private DateTime _date;
        private double _amount;

        //Contructors
        public Transaction(DateTime date, double amount)
        {
            _date = date;
            _amount = amount;
        }

        public DateTime Date { get => _date; set => _date = value; }
        public double Amount { get => _amount; set => _amount = value; }
    }
}
