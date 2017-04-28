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
            //DataAccessLogic obj = new DataAccessLogic();
            //var dataList = obj.GetAssessments();
            //grdAssessments.DataSource = dataList;
            //grdAssessments.DataBind();
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
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