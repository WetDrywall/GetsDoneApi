using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class Users
    {
        [Key]
        public int UId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}