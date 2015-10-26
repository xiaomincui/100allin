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

public partial class admin_usercontrols_adminleft : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //如果用户登陆信息正确，显示管理页面
        if (this.Request.Cookies["admin"] == null)
        {
            Server.Transfer("/admin/login.aspx");
        }
        else
        {
            if (this.Request.Cookies["admin"].Value == "yes")
            {

            }
            else
            {
                Server.Transfer("/admin/login.aspx");
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies["admin"].Value = "";
        Response.Redirect("/admin/");
    }
}
