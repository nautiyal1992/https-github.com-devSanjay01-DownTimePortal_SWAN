using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


public partial class Home : System.Web.UI.Page
{
    public String str = null;
    public string uname = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        str = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        if (!IsPostBack)
        {
            try
            {
                uname = Session["name"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            if (uname != null)
            {
                Detail();
                ppdetail();
                DateTime fdy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                TextBox1.Text = fdy.ToShortDateString();
                TextBox4.Text = DateTime.Today.ToShortDateString();
            }
        }
            
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "")
        {
            Page.RegisterStartupScript("SS", "<script> alert('Data Fiels Can not be Blank'); </script>");
        }
        else if (DropDownList1.Text == "Reason")
        {
            Page.RegisterStartupScript("SS", "<script> alert('Kindly Select Reason for Down'); </script>");
        }
        else
        {
            //try
            //{
            DateTime dt1 = Convert.ToDateTime(TextBox1.Text);
            DateTime tm1 = Convert.ToDateTime(TextBox2.Text);
            DateTime dt2 = Convert.ToDateTime(TextBox4.Text);
            DateTime tm2 = Convert.ToDateTime(TextBox5.Text);
            TimeSpan dtf = dt2 - dt1;
            TimeSpan tmf = tm2 - tm1;
            TimeSpan ts1 = dtf + tmf;
            int dy = ts1.Days;
            int hr = ts1.Hours;
            int mn = ts1.Minutes;
            int sec = ts1.Seconds;
            double tmin = ts1.TotalMinutes;
            int Days = ts1.Days;
            int Hours = ts1.Hours;
            int Minutes = ts1.Minutes;
            int Seconds = ts1.Seconds;
            //DateTime Now = Convert.ToDateTime(TextBox4.Text);
            //int Years = new DateTime(DateTime.Now.Subtract(dt1).Ticks).Year - 1;
            //DateTime PastYearDate = dt1.AddYears(Years);
            //int Months = 0;
            //for (int i = 1; i <= 12; i++)
            //{
            //    if (PastYearDate.AddMonths(i) == Now)
            //    {
            //        Months = i;
            //        break;
            //    }
            //    else if (PastYearDate.AddMonths(i) >= Now)
            //    {
            //        Months = i - 1;
            //        break;
            //    }
            //}
            //int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            //int Hours = Now.Subtract(PastYearDate).Hours + tmf.Hours;
            //int Minutes = Now.Subtract(PastYearDate).Minutes + tmf.Minutes;
            //int Seconds = Now.Subtract(PastYearDate).Seconds;
            try
            {
            SqlConnection con = new SqlConnection(str);
            string insdntm = "INSERT Into Downdetail values(@and,@bnd,@bwth,@nopen,@ncls,@llddt,@lldtm,@rta,@lludt,@llutm,@rsn,@ttdtm,@rmk,@dnu,@tmn)";
            SqlCommand cmddtm = new SqlCommand(insdntm, con);
            cmddtm.Parameters.AddWithValue("@and", Label4.Text);
            cmddtm.Parameters.AddWithValue("@bnd", Label5.Text);
            cmddtm.Parameters.AddWithValue("@bwth", Convert.ToInt32(Label6.Text));
            cmddtm.Parameters.AddWithValue("@nopen", Label7.Text);
            cmddtm.Parameters.AddWithValue("@ncls", Label8.Text);
            cmddtm.Parameters.AddWithValue("@llddt", Convert.ToDateTime(TextBox1.Text));
            cmddtm.Parameters.AddWithValue("@lldtm", tm1);
            cmddtm.Parameters.AddWithValue("@rta", TextBox3.Text);
            cmddtm.Parameters.AddWithValue("@lludt", Convert.ToDateTime(TextBox4.Text));
            cmddtm.Parameters.AddWithValue("@llutm", tm2);
            cmddtm.Parameters.AddWithValue("@rsn", DropDownList1.Text);
            cmddtm.Parameters.AddWithValue("@ttdtm", Label9.Text);
            cmddtm.Parameters.AddWithValue("@rmk", TextBox6.Text);
            cmddtm.Parameters.AddWithValue("@dnu", TextBox7.Text);
            //cmddtm.Parameters.AddWithValue("@yr", Years);
            //cmddtm.Parameters.AddWithValue("@mnth", Months);
            cmddtm.Parameters.AddWithValue("@dy", Days);
            cmddtm.Parameters.AddWithValue("@hr", Hours);
            cmddtm.Parameters.AddWithValue("@mn", Minutes);
            cmddtm.Parameters.AddWithValue("@tmn", tmin);
            con.Open();
            int tag = (int)cmddtm.ExecuteNonQuery();
            con.Close();
            if (tag != 0)
                Page.RegisterStartupScript("SS", "<script> alert('Data Insert Successfully'); </script>");
            GridView1.DataBind();
            Clearfield();
              }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    Page.RegisterStartupScript("SS", "<script> alert('Dublicate Entry not allow  for Same Date and Time that is already for A-END and B-End'); </script>");
            }
            
            //catch (Exception ex)
            //{
            //}
        }
    }
    void Clearfield()
    {
        TextBox2.Text = "00:00";
        TextBox3.Text = "NA";
        TextBox5.Text = "00:00";
        TextBox6.Text = "";
        TextBox7.Text = "";
        DropDownList1.ClearSelection();
        Label9.Text = "0";
        TextBox1.Text = DateTime.Today.ToShortDateString();
        TextBox4.Text = DateTime.Today.ToShortDateString();
    }
    void counttime()
    {

        try
        {
            DateTime dt1 = Convert.ToDateTime(TextBox1.Text);
            DateTime tm1 = Convert.ToDateTime(TextBox2.Text);
            DateTime dt2 = Convert.ToDateTime(TextBox4.Text);
            DateTime tm2 = Convert.ToDateTime(TextBox5.Text);
            TimeSpan dtf = dt2 - dt1;
            TimeSpan tmf = tm2 - tm1;
            TimeSpan ts1 = dtf + tmf;
            int Days = ts1.Days;
            int Hours = ts1.Hours;
            int Minutes = ts1.Minutes;
            int Seconds = ts1.Seconds;
            //Label12.Visible = true;
            //Label12.Text = ts1.ToString();
            //DateTime Now = Convert.ToDateTime(TextBox4.Text);
            //int Years = new DateTime(DateTime.Now.Subtract(dt1).Ticks).Year - 1;
            //DateTime PastYearDate = dt1.AddYears(Years);
            //int Months = 0;
            //for (int i = 1; i <= 12; i++)
            //{
            //    if (PastYearDate.AddMonths(i) == Now)
            //    {
            //        Months = i;
            //        break;
            //    }
            //    else if (PastYearDate.AddMonths(i) >= Now)
            //    {
            //        Months = i - 1;
            //        break;
            //    }
            //}
            //int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
             //int Hours = Now.Subtract(PastYearDate).Hours;
             //int Minutes = Now.Subtract(PastYearDate).Minutes;
             //int Seconds = Now.Subtract(PastYearDate).Seconds;
          
            //if (Years > 0)
            //{
            //    Label9.Text = Years + " Yr " + Months + " Mnth " + Days + " Day " + Hours + " Hrs " + Minutes + " Min ";
            //}
            //else if (Months > 0)
            //{
            //    Label9.Text = Months + " Mnth " + Days + " Day " + Hours + " Hrs " + Minutes + " Min ";
            //}
             if (Days > 0)
            {
                Label9.Text = Days + " Day " + Hours + " Hrs " + Minutes + " Min ";
            }
            else
            {
                Label9.Text = Hours + " Hrs " + Minutes + " Min ";
            }
        }
        catch (Exception ex)
        {
        }
    }
    
    void Detail()
    {
        try
        {
            String shq, dhq, pop;
            SqlConnection con = new SqlConnection(str);
            String usrdtl = "select * from AccountDetail where email=@e";
            SqlCommand cmd = new SqlCommand(usrdtl, con);
            cmd.Parameters.AddWithValue("@e", uname);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    shq = rd["SHQ"].ToString();
                    dhq = rd["DHQ"].ToString();
                    pop = rd["POP"].ToString();
                    if (dhq == pop)
                    {
                        Label4.Text = shq;
                        Label5.Text = dhq; 
                    }
                    else
                    {
                        Label4.Text = dhq;
                        Label5.Text = pop;
                    }
                }
            }
            con.Close();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    void ppdetail()
    {
        try
        {
            
            SqlConnection con = new SqlConnection(str);
            String usrdtl = "select * from POP where pop=@p";
            SqlCommand cmd = new SqlCommand(usrdtl, con);
            cmd.Parameters.AddWithValue("@p", Label5.Text);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                   // Label11.Text = rd["POP_Type"].ToString();
                    Label6.Text = rd["Bandwidth"].ToString();
                    Label7.Text = rd["NOC_Open_Time"].ToString();
                    Label8.Text = rd["NOC_Close_Time"].ToString();
                }
            }
            con.Close();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

   
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(TextBox1.Text) > Convert.ToDateTime(TextBox4.Text))
        {
            Label12.Visible = true;
            Label12.Text="Date can't be greater than LL UP Date";
        }
        else if (Convert.ToDateTime(TextBox4.Text) > DateTime.Now)
        {
            
           Label12.Text = "Date can't be greater than Curent Date and Time";
            TextBox4.Text = DateTime.Now.ToShortDateString();
           
        }
        else
        {
            Label12.Text = "";
            counttime();
        }
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        Regex checktime = new Regex(@"^(([0-9])|([0-1][0-9])|([2][0-3])):([0-5][0-9])$");
        if (!checktime.IsMatch(TextBox5.Text))
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Valid Time'); </script>");
            TextBox5.Text = "00:00";
        }
        else
        {
            Label12.Text = "";
            counttime();
        }
       
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox4.Text = DateTime.Now.ToShortDateString();
        if (Convert.ToDateTime(TextBox1.Text) > Convert.ToDateTime(TextBox4.Text))
        {
            Label12.Visible = true;
            Label12.Text = "Date can't be greater than LL UP Date";
            DateTime pdt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
            TextBox1.Text = pdt.ToShortDateString();
        }
        else
        {
            Label12.Text = "";
            counttime();
        }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

        Regex checktime = new Regex(@"^(([0-9])|([0-1][0-9])|([2][0-3])):([0-5][0-9])$");
        if (!checktime.IsMatch(TextBox2.Text))
        {
            Page.RegisterStartupScript("SS", "<script> alert('Enter Valid Time'); </script>");
            TextBox2.Text = "00:00";
        }
        else
        {

            Label12.Text = "";
            counttime();
        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string aend = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string bend = GridView1.DataKeys[e.RowIndex].Values[1].ToString();
        DateTime lldwndt = Convert.ToDateTime(GridView1.DataKeys[e.RowIndex].Values[2].ToString());
        string lldwntm = GridView1.DataKeys[e.RowIndex].Values[3].ToString();
        DateTime llupdt = Convert.ToDateTime(GridView1.DataKeys[e.RowIndex].Values[4].ToString());
        string lluptm = GridView1.DataKeys[e.RowIndex].Values[5].ToString();
        string rsn = GridView1.DataKeys[e.RowIndex].Values[6].ToString();
        SqlConnection con = new SqlConnection(str);
        string delrw = "Delete from Downdetail where A_End=@aend and B_End=@bend and LLDown_Date=@lldwndt and LLDown_Time=@lldwntm and LLUP_Date=@llupdt"
            + " and LLUP_Time=@lluptm and Reason=@rsn";
        SqlCommand cmd = new SqlCommand(delrw, con);
        cmd.Parameters.AddWithValue("@aend", aend);
        cmd.Parameters.AddWithValue("@bend", bend);
        cmd.Parameters.AddWithValue("@lldwndt", lldwndt);
        cmd.Parameters.AddWithValue("@lldwntm", lldwntm);
        cmd.Parameters.AddWithValue("@llupdt", llupdt);
        cmd.Parameters.AddWithValue("@lluptm", lluptm);
        cmd.Parameters.AddWithValue("@rsn", rsn);
        con.Open();
        int g = (int)cmd.ExecuteNonQuery();
        con.Close();
        if (g != 0)
        {
            Page.RegisterStartupScript("SS", "<script> alert('Record Delete Successfully'); </script>");
            GridView1.DataBind();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Reason")
        {
            TextBox6.Text = "";
            TextBox7.Text = "";
        }
        if (DropDownList1.SelectedItem.Text == "R1")
        {
            TextBox6.Text = "Power Cut";
            TextBox7.Text = "";
        }
        if (DropDownList1.SelectedItem.Text == "R2")
        {
            TextBox6.Text = "Down Due to BSNL";
            TextBox7.Text = "";
        }
        if (DropDownList1.SelectedItem.Text == "R3")
        {
            TextBox6.Text = "Device Problem";
            TextBox7.Text = "";
        }
        if (DropDownList1.SelectedItem.Text == "R4")
        {
            TextBox6.Text = "UPS Faulty/Backup Low";
            TextBox7.Text = "";
        }
        if (DropDownList1.SelectedItem.Text == "R5")
        {
            TextBox6.Text = "FMS Not Present";
            TextBox7.Text = "";
        }
        if (DropDownList1.SelectedItem.Text == "R6")
        {
            TextBox6.Text = "FMS Late/Left Early";
            TextBox7.Text = "";
        }
        if (DropDownList1.SelectedItem.Text == "R7")
        {
            TextBox6.Text = "Keys Not Available ";
            TextBox7.Text = "";
        }
        if (DropDownList1.SelectedItem.Text == "R8")
        {
            TextBox6.Text = "Other Reason";
            TextBox7.Text = "";
        }
    }
}