using System;

namespace TamoodlApi.Models
{
    public class StudentAddModel
    {  
        public int Id { get; set; }
        public StudentModel Student { get; set; }
        public string CourseName { get; set; }        

        // public override bool Equals(object obj)
        // {
        //     if (obj == null || GetType() != obj.GetType())
        //     {
        //         return false;
        //     }

        //     StudentAddModel model = obj as StudentAddModel;
            
        //     return CourseName.Equals(model.CourseName) && Student.Equals(model.Student);
        // }

        // public bool Equals(StudentAddModel other)
        // {
        //     if (other == null)
        //     {
        //         return false;
        //     }
            
        //     return CourseName.Equals(other.CourseName) && Student.Equals(other.Student);
        // }

        // public override int GetHashCode()
        // {
        //     return base.GetHashCode();
        // }
    }
}