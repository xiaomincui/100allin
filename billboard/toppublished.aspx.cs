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

public partial class billboard_toppublished : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        string sp = ck.CheckInput(Request.QueryString["sp"].ToString());
        string l = ck.CheckInput(Request.QueryString["l"].ToString());
        string y = ck.CheckInput(Request.QueryString["y"].ToString());
        string m = ck.CheckInput(Request.QueryString["m"].ToString());
        string type = ck.CheckInput(Request.QueryString["type"].ToString());
        string t = "";





        if (type == "fcl")
        {
            Label3.Text = "整箱海运价";
            t = "8";
        }

        if (type == "lcl")
        {
            Label3.Text = "拼箱海运价";
            t = "9";
        }

        if (type == "air")
        {
            Label3.Text = "空运运价";
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();


        string sql = "";


        if (type == "air")
        {
            sql = sql + "SELECT TOP 10 T_AIRINFO.USERID, TB_User.RealName, TB_User.CompanyName, COUNT(T_AIRINFO.USERID) AS C  ";
            sql = sql + "FROM T_AIRINFO INNER JOIN T_AIRPRICE ON T_AIRINFO.ID = T_AIRPRICE.AIRID INNER JOIN TB_User ON T_AIRINFO.USERID = TB_User.UserID  ";
            sql = sql + "WHERE (T_AIRINFO.USERID2 = '' OR T_AIRINFO.USERID2 IS NULL) AND T_AIRINFO.USERID <> 44 ";

            if (sp != "")
            {
                sql = sql + "AND T_AIRINFO.startport like '%" + sp + "%' ";
                Label5.Text = " - " + sp;
            }

            if (l != "")
            {
                sql = sql + "AND T_AIRINFO.line = '" + Server.UrlDecode(l).ToString() + "' ";
                Label5.Text = " - " + l;
            }


            if (y != "")
            {
                sql = sql + "AND YEAR(T_AIRINFO.PostDate) = " + y + " ";
                Label1.Text = y + "年";
            }

            if (m != "")
            {
                sql = sql + "AND MONTH(T_AIRINFO.PostDate) = " + m + " ";
                Label2.Text = m + "月";
            }


            sql = sql + "GROUP BY T_AIRINFO.USERID, TB_User.RealName, TB_User.CompanyName ";
            sql = sql + "ORDER BY c DESC ";

        }
        else
        {
            sql = sql + "SELECT TOP 10 TB_YunJia.UserID, TB_User.RealName, TB_User.CompanyName,COUNT(TB_YunJia.UserID) AS C ";
            sql = sql + "FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID ";
            sql = sql + "WHERE (TB_YunJia.UserID2 = '' OR TB_YunJia.UserID2 IS NULL)  AND TB_YunJia.USERID <> 44 ";

            if (sp != "")
            {
                sql = sql + "AND TB_YunJia.startport like '%" + sp + "%' ";
                Label5.Text = " - " + sp;
            }

            if (l != "")
            {
                sql = sql + "AND TB_YunJia.hangxianmiaoshu = '" + Server.UrlDecode(l).ToString() + "' ";
                Label5.Text = " - " + l;
            }

            if (t != "")
            {
                sql = sql + "AND TB_YunJia.yunjialeixing = '" + t + "' ";
            }

            if (y != "")
            {
                sql = sql + "AND YEAR(TB_YunJia.PostDate) = " + y + " ";
                Label1.Text = y + "年";
            }

            if (m != "")
            {
                sql = sql + "AND MONTH(TB_YunJia.PostDate) = " + m + " ";
                Label2.Text = m + "月";
            }


            sql = sql + "GROUP BY TB_YunJia.UserID, TB_User.RealName, TB_User.CompanyName  ";
            sql = sql + "ORDER BY c DESC ";
        }



        Label4.Text = Label1.Text + Label2.Text + Label3.Text + "发布量排行" + Label5.Text;
        Page.Title = "环球运费网 - " + Label4.Text;

        //Response.Write(sql);

        ds = cn.mdb_ds(sql, "top");

        RptTopView.DataSource = ds.Tables["top"].DefaultView;
        RptTopView.DataBind();
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);

    }
}
