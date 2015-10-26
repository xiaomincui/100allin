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

public partial class member_uc_welcome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        string u = "0";

        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        sql = "SELECT Realname FROM TB_User WHERE userid = " + u;

        ds = cn.mdb_ds(sql, "tb_user");


        ltrMyName.Text = ds.Tables["tb_user"].Rows[0][0].ToString();



        //显示未读消息
        sql = "select count(mid) as count from TB_PM where readed = 0 and listener = " + u;

        ds = cn.mdb_ds(sql, "tb_pm");

        ltrPm.Text = ds.Tables["tb_pm"].Rows[0]["count"].ToString();
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


    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
