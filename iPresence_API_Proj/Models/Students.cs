using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace iPresence_API_Proj.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Cell phone number must be 11 digits.")]
        public int PhoneNumber { get; set; }

        public DateTime EnrollmentDate { get; set; }

        [ForeignKey("Program")]
        public int ProgramID { get; set; }

        [ForeignKey("Classes")]
        public int ClassID { get; set; }
    }
}
