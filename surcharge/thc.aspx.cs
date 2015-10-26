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

public partial class surcharge_thc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds_months = cn.mdb_ds("select top 1 months from TB_THC order by  id desc", "months");
        string[] arrayDate = ds_months.Tables["months"].Rows[0][0].ToString().Split('-');
        string year = arrayDate[0].ToString();
        string month = arrayDate[1].ToString();

        //LitYear1.Text = year;
        LitYear2.Text = year;
        //LitMonth1.Text = month;
        LitMonth2.Text = month;
        //LitMonth3.Text = month;
        //LitMonth4.Text = month;
        //LitMonth5.Text = month;
        //LitMonth6.Text = month;

        Littitle.Text = "<title>" + year + "年" + month + "月" + "最新THC-环球运费网</title>";

        string PreviousMonth;
        string PreviousYear;
        if (month != "1")
        {
            PreviousMonth = Convert.ToString(Convert.ToInt32(month) - 1);
            PreviousYear = year;
        }
        else
        {
            PreviousMonth = "12";
            PreviousYear = Convert.ToString(Convert.ToInt32(year) - 1);
        }


        //LitPreviousMonthBaf.Text = "<a href='/surcharge/overdue_baf.aspx?y=" + PreviousYear + "&m=" + PreviousMonth + "'>" + PreviousMonth + "月各大船公司BAF/CAF</a>";
        //LitPreviousMonthThc.Text = "<a href='/surcharge/overdue_thc.aspx?y=" + PreviousYear + "&m=" + PreviousMonth + "'>" + PreviousMonth + "月各大船公司THC</a>";

        //this.Response.Write("");
        DataSet ds = cn.mdb_ds("select * from TB_THC where months='" + ds_months.Tables["months"].Rows[0][0].ToString() + "'  order by Carriers", "thc");
        Repeater1.DataSource = ds.Tables["thc"].DefaultView;
        Repeater1.DataBind();


        //绑定毛点
        string[] strletter ={ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        for (int i = 0; i < strletter.Length; i++)
        {
            DataRow[] row = ds.Tables["thc"].Select("Carriers like '" + strletter[i] + "%'", "id");
            if (row.Length != 0)
            {
                Label1.Text = Label1.Text + "<a href='#anchor" + row[0]["id"].ToString() + "'>" + strletter[i] + "</a> ";
            }
            else
            {
                Label1.Text = Label1.Text + strletter[i] + " ";
            }


        }
    }
}
