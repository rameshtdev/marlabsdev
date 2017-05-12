using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetWeb.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AspNetWeb.DataAccess
{
    public class DataAccessLogic
    {
        private string dbConn = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString.ToString();
        public void SaveAssessment(Assessment model)
        {

            using (var conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SaveAssessment";
                    cmd.Parameters.Add(new SqlParameter("@firstname", model.firstname));
                    cmd.Parameters.Add(new SqlParameter("@Lastname", model.lastname));
                    cmd.Parameters.Add(new SqlParameter("@Email", model.email));
                    cmd.Parameters.Add(new SqlParameter("@age", model.age));
                    cmd.Parameters.Add(new SqlParameter("@Country", model.country));
                    cmd.Parameters.Add(new SqlParameter("@gender", model.Gender));
                    cmd.Parameters.Add(new SqlParameter("@expertise", model.expertise));
                    cmd.Parameters.Add(new SqlParameter("@Qualification", model.qualification));

                    var count = cmd.ExecuteNonQuery();
                    //var count = cmd.ExecuteScalar();
                    //var count = cmd.ExecuteReader();

                }
                conn.Close();
            }
        }
        public List<Assessment> GetAssessments()
        {
            var returnList = new List<Assessment>();

            using (var conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAssessments";
                    cmd.CommandTimeout = 300;
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            returnList.Add(new Assessment()
                            {
                                firstname = Convert.ToString(datareader["firstname"]),
                                lastname = Convert.ToString(datareader["lastname"]),
                                email = Convert.ToString(datareader["email"]),
                                age = Convert.ToInt32(datareader["age"]),
                                country = Convert.ToString(datareader["country"]),
                                expertise = Convert.ToString(datareader["expertise"]),
                                qualification = Convert.ToString(datareader["qualification"]),
                                Gender = Convert.ToInt32(datareader["Gender"])
                            });
                        }
                    }
                }
                conn.Close();
            }
            return returnList;
        }

        public DataTable GetAssessmentsTable()
        {
            var returnList = new DataTable();
            returnList.Columns.Add("firstname");
            returnList.Columns.Add("lastname");
            returnList.Columns.Add("email");
            returnList.Columns.Add("age");
            returnList.Columns.Add("country");
            returnList.Columns.Add("expertise");
            returnList.Columns.Add("qualification");
            returnList.Columns.Add("Gender");

            using (var conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAssessments";
                    cmd.CommandTimeout = 300;
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            DataRow dr = returnList.NewRow();
                            dr[0] = Convert.ToString(datareader["firstname"]);
                            dr[1] = Convert.ToString(datareader["lastname"]);
                            dr[2] = Convert.ToString(datareader["email"]);
                            dr[3] = Convert.ToInt32(datareader["age"]);
                            dr[4] = Convert.ToString(datareader["country"]);
                            dr[5] = Convert.ToString(datareader["expertise"]);
                            dr[6] = Convert.ToString(datareader["qualification"]);
                            dr[7] = Convert.ToInt32(datareader["Gender"]);
                            returnList.Rows.Add(dr);                           
                        }
                    }
                }
                conn.Close();
            }
            return returnList;
        }

        public DataSet GetAssessmentsDataSet()
        {
            var ds = new DataSet();
           
            using (var conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAssessments";
                    cmd.CommandTimeout = 300;

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds, "Assessments");


                        DataRow dr = ds.Tables[0].NewRow();
                        dr[0] = "FirstName_552017";
                        dr[1] = "LastName_552017";
                        dr[2] = "EMail-test";
                        dr[3] = 23;
                        dr[4] = 1;
                        dr[5] = "Expertise_552017";
                        dr[6] = "Qualification_552017";
                        dr[7] = "USA";

                        ds.Tables[0].Rows.Add(dr);

                        var insertCommand = new SqlCommand("INSERT INTO [dbo].[Assessment] values (@FirstName,@LastName,@Email,@Age,@Gender,@Expertise,@Qualification,@Country)", conn);

                        insertCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
                        insertCommand.Parameters["@FirstName"].SourceVersion = DataRowVersion.Current;
                        insertCommand.Parameters["@FirstName"].SourceColumn = "FirstName";

                        insertCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
                        insertCommand.Parameters["@LastName"].SourceVersion = DataRowVersion.Current;
                        insertCommand.Parameters["@LastName"].SourceColumn = "LastName";

                        insertCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                        insertCommand.Parameters["@Email"].SourceVersion = DataRowVersion.Current;
                        insertCommand.Parameters["@Email"].SourceColumn = "Email";

                        insertCommand.Parameters.Add(new SqlParameter("@Age", SqlDbType.Int));
                        insertCommand.Parameters["@Age"].SourceVersion = DataRowVersion.Current;
                        insertCommand.Parameters["@Age"].SourceColumn = "Age";

                        insertCommand.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int));
                        insertCommand.Parameters["@Gender"].SourceVersion = DataRowVersion.Current;
                        insertCommand.Parameters["@Gender"].SourceColumn = "Gender";

                        insertCommand.Parameters.Add(new SqlParameter("@Expertise", SqlDbType.NVarChar));
                        insertCommand.Parameters["@Expertise"].SourceVersion = DataRowVersion.Current;
                        insertCommand.Parameters["@Expertise"].SourceColumn = "Expertise";

                        insertCommand.Parameters.Add(new SqlParameter("@Qualification", SqlDbType.NVarChar));
                        insertCommand.Parameters["@Qualification"].SourceVersion = DataRowVersion.Current;
                        insertCommand.Parameters["@Qualification"].SourceColumn = "Qualification";

                        insertCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar));
                        insertCommand.Parameters["@Country"].SourceVersion = DataRowVersion.Current;
                        insertCommand.Parameters["@Country"].SourceColumn = "Country";

                        adapter.InsertCommand = insertCommand;

                        adapter.Update(ds, "Assessments");
                    }


                }
                conn.Close();
            }
            return ds;
        }
    }
}