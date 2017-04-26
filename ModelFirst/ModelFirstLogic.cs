using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelFirst;

namespace ModelFirst
{
    public class ModelFirstLogic
    {
        public void AddCourse(string name, string credits)
        {
            var course = new Course() { CourseId = 1, Name = name, Credits = credits };
            
            using (var dbcontext = new ModelFirstContainer())
            {
                dbcontext.Courses.Add(course);
                dbcontext.SaveChanges();
            }
        }

        public void AddStudent(string firstName, string LastName)
        {
            var student = new Student() { StudentId = 1, FirstName = firstName, LastName = LastName };

            student.Enrollments = new List<Enrollment>() {
                new Enrollment() {CourseCourseId=1 },
                new Enrollment() {CourseCourseId=2 },
                new Enrollment() { CourseCourseId=3},
                new Enrollment() {CourseCourseId=4 }
            };

            using (var dbcontext = new ModelFirstContainer())
            {
                dbcontext.Students.Add(student);
                dbcontext.SaveChanges();
            }
        }

        public Student GetStudent(int StudentId)
        {
            using (var dbcontext = new ModelFirstContainer())
            {
                dbcontext.Configuration.LazyLoadingEnabled = false;

                //Eager loading
                //var student = dbcontext.Students.Include("Enrollments").Where(w => w.StudentId == StudentId).FirstOrDefault();


                //var student = dbcontext.Students.Where(w => w.StudentId == StudentId).FirstOrDefault();
                var student = (from stud in dbcontext.Students where stud.StudentId == StudentId select stud).FirstOrDefault();

                //Explicit Loading
                dbcontext.Entry(student).Collection(s => s.Enrollments).Load();

                return student;
            }
        }
    }
}
