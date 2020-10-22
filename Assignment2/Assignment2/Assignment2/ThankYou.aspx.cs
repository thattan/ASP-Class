using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ThankYou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string firstName = Session["name"].ToString();
            lblPerson.Text = "Thank you, " + firstName;
        } else
        {
            Response.Redirect("Registration.aspx");
        }
    }
}