using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class SaveUser
    {
        [Key]
        public int UId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
