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

public partial class Account_Login : System.Web.UI.Page
{
    String con_str1 = null;
    DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    DateTime dt2 = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = dt1.ToShortDateString();
        Label3.Text = dt2.ToShortDateString();
        con_str1 = WebConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        if (!Page.IsPostBack)
        {
            LoadSHQ();
            PreloadDHQ();
            LoadDHQ();
          //DataTable dt = GetData();
          //LoadChartData(dt);
            
        }
    }
      
    void LoadSHQ()
    {
        SqlConnection con = new SqlConnection(con_str1);
        String DHQ = "Select SHQ from DHQ ";
        SqlCommand cmd = new SqlCommand(DHQ, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
            while (rd.Read())
            {
                Label1.Text=rd[0].ToString();
            }
        }
        con.Close();
    }
    void PreloadDHQ()
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(con_str1);
        String pop = "select DHQ from DHQ where SHQ=@dq";
        SqlCommand cmd = new SqlCommand(pop, con);
        cmd.Parameters.AddWithValue("@dq", Label1.Text);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
            while (rd.Read())
            {
                DropDownList2.Items.Add(rd[0].ToString());
            }
        }
        con.Close();
        DataTable dt = GetData(Label1.Text);
        LoadChartData(dt);
        Chart1.DataBind();
        
        
    }

       void LoadDHQ()
    {
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("Select All");
        DropDownList1.SelectedIndex = 0;
        SqlConnection con = new SqlConnection(con_str1);
        String DHQ = "Select DHQ from DHQ ";
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
      
   
    private DataTable GetData(string a)
    {
        string aend=a;
        Int16 popn = 0;
        string npop = null;
        SqlConnection con = new SqlConnection(con_str1);
        if (DropDownList1.SelectedItem.Text == "Select All")
        {
            npop = "select count(DHQ) from DHQ where SHQ=@dq";
        }
        else
        {
             npop = "select count(POP) from POP where DHQ=@dq";
        }
      //  string npop = "select count(DISTINCT B_End) from Downdetail where A_End=@dq";
        SqlCommand cmd = new SqlCommand(npop, con);
        cmd.Parameters.AddWithValue("@dq",aend);
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
        dt.Columns.Add("POP", Type.GetType("System.String"));
        dt.Columns.Add("R1", Type.GetType("System.String"));
        dt.Columns.Add("R2", Type.GetType("System.String"));
        dt.Columns.Add("R3", Type.GetType("System.String"));
        dt.Columns.Add("R4", Type.GetType("System.String"));
        dt.Columns.Add("R5", Type.GetType("System.String"));
        dt.Columns.Add("R6", Type.GetType("System.String"));
        dt.Columns.Add("R7", Type.GetType("System.String"));
        dt.Columns.Add("R8", Type.GetType("System.String"));
        //dt.Columns.Add("R1", Type.GetType("System.TimeSpan"));
        //dt.Columns.Add("R2", Type.GetType("System.TimeSpan"));
        //dt.Columns.Add("R3", Type.GetType("System.TimeSpan"));
        //dt.Columns.Add("R4", Type.GetType("System.TimeSpan"));
        //dt.Columns.Add("R5", Type.GetType("System.TimeSpan"));
        //dt.Columns.Add("R6", Type.GetType("System.TimeSpan"));
        //dt.Columns.Add("R7", Type.GetType("System.TimeSpan"));
        //dt.Columns.Add("R8", Type.GetType("System.TimeSpan"));
        string[] Rsn = new string[] { "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8" };
        for (int i = 0; i < popn; i++)
        {
            sumr(Rsn, i);
            // Int64 [] ts = new Int64[8];
            //for(int t=0;t<=7;t++)
            //{
            //    if (Rsn[t] == "")
            //        Rsn[t] = "0";
            //    else
            //        ts[t] = Convert.ToInt64(Rsn[t]);
            TimeSpan[] ts = new TimeSpan[8];
            for (int t = 0; t <= 7; t++)
            {
                if (Rsn[t] == "")
                    Rsn[t] = "0";
                else
                    ts[t] = TimeSpan.FromMinutes(Convert.ToDouble(Rsn[t]));
            }
            DataRow dr1 = dt.NewRow();
            dr1["POP"] = DropDownList2.Items[i].Text;
            dr1["R1"] = ts[0].Days + " Days " + ts[0].Hours + " Hrs " + ts[0].Minutes +" Min";
            dr1["R2"] = ts[1].Days + " Days " + ts[1].Hours + " Hrs " + ts[1].Minutes + " Min";
            dr1["R3"] = ts[2].Days + " Days " + ts[2].Hours + " Hrs " + ts[2].Minutes + " Min";
            dr1["R4"] = ts[3].Days + " Days " + ts[3].Hours + " Hrs " + ts[3].Minutes + " Min";
            dr1["R5"] = ts[4].Days + " Days " + ts[4].Hours + " Hrs " + ts[4].Minutes + " Min";
            dr1["R6"] = ts[5].Days + " Days " + ts[5].Hours + " Hrs " + ts[5].Minutes + " Min";
            dr1["R7"] = ts[6].Days + " Days " + ts[6].Hours + " Hrs " + ts[6].Minutes + " Min";
            dr1["R8"] = ts[7].Days + " Days " + ts[7].Hours + " Hrs " + ts[7].Minutes + " Min";
            dt.Rows.Add(dr1);
        }
        return dt;
    }
    public string[] sumr(string[] s, int i)
    {
        string[] Rn = new string[] { "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8" };
        string[] R=new string[8];
         for (int j = 0; j <= 7; j++)
            {
                SqlConnection con = new SqlConnection(con_str1);
                string sumrsn = "select sum(TotalMin) from Downdetail where LLdown_Date BETWEEN @dt1 AND @dt2 AND Reason=@rsn AND B_End=@pp";
                SqlCommand cmd = new SqlCommand(sumrsn, con);
                cmd.Parameters.AddWithValue("@dt1", dt1);
                cmd.Parameters.AddWithValue("@dt2", dt2);
               // cmd.Parameters.AddWithValue("@aend", DropDownList1.Items[i].Text);
                cmd.Parameters.AddWithValue("@pp", DropDownList2.Items[i].Text);
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
         return R;
    }

    private void LoadChartData(DataTable initialDataSource)
    {
        GridView1.DataSource = initialDataSource;
        GridView1.DataBind();
        //string[] x = new string[initialDataSource.Rows.Count];
        //Int64 [] y = new Int64[initialDataSource.Rows.Count];
        //for (int i = 0; i <= initialDataSource.Rows.Count; i++)
        //{
        //    x[i] = initialDataSource.Rows[i][0].ToString();
        //    //y[i] =Convert.ToInt64(initialDataSource.Rows[i][1]);
        //Chart1.Series[i].Points.DataBindXY(x, y);
        //Chart1.Series[i].ChartType = SeriesChartType.Column;
        //Chart1.ChartAreas[i].Area3DStyle.Enable3D = true;
        //Chart1.Legends[i].Enabled = true;
        //}
        ////Chart1.Series[i].Points.DataBindXY(x, y);
        ////Chart1.Series[0].ChartType = SeriesChartType.Column;
        ////Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        ////Chart1.Legends[0].Enabled = true;
        ////for (int i = 1; i <= initialDataSource.Rows.Count; i++)
        ////{
        ////    Series series = new Series();
        ////    ChartArea ca=new ChartArea();
        ////    foreach (DataRow dr in initialDataSource.Rows)
        ////    {
        ////        //  int y = (int)dr[i];
        ////        series.Points.AddXY(dr["POP"].ToString(), i);
        ////        series.Points.AddXY(dr["R1"].ToString(),i);
        ////        series.Points.AddXY(dr["R2"].ToString(),i);
        ////        series.Points.AddXY(dr["R3"].ToString(),i);
        ////        series.Points.AddXY(dr["R4"].ToString(),i);
        //        series.Points.AddXY(dr["R5"].ToString(),i);
        //        series.Points.AddXY(dr["R6"].ToString(),i);
        //        series.Points.AddXY(dr["R7"].ToString(),i);
        //        series.Points.AddXY(dr["R8"].ToString(),i);
        //    }
        //    Chart1.Series.Add(series);
            

        //}
        Chart1.DataBind();
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select All")
        {
            PreloadDHQ();
        }
        else
        {
            DropDownList2.Items.Clear();
            SqlConnection con = new SqlConnection(con_str1);
            String pop = "select POP from POP where DHQ=@dq";
            SqlCommand cmd = new SqlCommand(pop, con);
            cmd.Parameters.AddWithValue("@dq", DropDownList1.SelectedItem.Value);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    DropDownList2.Items.Add(rd[0].ToString());
                }
            }
            con.Close();
            DataTable dt = GetData(DropDownList1.SelectedItem.Text);
            LoadChartData(dt);
        }
    }
   
}