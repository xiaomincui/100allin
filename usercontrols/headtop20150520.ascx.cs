using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_headtop20150520 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["user_id"] != null)
        {
            if (Request.Cookies["user_id"].Value.ToString() != "")
            {
                pm p = new pm();
                string newpm = p.getnewpm(Request.Cookies["user_id"].Value.ToString());

                if (newpm == "0")
                {
                    Literal2.Text = "";
                }
                else
                {
                    Literal2.Text = "<span class=\"sep\">|</span><a href=\"/member/pm.aspx\">您有" + newpm + "条未读留言</a>";
                }
                if (Request.Cookies["realname"] != null)
                {
                    Literal1.Text = "<b class=\"top-username\"><a href=\"/member/\">" + Server.UrlDecode(Request.Cookies["realname"].Value.ToString()) + "</a></b>，您好！欢迎使用100Allin <a href=\"/accounts/logout.aspx\">[退出登录]</a> <span class=\"sep\">|</span><a href=\"/member/\">我的办公室</a><script src='/home/newlogin.php'></script>";
                }
            }
            else
            {

                Literal1.Text = "<b class=\"top-username\">用户</b>，您好！欢迎使用100Allin <a href=\"/accounts/login.aspx\">[登录]</a><script src='/home/newlogout.php'></script>";
            }
        }
        else
        {
            Literal1.Text = "<b class=\"top-username\">用户</b>，您好！欢迎使用100Allin <a href=\"/accounts/login.aspx\">[登录]</a><script src='/home/newlogout.php'></script>";
        }

        //data_conn cn = new data_conn();
        //DataSet ds = new DataSet();
        //string sql;
        //sql = "SELECT TOP 30 ";
        //sql = sql + "* ";
        //sql = sql + "FROM ";
        //sql = sql + "TB_NEWYEARMERRY2011 ";
        //sql = sql + "ORDER BY nid DESC ";

        //ds = cn.mdb_ds(sql, "zhufu");
        //Rptzhufu.DataSource = ds.Tables["zhufu"].DefaultView;
        //Rptzhufu.DataBind();
    }
}