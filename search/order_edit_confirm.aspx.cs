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

public partial class search_order_edit_confirm : System.Web.UI.Page
{
    public AllinOrder AllinOrder1 = new AllinOrder();
    public AllinFreight AllinFreight1 = new AllinFreight();
    public GetRequest GetRequest1 = new GetRequest();
    public check check1 = new check();

    protected void Page_Load(object sender, EventArgs e)
    {
        string orderid = GetRequest1.GetRequestQueryString("orderid", "0");
        string type = GetRequest1.GetRequestQueryString("type", "0");
        string u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

        string[] odetail;
        odetail = AllinOrder1.GetOrderDetail(orderid);

        if (u != odetail[3])
        {
            Response.Redirect("/search/err.aspx");
        }

        if (odetail[131] == "0")
        {
            Response.Redirect("/search/err.aspx");
        }

        if (type == "ok")
        {
            AllinOrder1.UpdateOrderPriceOk(orderid);
            Response.Redirect("order_success.aspx?type=editpriceok&orderid=" + orderid);
        }
        else if (type == "cancel")
        {
            AllinOrder1.UpdateOrderPriceCancel(orderid);
            Response.Redirect("order_success.aspx?type=editpricecancel&orderid=" + orderid);
        }
        


    }
}
