using System;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class GradeModel
    {
        [Key]
        public int Id { get; set; }
        [Range(0, 10)]
        public byte Grade { get; set; }
        public string StudentEmail { get; set; }
        public string CourseName { get; set; }
        public string Date { get; set; }

        // public DateTime CreationDate { get; set; }
    }
}