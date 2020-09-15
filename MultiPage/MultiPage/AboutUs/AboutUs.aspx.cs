using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AboutUs_AboutUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAboutUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AboutUs/AboutUs.aspx"); // Changes URL
    }

    protected void btnContactUs_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/ContactUs/ContactUs.aspx"); // Does not change URL
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}