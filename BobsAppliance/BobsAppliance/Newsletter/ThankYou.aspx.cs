using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Newsletter_ThankYou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Cust"] != null)
        {
            string firstName = Session["Cust"].ToString();
            lblCustomer.Text = firstName;
        } else
        {
            Response.Redirect("~/Newsletter/NewsLetter.aspx");
        }
    }
}