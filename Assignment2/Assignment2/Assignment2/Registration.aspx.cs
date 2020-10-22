using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string firstName;
        string lastName;
        string email;
        string phone;
        int numRecords;


        firstName = txtFirstName.Text;
        lastName = txtLastName.Text;
        email = txtEmail.Text;
        phone = txtPhone.Text;

        Person person = new Person();
        person.FirstName = firstName;
        person.LastName = lastName;
        person.Email = email;
        person.Phone = phone;


        Session["name"] = firstName;

        numRecords = PersonDA.AddPerson(person);

        if (numRecords > 0)
        {
            Server.Transfer("~/ThankYou.aspx");
        }
        else
        {
            Session["Cust"] = "Sorry add failed try later";
            Server.Transfer("~/ErrorPage.aspx");
        }
    }
}