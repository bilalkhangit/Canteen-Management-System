using Canteen_Management_System.Core.Common;
using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.CustomerAggregate
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Cnic { get; private set; }
        public string MobileNumber { get; private set; }

        private const int CnicCharLength = 13;
        public Customer()
        {

        }
        private Customer(string name, string cnic, string mobileNumber)
        {
            Name = name;
            Cnic = Cnic;
            MobileNumber = mobileNumber;
        }

        public Customer AddCustomer(string name, string cnic, string mobileNumber)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (string.IsNullOrEmpty(cnic))
                throw new ArgumentNullException("cnic");

            if (cnic.Length < CnicCharLength)
                throw new ArgumentOutOfRangeException($"Cnic should be of {CnicCharLength} characters");

            var customer = new Customer(name, cnic, mobileNumber);

            var customerAdded = new CustomerAdded(customer);
            customer.Events.Add(customerAdded);

            return customer;
        }
    }
}
