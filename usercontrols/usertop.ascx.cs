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

public partial class usercontrols_usertop : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            LoadMember();
            PageRecord();
        }
    }

    void LoadMember()
    {
        //计算网站运价和货盘的总数，显示在页面顶端
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "fclcount,lclcount,aircount,cargocount ";
        sql = sql + "FROM ";
        sql = sql + "tb_pricecount ";
        sql = sql + "WHERE ";
        sql = sql + "cid=1 ";

        ds = cn.mdb_ds(sql, "count");

        lblCountZx.Text = Convert.ToInt32(ds.Tables["count"].Rows[0][0]).ToString("N0");
        lblCountPx.Text = Convert.ToInt32(ds.Tables["count"].Rows[0][1]).ToString("N0");
        lblCountHk.Text = Convert.ToInt32(ds.Tables["count"].Rows[0][2]).ToString("N0");
        lblCountHp.Text = Convert.ToInt32(ds.Tables["count"].Rows[0][3]).ToString("N0");
    }

    void PageRecord()
    {
        check ck = new check();
        string request;
        if (Request.ServerVariables["HTTP_REFERER"] == null)
        {
            request = "";
        }
        else
        {
            request = Request.ServerVariables["HTTP_REFERER"].ToString();
            request = ck.CheckRecord(request);
        }

        string page = Request.Url.ToString();
        page = ck.CheckRecord(page);

        string pagefile = Request.Url.AbsolutePath.ToString();
        pagefile = ck.CheckRecord(pagefile);

        


        string pagesql = "select pagearea from TB_PageArea where pageaddress = '" + pagefile + "'";
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        ds = cn.mdb_ds(pagesql, "TB_PageArea");


        string pagearea = "";

        if (ds.Tables["TB_PageArea"].Rows.Count > 0)
        {
            pagearea = ds.Tables["TB_PageArea"].Rows[0][0].ToString();
        }



        string address = Page.Request.UserHostAddress;
        if (this.Request.Cookies["user_id"] == null)
        {
            string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
            
            cn.mdb_exe(sql);

        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {
                string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (0,'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                cn.mdb_exe(sql);
            }
            else
            {
                string a = this.Request.Cookies["user_id"].Value;
                string sql = "insert into TB_BrowseRecord (Userid,UserIP,Pageid,NowTime,Request,page,pagearea) values (" + this.Request.Cookies["user_id"].Value + ",'" + address + "',1,Getdate(),'" + request + "','" + page + "','" + pagearea + "')";
                cn.mdb_exe(sql);
            }
        }
    }
}
