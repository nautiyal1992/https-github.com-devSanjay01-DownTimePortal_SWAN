using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using Microsoft.Reporting.WebForms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class Report : System.Web.UI.Page
{
    string uname = null;
    String con_str1 = null;
    DateTime dt1;
    DateTime dt2;
    protected void Page_Load(object sender, EventArgs e)
    {
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
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
             
             if (!Page.IsPostBack)
             {
                 //dt1 = Convert.ToDateTime(TextBox1.Text);
                 //dt2 = Convert.ToDateTime(TextBox2.Text);
                 TextBox1.Visible = true;
                 TextBox2.Visible = false;
                 Label12.Text = "Select Date";
                 Label12.Visible = true;
                 Label13.Visible = false;
                 TextBox1.Text = DateTime.Today.ToShortDateString();
                 LoadDHQ();
                 // DataTable dt = GetData();
                 //LoadChartData(dt);
             }
        }
    }
    void LoadDHQ()
    {
        SqlConnection con = new SqlConnection(con_str1);
        String DHQ = "Select DHQ from AccountDetail Where Email=@eml";
        SqlCommand cmd = new SqlCommand(DHQ, con);
        cmd.Parameters.AddWithValue("@eml", uname);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
            while (rd.Read())
            {
                Label11.Text = rd[0].ToString();
            }
        }
        con.Close();
        LoadPOP();
    }
    void LoadPOP()
   {
       DropDownList1.Items.Clear();
        //DropDownList1.Items.Add("Select All");
        //DropDownList1.SelectedIndex = 0;
       // DropDownList2.Items[0].Value = "";
        SqlConnection con = new SqlConnection(con_str1);
        String POP = "Select POP from POP where dhq=@dq";
        SqlCommand cmd = new SqlCommand(POP, con);
        cmd.Parameters.AddWithValue("@dq",Label11.Text);
        con.Open();
        SqlDataReader rd1 = cmd.ExecuteReader();
        if (rd1.HasRows)
        {
            while (rd1.Read())
            {
                DropDownList1.Items.Add(rd1[0].ToString());
            }
        }
        con.Close();
    }
    private DataTable GetData()
    {
       // DataSet Reportset = new DataSet();
        //string aend = a;
        Int16 popn = 0;
        string pp=null;
            string ltype=null;
            double abstm=0;
        string npop;
       
        SqlConnection con = new SqlConnection(con_str1);
        npop = "select count(POP) from POP where DHQ=@dq";
        //  string npop = "select count(DISTINCT B_End) from Downdetail where A_End=@dq";
        SqlCommand cmd = new SqlCommand(npop, con);
        cmd.Parameters.AddWithValue("@dq", Label11.Text);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
            while (rd.Read())
            { 
                popn = Convert.ToInt16(rd[0].ToString());
            }
        }
        con.Close();
        DataTable dt = new DataTable();
        dt.TableName = "DownTime";
        dt.Columns.Add("S_NO", Type.GetType("System.String"));
        dt.Columns.Add("LType", Type.GetType("System.String"));
        dt.Columns.Add("AEND", Type.GetType("System.String"));
        dt.Columns.Add("BEND", Type.GetType("System.String"));
        dt.Columns.Add("WHrs", Type.GetType("System.String"));
        dt.Columns.Add("R1", Type.GetType("System.String"));
        dt.Columns.Add("R2", Type.GetType("System.String"));
        dt.Columns.Add("R3", Type.GetType("System.String"));
        dt.Columns.Add("R4", Type.GetType("System.String"));
        dt.Columns.Add("R5", Type.GetType("System.String"));
        dt.Columns.Add("R6", Type.GetType("System.String"));
        dt.Columns.Add("R7", Type.GetType("System.String"));
        dt.Columns.Add("R8", Type.GetType("System.String"));
        dt.Columns.Add("CPenalty", Type.GetType("System.String"));
        string[] Rsn = new string[] { "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8" };
        for (int i = 0; i < popn; i++)
        {
           
          string lnk = poplk(ltype, i);
          string AEND =  popand(pp, i);
          double wtm= Workhrs( i);
          if (wtm == 23.59)
          {
              abstm = Convert.ToInt32(Math.Ceiling(wtm));
          }
          else
          {
              abstm = wtm;
          }
           sumr(Rsn, i);
           TimeSpan[] ts = new TimeSpan[8];
           int  [] tim = new int [8];
           string[] data = new string[8];
           for (int t = 0; t <= 7; t++)
           {
               if (Rsn[t] == "")
               {
                   Rsn[t] = "0";
               }
               else
               {
                   ts[t] = TimeSpan.FromMinutes(Convert.ToDouble(Rsn[t]));
               }
               int d = ts[t].Days;
               int td = d * 24;
               int tdd = td + ts[t].Hours;
               if (ts[t].TotalMinutes == 0)
               {
                   data[t] = "NIL";
               }
               else
               {
                   tim[t] = tdd;
                   data[t] = tim[t] + ":" + ts[t].Minutes;
               }
           }
            DataRow dr1 = dt.NewRow();
            dr1["S_No"] = i+1;
            dr1["AEND"] = AEND;
            dr1["LType"] = lnk;
            dr1["WHrs"] = abstm;
            dr1["BEND"] = DropDownList1.Items[i].Text;
            dr1["R1"] = data[0];
            dr1["R2"] = data[1];
            dr1["R3"] = data[2];
            dr1["R4"] = data[3];
            dr1["R5"] = data[4];
            dr1["R6"] = data[5];
            dr1["R7"] = data[6];
            dr1["R8"] = data[7];
            dr1["CPenalty"]="";
            dt.Rows.Add(dr1);
        }
    
        
      //  dss.Tables[0].TableName = "DownTime";
        //dss.GetXmlSchema();
        //dt.WriteXmlSchema("D:/Projects/DownTimePortal/App_Code/Reportset.xsd");
        //dt.WriteXml("D:/Projects/DownTimePortal/App_Code/Reportset.xml");
         SqlDataAdapter adapter = new SqlDataAdapter();
            NewDataSet ds = new NewDataSet();
         //   ds.Merge(dt);
          //  return ds.Tables["DownTime"];
            return dt;
       
    }
    double Workhrs(int i)
    {
       // int Opentime=0;

        DateTime opn = DateTime.Now ;
        DateTime cls = DateTime.Now;
        TimeSpan Opentime;
        SqlConnection con = new SqlConnection(con_str1);
            string sumrsn = "select NOC_Open_Time,NOC_Close_Time from POP where POP=@pp";
            SqlCommand cmd = new SqlCommand(sumrsn, con);
            cmd.Parameters.AddWithValue("@pp", DropDownList1.Items[i].Text);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    opn = Convert.ToDateTime(rd[0].ToString());
                    cls = Convert.ToDateTime(rd[1].ToString());
                    
                }
            }
            con.Close();
            Opentime = cls - opn;
          //  return Opentime;
            return Convert.ToDouble(Opentime.Hours+"."+Opentime.Minutes);   
        
    }
    public string poplk(string Ltype,int i)
    {
            SqlConnection con = new SqlConnection(con_str1);
            string sumrsn = "select Link_Type from POP where POP=@pp";
            SqlCommand cmd = new SqlCommand(sumrsn, con);
            cmd.Parameters.AddWithValue("@pp", DropDownList1.Items[i].Text);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Ltype = rd[0].ToString();
                    //pp[1] = rd[1].ToString();
                }
            }
            con.Close();
            return Ltype;       
    }
    public string popand(string pp, int i)
    {
        SqlConnection con = new SqlConnection(con_str1);
        string sumrsn = "select DISTINCT A_End from Downdetail where B_End=@pp";
        SqlCommand cmd = new SqlCommand(sumrsn, con);
        cmd.Parameters.AddWithValue("@pp", DropDownList1.Items[i].Text);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
            while (rd.Read())
            {
                pp = rd[0].ToString();
                //pp[1] = rd[1].ToString();
            }
        }
        con.Close();
        return pp;
    }
    public string[] sumr(string[] s, int i)
    {
        string[] Rn = new string[] { "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8" };
        string[] R = new string[8];
        //for (int p = 0; p <= DropDownList2.Items.Count; p++)
        //{
        for (int j = 0; j <= 7; j++)
        {
            SqlConnection con = new SqlConnection(con_str1);
            string sumrsn = "select sum(TotalMin) from Downdetail where LLdown_Date BETWEEN @dt1 AND @dt2 AND Reason=@rsn AND B_End=@pp";
            SqlCommand cmd = new SqlCommand(sumrsn, con);
            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
            // cmd.Parameters.AddWithValue("@aend", DropDownList1.Items[i].Text);
            cmd.Parameters.AddWithValue("@pp", DropDownList1.Items[i].Text);
            cmd.Parameters.AddWithValue("@rsn", Rn[j]);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    s[j] = rd[0].ToString();
                    R[j] = Rn[j];
                }
            }
            con.Close();
        }
        //}

        return R;
    }
    private void LoadChartData(DataTable initialDataSource)
    {
    //    DataTable dt = GetData();
    //    dt.TableName = "DownTime";
    //    dt.WriteXmlSchema(@"D:\Projects\DownTimePortal\App_Code\Reportset.xsd");


    //    // LoadChartData(dt);

    //    GridView1.DataSource = dt;
    //    GridView1.DataBind();
    //    if (!IsPostBack)
    //    {
    //        ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc");
    //        ReportDataSource datasource = new ReportDataSource("DownTime", dt);
    //        ReportViewer1.LocalReport.DataSources.Clear();
    //        ReportViewer1.LocalReport.DataSources.Add(datasource);
    //        ReportViewer1.DataBind();
    //        ReportViewer1.LocalReport.Refresh();
       // }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (RadioButtonList1.SelectedItem.Text == "Daily Down Time Report")
        {

            if (TextBox1.Text == "")
            {
                Page.RegisterStartupScript("SS", "<script> alert('Field can't be blank'); </script>");
            }
            else
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Detail.rdlc");
                DataTable dt = GetSPResultd();
                ReportDataSource datasource = new ReportDataSource("Downdetail", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportParameter[] rptparameter = new ReportParameter[]
                    {
                        new ReportParameter("Cdate",TextBox1.Text)
                    };
                ReportViewer1.LocalReport.SetParameters(rptparameter);
                ReportViewer1.LocalReport.Refresh();

            }
        }
        else if (RadioButtonList1.SelectedItem.Text == "Monthly Panelty Report")
        {
            //  DataSet ds = new DataSet();
            if (TextBox1.Text == "")
            {
                Page.RegisterStartupScript("SS", "<script> alert('Kindly Select First Date'); </script>");
            }
            else if (TextBox2.Text == "")
            {
                Page.RegisterStartupScript("SS", "<script> alert('Kindly Select Last Date'); </script>");
            }
            else
            {
                dt1 = Convert.ToDateTime(TextBox1.Text);
                dt2 = Convert.ToDateTime(TextBox2.Text);
                // dt1 = new DateTime(dt2.Year, dt2.Month, 1);
                if (dt1.Month != dt2.Month && dt1.Year != dt2.Year)
                {
                    Page.RegisterStartupScript("SS", "<script> alert('Kindly Select Same month and Year'); </script>");
                }
                else
                {
                    DataTable dtt1 = GetData();
                    dtt1.TableName = "DownTime";
                    LoadChartData(dtt1);
                    GridView1.DataSource = dtt1;
                    GridView1.DataBind();
                    dtt1.Clear();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/DHQReport.rdlc");
                    DataTable dt = GetData();
                    ReportDataSource datasource = new ReportDataSource("DownTime", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    string mth = Convert.ToDateTime(TextBox2.Text).Month.ToString();
                    string yr = Convert.ToDateTime(TextBox2.Text).Year.ToString();
                    ReportParameter[] rptparameter = new ReportParameter[]
        {
            new ReportParameter("DHQ",Label11.Text),
            new ReportParameter("Month",mth),
            new ReportParameter("Year",yr)
        };
                    ReportViewer1.LocalReport.SetParameters(rptparameter);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
            //  int row = dt.Rows.Count;
            //for (int i = 0; i < row; i++)
            //{
            //       ReportParameter[] rptparameter1 = new ReportParameter[]
            //   {
            //       new ReportParameter("DHQ",Label11.Text),
            //       new ReportParameter("Month",mth),
            //       new ReportParameter("Year",yr),
            //       new ReportParameter("SN",dt.Rows[1].ToString()),
            //       new ReportParameter("LKN",dt.Rows[1].ToString()),
            //       new ReportParameter("AEND",dt.Rows[1].ToString()),
            //       new ReportParameter("BEND",dt.Rows[1].ToString()),
            //       new ReportParameter("WHR",dt.Rows[1].ToString()),
            //       new ReportParameter("R1",dt.Rows[1].ToString()),
            //       new ReportParameter("R2",dt.Rows[1].ToString()),
            //       new ReportParameter("R3",dt.Rows[1].ToString()),
            //       new ReportParameter("R4",dt.Rows[1].ToString()),
            //       new ReportParameter("R5",dt.Rows[1].ToString()),
            //       new ReportParameter("R6",dt.Rows[1].ToString()),
            //       new ReportParameter("R7",dt.Rows[1].ToString()),
            //       new ReportParameter("R8",dt.Rows[1].ToString()),
            //       new ReportParameter("Cmpny",dt.Rows[1].ToString()),

            //   };

            //       ReportViewer1.LocalReport.SetParameters(rptparameter1);
            ////   }


            //   ReportViewer1.LocalReport.Refresh();

        }

    }

    private DataTable GetSPResultd()
    {
        DataTable Downdetail = new DataTable();
        SqlConnection con = new SqlConnection(con_str1);
        string qry = "SELECT A_End, B_End, NOC_Open, NOC_Close, LLDown_Date, LLDown_Time, Report_Agency, LLUP_Date, LLUP_Time, Reason, TotalDown_Time, Remark, Docket_No,TotalMin FROM Downdetail WHERE LLUP_Date = @ddate AND (A_End=@dhq or B_End=@dhq) ORDER BY A_End";
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.Parameters.AddWithValue("@ddate", Convert.ToDateTime(TextBox1.Text));
        cmd.Parameters.AddWithValue("@dhq", Label11.Text);
        // cmd.Parameters.AddWithValue("@tm", min);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        Majorissueset ds = new Majorissueset();
        adapter.Fill(ds.Tables["Downdetail"]);
        return ds.Tables["Downdetail"];
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "Daily Down Time Report")
        {

            TextBox1.Visible = true;
            TextBox2.Visible = false;
            Label12.Text = "Select Date";
            Label12.Visible = true;
            Label13.Visible = false;
            Clearfiled();
            TextBox1.Text = DateTime.Today.ToShortDateString();
        }
        else if (RadioButtonList1.SelectedItem.Text == "Monthly Panelty Report")
        {
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Label12.Text = "Select From Date :";
            Label12.Visible = true;
            Label13.Visible = true;
            Clearfiled();
            DateTime cdate =new  DateTime (DateTime.Now.Year,DateTime.Now.Month,1);
            TextBox1.Text = cdate.ToShortDateString();
            TextBox2.Text = DateTime.Today.ToShortDateString();
        }
    }
    void Clearfiled()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Reset();

    }
}