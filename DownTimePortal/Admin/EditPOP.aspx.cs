using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text.RegularExpressions;

public partial class Admin_EditPOP : System.Web.UI.Page
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
         if(TextBox1.Text=="" || TextBox2.Text=="" || TextBox3.Text=="" )
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
         else if (DropDownList4.SelectedItem.Text == "---Select Link Type---")
         {
             Page.RegisterStartupScript("SS", "<script> alert('Please select POP Link Type'); </script>");

         }
        else
        {
            try
            {

                SqlConnection con = new SqlConnection(con_str1);
                String udtpop = "UPDATE POP SET Bandwidth=@bth, NOC_Open_Time=@not, NOC_Close_Time=@nct, Link_Type=@lk where POP=@pp and DHQ=@dq";
                SqlCommand cmd = new SqlCommand(udtpop, con);
                cmd.Parameters.AddWithValue("@bth", Convert.ToInt32(TextBox1.Text));
                cmd.Parameters.AddWithValue("@not", Convert.ToDateTime(TextBox2.Text));
                cmd.Parameters.AddWithValue("@nct", Convert.ToDateTime(TextBox3.Text));
                cmd.Parameters.AddWithValue("@pp", DropDownList3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@dq", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@lk", DropDownList4.SelectedItem.Text);

                con.Open();
                int g = (int)cmd.ExecuteNonQuery();
                con.Close();
                if (g != 0)
                {
                    Page.RegisterStartupScript("SS", "<script> alert('POP Updated Successfully'); </script>");
                    Refdata();
                    Button2.Visible=false;
                }
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }
         }
    }
    void Refdata()
    {
        LoadDHQ();
        DropDownList3.Items.Clear();
        DropDownList3.Items.Add("---Select POP---");
        DropDownList4.Visible = false;
        DropDownList2.ClearSelection();
        DropDownList3.ClearSelection();
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox1.Visible = false;
        TextBox2.Visible = false;
        TextBox3.Visible = false;
        Button1.Visible = false;
        Label11.Text = "0";
        Label12.Text = "0";
        Label13.Text = "0";
        Label14.Text = "NA";
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
    void LoadLinks()
    {
        DropDownList4.Items.Clear();
        DropDownList4.Items.Add("---Select Link Type---");
        DropDownList4.SelectedIndex = 0;
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
                    DropDownList4.Items.Add(rd[0].ToString());
                }
            }
            con.Close();
        }
        catch (Exception)
        {

        }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        Regex checktime = new Regex(@"^(([0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])$");
        if (!checktime.IsMatch(TextBox2.Text))
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Valid Time'); </script>");
            TextBox2.Text = "00:00:00";
        }
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        Regex checktime = new Regex(@"^(([0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])$");
        if (!checktime.IsMatch(TextBox3.Text))
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Valid Time'); </script>");
            TextBox3.Text = "00:00:00";
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Regex checktime = new Regex(@"\d+$");
        if (!checktime.IsMatch(TextBox1.Text))
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Bandwidth Digit'); </script>");
            TextBox1.Text = "00";
        }
    }
   
    
          protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add("---Select POP---");
            DropDownList3.SelectedIndex = 0;
                SqlConnection con = new SqlConnection(con_str1);
                String POP = "Select POP from POP where DHQ=@dq and POP_Type=@ppt";
                SqlCommand cmd = new SqlCommand(POP, con);
                cmd.Parameters.AddWithValue("@dq", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ppt", DropDownList2.SelectedItem.Text);
                con.Open();
                SqlDataReader rd1 = cmd.ExecuteReader();
                if (rd1.HasRows)
                {
                    while (rd1.Read())
                    {
                        DropDownList3.Items.Add(rd1[0].ToString());
                    }
                }
                con.Close();
            }

          protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
          {
              string link = null;
              SqlConnection con = new SqlConnection(con_str1);
              String PPdata = "select * from POP where POP=@pp and DHQ=@dq";
              SqlCommand cmd = new SqlCommand(PPdata, con);
              cmd.Parameters.AddWithValue("@pp", DropDownList3.Text);
              cmd.Parameters.AddWithValue("@dq", DropDownList1.Text);
              con.Open();
              SqlDataReader rd2 = cmd.ExecuteReader();
              if (rd2.HasRows)
              {
                  while (rd2.Read())
                  {
                      Label11.Text = rd2["Bandwidth"].ToString();
                      Label12.Text = rd2["NOC_Open_Time"].ToString();
                      Label13.Text = rd2["NOC_Close_Time"].ToString();
                      Label14.Text = rd2["Link_Type"].ToString();
                      TextBox2.Text = rd2["NOC_Open_Time"].ToString();
                      TextBox3.Text = rd2["NOC_Close_Time"].ToString();
                      link=rd2["Link_Type"].ToString();
                      
                  }
                  Button2.Visible = true;
              }
              con.Close();
             // DropDownList4.Text = link;
             //DropDownList4.ClearSelection();
             //DropDownList4.Items.FindByText(link).Selected = true;
             
             // LoadLinks();

              
          }
          protected void Button2_Click(object sender, EventArgs e)
          {

             
               if (DropDownList1.SelectedItem.Text == "---Select DHQ---")
              {
                  Page.RegisterStartupScript("SS", "<script> alert('Please select a DHQ'); </script>");
              }
              else if (DropDownList2.SelectedItem.Text == "---Select POP Type---")
              {
                  Page.RegisterStartupScript("SS", "<script> alert('Please select POP Type'); </script>");
              }
               else if (DropDownList3.SelectedItem.Text == "---Select POP---")
               {
                   Page.RegisterStartupScript("SS", "<script> alert('Please select POP'); </script>");
               }
             
              else
              {
                  try
                  {

                      SqlConnection con = new SqlConnection(con_str1);
                      String dtpop = "Delete from POP where POP=@pp and DHQ=@dq and POP_Type=@ppt";
                      SqlCommand cmd = new SqlCommand(dtpop, con);
                      cmd.Parameters.AddWithValue("@dq", DropDownList1.SelectedItem.Text);
                      cmd.Parameters.AddWithValue("@ppt", DropDownList2.SelectedItem.Text);
                      cmd.Parameters.AddWithValue("@pp", DropDownList3.SelectedItem.Text);
                      con.Open();
                      int g = (int)cmd.ExecuteNonQuery();
                      con.Close();
                      if (g != 0)
                      {
                          Page.RegisterStartupScript("SS", "<script> alert('POP Deleted Successfully'); </script>");
                          Refdata();
                          Button2.Visible = false;
                      }
                  }

                  catch (Exception ex)
                  {
                      ex.Message.ToString();
                  }
              }
          }
          protected void LinkButton2_Click(object sender, EventArgs e)
          {
              TextBox1.Visible = true;
              TextBox2.Visible=true;
              TextBox3.Visible=true;
              Button1.Visible=true;
              DropDownList4.Visible = true;
          }
}
        //void LoadPOP()
        //{
        //DropDownList3.Items.Clear();
        //DropDownList3.Items.Add("---Select POP---");
        //DropDownList3.SelectedIndex = 0;
      
        //try
        //{
        //    SqlConnection con = new SqlConnection(con_str1);
        //    String POP = "Select POP from POP where DHQ=@dq and POP_Type=@ppt";
        //    SqlCommand cmd = new SqlCommand(POP, con);
        //    cmd.Parameters.AddWithValue("@dq", DropDownList1.SelectedItem);
        //    cmd.Parameters.AddWithValue("@ppt", DropDownList2.SelectedIndex);
        //    con.Open();
        //    SqlDataReader rd1 = cmd.ExecuteReader();
        //    if (rd1.HasRows)
        //    {
        //        while (rd1.Read())
        //        {
        //            DropDownList3.Items.Add(rd1[0].ToString());
        //        }
        //    }
        //    con.Close();
        //}
        //catch (Exception)
        //{

        //}
        //}

       
   