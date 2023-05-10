using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class UserMaster : System.Web.UI.MasterPage
{
    String str = null;
    String uname = null;
     protected void Page_Load(object sender, EventArgs e)
    {
        str=WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        if (Session["name"] != null)
        {
            uname = Session["name"].ToString();
            Detail(uname);
        }
    
               
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
            Session["name"] = null;
            Session.Contents.RemoveAll();
            if (Session["name"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        
    }
    void Detail(string a)
    {
        
            SqlConnection con = new SqlConnection(str);
            String usrdtl = "select Name,DHQ,POP,SHQ from AccountDetail where email=@e";
            SqlCommand cmd = new SqlCommand(usrdtl, con);
            cmd.Parameters.AddWithValue("@e", a);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Label1.Text = rd["Name"].ToString();
                    Label2.Text = rd["DHQ"].ToString();
                   Label10.Text = rd["POP"].ToString();
                   
                }
            }
            con.Close();
        }
       
        
    }
   
