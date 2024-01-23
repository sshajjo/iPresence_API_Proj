using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace iPresence_API_Proj.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [ForeignKey("SemesterID")]
        public Semester SemesterFk { get; set; }
        public int SemesterID { get; set; }

        [StringLength(12, MinimumLength = 8, ErrorMessage = "Password must contain 8 characters.")]
        public string? Password { get; set; }

        [ForeignKey("AccountTypeId")]

        public AccountTypes AccTypeFk {get; set;}

        public int AccountTypeId { get; set; }


    }
}
