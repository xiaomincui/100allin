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
        if (!IsPostBack)
        {
            TextBox1.Text = DateTime.Now.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Label1.Text = Editor1.Text;
        check ck = new check();
        
        data_conn cn = new data_conn();
        string sql = "insert into TB_En_News (title,content,PostDate) values ('" + txtTitle.Text + "','" + ck.CheckRecord(Editor1.Text) + "','" + TextBox1.Text + "')";
        //this.Response.Write(sql);
        cn.mdb_exe(sql);

        this.Response.Redirect("En_NewList.aspx");
    }
}

