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

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        sql_conn cn = new sql_conn();
        DataSet ds = new DataSet();
        ds = cn.dataset("select top 1 * from tb_user");

        Response.Write(ds.Tables[0].Rows[0][0].ToString());
    }
}
