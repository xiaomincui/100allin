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

public partial class member_feed_friend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        string u = "0";

        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        sql = "";

        sql = "SELECT UCenterHomeUid FROM TB_User WHERE userid = " + u;

        //Response.Write(sql);

        ds = cn.mdb_ds(sql, "tb_user");

        string uid = "0";

        uid = ds.Tables["tb_user"].Rows[0][0].ToString();

        mysqldata_conn mysqlcn = new mysqldata_conn();

        //以下为获得“我的好友”
        sql = "SELECT friendid FROM uc_friends WHERE uid = " + uid;

        ds = mysqlcn.mdb_ds(sql, "uc_friends");


        string uidlist = "";

        for (int i = 0; i < ds.Tables["uc_friends"].Rows.Count; i++)
        {
            if (uid != "")
            {
                uidlist += ds.Tables["uc_friends"].Rows[i][0].ToString() + ",";
            }

        }

        uidlist += "0";

        sql = "SELECT TOP 8 * FROM V_SHOW_ALL WHERE UCenterHomeUid in (" + uidlist + ") ORDER BY POSTDATE DESC";

        ds = cn.mdb_ds(sql, "myfriends");


        Repeater1.DataSource = ds.Tables["myfriends"].DefaultView;
        Repeater1.DataBind();
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
