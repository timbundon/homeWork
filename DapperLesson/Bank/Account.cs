using System;

namespace DapperLesson.Bank;

class Account {
    public int Id {get; set;}
    public double Amount {get; set;}
    public int ClientId {get; set;}
    public Client Client {get; set;}
}