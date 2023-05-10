using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security;

public partial class Account_SignUp : System.Web.UI.Page
{
    String con_str1 = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        if (!IsPostBack)
        {
            LoadDHQ();
          
           // LoadPOP();
        }
    }
    void Refereshfld()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        DropDownList1.ClearSelection();
        DropDownList2.ClearSelection();
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "---Select DHQ---")
            Page.RegisterStartupScript("SS", "<script> alert('Kindly Select any DHQ'); </script>");
        else if (DropDownList2.SelectedItem.Text == "---Select POP---")
            Page.RegisterStartupScript("SS", "<script> alert('Kindly Select Respective POP'); </script>");
        else
        {
            //  signup su = new signup();
            //   su.regs(TextBox1.Text, TextBox2.Text, TextBox3.Text, Convert.ToDateTime(TextBox4.Text), RadioButtonList1.Text, Label1.Text, DropDownList1.Text, DropDownList2.Text, TextBox5.Text, TextBox7.Text);
            //  Page.RegisterStartupScript("SS", "<script> alert('Account Successfully Create now wait for Admin Permission'); </script>");
            try
            {
                String pr = "Cancel";
                SqlConnection con = new SqlConnection(con_str1);
                string acdata = "INSERT INTO AccountDetail Values(@nm,@e,@mb,@g,@db,@ps,@sq,@dq,@pp,@addr,@pm,@acdt)";
                SqlCommand cmd = new SqlCommand(acdata, con);
                cmd.Parameters.AddWithValue("@nm", TextBox1.Text);
                cmd.Parameters.AddWithValue("@e", TextBox2.Text);
                cmd.Parameters.AddWithValue("@mb", TextBox3.Text);
                cmd.Parameters.AddWithValue("@g", RadioButtonList1.Text);
                cmd.Parameters.AddWithValue("@db", Convert.ToDateTime(TextBox4.Text));
                cmd.Parameters.AddWithValue("@ps", TextBox5.Text);
                cmd.Parameters.AddWithValue("@sq", Label1.Text);
                cmd.Parameters.AddWithValue("@dq", DropDownList1.Text);
                cmd.Parameters.AddWithValue("@pp", DropDownList2.Text);
                cmd.Parameters.AddWithValue("@addr", TextBox7.Text);
                cmd.Parameters.AddWithValue("@pm", pr);
                cmd.Parameters.AddWithValue("@acdt", DateTime.Now);
                con.Open();
                int adata = (int)cmd.ExecuteNonQuery();
                con.Close();
                if (adata != 0)
                    Page.RegisterStartupScript("SS", "<script> alert('Account Successfully Create now wait for Admin Permission'); </script>");
                Label2.Text = "Account Created Sussesfully";
                Label2.Visible = true;
                Refereshfld();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    Page.RegisterStartupScript("SS", "<script> alert('Given Email ID Already Exits Kindly Change Email ID'); </script>");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
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
            String DHQ = "Select DHQ from DHQ where SHQ=@sq";
            SqlCommand cmd = new SqlCommand(DHQ,con);
            cmd.Parameters.AddWithValue("@sq", Label1.Text);
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
        catch (Exception )
        {
            
        }

    }
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("---Select POP---");
        DropDownList2.SelectedIndex = 0;
        String Dname = DropDownList1.Text;
        try
        {
            SqlConnection con = new SqlConnection(con_str1);
            String POP = "Select POP from POP where DHQ=@dq";
            SqlCommand cmd = new SqlCommand(POP, con);
            cmd.Parameters.AddWithValue("@dq", Dname);
            con.Open();
            SqlDataReader rd1 = cmd.ExecuteReader();
            if (rd1.HasRows)
            {
                while (rd1.Read())
                {
                    DropDownList2.Items.Add(rd1[0].ToString());
                }
            }
            con.Close();
        }
        catch (Exception)
        {

        }
    }
}
