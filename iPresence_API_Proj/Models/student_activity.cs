using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace iPresence_API_Proj.Models
{
    public class Student_activity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StudentId")]
        public Students StudentFk { get; set; }
        public int StudentId { get; set; }

        public DateTime LoggedIn { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string AttendanceMark { get; set; }


        [ForeignKey("ClassId")]
        public Class ClassFk { get; set; }
        public int ClassId { get; set; }
    }
}

