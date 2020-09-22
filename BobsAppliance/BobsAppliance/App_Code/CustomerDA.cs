using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for CustomerDA
/// </summary>
public class CustomerDA
{
    public CustomerDA()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }

    public static int AddCustomer(Customer c)
    {
        int num = 0;
        String sql = "Insert into Customers (firstName, lastName, email, phone, numberAppliance) values" +
            "(@firstName, @lastName, @email, @phone, @numberAppliance)";

        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@firstName", c.FirstName);
        cmd.Parameters.AddWithValue("@lastName", c.LastName);
        cmd.Parameters.AddWithValue("@email", c.Email);
        cmd.Parameters.AddWithValue("@phone", c.Phone);
        cmd.Parameters.AddWithValue("@numberAppliance", c.NumberAppliance);

        try
        {
            conn.Open();
            num = cmd.ExecuteNonQuery();

            conn.Close();
            
        } catch (SqlException e)
        {
            HttpContext.Current.Session.Add("Error", e);
        }
        return num;
    }
}