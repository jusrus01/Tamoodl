using System;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class GradeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 10)]
        public byte Grade { get; set; }
        [Required]
        [MaxLength(100)]
        public string StudentEmail { get; set; }
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Date { get; set; }

        // public DateTime CreationDate { get; set; }
    }
}