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

public partial class admin_countpricepol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        LoadZxToday();
        LoadZxTotal();
        LoadPxToday();
        LoadPxTotal();
        LoadHkToday();
        LoadHkTotal();
        LoadZxYesterday();
        LoadPxYesterday();
        LoadHkYesterday();

        LoadZxAvailable();
        LoadPxAvailable();
        LoadHkAvailable();

    }


    public void LoadZxToday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND (yunjialeixing = 8) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND (yunjialeixing = 8) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView3.DataSource = ds.Tables["count"].DefaultView;
        GridView3.DataBind();

    }//统计今日整箱运价数量

    public void LoadZxTotal()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 8) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 8) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView8.DataSource = ds.Tables["count"].DefaultView;
        GridView8.DataBind();

    }//统计所有整箱运价数量

    public void LoadZxAvailable()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 8) ";
        sql = sql + "AND (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 8) ";
        sql = sql + "AND (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView19.DataSource = ds.Tables["count"].DefaultView;
        GridView19.DataBind();

    }//统计有效整箱运价数量

    public void LoadPxToday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND (yunjialeixing = 9) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND (yunjialeixing = 9) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView4.DataSource = ds.Tables["count"].DefaultView;
        GridView4.DataBind();

    }//统计今日拼箱运价数量

    public void LoadPxTotal()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 9) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 9) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView9.DataSource = ds.Tables["count"].DefaultView;
        GridView9.DataBind();

    }//统计所有拼箱运价数量

    public void LoadPxAvailable()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 9) ";
        sql = sql + "AND (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 9) ";
        sql = sql + "AND (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView20.DataSource = ds.Tables["count"].DefaultView;
        GridView20.DataBind();

    }//统计有效拼箱运价数量

    public void LoadHkToday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView5.DataSource = ds.Tables["count"].DefaultView;
        GridView5.DataBind();

    }//统计今日空运运价数量

    public void LoadHkTotal()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView10.DataSource = ds.Tables["count"].DefaultView;
        GridView10.DataBind();

    }//统计所有空运运价数量

    public void LoadHkAvailable()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView21.DataSource = ds.Tables["count"].DefaultView;
        GridView21.DataBind();

    }//统计今日空运运价数量



    public void LoadZxYesterday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND (yunjialeixing = 8) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 10 hangxianmiaoshu AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND (yunjialeixing = 8) ";
        sql = sql + "GROUP BY hangxianmiaoshu ";
        sql = sql + "ORDER BY T) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView13.DataSource = ds.Tables["count"].DefaultView;
        GridView13.DataBind();

    }//统计昨日整箱运价数量

    public void LoadPxYesterday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND (yunjialeixing = 9) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND (yunjialeixing = 9) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView14.DataSource = ds.Tables["count"].DefaultView;
        GridView14.DataBind();

    }//统计昨日拼箱运价数量

    public void LoadHkYesterday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT * FROM (";
        sql = sql + "SELECT TOP 20 startport AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "GROUP BY startport ";
        sql = sql + "ORDER BY C DESC) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView15.DataSource = ds.Tables["count"].DefaultView;
        GridView15.DataBind();

    }//统计昨日空运运价数量

}
