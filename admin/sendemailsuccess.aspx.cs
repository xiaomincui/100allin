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

public partial class admin_sendemailsuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";
        sql = "";
        sql = sql + "SELECT '共有' AS n, COUNT(*) AS c ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (importtype = 1) ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '发送成功' AS n, COUNT(*) AS c ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (importtype = 1) AND (advemailsuccess = '成功') ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '还需发送' AS n, COUNT(*) AS c ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (importtype = 1) AND (advemailsuccess = '') ";
        sql = sql + "UNION ALL ";
        sql = sql + "SELECT '发送失败' AS n, COUNT(*) AS c ";
        sql = sql + "FROM TB_User ";
        sql = sql + "WHERE (importtype = 1) AND (advemailsuccess = '失败') ";


        ds = cn.mdb_ds(sql, "count");




        GridView1.DataSource = ds.Tables["count"].DefaultView;
        GridView1.DataBind();
    }
}
