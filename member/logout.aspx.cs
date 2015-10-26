using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class member_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["user_id"].Value = "";
        Response.Cookies["user_name"].Value = "";
        Response.Cookies["user_password"].Value = "";
        Response.Cookies["realname"].Value = "";
        Response.Cookies["companyname"].Value = "";
        Response.Cookies["phone"].Value = "";
        Response.Cookies["useremail"].Value = "";
        Response.Redirect("/");
    }
}
