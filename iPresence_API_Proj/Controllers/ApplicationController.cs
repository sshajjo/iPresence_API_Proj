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
        public List<Teacher> GetTeachers()
        {
            return applicationDbContext.Teacher.ToList();

        }
        [HttpPost]
        [Route("AddTeacher")]
        public string AddTeachers(Teacher teachers)
        {
            string response = string.Empty;
            applicationDbContext.Teacher.Add(teachers);
            applicationDbContext.SaveChanges();
            return "Teacher Added";

        }
        [HttpPut]
        [Route("UpdateTeacher")]
        public string UpdateTeacher(Teacher teachers)
        {
            applicationDbContext.Entry(teachers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            applicationDbContext.SaveChanges();
            return "Teacher Updated";

        }
        [HttpDelete]
        [Route("DeleteTeacher")]
        public string DeleteTeacher(int id)
        {
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
        public List<Class> GetClassrooms()
        {
            return applicationDbContext.Classes.ToList();

        }
        [HttpPost]
        [Route("AddClassroom")]
        public string AddClassrooms(Class classrooms)
        {
            string response = string.Empty;
            applicationDbContext.Classes.Add(classrooms);
            applicationDbContext.SaveChanges();
            return "Classroom Added";
        }
        [HttpPut]
        [Route("UpdateClassroom")]
        public string UpdateTeacher(Class classrooms)
        {
            applicationDbContext.Entry(classrooms).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            applicationDbContext.SaveChanges();
            return "Classroom Updated";
        }
        [HttpDelete]
        [Route("DeleteClassroom")]
        public string DeleteClassroom(int id)
        {
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
        public List<Admin> GetAdmin()
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
            var student = await applicationDbContext.Students.FirstOrDefaultAsync(a => a.Email == loginAdmin.Email && a.Password == loginAdmin.Password);
            var teacher = await applicationDbContext.Teacher.FirstOrDefaultAsync(a => a.Email == loginAdmin.Email && a.Password == loginAdmin.Password);


            if (admin != null)
            {
                return Ok(new { Message = "Login successful!", user = admin });
            }
            else if (student != null)
            {
                return Ok(new { Message = "Login successful!", user = student });
            }
            else if (teacher != null)
            {
                return Ok(new { Message = "Login successful!", user = teacher });
            }

            return Unauthorized();
        }



        [HttpPost("markAttendance")]
        public async Task<IActionResult> MarkAttendance([FromBody] AttendanceRequest model)
        {
            try
            {
                // You might want to validate and sanitize the input before processing
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var studentActivity = new Student_activity
                {
                    StudentId = model.StudentId,
                    Location = model.Location,
                    AttendanceMark = model.AttendanceMark,
                    ClassId = model.ClassId,
                    LoggedIn = model.loggedIn
                };

                applicationDbContext.Student_activity.Add(studentActivity);
                await applicationDbContext.SaveChangesAsync();

                return Ok(new { Message = "Attendance marked successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getClassesBySemester")]
        public IActionResult GetClassesBySemester(int studentId)
        {
            try
            {
                // Get semesterId for the given student
                var semesterId = applicationDbContext.Students
                    .Where(s => s.StudentId == studentId)
                    .Select(s => s.SemesterID)
                    .FirstOrDefault();

                if (semesterId == 0)
                {
                    return NotFound("Student not found or missing semester information.");
                }

                // Get classes for the given semester
                var classes = applicationDbContext.Classes
                    .Where(c => c.SemesterID == semesterId && c.Status == true)
                    .Select(c => new { c.ClassId, c.ClassTitle }) // Adjust properties as needed
                    .ToList();

                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching classes: {ex.Message}");
            }
        }


        [HttpGet("getClassesForTeachers")]
        public IActionResult GetClassesByTeacher(int teacherId)
        {
            try
            {
                var classes = applicationDbContext.Classes
                    .Where(c => c.TeacherId == teacherId)
                    .Select(c => new { c.ClassId, c.ClassTitle })
                    .ToList();

                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPost("updateClassStatus")]
        public IActionResult UpdateClassStatus([FromBody] UpdateClassStatus model)
        {
            try
            {
                var classEntity = applicationDbContext.Classes.Find(model.ClassId);
                if (classEntity != null)
                {
                    classEntity.Status = model.Status;
                    applicationDbContext.SaveChanges();
                    return Ok($"Class status updated to {(model.Status ? "activated" : "deactivated")} successfully.");
                }
                else
                {
                    return NotFound(new { error = "Class not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpGet("students/{classId}")]
        public ActionResult<IEnumerable<AttendanceRequest>> GetStudentsByClassAndDate(int classId)
        {
            try
            {
                // Get the semester ID from the class table
                int semesterId = applicationDbContext.Classes.FirstOrDefault(c => c.ClassId == classId)?.SemesterID ?? 0;

                if (semesterId == 0)
                    return NotFound("Class not found");

                // Fetch students for the given semester ID
                var studentsInClass = applicationDbContext.Students
                    .Where(s => s.SemesterID == semesterId)
                    .ToList();

                // Get the current date without the time
                DateTime currentDate = DateTime.Now.Date;

                // Prepare a list to store attendance requests
                var attendanceRequestList = new List<AttendanceRequest>();

                foreach (var student in studentsInClass)
                {
                    // Check if a record exists in student_activity table for the current date, classId, and studentId
                    var existingRecord = applicationDbContext.Student_activity
                        .FirstOrDefault(sa =>
                            sa.ClassId == classId &&
                            sa.StudentId == student.StudentId &&
                            sa.LoggedIn.Date == currentDate);

                    // If no record exists or the existing record has attendanceMark as false, add a default record with attendanceMark as false
                    if (existingRecord == null || existingRecord.AttendanceMark == false)
                    {
                        attendanceRequestList.Add(new AttendanceRequest
                        {
                            ClassId = classId,
                            StudentId = student.StudentId,
                            AttendanceMark = false,
                            Location = "teacher location",
                            loggedIn = currentDate
                        });
                    }
                    // If a record exists and attendanceMark is true, skip adding this student to the list
                }

                return Ok(attendanceRequestList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        [HttpPost("attendance")]
        public ActionResult<string> UpdateAttendance(TeacherMarkedAttendance teacherMarkedAttendance)
        {
            try
            {
                // Assuming all records are to be added without checking existing records
                foreach (var attendanceRecord in teacherMarkedAttendance.AttendanceList)
                {
                    var newRecord = new Student_activity
                    {
                        ClassId = attendanceRecord.ClassId,
                        StudentId = attendanceRecord.StudentId,
                        LoggedIn = attendanceRecord.loggedIn,
                        AttendanceMark = attendanceRecord.AttendanceMark,
                        Location = "Not Needed",
                    };

                    applicationDbContext.Student_activity.Add(newRecord);
                }

                applicationDbContext.SaveChanges(); // Save changes to the database

                return Ok("Attendance updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{studentId}/attendance")]
        public async Task<ActionResult<IEnumerable<StudentsRecordByClass>>> GetStudentAttendance(int studentId)
        {
            try
            {
                var studentAttendance = await applicationDbContext.Student_activity
                    .Where(sa => sa.StudentId == studentId)
                    .GroupBy(sa => new { sa.LoggedIn.Date, sa.ClassId }) // Group by date and class
                    .Select(group => new StudentsRecordByClass
                    {
                        Date = group.Key.Date,
                        ClassId = group.Key.ClassId,
                        AttendanceMark = group.First().AttendanceMark, // Assuming attendance mark is the same for all records of the same class on the same day
                        StudentId = studentId
                    })
                    .ToListAsync();

                return Ok(studentAttendance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{classId}/classAttendance")]
        public async Task<ActionResult<IEnumerable<ClassAttendanceDto>>> GetClassAttendance(int classId)
        {
            try
            {
                var classAttendance = await applicationDbContext.Student_activity
                    .Where(sa => sa.ClassId == classId)
                    .GroupBy(sa => new { sa.LoggedIn.Date, sa.StudentId }) // Group by date and student
                    .Select(group => new ClassAttendanceDto
                    {
                        Date = group.Key.Date,
                        StudentId = group.Key.StudentId,
                        AttendanceMark = group.First().AttendanceMark,
                        FirstName = group.First().StudentFk.FirstName,
                        LastName = group.First().StudentFk.LastName
                    })
                    .ToListAsync();

                return Ok(classAttendance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
