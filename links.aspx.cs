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

public partial class links : System.Web.UI.Page
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

        sql = "select * from TB_LINK where types = 2";

        ds = cn.mdb_ds(sql, "link");

        DataList1.DataSource = ds.Tables["link"].DefaultView;
        DataList1.DataBind();


        sql = "select * from TB_LINK where types = 3";

        ds = cn.mdb_ds(sql, "link");

        DataList2.DataSource = ds.Tables["link"].DefaultView;
        DataList2.DataBind();


        sql = "select * from TB_LINK where types = 4";

        ds = cn.mdb_ds(sql, "link");

        DataList3.DataSource = ds.Tables["link"].DefaultView;
        DataList3.DataBind();
    }
}

