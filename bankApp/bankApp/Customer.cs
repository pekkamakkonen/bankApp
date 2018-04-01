using System;
using System.Collections.Generic;
using System.Text;

namespace bankApp
{
    class Customer
    {
        //Fields
        private string _firstName;
        private string _lastName;
        private string _accountNumber;

        //Constructors
        public Customer(string firstName, string lastName, string accountNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _accountNumber = accountNumber;
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }

        //Methods
        public override string ToString()
        {
            return ($"{_firstName} {_lastName} {_accountNumber}");
        }
    }
}
