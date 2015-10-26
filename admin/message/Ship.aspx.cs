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
            DataSet ds = cn.mdb_ds("select * from TB_Ship where id=" + this.Request["id"].ToString(), "ship");
            txtTitle.Text = ds.Tables["ship"].Rows[0]["name_cn"].ToString();
            TextBox2.Text = ds.Tables["ship"].Rows[0]["name_cn_s"].ToString();
            TextBox3.Text = ds.Tables["ship"].Rows[0]["name_en"].ToString();
            TextBox4.Text = ds.Tables["ship"].Rows[0]["name_en_s"].ToString();
            TextBox5.Text = ds.Tables["ship"].Rows[0]["Website"].ToString();
            TextBox6.Text = ds.Tables["ship"].Rows[0]["cargotail"].ToString();
            TextBox7.Text = ds.Tables["ship"].Rows[0]["contact"].ToString().Replace("<br>", "\r");
            TextBox8.Text = ds.Tables["ship"].Rows[0]["introduction"].ToString().Replace("<br>", "\r");

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "update TB_Ship set name_cn='" + txtTitle.Text + "',name_cn_s='" + TextBox2.Text + "',name_en='" + TextBox3.Text + "',name_en_s='" + TextBox4.Text + "',Website='" + TextBox5.Text + "',cargotail='" + TextBox6.Text + "',contact='" + TextBox7.Text.Replace("\r", "<br>") + "',introduction='" + TextBox8.Text.Replace("\r", "<br>") + "' where id=" + this.Request["id"].ToString();
        
        cn.mdb_exe(sql);
        this.Response.Redirect("ShipList.aspx");
    }

}
