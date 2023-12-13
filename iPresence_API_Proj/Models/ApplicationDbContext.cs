using Microsoft.EntityFrameworkCore;

namespace iPresence_API_Proj.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }


    }
}
