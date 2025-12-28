using System;

namespace SchoolControlSystem.Models;

class School {
    public int Id{ get; set; }
    public string Name{ get; set; }
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers{ get; set; }
    public List<Grade> Grades{ get; set; }
    public string Address{ get; set; }
}