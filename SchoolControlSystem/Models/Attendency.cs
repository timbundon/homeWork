using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolControlSystem.Models;

class Attendency {
    public int Id{ get; set; }
    public DateTime Time{ get; set; }
    public int StudentId{get; set;}
    public Student Student{ get; set; }
    public int SubjectId{get;set;}
    public Subject Subject {get;set;}
}