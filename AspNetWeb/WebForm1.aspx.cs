using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("in Page Load\n");
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("in Page_PreInit\n");
        }

        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("in Page_PreRender\n");
        }
        protected void Page_SaveViewState(object sender, EventArgs e)
        {
            Response.Write("in Page_SaveViewState\n");
        }

        protected void Page_Render(object sender, EventArgs e)
        {
            Response.Write("in Page_Render\n");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            //Response.Write("in Page_Unload");
        }

        protected void Page_LoadViewState(object sender, EventArgs e)
        {
            Response.Write("in Page_LoadViewState\n");
        }

       

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Response.Write("in Page_PreRenderComplete\n");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("in Page_Init\n");
        }
    }
}