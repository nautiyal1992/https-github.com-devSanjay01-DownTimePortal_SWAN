using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
public partial class Admin_AccountRequest : System.Web.UI.Page
{
    String con_str1 = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        string uname=null;
        try
        {
             uname = Session["name"].ToString();
                       
        }
       catch (Exception exs)
           {
                Response.Redirect("~/Account/Login.aspx");
           }    
    }
    

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Rowcolor();
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string value = (string)DataBinder.Eval(e.Row.DataItem, e.Row.Cells[9].Text.ToString());
           
        //    // e.Row.Cells[2] references the cell value you want to use
        //    if (value == "Allow")
        //    {
        //        e.Row.Cells[10].ForeColor = System.Drawing.Color.Green;
        //    }
        //    else if (value == "Cancel")
        //    {
        //        e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
        //    }
        //}
    }
    void Rowcolor()
    {
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            try
            {
                DropDownList sts1 = ((DropDownList)gvr.FindControl("DropDownList1"));
                string sts = ((Label)gvr.FindControl("Status")).Text;
                // if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (sts == "Admin")
                    {
                        //  gvr.Cells[9].BackColor = System.Drawing.Color.Green;
                        gvr.Cells[9].ForeColor = System.Drawing.Color.Blue;
                        //  e.Row.ForeColor = System.Drawing.Color.White;
                    }
                    if (sts == "Allow")
                    {
                        //  gvr.Cells[9].BackColor = System.Drawing.Color.Green;
                        gvr.Cells[9].ForeColor = System.Drawing.Color.ForestGreen;
                        //  e.Row.ForeColor = System.Drawing.Color.White;
                    }
                    if (sts == "Cancel")
                    {
                        //  e.Row.BackColor = System.Drawing.Color.Orange;
                        gvr.Cells[9].ForeColor = System.Drawing.Color.Red;
                        // gvr.Cells[9].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    }

                }
            }
            catch (Exception e)
            {
            }
        }
    }
   
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        String pr = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedItem.Text;
        string eml = GridView1.DataKeys[e.RowIndex].Value.ToString();
        SqlConnection con = new SqlConnection(con_str1);
        string chgper = "Update AccountDetail SET Permission=@pr where Email=@eml";
        SqlCommand cmd = new SqlCommand(chgper, con);
        cmd.Parameters.AddWithValue("@pr", pr);
        cmd.Parameters.AddWithValue("@eml", eml);
        con.Open();
        int g = (int)cmd.ExecuteNonQuery();
        con.Close();
        if (g != 0)
        {
            Page.RegisterStartupScript("SS", "<script> alert('Permission Change Successfully'); </script>");
          //  SendMail(pr,eml);
            GridView1.DataBind();
        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      //  String pr = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedItem.Text;
        string eml = GridView1.DataKeys[e.RowIndex].Value.ToString();
        SqlConnection con = new SqlConnection(con_str1);
        string chgper = "Delete from AccountDetail where Email=@eml";
        SqlCommand cmd = new SqlCommand(chgper, con);
        cmd.Parameters.AddWithValue("@eml", eml);
        con.Open();
        int g = (int)cmd.ExecuteNonQuery();
        con.Close();
        if (g != 0)
        {
            Page.RegisterStartupScript("SS", "<script> alert('Account Delete Successfully'); </script>");
         //   SendMail("Delete", eml);
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        GridView1.DataBind();
    }
    //public void SendMail(string per, string eml)
    //{
    //    MailMessage msg = new MailMessage();
    //    msg.From = new MailAddress("ukswan.nai.snfe@gmail.com");
    //    msg.To.Add(new MailAddress(eml));
    //    msg.Subject = "UKSWAN DOWNTIME PORTAL Admin";
    //    msg.IsBodyHtml = true;

    //    SmtpClient client = new SmtpClient();
    //    client.Host = "smtp.gmail.com";
    //    client.Port = 587;
    //    client.EnableSsl = true;
    //    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("ukswan.nai.snfe@gmail.com", "snfe@123#");
    //    client.UseDefaultCredentials = true;
    //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    //    client.Credentials = credentials;
               
    //    string Body;
    //    if (per == "Delete")
    //    {
    //        Body = "Dear User, Your account has been " + per;
    //    }
    //    else
    //    {
    //        Body = "Dear User, Your account permission has been changed with " + per;
    //    }
    //    msg.Body = string.Format("<html><head></head><body><b>" + Body + "</b></body>");
    //    try
    //    {
    //        client.Send(msg);
    //        // Label4.Text = "Your msg has been successfully send";
    //    }

    //    catch (Exception ex)
    //    {
    //        // Label4.Text = "Error occured while sending your msg" + ex.Message;
    //    }
    //}
    
}
