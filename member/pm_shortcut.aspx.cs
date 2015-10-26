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

public partial class member_pm_shortcut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            if (Request.Cookies["user_name"] != null)
            {
                if (Request.Cookies["user_name"].Value.ToString() != "")
                {
                    getpm();
                }
            }
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (Request.Cookies["user_name"] != null)
        {
            if (Request.Cookies["user_name"].Value.ToString() != "")
            {
                getpm();
            }
        }
    }

    protected void getpm()
    {
        try
        {
            pm p = new pm();
            string newpm = p.getnewpm(Request.Cookies["user_id"].Value.ToString());

            if (newpm == "0")
            {
                Label2.Text = "<a href=\"/member/pm.aspx?filter=new\" target=\"_blank\">&nbsp;您没有新留言</a>";
            }
            else
            {
                Label2.Text = "<a href=\"/member/pm.aspx?filter=new\" target=\"_blank\">您有<b style=\"color:red\">" + newpm + "</b>条新留言</a>";
            }
        }
        catch
        {
            Label2.Text = "&nbsp;网络有错误";
        }
    }
}
