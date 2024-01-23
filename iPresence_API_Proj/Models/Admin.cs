using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace iPresence_API_Proj.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Cell phone number must be 11 digits.")]
        public int PhoneNumber { get; set; }

        [StringLength(12, MinimumLength = 8, ErrorMessage = "Password must contain 8 characters.")]
        public string? Password { get; set; }

        [ForeignKey("AccountTypeId")]

        public AccountTypes AccTypeFk { get; set; }
        
        public int AccountTypeId { get; set; }



    }
}

