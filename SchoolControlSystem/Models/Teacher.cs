using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolControlSystem.Models;

class Teacher : User {
    public int HomeroomId { get; set; }
    [ForeignKey("HomeroomId")]
    public Grade Homeroom { get; set; }
    public decimal Salary { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}