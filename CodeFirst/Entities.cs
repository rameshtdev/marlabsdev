using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Student
    {
        public int StudentId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
