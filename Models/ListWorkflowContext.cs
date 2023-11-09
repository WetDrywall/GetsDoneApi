using Microsoft.EntityFrameworkCore;

namespace GetsDoneApi.Models
{
    public class ListWorkflowContext : DbContext
    {
        public ListWorkflowContext(DbContextOptions<ListWorkflowContext> options)
            : base(options)
        {
        }
        public DbSet<ListWorkflow> ListWorkflow { get; set; }
    }
}
