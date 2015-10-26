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

public partial class usercontrols_usertoptop20100711 : System.Web.UI.UserControl
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
                    Literal1.Text = "";
                }
                else
                {
                    Literal1.Text = "| 您共有<a href=\"/member/pm.aspx\" class=\"red_2\">" + newpm + "</a>条未读留言";
                }
                if (Request.Cookies["realname"] != null)
                {
                    Label8.Text = "<span style=\"color:#000000;\">欢迎您！" + Server.UrlDecode(Request.Cookies["realname"].Value.ToString()) + "</span> " + "<a href=\"/accounts/logout.aspx\">[退出登录]</a><script src='/home/newlogin.php'></script>";
                }
            }
            else
            {
                Label8.Text = "欢迎您！<a href=\"/accounts/login.aspx\">[登录]</a><script src='/home/newlogout.php'></script>"; 
            }
        }
        else
        {
            Label8.Text = "欢迎您！<a href=\"/accounts/login.aspx\">[登录]</a><script src='/home/newlogout.php'></script>"; 
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
