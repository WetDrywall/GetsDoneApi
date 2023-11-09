using Microsoft.EntityFrameworkCore;

namespace GetsDoneApi.Models
{
    public class SaveWorkflowContext : DbContext
    {
        public SaveWorkflowContext(DbContextOptions<SaveWorkflowContext> options)
            : base(options)
        {
        }
        public DbSet<SaveWorkflow> SaveWorkflow { get; set; }
    }
}
