using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer: EntityBase
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }

        public Customer() { }

        public Customer(int id, string name, string phoneNumber, string password)
        {
            ID = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public Customer(string name, string phoneNumber, string password)
        {
            ID = 0;
            Name = name;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public void UpdateName(string name) 
        {
            Name = name;
        }


    }
}
