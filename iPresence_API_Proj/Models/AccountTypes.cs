using System.ComponentModel.DataAnnotations;

namespace iPresence_API_Proj.Models
{
    public class AccountTypes
    {
        [Key]
        public int AccountTypeId { get; set; }

        public string AccountTitle { get; set; }
    }
}
