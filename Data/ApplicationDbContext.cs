using Microsoft.EntityFrameworkCore;
using Activity3.Models.Entities; // Goes to Form.cs file

namespace Activity3.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Represents the Forms table in the database
        public DbSet<Form> Forms { get; set; }

        // This constructor is used to receive database configuration options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
            
        }
    }
}
