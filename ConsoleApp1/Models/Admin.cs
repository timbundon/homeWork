using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models {
    class Admin: User {
        public int? StoreId {get; set;}
        [ForeignKey("StoreId")]
        public Store? Store {get;set;}
    }
}
