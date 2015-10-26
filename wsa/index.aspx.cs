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

public partial class wsa_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        string sql = "SELECT distinct yunjiaid,destport FROM TB_yunjiainfo WHERE yunjiaid = (select top 1 id from TB_Yunjia WHERE userid = 74973 order by id desc) ORDER BY destport ";
        DataSet ds = cn.mdb_ds(sql, "waysyunjia");
        Repeater1.DataSource = ds.Tables["waysyunjia"].DefaultView;
        Repeater1.DataBind();
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
