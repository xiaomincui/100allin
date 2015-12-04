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

public partial class admin_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            BasicDatePicker2_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            //LoadRecord();
        }
        LoadUserCountToday();
        LoadUserCountYesterday();
        LoadUserCountTotal();
        LoadZxToday();
        LoadZxTotal();
        LoadPxToday();
        LoadPxTotal();
        LoadHkToday();
        LoadHkTotal();
        //LoadHyhpToday();
        //LoadHyhpTotal();
        //LoadKyhpToday();
        //LoadKyhpTotal();
        LoadZxYesterday();
        LoadPxYesterday();
        LoadHkYesterday();
        //LoadHyhpYesterday();
        //LoadKyhpYesterday();

        LoadZxAvailable();
        LoadPxAvailable();
        LoadHkAvailable();

    }

    public void LoadUserCountToday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //定义SQL语句，查询某一用户发布的3种运价及货盘各自的总数
        sql = sql + "SELECT '合&nbsp;&nbsp;&nbsp;&nbsp;计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '直&nbsp;&nbsp;&nbsp;&nbsp;客' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "AND (CompanyType = 1) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '货&nbsp;&nbsp;&nbsp;&nbsp;代' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "AND (CompanyType = 2) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '船公司' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "AND (CompanyType = 3) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '其&nbsp;&nbsp;&nbsp;&nbsp;它' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "AND (CompanyType = 4) ";
        ds = cn.mdb_ds(sql, "count");

        GridView1.DataSource = ds.Tables["count"].DefaultView;
        GridView1.DataBind();

    }//统计今日用户数量

    public void LoadUserCountYesterday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //定义SQL语句，查询某一用户发布的3种运价及货盘各自的总数
        sql = sql + "SELECT '合&nbsp;&nbsp;&nbsp;&nbsp;计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '直&nbsp;&nbsp;&nbsp;&nbsp;客' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "AND (CompanyType = 1) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '货&nbsp;&nbsp;&nbsp;&nbsp;代' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "AND (CompanyType = 2) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '船公司' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "AND (CompanyType = 3) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '其&nbsp;&nbsp;&nbsp;&nbsp;它' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CONVERT(varchar(10), Regtime, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "AND (CompanyType = 4) ";
        ds = cn.mdb_ds(sql, "count");

        GridView18.DataSource = ds.Tables["count"].DefaultView;
        GridView18.DataBind();

    }//统计昨日用户数量
    
    public void LoadUserCountTotal()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合&nbsp;&nbsp;&nbsp;&nbsp;计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE ifimport is null ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '直&nbsp;&nbsp;&nbsp;&nbsp;客' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CompanyType = 1) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '货&nbsp;&nbsp;&nbsp;&nbsp;代' AS 类型, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CompanyType = 2) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '船公司' AS 类型, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CompanyType = 3) ";
        sql = sql + "AND ifimport is null ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '其&nbsp;&nbsp;&nbsp;&nbsp;它' AS 类型, COUNT(*) AS C ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (CompanyType = 4) ";
        sql = sql + "AND ifimport is null ";
        ds = cn.mdb_ds(sql, "count");

        GridView2.DataSource = ds.Tables["count"].DefaultView;
        GridView2.DataBind();

    }//统计所有用户数量


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
        sql = sql + "SELECT TOP 10 hangxianmiaoshu AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND (yunjialeixing = 8) ";
        sql = sql + "GROUP BY hangxianmiaoshu ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 hangxianmiaoshu AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 8) ";
        sql = sql + "GROUP BY hangxianmiaoshu ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 hangxianmiaoshu AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 8) ";
        sql = sql + "AND (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY hangxianmiaoshu ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 hangxianmiaoshu AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "AND (yunjialeixing = 9) ";
        sql = sql + "GROUP BY hangxianmiaoshu ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 hangxianmiaoshu AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 9) ";
        sql = sql + "GROUP BY hangxianmiaoshu ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 hangxianmiaoshu AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (yunjialeixing = 9) ";
        sql = sql + "AND (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY hangxianmiaoshu ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 line AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY line ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 line AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "GROUP BY line ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 line AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), enddate, 120) >= CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY line ";
        sql = sql + "ORDER BY T) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView21.DataSource = ds.Tables["count"].DefaultView;
        GridView21.DataBind();

    }//统计今日空运运价数量

    public void LoadHyhpToday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '海运货盘') ";
        sql = sql + "AND (CONVERT(varchar(10), TB_AIRGOODS.POSTDATE, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT TB_GOODS_LINE.GOOD_LINE_CH AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '海运货盘') ";
        sql = sql + "AND (CONVERT(varchar(10), TB_AIRGOODS.POSTDATE, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY TB_GOODS_LINE.GOOD_LINE_CH ";
        ds = cn.mdb_ds(sql, "count");

        GridView6.DataSource = ds.Tables["count"].DefaultView;
        GridView6.DataBind();

    }//统计今日海运货盘数量

    public void LoadHyhpTotal()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '海运货盘') ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT TB_GOODS_LINE.GOOD_LINE_CH AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '海运货盘') ";
        sql = sql + "GROUP BY TB_GOODS_LINE.GOOD_LINE_CH ";
        ds = cn.mdb_ds(sql, "count");

        GridView11.DataSource = ds.Tables["count"].DefaultView;
        GridView11.DataBind();

    }//统计所有海运货盘数量

    public void LoadKyhpToday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '空运货盘') ";
        sql = sql + "AND (CONVERT(varchar(10), TB_AIRGOODS.POSTDATE, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT TB_GOODS_LINE.GOOD_LINE_CH AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '空运货盘') ";
        sql = sql + "AND (CONVERT(varchar(10), TB_AIRGOODS.POSTDATE, 120) = CONVERT(varchar(10), { fn NOW() }, 120)) ";
        sql = sql + "GROUP BY TB_GOODS_LINE.GOOD_LINE_CH ";
        ds = cn.mdb_ds(sql, "count");

        GridView7.DataSource = ds.Tables["count"].DefaultView;
        GridView7.DataBind();

    }//统计今日空运货盘数量

    public void LoadKyhpTotal()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '空运货盘') ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT TB_GOODS_LINE.GOOD_LINE_CH AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '空运货盘') ";
        sql = sql + "GROUP BY TB_GOODS_LINE.GOOD_LINE_CH ";
        ds = cn.mdb_ds(sql, "count");

        GridView12.DataSource = ds.Tables["count"].DefaultView;
        GridView12.DataBind();

    }//统计所有空运货盘数量

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
        sql = sql + "SELECT TOP 10 hangxianmiaoshu AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_YunJia ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "AND (yunjialeixing = 9) ";
        sql = sql + "GROUP BY hangxianmiaoshu ";
        sql = sql + "ORDER BY T) ";
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
        sql = sql + "SELECT TOP 10 line AS T, COUNT(*) AS C ";
        sql = sql + "FROM T_AIRINFO ";
        sql = sql + "WHERE (CONVERT(varchar(10), PostDate, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "GROUP BY line ";
        sql = sql + "ORDER BY T) ";
        sql = sql + "AS T1 ";
        ds = cn.mdb_ds(sql, "count");

        GridView15.DataSource = ds.Tables["count"].DefaultView;
        GridView15.DataBind();

    }//统计昨日空运运价数量

    public void LoadHyhpYesterday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '海运货盘') ";
        sql = sql + "AND (CONVERT(varchar(10), TB_AIRGOODS.POSTDATE, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT TB_GOODS_LINE.GOOD_LINE_CH AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '海运货盘') ";
        sql = sql + "AND (CONVERT(varchar(10), TB_AIRGOODS.POSTDATE, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "GROUP BY TB_GOODS_LINE.GOOD_LINE_CH ";
        ds = cn.mdb_ds(sql, "count");

        GridView16.DataSource = ds.Tables["count"].DefaultView;
        GridView16.DataBind();

    }//统计昨日海运货盘数量

    public void LoadKyhpYesterday()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT '合计' AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '空运货盘') ";
        sql = sql + "AND (CONVERT(varchar(10), TB_AIRGOODS.POSTDATE, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT TB_GOODS_LINE.GOOD_LINE_CH AS T, COUNT(*) AS C ";
        sql = sql + "FROM TB_GOODS_LINE LEFT OUTER JOIN ";
        sql = sql + "TB_AIRGOODS ON TB_GOODS_LINE.GOOD_LINE_EN = TB_AIRGOODS.LINE ";
        sql = sql + "WHERE (TB_AIRGOODS.TYPEM = '空运货盘') ";
        sql = sql + "AND (CONVERT(varchar(10), TB_AIRGOODS.POSTDATE, 120) = CONVERT(varchar(10), { fn NOW() } - 1, 120)) ";
        sql = sql + "GROUP BY TB_GOODS_LINE.GOOD_LINE_CH ";
        ds = cn.mdb_ds(sql, "count");

        GridView17.DataSource = ds.Tables["count"].DefaultView;
        GridView17.DataBind();

    }//统计昨日空运货盘数量

    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadRecord();
    }

    protected void LoadRecord()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        check ck = new check();
        string sql = "";

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


        sql = "SELECT count(*) c ";
        sql = sql + "FROM TB_BrowseRecord ";
        sql = sql + "WHERE 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;

        ds = cn.mdb_ds(sql, "count");

        Label1.Text = ds.Tables["count"].Rows[0][0].ToString();


        sql = "";
        sql = "SELECT COUNT(DISTINCT UserIP) c ";
        sql = sql + "FROM TB_BrowseRecord ";
        sql = sql + "WHERE 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;



        ds = cn.mdb_ds(sql, "count");

        Label2.Text = ds.Tables["count"].Rows[0][0].ToString();
    }
}
