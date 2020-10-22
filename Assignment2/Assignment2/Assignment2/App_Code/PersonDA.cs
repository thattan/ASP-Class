using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PersonDA
/// </summary>
public class PersonDA
{
    public PersonDA()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["Assignment2"].ConnectionString;
    }

    public static int AddPerson(Person person)
    {
        int num = 0;
        String sql = "Insert into Person (firstName, lastName, email, phone) values" +
            "(@firstName, @lastName, @email, @phone)";

        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@firstName", person.FirstName);
        cmd.Parameters.AddWithValue("@lastName", person.LastName);
        cmd.Parameters.AddWithValue("@email", person.Email);
        cmd.Parameters.AddWithValue("@phone", person.Phone);

        try
        {
            conn.Open();
            num = cmd.ExecuteNonQuery();

            conn.Close();

        }
        catch (SqlException e)
        {
            HttpContext.Current.Session["Error"] = "An error occured";
        }
        return num;
    }

}