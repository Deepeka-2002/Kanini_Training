 using WebAPIwithEFCodeFirst.Models;
using WebAPIwithEFCodeFirst.Services.StudentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Runtime.InteropServices;

namespace WebAPIwithEFCodeFirst.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private  readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudentDetails()
        {
            return await _studentService.GetAllStudentDetails();
        }

       

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentDetailById(int id)
        {
           // var student = students.Where(s => s.StudId == id).FirstOrDefault();
           var student = await  _studentService.GetStudentDetailById(id);
            if(student is null)
            {
                return NotFound("StudId not matching");
            }

            return Ok(student);
        }
       
        
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudentDetail(Student stud)
        {
            var students = await _studentService.AddStudentDetail(stud);
            return Ok(students);
        }

       
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudentDetailById(int id, Student stud)
        {
            //var student = students.Where(s => s.StudId == id).FirstOrDefault();
             var students = await _studentService.UpdateStudentDetailById(id, stud);
            if (students is null)
            {
                return NotFound("StudId not matching");
            }
            
            return Ok(students);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudentDetailById(int id)
        {
            //var student = students.Where(s => s.StudId == id).FirstOrDefault();
            var students = await _studentService.DeleteStudentDetailById(id);
            if (students is null)
            {
                return NotFound("StudId not matching");
            }

            return Ok(students);
        }

        
    /*
       [HttpDelete]
        public async Task<ActionResult> DeleteAllStudentDetails()
        {
            
            foreach(var student in students)
                students.Remove(student);
            return Ok();
        } */

    }

}
