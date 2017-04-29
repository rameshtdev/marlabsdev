using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetWeb.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

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
                    cmd.CommandText = "GETAssessments";
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

        public bool Register(string email,string password)
        {
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                SqlCommand cmd = new SqlCommand("register",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", email));
                string enc_password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                cmd.Parameters.Add(new SqlParameter("@password", enc_password));
                con.Open();
                var count = cmd.ExecuteNonQuery();
                if (count == 1) { return true; } else { return false; }
            }
        }

        public bool Login(string email,string password)
        {
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                SqlCommand cmd = new SqlCommand("ValidateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", email));
                string enr_password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                cmd.Parameters.Add(new SqlParameter("@password", enr_password));
                con.Open();
                var count =(int)cmd.ExecuteScalar();
                if(count == 1) { return true; }else { return false; }
            }
        }
    }
}