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

public partial class member_order_edit_detail : System.Web.UI.Page
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


        string pmtxt_shipper = "";
        pmtxt_shipper += "<table border=\"1\" cellpadding=\"3\" cellspacing=\"1\" style=\"border-collapse: collapse; font-size:12px;\">";
        pmtxt_shipper += "<tr><td></td><td>20GP</td><td>40GP</td><td>40HQ</td><td>45HQ</td><td>船公司</td></tr>";
        pmtxt_shipper += "<tr><td>原运费</td><td>" + odetail[45] + "</td><td>" + odetail[46] + "</td><td>" + odetail[47] + "</td><td>" + odetail[48] + "</td><td>" + odetail[68] + "</td></tr>";
        pmtxt_shipper += "<tr><td>修改后</td><td>" + odetail[133] + "</td><td>" + odetail[134] + "</td><td>" + odetail[135] + "</td><td>" + odetail[136] + "</td><td>" + odetail[146] + "</td></tr>";
        pmtxt_shipper += "</table>";


        Literal1.Text = "承运方" + odetail[102] + "修改了订单" + odetail[109] + "的运费信息<br/><br/>" + pmtxt_shipper + "<br/>以上修改等待您的确认！<br/><br/><a href=\"/search/order_edit_confirm.aspx?type=ok&orderid=" + orderid + "\">同意</a> <a href=\"/search/order_edit_confirm.aspx?type=cancel&orderid=" + orderid + "\">不同意</a>";

    }
}
