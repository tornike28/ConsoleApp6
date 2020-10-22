using System.Data.Entity;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp6
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<SubjectPoint> SubjectPoint { get; set; }

        public StudentDbContext() : base("server=DESKTOP-80NBQDT;database=grades;integrated security =true;")
        {

        }
    }
    public class Student
    {
        public int StudentId { get; set; }
        public int StudentName { get; set; }

    }
    public class Subject
    {
        public int SubjectId { get; set; }
        public int SubjectName { get; set; }
    }
    public class SubjectPoint
    {
        public SubjectPoint(
              int studentName,
              int subjectName,
              int point)
        {
            StudentName = studentName;
            SubjectName = subjectName;
            Point = point;
        }
        public int Id { get; set; }
        public int SubjectName { get; set; }
        public int StudentName { get; set; }
        public int Point { get; set; }
    }
}


