using FirstAPI.Models;
using FirstAPI.Services.StudentService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Services.StudentService
{
    public class StudentService : IStudentService
    {

        private static List<Student> students = new List<Student>
        {
                new Student {StudId = 1, Name = "Ram", City="Chennai", Pin=643738},
                new Student {StudId =2, Name ="Raj", City="bengalore", Pin=632272},
                new Student { StudId = 3, Name = "Rahul", City = "Mumbai", Pin = 732833 },
                new Student { StudId = 4, Name = "Sai", City = "Andhra", Pin = 843834 }
        };

        
        public List<Student> GetAllStudentDetails()
        {
            return students;
        }

        public Student? GetStudentDetailById(int id)
        {
            // var student = students.Where(s => s.StudId == id).FirstOrDefault();
            var student = students.Find(s => s.StudId == id);
            if (student is null)
            {
                return null;
            }

            return student;
        }

        public List<Student> AddStudentDetail(Student stud)
        {

            students.Add(stud);
            return students;
        }

        public List<Student>? UpdateStudentDetailById(int id, Student stud)
        {
            var student = students.Find(s => s.StudId == id);
            if (student is null)
            {
                return null;
            }
            student.Name = stud.Name;
            student.City = stud.City;
            student.Pin = stud.Pin;

            return students;
        }

        public List<Student>? DeleteStudentDetailById(int id)
        {
            var student = students.Find(s => s.StudId == id);
            if (student is null)
            {
                return null;
            }
            students.Remove(student);
            return students;
        }
    
    }
}
