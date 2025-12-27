using System;

namespace ConsoleApp1.Models;

class Visit {
    public int Id {get; set;}
    public int CustomerId {get; set;}
    public Customer Customer{get; set;}
    public int StoreId{get; set;}
    public Store Store{get; set;}
}