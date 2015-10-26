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

public partial class usercontrols_usernewtop : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["user_name"] != null)
        {
            if (Request.Cookies["user_name"].Value.ToString() != "")
            {
                Literal1.Text = "<a href=\"/accounts/logout.aspx\">退出</a>";
            }
            else
            {
                Literal1.Text = "<a href=\"/accounts/login.aspx\">登录</a>"; ;
            }
        }
        else
        {
            Literal1.Text = "<a href=\"/accounts/login.aspx\">登录</a>";
        }

        if (Request.Cookies["user_lan"] != null)
        {
            if (Request.Cookies["user_lan"].Value == "0")
            {
                LinkButton1.Text = "繁體中文";
            }
            else
            {
                LinkButton1.Text = "简体中文";
            }
        }
        else
        {
            LinkButton1.Text = "繁體中文";
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["user_lan"] != null)
        {
            if (Request.Cookies["user_lan"].Value == "0")
            {
                Response.Cookies["user_lan"].Value = "1";
            }
            else
            {
                Response.Cookies["user_lan"].Value = "0";
            }
            Response.Cookies["user_lan"].Expires = DateTime.Now.AddDays(365);
        }
        else
        {
            Response.Cookies["user_lan"].Value = "1";
            Response.Cookies["user_lan"].Expires = DateTime.Now.AddDays(365);
        }

        Response.Redirect(Request.ServerVariables["HTTP_REFERER"]);
    }
}
