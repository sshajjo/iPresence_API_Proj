namespace iPresence_API_Proj.Models
{
    public class ClassAttendanceDto
    {
            public DateTime Date { get; set; }
            public int StudentId { get; set; }
            public bool AttendanceMark { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

}
