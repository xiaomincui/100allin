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

public partial class admin_baf_bafedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LoadBAF();
        }
    }

    protected void LoadBAF()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "* ";
        sql = sql + "FROM ";
        sql = sql + "TB_File ";
        sql = sql + "WHERE ";
        sql = sql + "ID=298 ";

        ds = cn.mdb_ds(sql, "baf");

        myTextArea.Value = ds.Tables["baf"].Rows[0]["Content"].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        string sql = "";

        sql = sql + "UPDATE ";
        sql = sql + "TB_File ";
        sql = sql + "SET ";
        sql = sql + "Content = '" + myTextArea.Value.ToString() + "' ";
        sql = sql + "WHERE ";
        sql = sql + "ID=298 ";

        cn.mdb_exe(sql);
    }
}
