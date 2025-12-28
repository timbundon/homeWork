using System;

namespace SchoolControlSystem.Models;

class User {
    public int Id{ get; set; }
    public string Username{ get; set; }
    public string Password{ get; set; }
    public string FullName{ get; set; }
    public int Age{ get; set; }
    public int SchoolId{ get; set; }
    public School School{ get; set; }
}