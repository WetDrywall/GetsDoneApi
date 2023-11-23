using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class SaveWorkflowAssignment
    {
        public int WFId { get; set; }
        [Key]
        public int AId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignmentNumber { get; set; }
        public bool Completed { get; set; }
        public DateTime Deadline { get; set; }
    }
}
