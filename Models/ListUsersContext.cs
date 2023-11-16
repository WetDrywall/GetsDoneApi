using Microsoft.EntityFrameworkCore;

namespace GetsDoneApi.Models
{
    public class ListUsersContext : DbContext
    {
        public ListUsersContext(DbContextOptions<ListUsersContext> options)
            : base(options)
        {
        }
        public DbSet<ListUsers> ListUsers { get; set; }
    }
}

