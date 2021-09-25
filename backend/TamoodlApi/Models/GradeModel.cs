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

        public DateTime CreationDate { get; set; }
    }
}