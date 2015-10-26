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

public partial class usercontrols_userlinkbottom4 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadLinks();
    }

    protected void LoadLinks()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = "select * from TB_LINK where types = 8";

        ds = cn.mdb_ds(sql, "link");

        Repeater1.DataSource = ds.Tables["link"].DefaultView;
        Repeater1.DataBind();
    }
}
