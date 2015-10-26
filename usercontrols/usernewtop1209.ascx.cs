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

public partial class usercontrols_usernewtop1209 : System.Web.UI.UserControl
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
                Literal2.Text = "<a href=\"/accounts/login.aspx\"><img src=\"/images/fcl/jt.gif\" border=\"0\" />登录</a>";
                homelogin.Visible = false;
                homelogout.Visible = true;
            }
        }
        else
        {
            PlaceHolder1.Visible = false;
            Literal2.Text = "<a href=\"/accounts/login.aspx\"><img src=\"/images/fcl/jt.gif\" border=\"0\" />登录</a>";
            homelogin.Visible = false;
            homelogout.Visible = true;
        }
    }
}
