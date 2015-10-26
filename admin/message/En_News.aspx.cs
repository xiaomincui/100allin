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

public partial class admin_message_News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_En_News where id=" + this.Request["id"].ToString(), "news");
            Editor1.Text = ds.Tables["news"].Rows[0]["content"].ToString();
            txtTitle.Text = ds.Tables["news"].Rows[0]["title"].ToString();
            TextBox1.Text = ds.Tables["news"].Rows[0]["Postdate"].ToString();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "update TB_En_News set title='" + txtTitle.Text + "',content='" + ck.CheckRecord(Editor1.Text) + "',Postdate='" + TextBox1.Text + "' where id=" + this.Request["id"].ToString();
        
        cn.mdb_exe(sql);
        this.Response.Redirect("En_NewList.aspx");
    }

}
