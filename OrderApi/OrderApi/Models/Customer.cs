using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Customer()
        {
            CustomerId = Guid.NewGuid().ToString();
        }

        public Customer(string name) : this()
        {
            CustomerName = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   CustomerId == customer.CustomerId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CustomerId);
        }
    }
}
