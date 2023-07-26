 using Microsoft.AspNetCore.Mvc;

namespace WebAPIwithEFCodeFirst.Services.StudentService
{

        public interface IStudentService
        {
            Task <List<Student>> GetAllStudentDetails();
        
            Task<Student>? GetStudentDetailById(int id);
        
            Task<List<Student>> AddStudentDetail(Student stud);

            Task<List<Student>?> UpdateStudentDetailById(int id, Student stud);

            Task<List<Student>?> DeleteStudentDetailById(int id);
        
        }
        

}
