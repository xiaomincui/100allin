using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_message_Setrate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            LoadRate();
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        

        data_conn cn = new data_conn();
        string sql = "update TB_NEWRATE set rate = '" + TextBox5.Text + "' ,rdate = getdate(), ratesimple = '" + TextBox1.Text + "|" + TextBox2.Text + "|" + TextBox3.Text + "|" + TextBox4.Text + "'";
        //this.Response.Write(sql);
        cn.mdb_exe(sql);
        Response.Redirect("Setrate.aspx");



    }


    protected void LoadRate()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "Select rate from TB_NEWRATE Order by rid desc";

        ds = cn.mdb_ds(sql, "rate");

        if (ds.Tables["rate"].Rows.Count > 0)
        {
            TextBox5.Text = ds.Tables["rate"].Rows[0][0].ToString();
        }


        sql = "select ratesimple from TB_NEWRATE";
        ds = cn.mdb_ds(sql, "bbs");

        string[] ratexxs = new string[4];

        string ratexx;
        ratexx = ds.Tables["bbs"].Rows[0][0].ToString();

        ratexxs = ratexx.Split('|');

        TextBox1.Text = ratexxs[0];
        TextBox2.Text = ratexxs[1];
        TextBox3.Text = ratexxs[2];
        TextBox4.Text = ratexxs[3];
        
    }
}
