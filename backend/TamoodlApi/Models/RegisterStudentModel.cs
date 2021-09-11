using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class RegisterStudentModel
    {
        [Required]
        [StringLength(80)]
        public string Email { get; set; }
        [Required]
        [StringLength(80)]
        public string Username { get; set; }
        [Required]
        [StringLength(80)]
        public string Password { get; set; }
    }
}