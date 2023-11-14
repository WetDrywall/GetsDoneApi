using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class UserLogin
    {
        [Key]
        public int UId { get; set; }
        public bool Findes { get; set; }
    }
}
