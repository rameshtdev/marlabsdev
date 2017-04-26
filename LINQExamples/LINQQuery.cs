using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;

namespace LINQExamples
{
    public class LINQQuery
    {
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["LINQExamples.Properties.Settings.ModelFirstDemoConnectionString"].ToString();
        string myXML = @"<departments>
                            <department>Dev</department>
                            <department>QA</department>
                            <department>Sales</department>
                            <department>DevOps</department>
                        </departments>";
        public void LINQtoObject()
        {
            string[] deparments = { "QA", "sales", "OPerations", "Development", "Infrastructure" };

            //Query syntax
            var list = from department in deparments select department;

            //Method Syntax(lamda)
            var list1 = deparments.Select(s => s);

            var customers = new List<Customer>() {
                new Customer() {firstname="Ramesh",email= "Ramesh@marlabs.com" },
                new Customer() {firstname="Joe",email= "Joe@marlabs.com" },
                new Customer() {firstname="Mike",email= "Mike@marlabs.com" },
                new Customer() {firstname="Sam",email= "Sam@marlabs.com" },
            };

            var list2 = from customer in customers select new { name = customer.firstname, email = customer.email };

            var list3 = customers.Where(w=>w.firstname.Contains("e")).Select(s => new { name = s.firstname, email = s.email }).OrderByDescending(o=>o.name).ThenByDescending(o=>o.email);

            foreach (var item in list3)
            {
                Console.WriteLine("name:{0} - email:{1}", item.name,item.email);
            }

            foreach (var item in list1)
            {
                Console.WriteLine("Department:{0}", item);
            }

            Console.ReadKey();
        }
        public void LINQtoSQL()
        {
            LINQtoSQLDataContext context = new LINQtoSQLDataContext(connectionstring);

            //Add a new ROW
            /* 
             var newcourse = new Course() { Name = "Marine Biology", Credits = "4" };
             context.Courses.InsertOnSubmit(newcourse);
             context.SubmitChanges();
             */
            /*//Update
           var updateCourse = context.Courses.FirstOrDefault(c => c.Name.Equals("Marine Biology"));
           updateCourse.Credits = "5";
           context.SubmitChanges();
           
            var DeleteCourse = context.Courses.FirstOrDefault(c => c.Name.Equals("Marine Biology"));
            context.Courses.DeleteOnSubmit(DeleteCourse);
            context.SubmitChanges();
            */

            var list1 = context.Courses.Join(context.Enrollments, x => x.CourseId, y => y.CourseCourseId, (x, y) => new { x, y })
                .GroupBy(g => g.y.Student.StudentId)
                .Select(s => new { studentid = s.Key, count = s.Count() }).OrderByDescending(o => o.studentid);

            foreach (var s in list1)
            {
                Console.WriteLine("{0}-{1}", s.studentid, s.count);
            }
            Console.ReadLine();
        }
        public void LINQtoXML()
        {
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(myXML);

            /*
            var result = xdoc.Element("departments").Descendants();

            foreach(XElement element in result)
            {
                Console.WriteLine("Department name - {0}",element.Value);
            }
            Console.ReadKey();
            
            xdoc.Element("departments").AddFirst(new XElement("department", "Support"));
            xdoc.Element("departments").Add(new XElement("department", "Finance"));
            */

            xdoc.Descendants().Where(w => w.Value == "Sales").Remove();

            var result = xdoc.Element("departments").Descendants();

            foreach (XElement element in result)
            {
                Console.WriteLine("Department name - {0}", element.Value);
            }
            Console.ReadKey();
        }
        public void LINQtoDataSet()
        {

            string sqlcommand = "SELECT * FROM Enrollments; SELECT * FROM Students;";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand, connectionstring);

            adapter.TableMappings.Add("Table", "Enrollment");
            adapter.TableMappings.Add("Table1", "Student");

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataRelation dr = ds.Relations.Add("FK_Student_Enrollment",
                ds.Tables["Student"].Columns["StudentId"],
                ds.Tables["Enrollment"].Columns["StudentStudentId"]
                );

            DataTable enrollment = ds.Tables["Enrollment"];
            DataTable student = ds.Tables["Student"];

            var query = from e in enrollment.AsEnumerable()
                        join s in student.AsEnumerable()
                        on e.Field<int>("StudentStudentId") equals s.Field<int>("StudentId")
                        select new
                        {
                            StudentId = s.Field<int>("StudentId"),
                            Name = s.Field<string>("FirstName"),
                            CourseCourseId = e.Field<int>("CourseCourseId")
                        };

            foreach(var q in query)
            {
                Console.WriteLine("{0}-{1}-{2}", q.StudentId, q.Name, q.CourseCourseId);
            }
            Console.ReadKey();

        }
    }

    public class Customer
    {
        public string firstname { get; set; }
        public string email { get; set; }
    }
}

