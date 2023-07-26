using WebAPIwithEFCodeFirst.Models;
using WebAPIwithEFCodeFirst.Services.StudentService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPIwithEFCodeFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPIwithEFCodeFirst.Services.StudentService
{
    public class StudentService : IStudentService
    {
        public StudentDataContext _studentDataContext;
        public StudentService(StudentDataContext studentDataContext)
        {
            _studentDataContext = studentDataContext;
        }
        public async Task<List<Student>> GetAllStudentDetails()
        {
            var students = await _studentDataContext.Students.ToListAsync();
            return students;
        }
        
        public async Task<Student?> GetStudentDetailById(int id)
        {
            // var student = students.Where(s => s.StudId == id).FirstOrDefault();
            var student = await _studentDataContext.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }

            return student;
        }
        
        public async Task<List<Student>> AddStudentDetail(Student stud)
        {

            _studentDataContext.Students.Add(stud);
            await _studentDataContext.SaveChangesAsync();
            return await _studentDataContext.Students.ToListAsync();
        }


        public async Task<List<Student>?> UpdateStudentDetailById(int id, Student stud)
        {
            var student = await _studentDataContext.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }
            student.Name = stud.Name;
            student.City = stud.City;
            student.Pin = stud.Pin;
            await _studentDataContext.SaveChangesAsync();
            return await _studentDataContext.Students.ToListAsync();
           
        }


        public async Task<List<Student>?> DeleteStudentDetailById(int id)
        {
            var student = await _studentDataContext.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }
            _studentDataContext.Remove(student);
            await _studentDataContext.SaveChangesAsync();
            return await _studentDataContext.Students.ToListAsync();
        }    
    }
}
