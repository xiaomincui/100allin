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

public partial class admin_usercontrols_admintop : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string address = Page.Request.UserHostAddress;
        if (address == "101.229.232.134" | address == "180.166.76.178" | address == "127.0.0.1" | address == "222.73.45.25" | address == "61.175.132.98" | address == "121.10.239.168")
        {

        }
        else
        {
            Response.Redirect("/");
        }    
    }
}
