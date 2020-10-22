 namespace ConsoleApp6.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApp6.StudentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ConsoleApp6.StudentDbContext";
        }

        protected override void Seed(ConsoleApp6.StudentDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            List<Subject> subjects = new List<Subject>()
            {
                new Subject{SubjectName=1},
                new Subject{SubjectName=2},
                new Subject{SubjectName=3 },
                new Subject{SubjectName=4},
                new Subject{SubjectName=5},
            };
            List<Student> students = new List<Student>()
            {
                new Student{StudentName=1},
                new Student{StudentName=2},
                new Student{StudentName=3},
                new Student{StudentName=4},
                new Student{StudentName=5},
            };
            context.Set<Student>().AddOrUpdate(s => s.StudentName, students.ToArray());
            context.Set<Subject>().AddOrUpdate(s => s.SubjectName, subjects.ToArray());
        }
    }
}
