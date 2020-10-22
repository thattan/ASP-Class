using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Person
/// </summary>
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public Person()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Person(string fname, string lname, string email, string phone)
    {
        this.FirstName = fname;
        this.LastName = lname;
        this.Email = email;
        this.Phone = phone;

    }
}