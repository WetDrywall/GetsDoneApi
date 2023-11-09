using Microsoft.EntityFrameworkCore;

namespace GetsDoneApi.Models
{
    public class SaveWorkflowAssignmentContext : DbContext
    {
        public SaveWorkflowAssignmentContext(DbContextOptions<SaveWorkflowAssignmentContext> options)
            : base(options)
        {
        }
        public DbSet<SaveWorkflowAssignment> SaveWorkflowAssignment { get; set; }
    }
}