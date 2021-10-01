using System;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class CourseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string OwnerEmail { get; set; }
        [Required]
        [MaxLength(100)]
        public string Date { get; set; }
    }
}