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

public partial class accounts_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["redirect_url"] == null)
        {
            Response.Redirect("logout.aspx?redirect_url=" + Server.UrlEncode(Request.ServerVariables["HTTP_REFERER"].ToString()));
        }
        else
        {
            if (Request.QueryString["redirect_url"] == "")
            {
                Response.Redirect("logout.aspx?redirect_url=" + Server.UrlEncode(Request.ServerVariables["HTTP_REFERER"].ToString()));
            }
            else
            {
                Response.Cookies["user_id"].Value = "";
                Response.Cookies["user_name"].Value = "";
                Response.Cookies["user_password"].Value = "";
                Response.Cookies["realname"].Value = "";
                Response.Cookies["companyname"].Value = "";
                Response.Cookies["phone"].Value = "";
                Response.Cookies["useremail"].Value = "";
                Response.Redirect(Request.QueryString["redirect_url"].ToString());
            }
        }

    }
}
