using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace iPresence_API_Proj.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public string ClassTitle { get; set; }

        [Required]
        public bool Status { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher TeacherFk { get; set; }
        public int TeacherId { get; set; }


        [ForeignKey("SemesterID")]
        public Semester SemesterFk { get; set; }
        public int SemesterID { get; set; }

        
    }
}

