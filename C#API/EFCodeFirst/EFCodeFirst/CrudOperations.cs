using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    internal class CrudOperations
    {
        public void InsertRecordsInCourseEntity()
        {
            using (var context = new WorldEventsContext())
            {
                var cour = new Course()
                {
                    CourseId = 1,
                    Name = "CSE"
                };
                context.Courses.Add(cour);
                context.SaveChanges();
            }
        }
        public void InsertRecordsInStudEntity()
        {
            using (var context = new WorldEventsContext())
            {
                var stud = new Student()
                {
                    StudentId = 11,
                    Name = "Ram"
                };
                context.Students.Add(stud);
                context.SaveChanges();
            }
        }
        public void UpdateRecordsInStudEntity()
        {
            using (var context = new WorldEventsContext())
            {
                var stud = context.Students.First<Student>(s => (s.StudentId == 11));
                stud.Age = 22;
                context.SaveChanges();
            }
        }
        public void DeleteRecordsInStudEntity()
        {
            using (var context = new WorldEventsContext())
            {
                var stud = context.Students.First<Student>();
                context.Students.Remove(stud);
                context.SaveChanges();
            }
        }

        public void ReadRecordsInStudEntity(string name)
        {
            using (var context = new WorldEventsContext())
            {
                var st = context.Students.Where(s => s.Name == name);
                foreach (var s in st)
                {
                    Console.WriteLine(s.Name);
                }
            }

        }

        public void Projection()
        {
            using ( var context = new WorldEventsContext())
            {
                var st = context.Students.Where(s => s.Name == "Ram").Select(s => new
                {
                    Student = s,
                   Name = s.Name,
                    Age = s.Age
                }).FirstOrDefault();
                foreach (var s in st)
                {
                    Console.WriteLine(s.Name + " " +s.Age);
                }
            }
        }

    }
}

