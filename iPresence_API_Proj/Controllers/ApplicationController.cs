using iPresence_API_Proj.Models;
using Microsoft.AspNetCore.Mvc;

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
            Students students = applicationDbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            if (students == null)
            {
                return "Not Found";
            }
            applicationDbContext.Students.Remove(students);
            applicationDbContext.SaveChanges();
            return "User Deleted";
        }
    }
}
