using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    class Customer
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string passport { get; set; }
        public string place { get; set; }

        public Customer()
        {
            surname = GetCustomer("Surname");
            name = GetCustomer("Name");
            passport = GetCustomer("PassportNum");
            place = GetCustomer("Place");
        }

        string GetCustomer(string key)
        {
            return CustomerInfoReader.GetData(key).Value;
        }

    }
}
