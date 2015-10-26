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

public partial class news_news_detail : System.Web.UI.Page
{
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
        try
        {
            check ck = new check();
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";
            string nid = "0";

            if (Request.QueryString["nid"] != null)
            {
                nid = ck.CheckInput(Request.QueryString["nid"].ToString());
            }

            sql = "select * from tb_bbs ";
            sql += "where id = " + nid;

            ds = cn.mdb_ds(sql, "news");

            if (ds.Tables["news"].Rows.Count == 0)
            {
                Response.Status = "404 Not Found";
            }

            Literal1.Text = ds.Tables["news"].Rows[0]["title"].ToString();
            Literal2.Text = ds.Tables["news"].Rows[0]["title"].ToString();
            Literal3.Text = "<title>" + ds.Tables["news"].Rows[0]["title"].ToString() + "-物流聚焦-环球运费网</title>";
            Literal6.Text = "<meta name=\"description\" content=\"" + ds.Tables["news"].Rows[0]["title"].ToString() + "，环球运费网是全球最大的专业运价查询平台，提供最新航运动态\" />";
            Literal4.Text = Convert.ToDateTime(ds.Tables["news"].Rows[0]["PostDate"].ToString()).ToString("yyyy年MM月dd日 hh:mm");
            Literal5.Text = ds.Tables["news"].Rows[0]["Data"].ToString();


            //string newsbody = ds.Tables["news"].Rows[0]["Data"].ToString();
            //newsbody = newsbody.Replace("马士基", "<a href=\"/fcl/list---MSK-0-0-0--------------------1.html\" title=\"点击查看马士基最新整箱运价\" target=\"_blank\">马士基</a>");
            //newsbody = newsbody.Replace("MSC", "string1");
            //newsbody = newsbody.Replace("地中海航运", "string2");
            //newsbody = newsbody.Replace("string1", "<a href=\"/fcl/list---MSC-0-0-0--------------------1.html\" title=\"点击查看地中海航运最新整箱运价\" target=\"_blank\">MSC</a>");
            //newsbody = newsbody.Replace("string2", "<a href=\"/fcl/list---MSC-0-0-0--------------------1.html\" title=\"点击查看地中海航运最新整箱运价\" target=\"_blank\">地中海航运</a>");



            //Label3.Text = newsbody;

            sql = "select ratesimple from TB_NEWRATE";
            ds = cn.mdb_ds(sql, "rate");

            string[] ratexxs = new string[4];

            string ratexx;
            ratexx = ds.Tables["rate"].Rows[0][0].ToString();

            ratexxs = ratexx.Split('|');

            try
            {
                ltrRate1.Text = (Convert.ToDouble(ratexxs[0]) / 100).ToString();
                ltrRate2.Text = (100 / Convert.ToDouble(ratexxs[0])).ToString("f4");
                //ltrRate3.Text = Math.Round((Convert.ToDouble(ratexxs[2])), 4).ToString("f4");
                //ltrRate4.Text = Math.Round((Convert.ToDouble(ratexxs[3])), 4).ToString("f3");
            }
            catch
            {

            }

            sql = "select top 8 ";
            sql = sql + "id,title,postdate ";
            sql = sql + "FROM TB_BBS WHERE (types = 5) ORDER BY newid() ";
            ds = cn.mdb_ds(sql, "bbs");
            RptaHangYunDongTai.DataSource = ds.Tables["bbs"].DefaultView;
            RptaHangYunDongTai.DataBind();
        }
        catch
        {
            //Response.Redirect("/search/err.aspx");
        }





    }

    public string bbsstyle(int r)
    {
        string s = "4";
        if (r <= 3)
        {
            return (r + 1).ToString();
        }
        else
        {
            return s;
        }

    }

}
