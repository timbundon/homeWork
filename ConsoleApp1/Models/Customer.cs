using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models {
    class Customer: User {
        public decimal Balance { get; set; }
        public List<Product> Products {get;set;}
    }
}
