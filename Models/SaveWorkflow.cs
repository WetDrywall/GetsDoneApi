using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class SaveWorkflow
    {
        [Key]
        public int WFId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int WOwner { get; set; }
        public string WUser { get; set; }
        public DateTime Deadline { get; set; }
    }
}
