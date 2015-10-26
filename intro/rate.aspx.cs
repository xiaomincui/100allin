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

public partial class intro_rate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "rate ";
        sql = sql + "FROM ";
        sql = sql + "TB_NEWRATE ORDER BY RID DESC";

        ds = cn.mdb_ds(sql, "rate");

        if (ds.Tables["rate"].Rows.Count > 0)
        {
            Label2.Text = ds.Tables["rate"].Rows[0][0].ToString();
        }
        
    }
}
