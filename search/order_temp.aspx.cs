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

public partial class search_order_temp : System.Web.UI.Page
{
    public GetRequest GetRequest1 = new GetRequest();
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = GetRequest1.GetRequestQueryString("type", "");
        string filter = GetRequest1.GetRequestQueryString("filter", "");
        string yid = GetRequest1.GetRequestQueryString("yid", "");
        string ydid = GetRequest1.GetRequestQueryString("ydid", "");
        string f = GetRequest1.GetRequestQueryString("f", "");

        Literal1.Text = "<a href=\"/search/" + type + "_order.aspx?filter=" + filter + "&yid=" + yid + "&ydid=" + ydid + "&f=" + f + "\"><img src=\"/images/fcl/botton_125.jpg\" border=\"0\" /></a>";

    }
}
