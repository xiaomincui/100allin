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

public partial class admin_searchwordscount : System.Web.UI.Page
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
            sqldate1 = sqldate1 + "AND STIME >= '" + date1 + "' ";
        }

        if (date2 != "")
        {
            date2 = date2 + " 23:59:59";
            sqldate2 = sqldate2 + "AND STIME <= '" + date2 + "' ";
        }
        
        string max1 = "1";
        string max2 = "1";
        string max3 = "1";

        string sql = "";
        sql = "SELECT TOP 1 STARTPORT AS N, COUNT(STARTPORT) AS c ";
        sql = sql + "FROM TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE (STARTPORT <> '') ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY STARTPORT ";
        sql = sql + "ORDER BY c DESC ";

        ds = cn.mdb_ds(sql, "TB_SEA_SEARCHWORDS1_MAX");
        if (ds.Tables["TB_SEA_SEARCHWORDS1_MAX"].Rows.Count > 0)
        {
            max1 = ds.Tables["TB_SEA_SEARCHWORDS1_MAX"].Rows[0]["c"].ToString();
        }



        sql = "SELECT TOP 20 STARTPORT AS N, COUNT(STARTPORT) AS c ,dbo.get_validprice('',STARTPORT,'', GETDATE()) AS v ,COUNT(STARTPORT)*450/" + max1 + " AS p ";
        sql = sql + "FROM TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE (STARTPORT <> '') ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY STARTPORT ";
        sql = sql + "ORDER BY c DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "TB_SEA_SEARCHWORDS1");

        Repeater1.DataSource = ds.Tables["TB_SEA_SEARCHWORDS1"].DefaultView;
        Repeater1.DataBind();
     

        sql = "";
        sql = "SELECT TOP 1 DESTPORT AS N, COUNT(DESTPORT) AS c ";
        sql = sql + "FROM TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE (DESTPORT <> '') ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY DESTPORT ";
        sql = sql + "ORDER BY c DESC ";

        ds = cn.mdb_ds(sql, "TB_SEA_SEARCHWORDS2_MAX");
        if (ds.Tables["TB_SEA_SEARCHWORDS2_MAX"].Rows.Count > 0)
        {
            max2 = ds.Tables["TB_SEA_SEARCHWORDS2_MAX"].Rows[0]["c"].ToString();
        }

        sql = "SELECT TOP 20 DESTPORT AS N, COUNT(DESTPORT) AS c ,dbo.get_validprice('','',DESTPORT, GETDATE()) AS v , COUNT(DESTPORT)*450/" + max2 + " AS p ";
        sql = sql + "FROM TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE (DESTPORT <> '') ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY DESTPORT ";
        sql = sql + "ORDER BY c DESC ";

        ds = cn.mdb_ds(sql, "TB_SEA_SEARCHWORDS2");

        Repeater2.DataSource = ds.Tables["TB_SEA_SEARCHWORDS2"].DefaultView;
        Repeater2.DataBind();

        sql = "";

        sql = "SELECT TOP 20 LINE AS N, COUNT(LINE) AS c ";
        sql = sql + "FROM TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE (LINE <> '') ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY LINE ";
        sql = sql + "ORDER BY c DESC ";

        ds = cn.mdb_ds(sql, "TB_SEA_SEARCHWORDS3_MAX");
        if (ds.Tables["TB_SEA_SEARCHWORDS3_MAX"].Rows.Count > 0)
        {
            max3 = ds.Tables["TB_SEA_SEARCHWORDS3_MAX"].Rows[0]["c"].ToString();
        }

        sql = "SELECT TOP 20 LINE AS N, COUNT(LINE) AS c , dbo.get_validprice(LINE,'','', GETDATE()) AS v ,COUNT(LINE)*450/" + max3 + " AS p ";
        sql = sql + "FROM TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE (LINE <> '') ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "GROUP BY LINE ";
        sql = sql + "ORDER BY c DESC ";

        ds = cn.mdb_ds(sql, "TB_SEA_SEARCHWORDS3");

        Repeater3.DataSource = ds.Tables["TB_SEA_SEARCHWORDS3"].DefaultView;
        Repeater3.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadRecord();
    }


}
