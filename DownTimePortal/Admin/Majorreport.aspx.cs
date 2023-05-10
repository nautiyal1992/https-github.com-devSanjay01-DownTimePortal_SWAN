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
    using Microsoft.Reporting.WebForms;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;

    public partial class Admin_Majorreport : System.Web.UI.Page
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
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Page.RegisterStartupScript("SS", "<script> alert('Field can't be blank'); </script>");
            }
            else
            {
                Regex checktime = new Regex(@"\d+$");
                if (!checktime.IsMatch(int.Parse(TextBox1.Text).ToString()))
                {
                    Page.RegisterStartupScript("SS", "<script> alert('Enter Days in Digit'); </script>");
                    TextBox1.Text = "0";
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (RadioButtonList1.SelectedItem.Text == "Major Issue")
            {
                
                if (TextBox1.Text == "" || TextBox2.Text == "")
                {
                    Page.RegisterStartupScript("SS", "<script> alert('Field can't be blank'); </script>");
                }
                else
                {
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/MajorIssue.rdlc");
                    DataTable dt = GetSPResult();
                    ReportDataSource datasource = new ReportDataSource("Downdetail", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    ReportParameter[] rptparameter = new ReportParameter[]
            {
                new ReportParameter("Cdate",TextBox2.Text)
            };
                    ReportViewer1.LocalReport.SetParameters(rptparameter);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
            else if (RadioButtonList1.SelectedItem.Text == "Detailed")
            {
                
                if (TextBox2.Text == "")
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
                        new ReportParameter("Cdate",TextBox2.Text)
                    };
                    ReportViewer1.LocalReport.SetParameters(rptparameter);
                    ReportViewer1.LocalReport.Refresh();

                }
            }
            else if (RadioButtonList1.SelectedItem.Text == "Detailed Summary")
            {
                if (TextBox2.Text == "")
                {
                    Page.RegisterStartupScript("SS", "<script> alert('Field can't be blank'); </script>");
                }
                else
                {
                    string[,] SDetail = new string[10,3];
                    string[] pps = new string[2];
                    string[] dwndy = new string[3];
                    pps = pops();
                    dwndy = downpop();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/DetailSummary.rdlc");
                    DataTable dt = GetSPResultd();
                    ReportDataSource datasource = new ReportDataSource("Downdetail", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    SDetail = GetSPResultr(Convert.ToDateTime(TextBox2.Text));
                    int ndpop=Convert.ToInt32(pps[0])-Convert.ToInt32(SDetail[9,1]);
                    ReportParameter[] rptparameter = new ReportParameter[]
                    {
                        new ReportParameter("Cdate",TextBox2.Text),
                        new ReportParameter("R1POPname",SDetail[0,0]),
                        new ReportParameter("R1Downpop",SDetail[0,1]),
                        new ReportParameter("R1Downtime",SDetail[0,2]),
                        new ReportParameter("R2POPname",SDetail[1,0]),
                        new ReportParameter("R2Downpop",SDetail[1,1]),
                        new ReportParameter("R2Downtime",SDetail[1,2]),
                        new ReportParameter("R3POPname",SDetail[2,0]),
                        new ReportParameter("R3Downpop",SDetail[2,1]),
                        new ReportParameter("R3Downtime",SDetail[2,2]),
                        new ReportParameter("R4POPname",SDetail[3,0]),
                        new ReportParameter("R4Downpop",SDetail[3,1]),
                        new ReportParameter("R4Downtime",SDetail[3,2]),
                        new ReportParameter("R5POPname",SDetail[4,0]),
                        new ReportParameter("R5Downpop",SDetail[4,1]),
                        new ReportParameter("R5Downtime",SDetail[4,2]),
                        new ReportParameter("R6POPname",SDetail[5,0]),
                        new ReportParameter("R6Downpop",SDetail[5,1]),
                        new ReportParameter("R6Downtime",SDetail[5,2]),
                        new ReportParameter("R7POPname",SDetail[6,0]),
                        new ReportParameter("R7Downpop",SDetail[6,1]),
                        new ReportParameter("R7Downtime",SDetail[6,2]),
                        new ReportParameter("R8POPname",SDetail[7,0]),
                        new ReportParameter("R8Downpop",SDetail[7,1]),
                        new ReportParameter("R8Downtime",SDetail[7,2]),
                        new ReportParameter("MRPOPname",SDetail[8,0]),
                        new ReportParameter("MRDownpop",SDetail[8,1]),
                        new ReportParameter("MRDowntime",SDetail[8,2]),
                         new ReportParameter("Totalpop",SDetail[9,1]),
                        new ReportParameter("Totaltime",SDetail[9,2]),
                        new ReportParameter("Commisionedpop",pps[0]),
                        new ReportParameter("Scanedpop",pps[1]),
                         new ReportParameter("Oneday",dwndy[0]),
                         new ReportParameter("weekday",dwndy[1]),
                         new ReportParameter("monthday",dwndy[2]),
                         new ReportParameter("Nodwnpop",ndpop.ToString())
                      
                    };
                    ReportViewer1.LocalReport.SetParameters(rptparameter);
                    ReportViewer1.LocalReport.Refresh();

                }
            }
            else if (RadioButtonList1.SelectedItem.Text == "Reason Summary")
            {
                if (TextBox2.Text == "")
                {
                    Page.RegisterStartupScript("SS", "<script> alert('Field can't be blank'); </script>");
                }
                else
                {
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/ReasonSummary.rdlc");
                    DataTable dt = GetDataReason();
                    ReportDataSource datasource = new ReportDataSource("Reason", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    ReportParameter[] rptparameter = new ReportParameter[]
                    {
                        new ReportParameter("Cdate",TextBox2.Text)
                    };
                    ReportViewer1.LocalReport.SetParameters(rptparameter);
                    ReportViewer1.LocalReport.Refresh();

                }
            }
        }

        string[] pops()
        {
            string[] pop = new string[2];
            SqlConnection con = new SqlConnection(con_str1);
            string dwndy = "SELECT COUNT(POP) FROM POP";
                SqlCommand cmd = new SqlCommand(dwndy, con);
                 con.Open();
                SqlDataReader prd = cmd.ExecuteReader();
                if (prd.HasRows)
                {
                    while (prd.Read())
                    {
                        pop[0] = prd[0].ToString();
                    }
                }
                con.Close();
                int scndp = Convert.ToInt32(pop[0].ToString());
                scndp = scndp + 2;
                pop[1] = scndp.ToString();
            return pop;
        }
        string[] downpop()
        {
            string [] dy = new string[3];
            int d = 1 * 24 * 60;
            int w = 7 * 24 * 60;
            int m = 30 * 24 * 60;
            int[] min = new int[]{d,w,m};
            SqlConnection con = new SqlConnection(con_str1);
            string dwndy = "SELECT COUNT(DISTINCT B_End) FROM Downdetail WHERE (LLUP_Date = @ddate) AND (TotalMin >= @tm )";
            for (int i = 0; i < 3; i++)
            {
                SqlCommand cmd = new SqlCommand(dwndy, con);
                cmd.Parameters.AddWithValue("@ddate", Convert.ToDateTime(TextBox2.Text));
                cmd.Parameters.AddWithValue("@tm", min[i]);
                con.Open();
                SqlDataReader drd = cmd.ExecuteReader();
                if (drd.HasRows)
                {
                    while (drd.Read())
                    {
                        dy[i] = drd[0].ToString();
                    }
                }
                con.Close();
            }
            return dy;
         }
        private DataTable GetSPResult()
        {
            int d = int.Parse(TextBox1.Text);
            int min = d * 24 * 60;
                DataTable Downdetail = new DataTable();
                 SqlConnection con = new SqlConnection(con_str1);
                 string qry = "SELECT A_End, B_End, NOC_Open, NOC_Close, LLDown_Date, LLDown_Time, Report_Agency, LLUP_Date, LLUP_Time, Reason, TotalDown_Time, Remark, Docket_No,TotalMin FROM Downdetail WHERE (LLUP_Date = @ddate) AND (TotalMin >= @tm ) ORDER BY A_End";
                SqlCommand cmd = new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@ddate",Convert.ToDateTime(TextBox2.Text));
                cmd.Parameters.AddWithValue("@tm", min);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                Majorissueset ds = new Majorissueset();
                adapter.Fill(ds.Tables["Downdetail"]);
                return ds.Tables["Downdetail"];
        }
        private DataTable GetSPResultd()
        {
            DataTable Downdetail = new DataTable();
            SqlConnection con = new SqlConnection(con_str1);
            string qry = "SELECT A_End, B_End, NOC_Open, NOC_Close, LLDown_Date, LLDown_Time, Report_Agency, LLUP_Date, LLUP_Time, Reason, TotalDown_Time, Remark, Docket_No,TotalMin FROM Downdetail WHERE LLUP_Date = @ddate ORDER BY A_End";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@ddate", Convert.ToDateTime(TextBox2.Text));
           // cmd.Parameters.AddWithValue("@tm", min);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            Majorissueset ds = new Majorissueset();
            adapter.Fill(ds.Tables["Downdetail"]);
            return ds.Tables["Downdetail"];
        }
        
        public string[,] GetSPResultr(DateTime datedetail)
        {
            string[] Rn = new string[] { "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8" };
            string[,] R = new string[10,3];
            string pops = null, time = null, r = null;
            string npop = null;
            int totalpop = 0;
            double totaltime = 0;
            TimeSpan t = new TimeSpan();
            TimeSpan ttl = new TimeSpan();
            for (int i = 0; i < 8; i++)
            {
                SqlConnection con = new SqlConnection(con_str1);
               string qry = "SELECT COUNT(DISTINCT B_End) as pop,SUM(TotalMin) as time FROM Downdetail WHERE LLUP_Date = @ddate and Reason=@r";
              //  string qry = "SELECT SUM(TotalMin) as time FROM Downdetail WHERE LLDown_Date = @ddate and Reason=@r";
                SqlCommand cmd = new SqlCommand(qry, con);
                //cmd.Parameters.AddWithValue("@ddate", Convert.ToDateTime(TextBox2.Text));
                cmd.Parameters.AddWithValue("@ddate", Convert.ToDateTime(datedetail));
                cmd.Parameters.AddWithValue("@r", Rn[i]);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                       // pops = rd[0].ToString() + "," + pops;
                         npop = rd[0].ToString();
                         time = rd[1].ToString();
                    }
                }
                con.Close();
                string qry1 = "SELECT DISTINCT (B_End) FROM Downdetail WHERE LLUP_Date = @ddate and Reason=@r";
                SqlCommand cmd1 = new SqlCommand(qry1, con);
               // cmd1.Parameters.AddWithValue("@ddate", Convert.ToDateTime(TextBox2.Text));
                cmd1.Parameters.AddWithValue("@ddate", Convert.ToDateTime(datedetail));
                cmd1.Parameters.AddWithValue("@r", Rn[i]);
                con.Open();
                SqlDataReader rd1 = cmd1.ExecuteReader();
                if (rd1.HasRows)
                {
                    while (rd1.Read())
                    {
                        //  pops = pops + "," + rd[0].ToString();
                        pops = rd1[0].ToString() + "," + pops;

                    }

                }
                con.Close();
               
                if (pops == null)
                    pops = "NA";
                else if (npop == null)
                    npop = "0";
                else if (time == "")
                    time = "0";
                else
                {
                    totalpop = Convert.ToInt16(npop) + totalpop;
                    t = TimeSpan.FromMinutes(Convert.ToDouble(time));
                    totaltime = Convert.ToDouble(time) + totaltime;
                    r = t.Days + " Days " + t.Hours + " Hr " + t.Minutes + " Min";
                    R[i, 0] = pops;
                    R[i, 1] = npop;
                    R[i, 2] = r;
                }
                pops = null;
                npop = null;
                time = "";
            }
            int  gnpop=0;
            SqlConnection con1 = new SqlConnection(con_str1);
            string qry9 = "SELECT B_End,COUNT(DISTINCT B_End) FROM Downdetail WHERE LLUP_Date = @ddate GROUP BY B_End HAVING Count(B_End)>1 and count(distinct reason)>=2 ";
            //string qry9 = "SELECT B_End,COUNT(DISTINCT B_End) FROM Downdetail WHERE  where LLDown_Date = @ddate GROUP BY B_End HAVING Count(B_End)>1 ";
            SqlCommand cmd9 = new SqlCommand(qry9, con1);
           // cmd9.Parameters.AddWithValue("@ddate", Convert.ToDateTime(TextBox2.Text));
            cmd9.Parameters.AddWithValue("@ddate", Convert.ToDateTime(datedetail));
           // cmd9.Parameters.AddWithValue("@r", Rn[i]);
            con1.Open();
            SqlDataReader rd9 = cmd9.ExecuteReader();
            if (rd9.HasRows)
            {
                while (rd9.Read())
                {
                    //  pops = pops + "," + rd[0].ToString();
                    pops = rd9[0].ToString() + "," + pops;
                    npop = rd9[1].ToString();
                     gnpop =Convert.ToInt32(npop) + gnpop;
                    totalpop +=Convert.ToInt32(npop);
                }
                R[8, 0] = pops;
                R[8, 1] = gnpop.ToString();
                R[8, 2] = "0";
            }
            con1.Close();

            ttl = TimeSpan.FromMinutes(totaltime);
            string ttim = ttl.Days + " Days " + ttl.Hours + " Hr " + ttl.Minutes + " Min";
            R[9, 0] = "NA";
            R[9, 1] = totalpop.ToString();
            R[9, 2] = ttim;
            return R;
               
        }
        private DataTable GetDataReason()
        {
            
            DateTime cdate= Convert.ToDateTime(TextBox2.Text);
            DateTime fdate = new DateTime(cdate.Year, cdate.Month, 1);
            string[,] SDetail = new string[10, 3];
            string[] pps = new string[2];
            string[] dwndy = new string[3];
            pps = pops();
            dwndy = downpop();
            DataTable dt = new DataTable();
            dt.TableName = "Reason";
            dt.Columns.Add("SNo", Type.GetType("System.String"));
            dt.Columns.Add("TPOP", Type.GetType("System.Int32"));
            dt.Columns.Add("R1", Type.GetType("System.Int32"));
            dt.Columns.Add("R2", Type.GetType("System.Int32"));
            dt.Columns.Add("R3", Type.GetType("System.Int32"));
            dt.Columns.Add("R4", Type.GetType("System.Int32"));
            dt.Columns.Add("R5", Type.GetType("System.Int32"));
            dt.Columns.Add("R6", Type.GetType("System.Int32"));
            dt.Columns.Add("R7", Type.GetType("System.Int32"));
            dt.Columns.Add("R8", Type.GetType("System.Int32"));
            dt.Columns.Add("MultiR", Type.GetType("System.Int32"));
            dt.Columns.Add("NetPOP", Type.GetType("System.Int32"));
            for (int i = 1; i <= (cdate.Day); i++)
            {
                DateTime getd = new DateTime(cdate.Year, cdate.Month, i);
                SDetail = GetSPResultr(getd);
                pps = pops();
                int sumrpop=0;
                DataRow dr1 = dt.NewRow();
                dr1["SNo"] = i;
                dr1["TPOP"] = pps[0];

                for(int j=0;j<8;j++)
                {
                    if (SDetail[j, 1] == null)
                    {
                        dr1[j + 2] = 0;
                    }
                    else
                    {
                        dr1[j+2] = SDetail[j, 1];
                       sumrpop = sumrpop + Convert.ToInt32(SDetail[j, 1]);
                    }
                }
                
                if (SDetail[8, 1] == null)
                {
                    dr1["MultiR"] = 0;
                }
                else
                {
                    dr1["MultiR"] = SDetail[8, 1];
                }
                int cpop = Convert.ToInt32(pps[0]);
                dr1["NetPOP"] = cpop-sumrpop;
                dt.Rows.Add(dr1);
            }


            //  dss.Tables[0].TableName = "DownTime";
            //dss.GetXmlSchema();
            //dt.WriteXmlSchema("D:/Projects/DownTimePortal/App_Code/Reportset.xsd");
            //dt.WriteXml("D:/Projects/DownTimePortal/App_Code/Reportset.xml");
            SqlDataAdapter adapter = new SqlDataAdapter();
            Reasonsumry rd = new Reasonsumry();
            //   rs.Merge(dt);
            //  return rs.Tables["DownTime"];
            return dt;

        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Text == "Major Issue")
            {
               
                TextBox1.Visible = true;
                Label11.Visible = true;
                Clearfiled();
                TextBox1.Text = "0";
            }
            else if (RadioButtonList1.SelectedItem.Text == "Detailed")
            {
                TextBox1.Visible = false;
                Label11.Visible = false;
                Clearfiled();
            }
            else if (RadioButtonList1.SelectedItem.Text == "Detailed Summary")
            {
                TextBox1.Visible = false;
                Label11.Visible = false;
                Clearfiled();
            }
            else if (RadioButtonList1.SelectedItem.Text == "Reason Summary")
            {
                TextBox1.Visible = false;
                Label11.Visible = false;
                Clearfiled();
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