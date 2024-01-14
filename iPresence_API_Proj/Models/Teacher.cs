using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace iPresence_API_Proj.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public DateTime HireDate { get; set; }
        

        [StringLength(12, MinimumLength = 8, ErrorMessage = "Password must contain 8 characters.")]
        public string? Password { get; set; }
    }
}
