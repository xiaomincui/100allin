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

public partial class herocean_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql;


        sql = "select ";
        sql = sql + "id,yunjiainfoid as did,yunjiaid as sid,destport,price20gp,price40gp,price40hq,price45hq,shipcompany,postdatex ";
        sql = sql + "from  ";
        sql = sql + "TB_YunjiaInfo_Effective_8 ";
        sql = sql + "where useridx = 117726 ";
        sql = sql + "order by postdatex desc ";

        ds = cn.mdb_ds(sql, "yunjia");
        Repeater1.DataSource = ds.Tables["yunjia"].DefaultView;
        Repeater1.DataBind();
    }
}
