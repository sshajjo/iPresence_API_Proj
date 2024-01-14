using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using iPresence_API_Proj.Models;

namespace iPresenceAPIProj.Models
{
    public class Program
    {
        [Key]
        public int ProgramId { get; set; }

        [Required]
        public string ProgramName { get; set; }

        public int ProgramHeadName { get; set; }

        //public int ProgramHeadId { get; set; }
           //[ForeignKey("Teacherid")]
        //public Teacher TeacherFk { get; set; }
        //public int Teacherid { get; set; }

    }
}

