using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models {
    class Product {
        public dynamic this[string prop] {
            get {
                if (prop == "Name") {
                    return Name;
                } else if (prop == "Price") {
                    return Price;
                } else {
                    return null;
                }
            }
            set {
                if (prop == "Name") {
                    Name = value;
                } else if (prop == "Price") {
                    Price = int.Parse(value);
                }
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Store> Stores {get; set;}
        public List<Customer> Customers {get; set;}
    }
}
