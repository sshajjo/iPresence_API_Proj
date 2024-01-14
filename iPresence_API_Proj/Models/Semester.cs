using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace iPresence_API_Proj.Models
{
    public class Semester
    {
        [Key]
        public int Semester_Id { get; set; }

        [Required]
        public string SemName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }


        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public Programs ProgramFK { get; set; }  

    }
}