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

public partial class admin_hotport_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            LoadRecord();
        }
    }

    protected void LoadRecord()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";
        sql = sql + "select * from TB_HOT_PORT where hid = " + Request.QueryString["id"].ToString();
        ds = cn.mdb_ds(sql, "zhufu");
        txt_startport.Text = ds.Tables["zhufu"].Rows[0]["startport"].ToString();
        txt_destport.Text = ds.Tables["zhufu"].Rows[0]["destport"].ToString();
        txt_htype.Text = ds.Tables["zhufu"].Rows[0]["htype"].ToString();
        txt_horder.Text = ds.Tables["zhufu"].Rows[0]["horder"].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check check1 = new check();
        data_conn cn = new data_conn();
        string sql = "";
        sql = sql + "update TB_HOT_PORT set ";
        sql = sql + "startport = '" + check1.CheckInput(txt_startport.Text) + "', ";
        sql = sql + "destport = '" + check1.CheckInput(txt_destport.Text) + "', ";
        sql = sql + "htype = " + check1.CheckInput(txt_htype.Text) + ", ";
        sql = sql + "horder = " + check1.CheckInput(txt_horder.Text) + " ";
        sql = sql + "where hid = " + Request.QueryString["id"].ToString();
        cn.mdb_exe(sql);

        Response.Redirect("list.aspx");
    }
}
