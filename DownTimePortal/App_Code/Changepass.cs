using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for Changepass
/// </summary>
public class Changepass
{
   // String con_str1 = null;
	public Changepass()
	{
       // con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
	}
    //public bool permupdate(string eml, string persts)
    //{
    //    SqlConnection con = new SqlConnection(con_str1);
    //    string cpas = "Update AccountDetail set Permision=@persts where Email=@eml";
    //    SqlCommand cmd = new SqlCommand(cpas, con);
    //    cmd.Parameters.AddWithValue("@persts", eml);
    //    cmd.Parameters.AddWithValue("@eml", eml);
    //    con.Open();
    //    int flag = (int)cmd.ExecuteNonQuery();
    //    con.Close();
    //    if (flag != 0)
    //        return true;
    //    else
    //        return false;     

    //}

}