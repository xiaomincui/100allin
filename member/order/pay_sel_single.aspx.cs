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

public partial class member_order_pay_sel_single : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();


        orderid.Value = ck.CheckInput(GetRequestQueryString("orderid", "0"));

        string sql = "";

        sql += "SELECT * FROM TB_ORDER,TB_ORDER_STATUS WHERE TB_ORDER.order_status = TB_ORDER_STATUS.sid AND order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";


        ds = cn.mdb_ds(sql, "order");


        string order_type_string = "fcl";


        double base_fee = 0;

        base_fee = Convert.ToDouble(ds.Tables["order"].Rows[0]["xxf"].ToString());
        Literal1.Text = (base_fee * 4).ToString();
        Literal2.Text = (base_fee * 3).ToString();

        string u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        sql = "SELECT * FROM TB_USER,TB_ORDER_ACCOUNT WHERE TB_USER.userid = TB_ORDER_ACCOUNT.userid AND TB_ORDER_ACCOUNT.userid = " + u;

        ds = cn.mdb_ds(sql, "account");

        ltrCredits.Text = ds.Tables["account"].Rows[0]["credit"].ToString();
        ltrOverage.Text = ds.Tables["account"].Rows[0]["overage"].ToString();
        if (Convert.ToDouble(ltrOverage.Text) <= 1000)
        {
            ltrResultTip.Text = "您的预存费余额不足，为了保证您的正常业务，请立即充值";
        }

        TextBox1.Text = ds.Tables["account"].Rows[0]["ali_account"].ToString();
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
                data_conn cd1 = new data_conn();
            }
        }
        return outputstring;
    }//获得指定Cookies参数


}
