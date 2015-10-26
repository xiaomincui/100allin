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

public partial class admin_countuser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        LoadUserCountToday();
        LoadUserCountYesterday();
        LoadUserCountTotal();

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



}
