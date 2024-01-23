using System.ComponentModel.DataAnnotations;

namespace iPresence_API_Proj.Models
{
    public class AttendanceRequest
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public bool AttendanceMark { get; set; }
        [Required]
        public int ClassId { get; set; }

        [Required]
        public DateTime loggedIn { get; set; }
    }
}
