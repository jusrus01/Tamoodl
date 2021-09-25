using System;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class CourseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string CourseName { get; set; }
        [Required]
        [EmailAddress]
        public string OwnerEmail { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public StudentModel[] Students { get; set; }
    }
}