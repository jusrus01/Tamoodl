using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TamoodlApi.Dtos;

namespace TamoodlApi.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        public ICollection<GradeReadDto> Grades { get; set; }
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
    }
}