using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class ListWorkflow
    {
        [Key]
        public int WFId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int WOwner { get; set; }
        public int WUser { get; set; }
        public string Deadline { get; set; }
    }
}
