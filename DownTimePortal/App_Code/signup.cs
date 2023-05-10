using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.Data.SqlClient;
using System.Web.Configuration;


/// <summary>
/// Summary description for signup
/// </summary>
public class signup
{
    String con_str1 = null;
    public signup()
    {
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
    }
   //// public bool regs(String n, String e, String m, DateTime bd, String g, String s, String dq, String pop, String pwd, String add)
   // {
   //     try
   //     {
   //         String pr = "Cancel";
   //         SqlConnection con = new SqlConnection(con_str1);
   //         string acdata = "INSERT INTO AccountDetail Values(@e,@nm,@mb,@ps,@db,@g,@addr,@sq,@dq,@pp,@pm,@adt)";
   //         SqlCommand cmd = new SqlCommand(acdata, con);
   //         cmd.Parameters.AddWithValue("@e", e);
   //         cmd.Parameters.AddWithValue("@mb", m);
   //         cmd.Parameters.AddWithValue("@ps", pwd);
   //         cmd.Parameters.AddWithValue("@sq", s);
   //         cmd.Parameters.AddWithValue("@dq", dq);
   //         cmd.Parameters.AddWithValue("@pp", pop);
   //         cmd.Parameters.AddWithValue("@pm", pr);
   //         cmd.Parameters.AddWithValue("@adt", DateTime.Now);
   //         cmd.Parameters.AddWithValue("@nm", n);
   //         cmd.Parameters.AddWithValue("@db", bd);
   //         cmd.Parameters.AddWithValue("@g", g);
   //         cmd.Parameters.AddWithValue("@addr", add);
   //         con.Open();
   //         int adata = (int)cmd.ExecuteNonQuery();
   //         con.Close();
   //         if (adata != 0)
   //             return true;
   //         else
   //             return false;
   //     }
   //     catch (SqlException ex)
   //     {
            
   //     }
   // }
}