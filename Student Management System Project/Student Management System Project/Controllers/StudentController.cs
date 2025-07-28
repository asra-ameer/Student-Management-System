using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System_Project.Data;
using Student_Management_System_Project.Model;
using Student_Management_System_Project.Model.Entity;

namespace Student_Management_System_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult getStudents() {
            return Ok(dbContext.Students.ToList());
        }

        [HttpPost]
        public IActionResult addStudents(AddStudentsDto addStudentsDto)
        {
            var studentsEntity = new Student()
            {
                
                Name = addStudentsDto.Name,
                Email = addStudentsDto.Email,
                FollowingDegree = addStudentsDto.FollowingDegree,
                Address = addStudentsDto.Address,
            };
            dbContext.Students.Add(studentsEntity);
            dbContext.SaveChanges();
            return Ok(dbContext.Students);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getStudentsById(Guid id)
        {
            var student = dbContext.Students.Find(id);
            if (student is null) {
             return NotFound($"Student with id{id} is not available");
            }
            return Ok(student);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult updateStudentsById(Guid id,UpdateStudentsDto updateStudetsDto)
        {
            var student = dbContext.Students.Find(id);
            if (student is null)
            {
                return NotFound($"Student with id{id} is not available");
            }
            
            student.Name=updateStudetsDto.Name;
            student.Email=updateStudetsDto.Email;
            student.FollowingDegree=updateStudetsDto.FollowingDegree;
            student.Address=updateStudetsDto.Address;

            dbContext.SaveChanges();
            return Ok(student);
        }
        [HttpDelete]
        public IActionResult deleteStudentsById(Guid id) { 
            var student=dbContext.Students.Find(id);
            if (student is null) {
                return NotFound($"Student with id:- {id} not found");
            }
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return Ok($"Sucessfully removed student with id:- {id}");
        }



    }
}
