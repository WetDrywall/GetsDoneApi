using Microsoft.EntityFrameworkCore;

namespace GetsDoneApi.Models
{
    public class SaveUserContext : DbContext
    {
        public SaveUserContext(DbContextOptions<SaveUserContext> options)
            : base(options)
        {
        }
        public DbSet<SaveUser> SaveUser { get; set; }
    }
}
