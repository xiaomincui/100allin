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

public partial class member_order_pay_bank : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        string sql = "";
        sql += "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + u;

        ds = cn.mdb_ds(sql, "account");

        ltrCredits.Text = ds.Tables["account"].Rows[0]["credit"].ToString();
        ltrOverage.Text = ds.Tables["account"].Rows[0]["overage"].ToString();
        if (Convert.ToDouble(ltrOverage.Text) <= 1000)
        {
            ltrResultTip.Text = "您的预存费余额不足，为了保证您的正常业务，请立即充值";
        }
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
