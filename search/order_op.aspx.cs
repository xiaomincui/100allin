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

public partial class search_order_op : System.Web.UI.Page
{
    public AllinOrder AllinOrder1 = new AllinOrder();
    public AllinFreight AllinFreight1 = new AllinFreight();
    public GetRequest GetRequest1 = new GetRequest();

    protected void Page_Load(object sender, EventArgs e)
    {
        string a = GetRequest1.GetRequestQueryString("a","0");
        string c1 = GetRequest1.GetRequestQueryString("c1", "0");
        string c2 = GetRequest1.GetRequestQueryString("c2", "0");
        string orderid = GetRequest1.GetRequestQueryString("orderid", "0");

        AllinOrder1.SetOrderDetail(a, c1, c2, orderid,"");

        if (a == "1" & c1 == "3" & c2 == "4") 
        {
            Response.Redirect("order_success.aspx?type=finishs1&orderid=" + orderid);
        }

        if (a == "2" & c1 == "3" & c2 == "5")
        {
            Response.Redirect("order_success.aspx?type=finishf1&orderid=" + orderid);
        }

        if (a == "1" & c1 == "5" & c2 == "6")
        {
            Response.Redirect("order_success.aspx?type=finishs2&orderid=" + orderid);
        }

        if (a == "2" & c1 == "4" & c2 == "6")
        {
            Response.Redirect("order_success.aspx?type=finishf2&orderid=" + orderid);
        }

        if (a == "1" & c1 == "2" & c2 == "8")
        {
            Response.Redirect("order_success.aspx?type=cancel&orderid=" + orderid);
        }

        if (a == "2" & c1 == "2" & c2 == "3")
        {
            Response.Redirect("order_success.aspx?type=accept&orderid=" + orderid);
        }

        if (a == "2" & c1 == "2" & c2 == "7")
        {
            Response.Redirect("order_success.aspx?type=reject&orderid=" + orderid);
        }
    }
}
