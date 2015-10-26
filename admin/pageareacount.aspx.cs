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

public partial class admin_pageareacount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            BasicDatePicker2_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            LoadRecord();
        }
    }

    protected void LoadRecord()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        check ck = new check();

        string date1 = "";
        string date2 = "";

        string sqldate1 = "";
        string sqldate2 = "";

        date1 = BasicDatePicker1_TextBox.Value.ToString();
        date2 = BasicDatePicker2_TextBox.Value.ToString();

        if (date1 != "")
        {
            date1 = date1 + " 00:00:00";
            sqldate1 = sqldate1 + "AND NowTime >= '" + date1 + "' ";
        }

        if (date2 != "")
        {
            date2 = date2 + " 23:59:59";
            sqldate2 = sqldate2 + "AND NowTime <= '" + date2 + "' ";
        }

        string max1 = "1";
        string max2 = "1";

        string sql = "";
        sql = "SELECT TOP 1 pagearea AS pa, COUNT(pagearea) AS c ";
        sql = sql + "FROM TB_BrowseRecord ";
        sql = sql + "WHERE pagearea is not null and pagearea <> '' ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY pagearea ";
        sql = sql + "ORDER BY c DESC ";

        ds = cn.mdb_ds(sql, "TB_BrowseRecord_MAX");
        if (ds.Tables["TB_BrowseRecord_MAX"].Rows.Count > 0)
        {
            max1 = ds.Tables["TB_BrowseRecord_MAX"].Rows[0]["c"].ToString();
        }

        sql = "SELECT TOP 30 pagearea AS pa, COUNT(pagearea) AS c ,COUNT(pagearea)*250/" + max1 + " AS p ";
        sql = sql + "FROM TB_BrowseRecord ";
        sql = sql + "WHERE pagearea is not null and pagearea <> '' ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY pagearea ";
        sql = sql + "ORDER BY c DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "TB_BrowseRecord");

        Repeater1.DataSource = ds.Tables["TB_BrowseRecord"].DefaultView;
        Repeater1.DataBind();



        sql = "";
        sql = "SELECT TOP 1 pagearea AS pa, COUNT(pagearea) AS c ";
        sql = sql + "FROM (SELECT pagearea, UserIP FROM TB_BrowseRecord ";
        sql = sql + "WHERE pagearea is not null and pagearea <> '' ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY pagearea, UserIP) t ";
        sql = sql + "GROUP BY pagearea ";
        sql = sql + "ORDER BY c DESC ";

        ds = cn.mdb_ds(sql, "TB_BrowseRecord2_MAX");
        if (ds.Tables["TB_BrowseRecord2_MAX"].Rows.Count > 0)
        {
            max2 = ds.Tables["TB_BrowseRecord2_MAX"].Rows[0]["c"].ToString();
        }

        sql = "SELECT TOP 30 pagearea AS pa, COUNT(pagearea) AS c ,COUNT(pagearea)*250/" + max2 + " AS p ";
        sql = sql + "FROM (SELECT pagearea, UserIP FROM TB_BrowseRecord ";
        sql = sql + "WHERE pagearea is not null and pagearea <> '' ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY pagearea, UserIP) t ";
        sql = sql + "GROUP BY pagearea ";
        sql = sql + "ORDER BY c DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "TB_BrowseRecord2");

        Repeater2.DataSource = ds.Tables["TB_BrowseRecord2"].DefaultView;
        Repeater2.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadRecord();
    }
}
