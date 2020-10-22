using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {

            string csvContents = File.ReadAllText(@"C:\Users\SMART 34\Desktop\text.txt");
            List<CsvRead> itemsFromCsv = new List<CsvRead>();

            foreach (var line in csvContents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Skip(1))
            {
                var lineSplitted = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                CsvRead item = new CsvRead();
                item.StudentName = int.Parse(lineSplitted[0]);
                item.SubjectName = int.Parse(lineSplitted[1]);
                item.Point = int.Parse(lineSplitted[2]);
                itemsFromCsv.Add(item);
            }

            int CountTrue = 0;
            int CountFalse = 0;
            using (var db = new StudentDbContext())
            {
                foreach (var item in itemsFromCsv)
                {
                    var student = db.Student
                        .FirstOrDefault(s => s.StudentName == item.StudentName);
                    var subject = db.Subject
                        .FirstOrDefault(s => s.SubjectName == item.SubjectName);
                    if (student!=null && subject!=null)
                    {
                        db.Set<SubjectPoint>().Add(new SubjectPoint(student.StudentName, subject.SubjectName, item.Point));
                        CountTrue++;
                        db.SaveChanges();
                    }
                    else
                    {
                        CountFalse++;
                    }
                }
            }
            Console.WriteLine("{0} Records returned, But there was no info about {1} Students", CountTrue, CountFalse) ;
        }
    }
}


