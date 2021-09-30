using System;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Dtos.Courses
{
    public class CourseUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string CourseName { get; set; }
        [Required]
        [EmailAddress]
        public string OwnerEmail { get; set; }
    }
}