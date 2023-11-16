using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class ListUsers
    {
        [Key]
        public int UId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
