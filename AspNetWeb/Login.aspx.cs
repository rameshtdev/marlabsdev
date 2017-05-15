using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            DataAccess.DataAccessLogic obj = new DataAccess.DataAccessLogic();
            var res = obj.Login(email, password);
            if (res)
            {
                Session["Email"] = email;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblError.Text = "Invalid Email or Password";
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}