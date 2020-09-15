using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public int NumberAppliance { get; set; }

    public Customer()
    {     
        //
        // TODO: Add constructor logic here
        //
    }

    public Customer (string fname, string lname, string email, string phone, int numAppliance)
    {
        this.FirstName = fname;
        this.LastName = lname;
        this.Email = email;
        this.Phone = phone;
        this.NumberAppliance = numAppliance;
    }
}