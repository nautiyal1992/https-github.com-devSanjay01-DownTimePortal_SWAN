using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class UpdateDetail : System.Web.UI.Page
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
                     //Your code        
            }
        }
    }

    
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox nm = (TextBox)DetailsView1.Rows[0].Cells[1].FindControl("uname");
        string emlid = (string)DetailsView1.DataKey.Value;
        TextBox mbl = (TextBox)DetailsView1.Rows[2].Cells[1].FindControl("mobile");
        RadioButtonList gn = (RadioButtonList)DetailsView1.Rows[3].Cells[1].FindControl("Genradio");
        TextBox dob = (TextBox)DetailsView1.Rows[4].Cells[1].FindControl("dob");
        TextBox adds = (TextBox)DetailsView1.Rows[8].Cells[1].FindControl("address");
        string nam = nm.Text;
        string mobl = mbl.Text;
        string gen = gn.SelectedItem.Text;
        string db = dob.Text;
        string ads = adds.Text;
        string eml = emlid;
         SqlConnection con = new SqlConnection(str);
            string updetail = "Update AccountDetail set Name=@nm, Mobile=@mbl, Gender=@gn, DOB=@db, Address=@adds where Email=@eml";
            SqlCommand cmd = new SqlCommand(updetail, con);
            cmd.Parameters.AddWithValue("@nm", nm.Text);
            cmd.Parameters.AddWithValue("@mbl", Convert.ToInt64(mbl.Text));
            cmd.Parameters.AddWithValue("@gn", gn.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@db", Convert.ToDateTime(dob.Text));
            cmd.Parameters.AddWithValue("@adds", adds.Text);
            cmd.Parameters.AddWithValue("@eml", emlid);
            con.Open();
            int g = (int)cmd.ExecuteNonQuery();
            con.Close();
            if (g != 0)
            {
               
                DetailsView1.DataBind();
                Response.Redirect("~/POP/UpdateDetail.aspx");
                Page.RegisterStartupScript("SS", "<script> alert('Data Update Successfully'); </script>");
             }
           
         }
   }