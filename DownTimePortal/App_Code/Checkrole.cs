using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;
/// <summary>
/// Summary description for Checkrole
/// </summary>
public class Checkrole
{
    String con_str1 = null;
	public Checkrole()
	{
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
	}
    public string[] Role(string name, string pass)
    {
        string[] role = new string[4];
        SqlConnection con = new SqlConnection(con_str1);
        string acc = "select Permission, DHQ,POP,SHQ from AccountDetail where Email=@e and Password=@ps";
        SqlCommand cmd = new SqlCommand(acc, con);
        cmd.Parameters.AddWithValue("@e", name);
        cmd.Parameters.AddWithValue("@ps", pass);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if(rd.HasRows)
        {
            while(rd.Read())
            {
                role[0]=rd[0].ToString();
                role[1] = rd[1].ToString();
                role[2] = rd[2].ToString();
                role[3] = rd[3].ToString();
            }
        }
        return role;
    }
}