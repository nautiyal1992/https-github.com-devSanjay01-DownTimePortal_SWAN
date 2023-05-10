using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;


public partial class Use_Control_LoginUC : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
               
    }
    protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Checkstatus cs = new Checkstatus();
        e.Authenticated = cs.checklogin(Login1.UserName, Login1.Password);
        if (e.Authenticated)
        {

            Checkrole chr = new Checkrole();
            string[] role = chr.Role(Login1.UserName, Login1.Password);
            Session["dhqac"] = role[1].ToString();
            Session["Popac"] = role[2].ToString();
            Session["shqac"] = role[3].ToString();
            if (role[0] == "Admin")
            {
                Session["name"] = Login1.UserName;
                Response.Redirect("~/Admin/AccountRequest.aspx");
            }
            else if (role[0] == "Allow")
            {
                Session["name"] = Login1.UserName;
                if (role[1] == role[2])
                    Response.Redirect("~/DHQHome.aspx");
                else
                    Response.Redirect("~/Home.aspx");
            }
            else if (role[0] == "Cancel")
            {
                // Page.RegisterStartupScript("SS", "<script> alert('Admin not allow you for access '); </script>");
                Response.Redirect("~/Responce.aspx");
            }
        }
       
    }
}