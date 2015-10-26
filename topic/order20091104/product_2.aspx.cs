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

public partial class topic_order20091104_product_2 : System.Web.UI.Page
{
    public AllinFreight AllinFreight1 = new AllinFreight();

    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        sql += "select * from tb_user where star_allin = 1";

        ds = cn.mdb_ds(sql,"order");

        DataList1.DataSource = ds.Tables["order"].DefaultView;
        DataList1.DataBind();


    }
}
