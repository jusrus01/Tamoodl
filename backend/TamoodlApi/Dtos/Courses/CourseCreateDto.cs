using System;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Dtos.Courses
{
    public class CourseCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string OwnerEmail { get; set; }
    }
}