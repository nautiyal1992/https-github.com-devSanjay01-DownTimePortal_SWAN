using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;

public partial class Admin_Linktype : System.Web.UI.Page
{
    String con_str1 = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        string uname = null;
        try
        {
            uname = Session["name"].ToString();
        }
        catch (Exception exs)
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        if (!IsPostBack)
        {
            if (uname != null)
            {
               
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Link Name'); </script>");
        }
        else
        {
            try
            {
                SqlConnection con = new SqlConnection(con_str1);
                string addpop = "INSERT INTO LinkType VALUES (@lk)";
                SqlCommand cmd = new SqlCommand(addpop, con);
                cmd.Parameters.AddWithValue("@lk", TextBox1.Text);
                con.Open();
                int fg = (int)cmd.ExecuteNonQuery();
                con.Close();
                if (fg != 0)
                {
                    Page.RegisterStartupScript("SS", "<script> alert('Link Added Successfully'); </script>");
                    GridView1.DataBind();
                    TextBox1.Text = "";

                }
                else
                    Page.RegisterStartupScript("SS", "<script> alert('This Link not  Added'); </script>");

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    Page.RegisterStartupScript("SS", "<script> alert('Link Type Already Exists in This DHQ with POP Type'); </script>");
                TextBox1.Text = "";
            }
        }
    }
}