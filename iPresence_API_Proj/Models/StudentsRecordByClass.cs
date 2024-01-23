namespace iPresence_API_Proj.Models
{
    public class StudentsRecordByClass
    {
        public DateTime Date { get; set; }
        public int ClassId { get; set; }
        public string ClassTitle { get; set; }
        public bool AttendanceMark { get; set; }
        public int StudentId { get; set; }
    }
}
