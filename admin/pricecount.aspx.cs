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

public partial class admin_pricecount : System.Web.UI.Page
{
    public string pol1 = "";
    public string pol2 = "";
    public string ltime1 = "";
    public string ltime2 = "";
    public string star_allin = "";
    check check1 = new check();
    GetRequest GetRequest1 = new GetRequest();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            pol1 = check1.CheckInput(GetRequest1.GetRequestQueryString("pol1", ""));
            pol2 = check1.CheckInput(GetRequest1.GetRequestQueryString("pol2", ""));
            ltime1 = check1.CheckInput(GetRequest1.GetRequestQueryString("ltime1", ""));
            ltime2 = check1.CheckInput(GetRequest1.GetRequestQueryString("ltime2", ""));
            star_allin = check1.CheckInput(GetRequest1.GetRequestQueryString("star_allin", ""));

            if (ltime1 == "")
            {
                BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            }
            else
            {
                BasicDatePicker1_TextBox.Value = ltime1;
            }
            if (ltime2 == "")
            {
                BasicDatePicker2_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            }
            else
            {
                BasicDatePicker2_TextBox.Value = ltime2;
            }

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
        string sqlport1 = "";
        string sqlport2 = "";
        string sql_star_allin = "";

        date1 = BasicDatePicker1_TextBox.Value.ToString();
        date2 = BasicDatePicker2_TextBox.Value.ToString();

        if (date1 != "")
        {
            date1 = date1 + " 00:00:00";
            sqldate1 = sqldate1 + "AND PostDate >= '" + date1 + "' ";
        }

        if (date2 != "")
        {
            date2 = date2 + " 23:59:59";
            sqldate2 = sqldate2 + "AND PostDate <= '" + date2 + "' ";
        }

        if (pol1 != "")
        {
            sqlport1 = "AND (TB_YunJia.startport like '%" + pol1 + "%' OR TB_YunJia.startport like '%" + pol2 + "%') ";
            sqlport2 = "AND (T_Airinfo.startport like '%" + pol1 + "%' OR T_Airinfo.startport like '%" + pol2 + "%') ";
        }

        if (star_allin == "1")
        {
            sql_star_allin = "AND star_allin > 0 ";
        }
        if (star_allin == "0")
        {
            sql_star_allin = "AND star_allin = 0 ";
        }

        string sql = "";

        sql = "SELECT '全部航线' AS u, COUNT(TB_YunJia.id) AS c FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID ";
        sql = sql + "WHERE (TB_YunJia.yunjialeixing = 8) ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + sqlport1;
        sql = sql + sql_star_allin;
        sql = sql + "union all ";
        sql = sql + "SELECT TB_YunJia.hangxianmiaoshu AS u, COUNT(TB_YunJia.hangxianmiaoshu) AS c FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID ";
        sql = sql + "WHERE (TB_YunJia.yunjialeixing = 8) ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + sqlport1;
        sql = sql + sql_star_allin;
        sql = sql + "GROUP BY TB_YunJia.hangxianmiaoshu order by c desc";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "TB_YunJia8");

        Repeater1.DataSource = ds.Tables["TB_YunJia8"].DefaultView;
        Repeater1.DataBind();


        sql = "SELECT '全部航线' AS u, COUNT(TB_YunJia.id) AS c FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID ";
        sql = sql + "WHERE (TB_YunJia.yunjialeixing = 9) ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + sqlport1;
        sql = sql + sql_star_allin;
        sql = sql + "union all ";
        sql = sql + "SELECT TB_YunJia.hangxianmiaoshu AS u, COUNT(TB_YunJia.hangxianmiaoshu) AS c FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID ";
        sql = sql + "WHERE (TB_YunJia.yunjialeixing = 9) ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + sqlport1;
        sql = sql + sql_star_allin;
        sql = sql + "GROUP BY TB_YunJia.hangxianmiaoshu order by c desc";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "TB_YunJia9");

        Repeater2.DataSource = ds.Tables["TB_YunJia9"].DefaultView;
        Repeater2.DataBind();


        sql = "SELECT '全部航线' AS u, COUNT(*) AS c FROM T_AIRINFO INNER JOIN T_AIRPRICE ON T_AIRINFO.ID = T_AIRPRICE.AIRID INNER JOIN TB_User ON T_AIRINFO.USERID = TB_User.UserID ";
        sql = sql + "WHERE 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + sqlport2;
        sql = sql + sql_star_allin;
        sql = sql + "union all ";
        sql = sql + "SELECT T_Airinfo.line AS u, COUNT(T_Airinfo.line) AS c FROM T_AIRINFO INNER JOIN T_AIRPRICE ON T_AIRINFO.ID = T_AIRPRICE.AIRID INNER JOIN TB_User ON T_AIRINFO.USERID = TB_User.UserID ";
        sql = sql + "WHERE 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + sqlport2;
        sql = sql + sql_star_allin;
        sql = sql + "GROUP BY T_Airinfo.line order by c desc";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "TB_YunJia9");

        Repeater3.DataSource = ds.Tables["TB_YunJia9"].DefaultView;
        Repeater3.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("pricecount.aspx?pol1=" + pol1 + "&pol2=" + pol2 + "&ltime1=" + BasicDatePicker1_TextBox.Value + "&ltime2=" + BasicDatePicker2_TextBox.Value);
    }
}
