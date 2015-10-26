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


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();

        string sql = "insert into TB_Ship (name_cn,name_cn_s,name_en,name_en_s,Website,cargotail,contact,introduction) values ('" + txtTitle.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text.Replace("\r", "<br>") + "','" + TextBox8.Text.Replace("\r", "<br>") + "')";

        cn.mdb_exe(sql);
        this.Response.Redirect("ShipList.aspx");
    }

}
