using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        // [Required]
        public ICollection<GradeModel> Grades { get; set; }
        public string CourseName { get; set; }
    }
}