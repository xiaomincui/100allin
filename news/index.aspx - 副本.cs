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

public partial class news_index : System.Web.UI.Page
{
    public string pagecontrol_string;
    public string pagecontrol_prev;
    public string pagecontrol_next;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadNews();
            //LoadNewBBS();
        }
    }

    public void LoadNews()
    {
 
            check ck = new check();
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();

            string p = "1";

            if (Request.QueryString["page"] != null)
            {
                p = ck.CheckInput(Request.QueryString["page"].ToString());
            }

            int ps = (Convert.ToInt32(p) - 1) * 20;

            string sql = "";
            sql = "SELECT TOP 20 * ";
            sql += "FROM ";
            sql += "TB_BBS ";
            sql += "WHERE TYPES = 5";
            sql += "ORDER BY id DESC ";

            ds = cn.mdb_ds(sql, "news");

            //Response.Write(sql);
            //Response.Write("<br/>");
            //Response.Write(Request.Url.ToString());
            Repeater4.DataSource = ds.Tables["news"].DefaultView;
            Repeater4.DataBind();


            sql = "SELECT TOP 8 * ";
            sql += "FROM ";
            sql += "TB_BBS ";
            sql += "WHERE TYPES = 11";
            sql += "ORDER BY id DESC ";

            ds = cn.mdb_ds(sql, "news");

            //Response.Write(sql);
            //Response.Write("<br/>");
            //Response.Write(Request.Url.ToString());
            Repeater1.DataSource = ds.Tables["news"].DefaultView;
            Repeater1.DataBind();


            sql = "select * from TB_IMGIndex where id = 4";
            ds = cn.mdb_ds(sql, "news");

            Literal1.Text = ds.Tables["news"].Rows[0]["txttitle"].ToString();
            Literal2.Text = ds.Tables["news"].Rows[0]["txttext"].ToString();
            Literal3.Text = "<a href=\"" + ds.Tables["news"].Rows[0]["txtlink"].ToString() + "\" target=\"_blank\"><img src=\"/images2/index/news_top.jpg\" border=\"0\" width=\"200\" height=\"150\"  /></a>";
            Literal4.Text = "<a href=\"" + ds.Tables["news"].Rows[0]["txtlink"].ToString() + "\" target=\"_blank\">";
            Literal5.Text = "<a href=\"" + ds.Tables["news"].Rows[0]["txtlink"].ToString() + "\" target=\"_blank\">";
    }


    //public void LoadNewBBS()
    //{
    //    try
    //    {
    //        check ck = new check();
    //        data_conn cn = new data_conn();
    //        DataSet ds = new DataSet();
    //        string sql = "";

    //        sql = "select top 3 ";
    //        sql = sql + "id,title,postdate ";
    //        sql = sql + "FROM TB_BBS where types = 3 ORDER BY PostDate DESC ";
    //        ds = cn.mdb_ds(sql, "bbs");

    //        Repeater2.DataSource = ds.Tables["bbs"].DefaultView;
    //        Repeater2.DataBind();

    //        sql = "select top 3 ";
    //        sql = sql + "id,title,postdate ";
    //        sql = sql + "FROM TB_BBS where types = 2 ORDER BY PostDate DESC ";
    //        ds = cn.mdb_ds(sql, "bbs");

    //        Repeater3.DataSource = ds.Tables["bbs"].DefaultView;
    //        Repeater3.DataBind();
    //    }
    //    catch
    //    {

    //    }
    //}
}
