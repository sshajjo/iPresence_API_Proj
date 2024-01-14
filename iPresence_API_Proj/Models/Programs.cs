using System.ComponentModel.DataAnnotations;

namespace iPresence_API_Proj.Models
{
    public class Programs
    {
        [Key]
        public int ProgramID { get; set; }

        public string ProgramTitle { get; set; }

    }
}
