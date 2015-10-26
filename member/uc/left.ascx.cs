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

public partial class member_uc_left : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        string u = "0";
        string sql = "";
        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        if (u == "8299" | u == "9089")
        {
            PlaceHolder1.Visible = true;
        }
        else
        {
            PlaceHolder1.Visible = false;
        }

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();


        //显示未读消息
        sql = "select count(mid) as count from TB_PM where readed = 0 and listener = " + u;

        ds = cn.mdb_ds(sql, "tb_pm");

        ltrPm.Text = ds.Tables["tb_pm"].Rows[0]["count"].ToString();

        sql = "select count(oid) as count from TB_ORDER where (order_status = 2 or order_status = 4) and order_forward = " + u;

        ds = cn.mdb_ds(sql, "TB_ORDER");

        ltrNewBooking.Text = ds.Tables["TB_ORDER"].Rows[0]["count"].ToString();

    }

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
