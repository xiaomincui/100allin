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

public partial class admin_message_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_Exhibition where id=" + this.Request["id"].ToString(), "Exhibition");
            Editor1.Text = ds.Tables["Exhibition"].Rows[0]["detail"].ToString();
            txtTitle.Text = ds.Tables["Exhibition"].Rows[0]["title"].ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Label1.Text = Editor1.Text;
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "update TB_Exhibition set title='" + txtTitle.Text + "',detail='" + ck.CheckRecord(Editor1.Text) + "',PostDate=getdate() where id=" + this.Request["id"].ToString();
        //this.Response.Write(sql);
        cn.mdb_exe(sql);

        this.Response.Redirect("ExhibitionList.aspx");
    }
}

