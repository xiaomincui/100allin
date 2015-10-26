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

public partial class usercontrols_userwelcome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["user_name"] != null)
        {
            if (Request.Cookies["user_name"].Value.ToString() != "")
            {
                Label1.Text = "欢迎您！" + Server.UrlDecode(Request.Cookies["user_name"].Value.ToString())  + " <a href=\"/accounts/logout.aspx\">退出登录</a>"; ;
                homelogin.Visible = true;
                homelogout.Visible = false;
            }
            else
            {
                Label1.Text = "欢迎您！" + "<a href=\"/accounts/login.aspx\">登录</a>";
                homelogin.Visible = false;
                homelogout.Visible = true;
            }
        }
        else
        {
            Label1.Text = "欢迎您！" + "<a href=\"/accounts/login.aspx\">登录</a>";
            homelogin.Visible = false;
            homelogout.Visible = true;
        }
        
    }


}
