using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseFirst;

namespace DatabaseFirst
{
    public class DBFirstCodeLogic
    {
        public void AddCourse(string name, string credits)
        {
            var course = new Cours() { CourseId = 1, Name = name, Credits = credits };

            using (var dbcontext = new ModelFirstDemoEntities())
            {
                dbcontext.Courses.Add(course);
                dbcontext.SaveChanges();
            }
        }
    }
}
