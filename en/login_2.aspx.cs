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

public partial class en_login_2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies["user_id"].Value.ToString(), "user");

        Literal1.Text = ds.Tables["user"].Rows[0]["UserName"].ToString();
        Literal2.Text = ds.Tables["user"].Rows[0]["UserPassword"].ToString();
    }
}
