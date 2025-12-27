using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models;

class Store {
    public int Id {get; set;}
    public string Name {get; set;}
    public string Address {get; set;}
    public int AdminId {get;set;}
    [ForeignKey("AdminId")]
    public Admin Admin {get; set;}
    public List<Product> Products {get; set;}
}