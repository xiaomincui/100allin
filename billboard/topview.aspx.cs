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

public partial class billboard_topview : System.Web.UI.Page
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
            sql = sql + "SELECT TOP 20 ";
            sql = sql + "TB_User.RealName, ";
            sql = sql + "TB_User.CompanyName, ";
            sql = sql + "T_AIRINFO.title AS ttitle, ";
            sql = sql + "T_AIRINFO.StartPort AS tstartport, ";
            sql = sql + "T_AIRPRICE.DestPort AS tdestport, ";
            sql = sql + "T_AIRINFO.line AS tline,  ";
            sql = sql + "T_AIRINFO.id AS yid, ";
            sql = sql + "T_AIRPRICE.ID AS ydid,  ";
            sql = sql + "T_AIRPRICE.infohits ";
            sql = sql + "FROM T_AIRINFO,T_AIRPRICE,TB_User ";
            sql = sql + "WHERE  ";
            sql = sql + "T_AIRINFO.id = T_AIRPRICE.airid  ";
            sql = sql + "AND T_AIRINFO.UserID <> 44  ";
            sql = sql + "AND T_AIRINFO.UserID = TB_User.UserID  ";

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


            sql = sql + "ORDER BY T_AIRPRICE.infohits DESC, T_AIRPRICE.ID DESC ";

        }
        else
        {
            sql = sql + "SELECT TOP 20 ";
            sql = sql + "TB_User.RealName, ";
            sql = sql + "TB_User.CompanyName, ";
            sql = sql + "TB_YunJia.title AS ttitle, ";
            sql = sql + "TB_YunJia.StartPort AS tstartport, ";
            sql = sql + "TB_YunJiaInfo.DestPort AS tdestport, ";
            sql = sql + "TB_YunJia.hangxianmiaoshu AS tline,  ";
            sql = sql + "TB_YunJia.id AS yid, ";
            sql = sql + "TB_YunJiaInfo.ID AS ydid,  ";
            sql = sql + "TB_YunJiaInfo.infohits ";
            sql = sql + "FROM TB_YunJia,TB_YunJiaInfo,TB_User ";
            sql = sql + "WHERE  ";
            sql = sql + "TB_YunJia.id = TB_YunJiaInfo.YunJiaID  ";
            sql = sql + "AND TB_YunJia.UserID <> 44  ";
            sql = sql + "AND TB_YunJia.UserID = TB_User.UserID  ";

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


            sql = sql + "ORDER BY TB_YunJiaInfo.infohits DESC, TB_YunJiaInfo.ID DESC ";
        }



        Label4.Text = Label1.Text + Label2.Text + Label3.Text + "关注度排行" + Label5.Text;
        Page.Title = "环球运费网 - " + Label4.Text;

        //Response.Write(sql);

        ds = cn.mdb_ds(sql,"top");

        RptTopView.DataSource = ds.Tables["top"].DefaultView;
        RptTopView.DataBind();
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
        
    }
}
