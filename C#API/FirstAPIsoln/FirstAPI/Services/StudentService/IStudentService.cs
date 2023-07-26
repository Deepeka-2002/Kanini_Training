using FirstAPI.Models;

namespace FirstAPI.Services.StudentService
{
    public interface IStudentService
    {
        List<Student> GetAllStudentDetails();

        Student? GetStudentDetailById(int id);

        List<Student> AddStudentDetail(Student stud);

        List<Student> UpdateStudentDetailById(int id, Student stud);

        List<Student>? DeleteStudentDetailById(int id);
    }
}
