using Microsoft.EntityFrameworkCore;

namespace Activity3.Models
{
    public class FormDbContext : DbContext
    {
        public DbSet<Form> Forms { get; set; }

        public FormDbContext(DbContextOptions<FormDbContext> options) 
            : base(options)
        {

        }
    }
}
