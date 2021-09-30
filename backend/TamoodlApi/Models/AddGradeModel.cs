using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class AddGradeModel
    {
        [Required]
        public byte Grade { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
    }
}