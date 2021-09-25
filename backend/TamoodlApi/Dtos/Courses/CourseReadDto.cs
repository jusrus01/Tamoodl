using System;
using System.ComponentModel.DataAnnotations;
using TamoodlApi.Models;

namespace TamoodlApi.Dtos.Courses
{
    public class CourseReadDto
    {
        public string CourseName { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime CreationDate { get; set; }
        public StudentModel[] Students { get; set; }
    }
}