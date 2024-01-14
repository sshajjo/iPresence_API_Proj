using iPresence_API_Proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iPresence_API_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ApplicationController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        [Route("GetStudents")]
        public List<Students> GetStudents()
        {
            return applicationDbContext.Students.ToList();
        }

        [HttpPost]
        [Route("AddStudents")]
        public string AddStudents(Students students)
        {
            string response = string.Empty;
            applicationDbContext.Students.Add(students);
            applicationDbContext.SaveChanges();
            return "Applicant Added";
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public string UpdateStudent(Students students)
        {
            applicationDbContext.Entry(students).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            applicationDbContext.SaveChanges();
            return "Applicant Updated";
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public string DeleteStudent(int id)
        {
            Students students = applicationDbContext.Students.Where(x => x.StudentId == id).FirstOrDefault();
            if (students == null)
            {
                return "Not Found";
            }
            applicationDbContext.Students.Remove(students);
            applicationDbContext.SaveChanges();
            return "User Deleted";
        }
        [HttpGet]
        [Route("GetTeachers")]
        public List<Teacher> GetTeachers(){
            return applicationDbContext.Teacher.ToList();

        }
         [HttpPost]
        [Route("AddTeacher")]
        public string AddTeachers(Teacher teachers){
            string response = string.Empty;
            applicationDbContext.Teacher.Add(teachers);
            applicationDbContext.SaveChanges();
            return "Teacher Added";

        }
        [HttpPut]
        [Route("UpdateTeacher")]
        public string UpdateTeacher(Teacher teachers){
            applicationDbContext.Entry(teachers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            applicationDbContext.SaveChanges();
            return "Teacher Updated";

        }
        [HttpDelete]
        [Route("DeleteTeacher")]
        public string DeleteTeacher(int id){
             Teacher teachers = applicationDbContext.Teacher.Where(x => x.TeacherId == id).FirstOrDefault();
            if (teachers == null)
            {
                return "Not Found";
            }
            applicationDbContext.Teacher.Remove(teachers);
            applicationDbContext.SaveChanges();
            return "Teacher Deleted";
        }
        [HttpGet]
        [Route("GetClassrooms")]
        public List<Class> GetClassrooms(){
            return applicationDbContext.Classes.ToList();

        }
        [HttpPost]
        [Route("AddClassroom")]
        public string AddClassrooms(Class classrooms){
            string response = string.Empty;
            applicationDbContext.Classes.Add(classrooms);
            applicationDbContext.SaveChanges();
            return "Classroom Added";
        }
        [HttpPut]
        [Route("UpdateClassroom")]
        public string UpdateTeacher(Class classrooms){
            applicationDbContext.Entry(classrooms).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            applicationDbContext.SaveChanges();
            return "Classroom Updated";
        }
         [HttpDelete]
        [Route("DeleteClassroom")]
        public string DeleteClassroom(int id){
             Class classrooms = applicationDbContext.Classes.Where(x => x.ClassId == id).FirstOrDefault();
            if (classrooms == null)
            {
                return "Not Found";
            }
            applicationDbContext.Classes.Remove(classrooms);
            applicationDbContext.SaveChanges();
            return "Classroom Deleted";
        }    

        [HttpGet]
        [Route("GetSemesters")]
        public List<Semester> GetSemesters()
        {
            return applicationDbContext.Semester.ToList();

        }
        [HttpGet]
        [Route("GetAdmin")]
        public List<Admin>GetAdmin()
        {
            return applicationDbContext.Admin.ToList();
        }
        [HttpGet]
        [Route("GetAdmin/{id}")]
        public Admin GetAdminById(int id)
        {
           return applicationDbContext.Admin.FirstOrDefault(admin => admin.AdminId == id);
        }
        [HttpGet]
        [Route("GetProgram")]
        public List<Programs> GetPrograms()
        {
            return applicationDbContext.Programs.ToList();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginAdmin)
        {
            var admin = await applicationDbContext.Admin.FirstOrDefaultAsync(a => a.Email == loginAdmin.Email && a.Password == loginAdmin.Password);
            

            if (admin == null)
                return Unauthorized();

            return Ok(new { Message = "Login successful!" });
        }
    }
}
