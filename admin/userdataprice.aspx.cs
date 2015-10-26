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

public partial class admin_userdataprice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRequest GetRequest1 = new GetRequest();
        check check1 = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        
        string u = "0";
        u = check1.CheckNumber(GetRequest1.GetRequestQueryString("u", "0"));

        string sql = "";
        
        sql = "";
        sql += "SELECT * ";
        sql += "FROM TB_User ";
        sql += "WHERE (UserID = " + u + ") ";
        ds = cn.mdb_ds(sql, "user");

        ltrRealname.Text = ds.Tables["user"].Rows[0]["realname"].ToString() + "(" + ds.Tables["user"].Rows[0]["companyname"].ToString() + ")";
        
        sql = "";
        sql += "SELECT COUNT(ID) AS c,MIN(postdatex) as mindate,MAX(postdatex) as maxdate ";
        sql += "FROM TB_YunJiaInfo ";
        sql += "WHERE (UserIDx = " + u + ") AND (yunjialeixingx = 8) ";
        ds = cn.mdb_ds(sql, "user0");

        if (ds.Tables["user0"].Rows[0][0].ToString() != "0")
        {
            ltrFclTotal.Text = "整箱运价共 " + ds.Tables["user0"].Rows[0][0].ToString() + " 条(" + Convert.ToDateTime(ds.Tables["user0"].Rows[0][1].ToString()).ToShortDateString() + " 第一次发布，" + Convert.ToDateTime(ds.Tables["user0"].Rows[0][2].ToString()).ToShortDateString() + " 最后一次发布)，其中：";
        }
        else
        {
            ltrFclTotal.Text = "整箱运价共 0 条";
            phFclTotal.Visible = false;
        }

        sql = "";
        sql += "SELECT TOP 10 hangxianmiaoshux, COUNT(hangxianmiaoshux) AS c ";
        sql += "FROM TB_YunJiaInfo ";
        sql += "WHERE (UserIDx = " + u + ") AND (yunjialeixingx = 8) ";
        sql += "GROUP BY hangxianmiaoshux ";
        sql += "ORDER BY c DESC ";
        ds = cn.mdb_ds(sql, "user1");
        Repeater1.DataSource = ds.Tables["user1"].DefaultView;
        Repeater1.DataBind();


        sql = "";
        sql += "SELECT TOP 10 hangxianmiaoshux, shipcompany, COUNT(hangxianmiaoshux) AS c ";
        sql += "FROM TB_YunJiaInfo ";
        sql += "WHERE (UserIDx = " + u + ") AND (yunjialeixingx = 8) ";
        sql += "AND (shipcompany IS NOT NULL) AND (shipcompany <> '') ";
        sql += "GROUP BY hangxianmiaoshux, shipcompany ";
        sql += "ORDER BY c DESC ";
        ds = cn.mdb_ds(sql, "user1");
        Repeater2.DataSource = ds.Tables["user1"].DefaultView;
        Repeater2.DataBind();

        sql = "";
        sql += "SELECT COUNT(ID) AS c,MIN(postdatex) as mindate,MAX(postdatex) as maxdate ";
        sql += "FROM TB_YunJiaInfo ";
        sql += "WHERE (UserIDx = " + u + ") AND (yunjialeixingx = 9) ";
        ds = cn.mdb_ds(sql, "user0");
        if (ds.Tables["user0"].Rows[0][0].ToString() != "0")
        {
            ltrLclTotal.Text = "拼箱运价共 " + ds.Tables["user0"].Rows[0][0].ToString() + " 条(" + Convert.ToDateTime(ds.Tables["user0"].Rows[0][1].ToString()).ToShortDateString() + " 第一次发布，" + Convert.ToDateTime(ds.Tables["user0"].Rows[0][2].ToString()).ToShortDateString() + " 最后一次发布)，其中：";
        }
        else
        {
            ltrLclTotal.Text = "拼箱运价共 0 条";
            phLclTotal.Visible = false;
        }

        sql = "";
        sql += "SELECT TOP 10 hangxianmiaoshux, COUNT(hangxianmiaoshux) AS c ";
        sql += "FROM TB_YunJiaInfo ";
        sql += "WHERE (UserIDx = " + u + ") AND (yunjialeixingx = 9) ";
        sql += "GROUP BY hangxianmiaoshux ";
        sql += "ORDER BY c DESC ";
        ds = cn.mdb_ds(sql, "user1");
        Repeater3.DataSource = ds.Tables["user1"].DefaultView;
        Repeater3.DataBind();


        sql = "";
        sql += "SELECT TOP 10 hangxianmiaoshux, shipcompany, COUNT(hangxianmiaoshux) AS c ";
        sql += "FROM TB_YunJiaInfo ";
        sql += "WHERE (UserIDx = " + u + ") AND (yunjialeixingx = 9) ";
        sql += "AND (shipcompany IS NOT NULL) AND (shipcompany <> '') ";
        sql += "GROUP BY hangxianmiaoshux, shipcompany ";
        sql += "ORDER BY c DESC ";
        ds = cn.mdb_ds(sql, "user1");
        Repeater4.DataSource = ds.Tables["user1"].DefaultView;
        Repeater4.DataBind();


        sql = "";
        sql += "SELECT COUNT(ID) AS c,MIN(postdatex) as mindate,MAX(postdatex) as maxdate ";
        sql += "FROM T_AIRPRICE ";
        sql += "WHERE (UserIDx = " + u + ") ";
        ds = cn.mdb_ds(sql, "user0");

        if (ds.Tables["user0"].Rows[0][0].ToString() != "0")
        {
            ltrAirTotal.Text = "空运运价共 " + ds.Tables["user0"].Rows[0][0].ToString() + " 条(" + Convert.ToDateTime(ds.Tables["user0"].Rows[0][1].ToString()).ToShortDateString() + " 第一次发布，" + Convert.ToDateTime(ds.Tables["user0"].Rows[0][2].ToString()).ToShortDateString() + " 最后一次发布)，其中：";
        }
        else
        {
            ltrAirTotal.Text = "空运运价共 0 条";
            phAirTotal.Visible = false;
        }



        sql = "";
        sql += "SELECT TOP 10 linex, COUNT(linex) AS c ";
        sql += "FROM T_AIRPRICE ";
        sql += "WHERE (UserIDx = " + u + ") ";
        sql += "GROUP BY linex ";
        sql += "ORDER BY c DESC ";
        ds = cn.mdb_ds(sql, "user1");
        Repeater5.DataSource = ds.Tables["user1"].DefaultView;
        Repeater5.DataBind();


        sql = "";
        sql = "SELECT * FROM TB_USER WHERE userid = " + u + "";
        ds = cn.mdb_ds(sql, "user1");
        Literal2.Text = "<a href=\"/admin/freightlist.aspx\" target=\"_blank\">" + ds.Tables["user1"].Rows[0]["Login2_Adventage_Line_Adv"].ToString() + "</a>";
        Literal10.Text = ds.Tables["user1"].Rows[0]["Login2_Adventage_Line2_Adv"].ToString();



    }
}
