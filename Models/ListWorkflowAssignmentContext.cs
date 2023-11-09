using Microsoft.EntityFrameworkCore;

namespace GetsDoneApi.Models
{
    public class ListWorkflowAssignmentContext : DbContext
    {
        public ListWorkflowAssignmentContext(DbContextOptions<ListWorkflowAssignmentContext> options)
            : base(options)
        {
        }
        public DbSet<ListWorkflowAssignment> ListWorkflowAssignment { get; set; }
    }
}