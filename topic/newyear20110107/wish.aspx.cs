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

public partial class topic_newyear20110107_wish : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            check check1 = new check();
            GetRequest GetRequest1 = new GetRequest();
            string user_id = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";

            if (user_id != "0")
            {
                sql = sql + "SELECT ";
                sql = sql + "UserID,username,ifvip,ifmanage,realname,companyname,phone,useremail ";
                sql = sql + "FROM ";
                sql = sql + "TB_User ";
                sql = sql + "WHERE ";
                sql = sql + "userid = " + user_id + " ";

                ds = cn.mdb_ds(sql, "user");

                Text1.Value = ds.Tables["user"].Rows[0]["companyname"].ToString();

            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();
        string user_id = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));
        string zhufu = check1.CheckRecord(TEXTAREA1.Value);
        string companyname = check1.CheckRecord(Text1.Value);

        data_conn cn = new data_conn();
        string sql = "";
        sql = sql + "INSERT INTO ";
        sql = sql + "TB_NEWYEARMERRY2011 ";
        sql = sql + "(companyname,zhufu,userid) ";
        sql = sql + "VALUES ";
        sql = sql + "('" + companyname + "','" + zhufu + "'," + user_id + ") ";

        cn.mdb_exe(sql);

        Response.Redirect("default.aspx?success=1");
    }
}
