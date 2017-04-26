using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class CodeFirstDataLogic
    {
        public void AddCourse(string name, int credits)
        {
            var course = new Course() { CourseId = 1, Name = name, Credits = credits };

            using (var dbcontext = new CodeFirstDBContext())
            {
                dbcontext.Courses.Add(course);
                dbcontext.SaveChanges();
            }
        }
    }
}
