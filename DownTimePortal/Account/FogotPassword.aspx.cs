using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class Account_FogotPassword : System.Web.UI.Page
{
    String con_str1 = null;
    protected void Page_Load(object sender, EventArgs e)
    {
         con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "")
        {
            Page.RegisterStartupScript("SS", "<script> alert('Please Enter Values'); </script>");
        }
        else
        {
            decimal mb = Convert.ToDecimal(TextBox3.Text);
            DateTime db = Convert.ToDateTime(TextBox4.Text);
            SqlConnection con = new SqlConnection(con_str1);
            string getpass = "select Password from AccountDetail where Name=@nm and Email=@eml and Mobile=@mb and DOB=@db";
            SqlCommand cmd = new SqlCommand(getpass, con);
            cmd.Parameters.AddWithValue("@nm", TextBox1.Text);
            cmd.Parameters.AddWithValue("@eml", TextBox2.Text);
            cmd.Parameters.AddWithValue("mb", mb);
            cmd.Parameters.AddWithValue("@db", db);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = "Your Password :  " + " " + dr["Password"].ToString() + " ";
                    Label1.Visible = true;
                }
            }
            else
            {
                Page.RegisterStartupScript("SS", "<script> alert('Wrong Detail'); </script>");
                Label1.Text = "";
                Label1.Visible = false;
            }
            con.Close();
        }
    }
}