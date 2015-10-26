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

public partial class member_order_order_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string orderid = ck.CheckInput(GetRequestQueryString("orderid", ""));

        string sql = "";
        sql = "";
        sql += "SELECT * FROM TB_ORDER WHERE order_code = '" + orderid + "'";
        ds = cn.mdb_ds(sql, "order");

        string order_type_string = "";
        switch (ds.Tables["order"].Rows[0]["freight_type"].ToString())
        {
            case "8":
                order_type_string = "fcl";
                break;
            case "9":
                order_type_string = "lcl";
                break;
            case "10":
                order_type_string = "air";
                break;
            default:
                break;
        }//获得订单类型


        Response.Redirect("/search/" + order_type_string + "_order.aspx?filter=view&role=forward&orderid=" + orderid);
    }

    public string GetRequestQueryString(string q, string d)
    {
        string outputstring = d;
        if (Request.QueryString[q] != null)
        {
            if (Request.QueryString[q].ToString() != "")
            {
                outputstring = Request.QueryString[q].ToString();
            }
        }
        return outputstring;
    }//获得网页字符串参数

    public string GetRequestCookies(string c, string d)
    {
        string outputstring = d;
        if (Request.Cookies[c] != null)
        {
            if (Request.Cookies[c].Value.ToString() != "")
            {
                outputstring = Request.Cookies[c].Value.ToString();
            }
        }
        return outputstring;
    }//获得指定Cookies参数
}
