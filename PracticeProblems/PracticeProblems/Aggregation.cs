using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public class Address
    {
        public string addressLine, city, state;
        public Address(string addressLine, string city, string state)
        {
            this.addressLine = addressLine;
            this.city = city;
            this.state = state;
        }
    }
    public class Employe
    {
        public int id;
        public string name;
        public Address address; 
        public Employe(int id, string name, Address address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        public void display()
        {
            Console.WriteLine(id + " " + name + " " +
              address.addressLine + " " + address.city + " " + address.state);
        }
    }

}
