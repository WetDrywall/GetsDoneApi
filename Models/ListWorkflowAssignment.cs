using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class ListWorkflowAssignment
    {
        public int WFId { get; set; }
        [Key]
        public int AId { get; set; }
        public string ATitle { get; set; }
        public string ADescription { get; set; }
        public int AssignmentNumber { get; set; }
        public bool Completed { get; set; }
        public string Deadline { get; set; }
    }
}
