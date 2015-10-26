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
            DataSet ds = cn.mdb_ds("select * from TB_BBS where id=" + this.Request["id"].ToString(), "news");
            content1.Value = ds.Tables["news"].Rows[0]["Data"].ToString();
            txtTitle.Text = ds.Tables["news"].Rows[0]["title"].ToString();
            DropDownList1.SelectedValue = ds.Tables["news"].Rows[0]["types"].ToString();
            BasicDatePicker1_TextBox.Value = Convert.ToDateTime(ds.Tables["news"].Rows[0]["Postdate"].ToString()).ToString("yyyy-MM-dd");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "update TB_BBS set title='" + txtTitle.Text + "',Data='" + ck.CheckRecord(content1.Value) + "',EditDate=getdate(),Postdate='" + BasicDatePicker1_TextBox.Value + "',types = " + DropDownList1.SelectedValue.ToString() + ",UserID=41 where id=" + this.Request["id"].ToString();
        
        cn.mdb_exe(sql);
        //this.Response.Write(sql);
        this.Response.Redirect("NewList.aspx");
    }

}
