using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspNetWeb.Models;
using AspNetWeb.DataAccess;

namespace AspNetWeb
{
    public partial class SelfAssessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("http://www.google.com?id=45&name=abc");
           

            Application["language"] = "english";
            Cache["language"] = "english";
            Session["something"] = "56";
            if (!Page.IsPostBack)
            {
                ListItem[] expertise = {
                        new ListItem("C#"),
                        new ListItem("ASP.NET"),
                        new ListItem("SQL"),
                        new ListItem("MVC")
                };
                lstExpertise.Items.AddRange(expertise);
            }
            DataAccessLogic obj = new DataAccessLogic();
            // var dataList = obj.GetAssessments();
            //var dataList = obj.GetAssessmentsTable();
            var dataList = (obj.GetAssessmentsDataSet()).Tables[0];
            grdAssessments.DataSource = dataList;
            grdAssessments.DataBind();

            var lang = Convert.ToString(Application["language"]);
            var langCache = Convert.ToString(Cache["language"]);
            var session = Convert.ToString(Session["something"]);
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            Server.Transfer("/About.aspx", true);

            if (Page.IsValid)
            {
                

                string expertise = lstExpertise.SelectedItem.Text;
                string Qualification = chkQualification.SelectedItem.Text;

                var input = new Assessment()
                {
                    id = 1,
                    firstname = txtFirstName.Text,
                    lastname = textLastName.Text,
                    email = txtEmail.Text,
                    age = Convert.ToInt32(txtAge.Text),
                    Gender = (rdGender.SelectedIndex == 1) ? 2 : 1,
                    expertise = expertise,
                    country = ddlCountry.SelectedItem.Text,
                    qualification = Qualification
                };

                DataAccessLogic obj = new DataAccessLogic();
                obj.SaveAssessment(input);
                var dataList = obj.GetAssessments();
                grdAssessments.DataSource = dataList;
                grdAssessments.DataBind();
            }
        }



        protected void grdAssessments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataAccessLogic obj = new DataAccessLogic();
            grdAssessments.PageIndex = e.NewPageIndex;
            var dataList = obj.GetAssessments();
            grdAssessments.DataSource = dataList;
            grdAssessments.DataBind();
        }
    }
}