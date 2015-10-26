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
        //Editor1.Text = "asdfasf";
        //txtTitle.Text = "asdfasdf";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Label1.Text = Editor1.Text;
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "insert into TB_Exhibition (title,detail,PostDate) values ('" + txtTitle.Text + "','" + ck.CheckRecord(Editor1.Text) + "',getdate())";
        //this.Response.Write(sql);
        cn.mdb_exe(sql);

        this.Response.Redirect("ExhibitionList.aspx");
    }
}

