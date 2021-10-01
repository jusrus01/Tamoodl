using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TamoodlApi.Dtos
{
    [Keyless]
    [NotMapped]
    public class GradeReadDto
    {
        public string Date { get; set; }
        public byte Grade { get; set; }
        public string CourseName { get; set; }
    }
}