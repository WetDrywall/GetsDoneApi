using Microsoft.EntityFrameworkCore;

namespace GetsDoneApi.Models
{
    public class UserLoginContext : DbContext
    {
        public UserLoginContext(DbContextOptions<UserLoginContext> options)
            : base(options)
        {
        }
        public DbSet<UserLogin> UserLogin { get; set; }
    }
}