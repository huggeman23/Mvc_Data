using System.Collections.Generic;

namespace Mvc_Data.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        
        public Person(string name , int phone, string city)
        {
            Name = name;
            Phone = phone;  
            City = city;
        }
        
    }
}
