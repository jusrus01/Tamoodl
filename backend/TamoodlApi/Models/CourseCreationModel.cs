using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class CourseCreationModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Course { get; set; }
    }
}