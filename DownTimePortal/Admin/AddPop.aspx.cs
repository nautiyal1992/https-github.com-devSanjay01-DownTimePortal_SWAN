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

public partial class Admin_AddPop : System.Web.UI.Page
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
                
                LoadDHQ();
                LoadLinks();
                // LoadPOP();
            }

        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if(TextBox1.Text=="" || TextBox2.Text=="" || TextBox3.Text=="" || TextBox4.Text=="")
        {
             Page.RegisterStartupScript("SS", "<script> alert('Fields Can not be black'); </script>");
        }
        else if(DropDownList1.SelectedItem.Text=="---Select DHQ---" )
        {
            Page.RegisterStartupScript("SS", "<script> alert('Please select a DHQ'); </script>");
        }
         else if(DropDownList2.SelectedItem.Text=="---Select POP Type---" )
        {
            Page.RegisterStartupScript("SS", "<script> alert('Please select POP Type'); </script>");
        }
        else if (DropDownList3.SelectedItem.Text == "---Select Link Type---")
        {
            Page.RegisterStartupScript("SS", "<script> alert('Please select Link Type'); </script>");
        }
        else
        {
            try
            {
                SqlConnection con = new SqlConnection(con_str1);
                string addpop = "INSERT INTO POP VALUES (@pnm,@dq,@pty,@bwh,@nopn,@ncls, @lk)";
                SqlCommand cmd = new SqlCommand(addpop, con);
                cmd.Parameters.AddWithValue("@pnm", TextBox1.Text + " " + DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dq", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@pty", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@lk", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@bwh", TextBox2.Text);
                cmd.Parameters.AddWithValue("@nopn", Convert.ToDateTime(TextBox3.Text));
                cmd.Parameters.AddWithValue("@ncls", Convert.ToDateTime(TextBox4.Text));
                con.Open();
                int fg = (int)cmd.ExecuteNonQuery();
                con.Close();
                if (fg != 0)
                {
                    Page.RegisterStartupScript("SS", "<script> alert('POP Added Successfully'); </script>");
                    GridView1.DataBind();
                    Referesh();
                }
                else
                    Page.RegisterStartupScript("SS", "<script> alert('This POP not  Added'); </script>");

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    Page.RegisterStartupScript("SS", "<script> alert('POP Already Exists in This DHQ with POP Type'); </script>");
            }

            catch (Exception ex1)
            {

                string message = string.Format("Message: {0}\\n\\n", ex1.Message);
                message += string.Format("StackTrace: {0}\\n\\n", ex1.StackTrace.Replace(Environment.NewLine, string.Empty));
                message += string.Format("Source: {0}\\n\\n", ex1.Source.Replace(Environment.NewLine, string.Empty));
                message += string.Format("TargetSite: {0}", ex1.TargetSite.ToString().Replace(Environment.NewLine, string.Empty));
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
            }
        }
    }
    void Referesh()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        DropDownList2.SelectedIndex = 0;
        LoadDHQ();
        LoadLinks();
    }
    void LoadLinks()
    {
        DropDownList3.Items.Clear();
        DropDownList3.Items.Add("---Select Link Type---");
        DropDownList3.SelectedIndex = 0;
        try
        {
            SqlConnection con = new SqlConnection(con_str1);
            String DHQ = "Select Link_Type from LinkType";
            SqlCommand cmd = new SqlCommand(DHQ, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    DropDownList3.Items.Add(rd[0].ToString());
                }
            }
            con.Close();
        }
        catch (Exception)
        {

        }
    }
    void LoadDHQ()
    {
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("---Select DHQ---");
        DropDownList1.SelectedIndex = 0;
        try
        {
            SqlConnection con = new SqlConnection(con_str1);
            String DHQ = "Select DHQ from DHQ";
            SqlCommand cmd = new SqlCommand(DHQ, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    DropDownList1.Items.Add(rd[0].ToString());
                }
            }
            con.Close();
        }
        catch (Exception)
        {

        }
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        Regex checktime = new Regex(@"^(([0-9]|[0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])$");
        if (!checktime.IsMatch(TextBox4.Text))
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Valid Time'); </script>");
            TextBox4.Text = "00:00:00";
        }
        
    }
   
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        Regex checktime = new Regex(@"^(([0-9]|[0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])$");
        if (!checktime.IsMatch(TextBox3.Text))
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Valid Time'); </script>");
            TextBox3.Text = "00:00:00";
        }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        Regex checktime = new Regex(@"\d+$");
        if (!checktime.IsMatch(TextBox2.Text))
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Bandwidth Digit'); </script>");
            TextBox2.Text = "00";
        }
    }
} 