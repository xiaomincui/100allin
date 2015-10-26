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

public partial class usercontrols_usertop100414 : System.Web.UI.UserControl
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
                    Literal1.Text = "0";
                }
                else
                {
                    Literal1.Text = newpm;
                }
                if (Request.Cookies["realname"] != null)
                {
                    Literal2.Text = "欢迎您！" + Server.UrlDecode(Request.Cookies["realname"].Value.ToString()) + " <a href=\"/accounts/logout.aspx\">退出登录</a>";
                }

                homelogin.Visible = true;
                homelogout.Visible = false;
            }
            else
            {
                PlaceHolder1.Visible = false;
                PlaceHolder2.Visible = true;
                Literal2.Text = "<a href=\"/accounts/login.aspx\"><img src=\"/images/fcl/jt.gif\" border=\"0\" width=\"3\" height=\"5\" />登录</a>";
                homelogin.Visible = false;
                homelogout.Visible = true;
            }
        }
        else
        {
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = true;
            Literal2.Text = "<a href=\"/accounts/login.aspx\"><img src=\"/images/fcl/jt.gif\" border=\"0\" width=\"3\" height=\"5\" />登录</a>";
            homelogin.Visible = false;
            homelogout.Visible = true;
        }

        GetRequest GetRequest1 = new GetRequest();
        string uvid = "0";
        if (GetRequest1.GetRequestCookies("uvid", "0") == "0")
        {
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "INSERT INTO TB_UV_LIST (uvtime) values (getdate());select @@identity";
            ds = cn.mdb_ds(sql, "uvid");
            uvid = ds.Tables["uvid"].Rows[0][0].ToString();

            Response.Cookies["uvid"].Value = uvid;
            Response.Cookies["uvid"].Expires = DateTime.Now.AddDays(365);
        }
        else
        {
            uvid = GetRequest1.GetRequestCookies("uvid", "0");
        }



        string srvlink = "";
        srvlink += "<a title=\"欢迎使用在线客服\" id=\"service_link\" href=\"http://im.cn.alisoft.com/webim/webim/webclient!open.jspa?lang=zh_cn&img=0&memberid=";
        srvlink += "e" + uvid;
        srvlink += "&targetid=cnalichna910254766&siteId=4035516&initiative=1&domain=probe.alisoft.com&siteFlag=enet&colorStyle=orange&msg=&ct=\" target=\"_blank\">在线客服</a>";
        Literal3.Text = srvlink;
    }
}
