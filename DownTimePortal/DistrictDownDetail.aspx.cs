using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Messaging.Design;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;


public partial class DistrictDownDetail : System.Web.UI.Page
{
    public String str = null;
    string uname = null;
    static string SHQ;
    protected void Page_Load(object sender, EventArgs e)
    {
        str = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
       try
            {
                uname = Session["name"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
       if (!IsPostBack)
       {
           if (uname != null)
           {
              
               TextBox1.Text = DateTime.Now.ToShortDateString();
               TextBox2.Text = DateTime.Now.ToShortDateString();
               LoadDHQ();
               Loaddata();
               LoadBandwidth();
           }
       }

    }
     void Loaddata()
    {
       
        DateTime dt1 = Convert.ToDateTime(TextBox1.Text);
        DateTime dt2 = Convert.ToDateTime(TextBox2.Text);
        SqlConnection con = new SqlConnection(str);
        string gdata = "select * from Downdetail where (A_End=@dhq or B_End=@dhq) AND LLDown_Date BETWEEN @dt1 AND @dt2";
        //string gdata = "select * from Downdetail where A_End=@dhq or(A_End=@sq AND B_End=@dhq) AND LLDown_Date BETWEEN @dt1 AND @dt2";
      //  SearchData.SelectParameters["dt1"].DefaultValue = dt1.ToShortDateString();
      //  SearchData.SelectParameters["dt2"].DefaultValue = dt2.ToShortDateString();
      //  SearchData.SelectCommand = gdata;
      //  GridView1.DataSource = SearchData;
      //  GridView1.EmptyDataText = "No data Available";
      //GridView1.DataBind();
      //  Calculatedwntime();
        //SqlCommand cmd = new SqlCommand(gdata, con);
        //cmd.Parameters.AddWithValue("@dt1", dt1);
        //cmd.Parameters.AddWithValue("@dt2", dt2);
       // con.Open();
      //  GridView1.DataSource = cmd.ExecuteReader();
        SqlDataAdapter adp = new SqlDataAdapter(gdata, con);
        SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
        cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@dt1", dt1);
        cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@dt2", dt2);
        cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@dhq",Label19.Text);
        cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@sq", SHQ);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        ViewState["Downdetail"] = dt;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.EmptyDataText = "No data Available";
        Calculatedwntime();

    }
    void LoadDHQ()
    {
        //DropDownList1.Items.Clear();
        //DropDownList1.Items.Add("Select All");
        //DropDownList1.SelectedIndex = 0;
     //   DropDownList1.Items[0].Value = "";
            SqlConnection con = new SqlConnection(str);
            String DHQ = "Select DHQ,SHQ from AccountDetail Where Email=@eml";
            SqlCommand cmd = new SqlCommand(DHQ, con);
            cmd.Parameters.AddWithValue("@eml", uname);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                  Label19.Text=rd[0].ToString();
                  SHQ = rd[1].ToString();
                }
            }
            con.Close();
            LoadPOP();
     }

   void LoadPOP()
   {
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("Select All");
        DropDownList2.SelectedIndex = 0;
       // DropDownList2.Items[0].Value = "";
        SqlConnection con = new SqlConnection(str);
        String POP = "Select DISTINCT POP from POP where dhq=@dq";
        SqlCommand cmd = new SqlCommand(POP, con);
        cmd.Parameters.AddWithValue("@dq",Label19.Text);
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
    void LoadBandwidth()
    {
        DropDownList4.Items.Clear();
        DropDownList4.Items.Add("Select All");
        DropDownList4.SelectedIndex = 0;
        SqlConnection con = new SqlConnection(str);
        String POP = "Select DISTINCT Bandwidth from POP";
        SqlCommand cmd = new SqlCommand(POP, con);
        con.Open();
        SqlDataReader rd1 = cmd.ExecuteReader();
        if (rd1.HasRows)
        {
            while (rd1.Read())
            {
                DropDownList4.Items.Add(rd1[0].ToString());
                
            }
        }
        con.Close();
    }
    void clearlbl()
    {
        Label11.Text = "0";
        Label12.Text = "0";
        Label13.Text = "0";
        Label14.Text = "0";
        Label15.Text = "0";
        Label16.Text = "0";
        Label17.Text = "0";
        Label18.Text = "0";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        clearlbl();
        DateTime dt1 = Convert.ToDateTime(TextBox1.Text); 
        DateTime dt2 = Convert.ToDateTime(TextBox2.Text);
        SqlConnection con = new SqlConnection(str);
        string gdata = null;

        if  (DropDownList2.SelectedItem.Text == "Select All"  && DropDownList4.SelectedItem.Text == "Select All")
            {
                gdata = "select * from Downdetail where LLDown_Date BETWEEN @dt1 AND @dt2 AND (A_End=@aend or B_End=@aend) AND Reason like @rsn + '%'";  
            }
        else if (DropDownList3.SelectedItem.Text == "Select All" && DropDownList4.SelectedItem.Text == "Select All")
        {
            gdata = "select * from Downdetail where LLDown_Date BETWEEN @dt1 AND @dt2 AND ((A_End=@aend or A_End=@sq) AND B_End=@bnd) AND Reason like @rsn + '%'";
        }
        else if (DropDownList2.SelectedItem.Text == "Select All")
        {
            gdata = "select * from Downdetail where LLDown_Date BETWEEN @dt1 AND @dt2 AND Reason like @rsn + '%' AND (A_End=@aend or B_End=@aend) AND Bandwidth=@bwth";

        }
        else if (DropDownList2.SelectedItem.Text == Label19.Text && DropDownList4.SelectedItem.Text == "Select All")
        {
            
            gdata = "select * from Downdetail where LLDown_Date BETWEEN @dt1 AND @dt2 AND Reason like @rsn + '%' AND (A_End=@sq or B_End=@bnd)";

        }
        else if (DropDownList2.SelectedItem.Text == Label19.Text )
        {
            
            gdata = "select * from Downdetail where LLDown_Date BETWEEN @dt1 AND @dt2 AND Reason like @rsn + '%' AND (A_End=@sq or B_End=@bnd) AND Bandwidth=@bwth";

        }
        else if (DropDownList4.SelectedItem.Text == "Select All")
        {
            gdata = "select * from Downdetail where LLDown_Date BETWEEN @dt1 AND @dt2 AND (A_End=@aend or (A_End=@sq AND B_End=@bnd)) AND Reason like @rsn +'%'";
        }
        else
        {
            gdata = "select * from Downdetail where LLDown_Date BETWEEN @dt1 AND @dt2 AND ((A_End=@aend or A_End=@sq) AND B_End=@bnd) AND Bandwidth=@bwth AND Reason like @rsn + '%' ";

        }
            //SearchData.SelectParameters["dt1"].DefaultValue = dt1.ToShortDateString();
            //SearchData.SelectParameters["dt2"].DefaultValue = dt2.ToShortDateString();
            //SearchData.SelectParameters["aend"].DefaultValue = DropDownList1.SelectedItem.Value;
            //SearchData.SelectParameters["bnd"].DefaultValue = DropDownList2.SelectedItem.Value;
            //SearchData.SelectParameters["rsn"].DefaultValue = DropDownList3.SelectedItem.Value;
            //SearchData.SelectParameters["bwth"].DefaultValue = DropDownList4.SelectedItem.Value;
            //SearchData.SelectCommand = gdata;
            //GridView1.DataSource = SearchData;
            if (TextBox1.Text == "")
            {
                Page.RegisterStartupScript("SS", "<script> alert('Please Select First Down Date'); </script>");
            }
            else if(TextBox2.Text == "")
            {
                Page.RegisterStartupScript("SS", "<script> alert('Please Select Second Down Date'); </script>");
            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter(gdata, con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
                cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@sq", SHQ);
                cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@aend",Label19.Text);
                cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@bnd", DropDownList2.SelectedItem.Value);
                cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@rsn", DropDownList3.SelectedItem.Value);
                cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@bwth", DropDownList4.SelectedItem.Value);
                cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@dt1", dt1);
                cmd.DataAdapter.SelectCommand.Parameters.AddWithValue("@dt2", dt2);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                GridView1.EmptyDataText = "No data Available";
                //  GridView1.DataSource = null;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Calculatedwntime();
            }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Loaddata();
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
      Loaddata();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    void Calculatedwntime()
    {
         Int64 R1=0, R2=0, R3=0, R4=0, R5=0, R6=0, R7=0, R8 = 0;             
        foreach (GridViewRow gvr in GridView1.Rows)
       // for (int i = 0; i <GridView1.Rows.Count; i++)
        {

            string rsn = ((Label)gvr.FindControl("Reasonid")).Text;
            Label lblqy = (Label)gvr.FindControl("ttmin");
            //string rsn = ((Label)GridView1.Rows[i].Cells[12].FindControl("Reasonid")).Text;
            //Label lblqy = ((Label)GridView1.Rows[i].Cells[12].FindControl("ttmin"));
            if (gvr.RowType == DataControlRowType.DataRow)
          
        {
            if (rsn == "R1")
            {
                 Int64 tim = Int64.Parse(lblqy.Text); 
                R1 = R1 + tim;
            }
            if (rsn == "R2")
            {
                Int64 tim = Int64.Parse(lblqy.Text);
                R2 = R2 + tim;
            }
            if (rsn == "R3")
            {
                Int64 tim = Int64.Parse(lblqy.Text);
                R3 = R3 + tim;
            }
            if (rsn == "R4")
            {
                Int64 tim = Int64.Parse(lblqy.Text);
                R4 = R4 + tim;
            }
            if (rsn == "R5")
            {
                Int64 tim = Int64.Parse(lblqy.Text);
                R5 = R5 + tim;
            }
            if (rsn == "R6")
            {
                Int64 tim = Int64.Parse(lblqy.Text);
                R6 = R6 + tim;
            }
            if (rsn == "R7")
            {
                Int64 tim = Int64.Parse(lblqy.Text);
                R7 = R7 + tim;
            }
            if (rsn == "R8")
            {
                Int64 tim = Int64.Parse(lblqy.Text);
                R8 = R8 + tim;
            }
        }
         TimeSpan ts1 = TimeSpan.FromMinutes(Convert.ToDouble(R1));
         TimeSpan ts2 = TimeSpan.FromMinutes(Convert.ToDouble(R2));
         TimeSpan ts3 = TimeSpan.FromMinutes(Convert.ToDouble(R3));
         TimeSpan ts4 = TimeSpan.FromMinutes(Convert.ToDouble(R4));
         TimeSpan ts5 = TimeSpan.FromMinutes(Convert.ToDouble(R5));
         TimeSpan ts6 = TimeSpan.FromMinutes(Convert.ToDouble(R6));
         TimeSpan ts7 = TimeSpan.FromMinutes(Convert.ToDouble(R7));
         TimeSpan ts8 = TimeSpan.FromMinutes(Convert.ToDouble(R8));
         Label11.Text = ts1.Days + " Days " + ts1.Hours + " Hrs " + ts1.Minutes + " Min";
         Label12.Text = ts2.Days + " Days " + ts2.Hours + " Hrs " + ts2.Minutes + " Min";
         Label13.Text = ts3.Days + " Days " + ts3.Hours + " Hrs " + ts3.Minutes + " Min";
         Label14.Text = ts4.Days + " Days " + ts4.Hours + " Hrs " + ts4.Minutes + " Min";
         Label15.Text = ts5.Days + " Days " + ts5.Hours + " Hrs " + ts5.Minutes + " Min";
         Label16.Text = ts6.Days + " Days " + ts6.Hours + " Hrs " + ts6.Minutes + " Min";
         Label17.Text = ts7.Days + " Days " + ts7.Hours + " Hrs " + ts7.Minutes + " Min";
         Label18.Text = ts8.Days + " Days " + ts8.Hours + " Hrs " + ts8.Minutes + " Min";
        }
        
    } 
  
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Calculatedwntime();
        //if (e.Row.RowType == DataControlRowType.Pager)
        //{
        //    //DropDownList dls = (DropDownList)e.Row.FindControl("DropDownList1");
        //    //for (int i = 1; i <= GridView1.PageCount; i++)
        //    //{
        //    //    dls.Items.Add(i.ToString());
        //    //}

        //    //dls.SelectedIndex = GridView1.PageIndex;

        //    LinkButton link1 = (LinkButton)e.Row.FindControl("LinkButton1");
        //    LinkButton link2 = (LinkButton)e.Row.FindControl("LinkButton2");
        //    LinkButton link3 = (LinkButton)e.Row.FindControl("LinkButton3");
        //    LinkButton link4 = (LinkButton)e.Row.FindControl("LinkButton4");
        //    link1.Visible = (GridView1.PageIndex != 0);
        //    link2.Visible = (GridView1.PageIndex != 0);
        //    link3.Visible = (GridView1.PageIndex < GridView1.PageCount - 1);
        //    link4.Visible = (GridView1.PageIndex < GridView1.PageCount - 1);
        //}

    }
    void Rowcolor()
    {
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            string rsn = ((Label)gvr.FindControl("Reasonid")).Text;
           // if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (rsn == "R1")
                {
                    gvr.Cells[11].ForeColor = System.Drawing.Color.Red;
                    //  e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (rsn == "R2")
                {
                    //  e.Row.BackColor = System.Drawing.Color.Orange;
                    gvr.Cells[11].ForeColor = System.Drawing.Color.Yellow;
                }
                if (rsn == "R3")
                {
                    //  e.Row.BackColor = System.Drawing.Color.Orange;
                    gvr.Cells[11].BackColor = System.Drawing.Color.Blue;
                }
                if (rsn == "R4")
                {
                    //  e.Row.BackColor = System.Drawing.Color.Orange;
                    gvr.Cells[11].BackColor = System.Drawing.Color.SaddleBrown;
                }
                if (rsn == "R5")
                {
                    //  e.Row.BackColor = System.Drawing.Color.Orange;
                    gvr.Cells[11].BackColor = System.Drawing.Color.Gray;
                }
                if (rsn == "R6")
                {
                    //  e.Row.BackColor = System.Drawing.Color.Orange;
                    gvr.Cells[11].BackColor = System.Drawing.Color.Green;
                }
                if (rsn == "R7")
                {
                    //  e.Row.BackColor = System.Drawing.Color.Orange;
                   gvr.Cells[11].BackColor = System.Drawing.Color.White;
                }
                if (rsn == "R8")
                {
                    //  e.Row.BackColor = System.Drawing.Color.Orange;
                   gvr.Cells[11].BackColor = System.Drawing.Color.YellowGreen;
                }
            }
        }
    }
   
}