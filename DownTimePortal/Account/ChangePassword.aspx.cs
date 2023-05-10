using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    String con_str1 = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(con_str1);
        string cpas = "Update AccountDetail set Password=@nps where Email=@eml and Password=@ops";
        SqlCommand cmd = new SqlCommand(cpas, con);
        cmd.Parameters.AddWithValue("@eml", TextBox1.Text);
        cmd.Parameters.AddWithValue("@ops", TextBox2.Text);
        cmd.Parameters.AddWithValue("@nps", TextBox4.Text);
        con.Open();
        int flag = (int)cmd.ExecuteNonQuery();
        con.Close();
        if (flag != 0)
        {
            Label1.Text = "Password Change Successfully";
            Label1.Visible = true;
        }
        else
        {
            Page.RegisterStartupScript("SS", "<script> alert('You Entered Wrong Detail Password not Changed Try Again'); </script>");
            Label1.Text = "";
            Label1.Visible = false;
            TextBox1.Text = "";
        }
    }
}