using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolControlSystem.Models;

class Grade {
    public int Id{ get; set; }
    public string Letter{ get; set; }
    public int Year{ get; set; }
    public List<Student> Students{ get; set; }
    public int TutorId { get; set; }
    [ForeignKey("TutorId")]
    public Teacher Tutor { get; set; }
}