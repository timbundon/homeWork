using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolControlSystem.Models;

class Student : User {
    public int HomeroomId { get; set; }
    public Grade Homeroom { get; set; }
    public List<Subject> Subjects { get; set; }

}