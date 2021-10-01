using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class AddGradeModel
    {
        [Required]
        [Range(0, 10)]
        public byte Grade { get; set; }
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string StudentEmail { get; set; }
    }
}