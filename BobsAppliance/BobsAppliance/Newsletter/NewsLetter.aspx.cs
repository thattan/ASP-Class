﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Newsletter_NewsLetter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        string firstName;
        string lastName;
        string email;
        string phone;
        int numberAppliance;
        int numRecords;

        firstName = txtFirstName.Text;
        lastName = txtLastName.Text;
        email = txtEmail.Text;
        phone = txtPhoneNumber.Text;
        numberAppliance = Convert.ToInt16(txtNumberAppliance.Text);

        // create the object

        Customer c = new Customer(firstName, lastName, email, phone, numberAppliance);

        Session["Cust"] = firstName;

        //do something with the object data
        lblMessage.Text = firstName + " " + lastName;

        //Add them to the database
        numRecords = CustomerDA.AddCustomer(c);

        if (numRecords > 0)
        {
            Server.Transfer("~/NewsLetter/ThankYou.aspx");
        } else
        {
            Session["Cust"] = "Sorry add failed try later";
            Server.Transfer("~/NewsLetter/ErrorPage.aspx");
        }   
    }
}