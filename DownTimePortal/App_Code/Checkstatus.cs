using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Checkstatus
/// </summary>
public class Checkstatus
{
    String con_str1 = null;

	public Checkstatus()
	{
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
	}
    public bool checklogin(String name,String pass)
    {
      //  String permission = "Allow";
        SqlConnection con = new SqlConnection(con_str1);
        string acc = "select count(*) from AccountDetail where Email=@e and Password=@ps";
      //  string acc = "select count(*) from AccountDetail where Email=@e and Password=@ps and Permission=@p";
        SqlCommand cmd = new SqlCommand(acc, con);
        cmd.Parameters.AddWithValue("@e", name);
        //cmd.Parameters.AddWithValue("@m", name);
        cmd.Parameters.AddWithValue("@ps", pass);
       // cmd.Parameters.AddWithValue("@p", permission);
        con.Open();
            int g=(int)cmd.ExecuteScalar();
        con.Close();
            if (g != 0)
                return true;
            else
                return false;

    }
}