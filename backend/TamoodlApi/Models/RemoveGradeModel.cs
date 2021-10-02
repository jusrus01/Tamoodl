using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class RemoveGradeModel
    {
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Date { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string StudentEmail { get; set; }
    }
}