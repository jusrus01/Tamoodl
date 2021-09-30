using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public GradeModel[] Grades { get; set; }

        // public bool Equals(StudentModel other)
        // {
        //     if (other == null)
        //     {
        //         return false;
        //     }

        //     return Email.Equals(other.Email);
        // }

        // public override bool Equals(object obj)
        // {
        //     if (obj == null || GetType() != obj.GetType())
        //     {
        //         return false;
        //     }

        //     StudentModel model = obj as StudentModel;

        //     return Email.Equals(model.Email);
        // }

        // public override int GetHashCode()
        // {
        //     return base.GetHashCode();
        // }
    }
}