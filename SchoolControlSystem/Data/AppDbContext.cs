using System;
using Microsoft.EntityFrameworkCore;
using SchoolControlSystem.Models;

namespace ConsoleApp1.Data {
    class AppDbContext: DbContext {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<School> Schools { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5433; Username=postgres; Password=1234; Database=SchoolcontrolSystem");
        }
    }
}
