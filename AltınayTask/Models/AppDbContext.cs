using Microsoft.EntityFrameworkCore;

namespace AltınayTask.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            

        }

        public DbSet<JobObject> JobObject { get; set; }
    }
}
