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

public partial class admin_newyear2011_edit : System.Web.UI.Page
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

        sql = sql + "select * from TB_NEWYEARMERRY2011 where nid = " + Request.QueryString["id"].ToString();

        ds = cn.mdb_ds(sql, "zhufu");
        txt_companyname.Text = ds.Tables["zhufu"].Rows[0]["companyname"].ToString();
        txt_zhufu.Text = ds.Tables["zhufu"].Rows[0]["zhufu"].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check check1 = new check();
        data_conn cn = new data_conn();
        string sql = "";

        sql = sql + "update TB_NEWYEARMERRY2011 set ";
        sql = sql + "companyname = '" + check1.CheckInput(txt_companyname.Text) + "', ";
        sql = sql + "zhufu = '" + check1.CheckInput(txt_zhufu.Text) + "' ";
        sql = sql + "where nid = " + Request.QueryString["id"].ToString();

        cn.mdb_exe(sql);


        Response.Redirect("list.aspx");
    }
}
