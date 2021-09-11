using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Group { get; set; }
        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(40)]
        public string LastName { get; set; }
        public List<int> Grades { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}