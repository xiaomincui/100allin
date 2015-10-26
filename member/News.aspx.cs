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

public partial class member_News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (this.Request.Cookies["user_id"] == null)
        {
            this.Response.Redirect("default.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value.ToString() == "")
            {
                this.Response.Redirect("default.aspx");
            }
            else
            {
                data_conn cn = new data_conn();
                DataSet ds = cn.mdb_ds("select * from TB_User where ifmanage=1 and Username='" + this.Request.Cookies["user_name"].Value.ToString() + "'", "manager");
                if (ds.Tables["manager"].Rows.Count == 0)
                {
                    this.Response.Redirect("default.aspx");
                }
            }
        }

        if (!IsPostBack)
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_BBS where id=" + this.Request["id"].ToString(), "news");
            Editor1.Text = ds.Tables["news"].Rows[0]["Data"].ToString();
            txtTitle.Text = ds.Tables["news"].Rows[0]["title"].ToString();
            DropDownList1.SelectedIndex = (int)ds.Tables["news"].Rows[0]["types"] - 5;
            TextBox1.Text = ds.Tables["news"].Rows[0]["Postdate"].ToString();
        }

        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "update TB_BBS set title='" + txtTitle.Text + "',Data='" + ck.CheckRecord(Editor1.Text) + "',EditDate=getdate(),Postdate='" + TextBox1.Text + "',UserID=381 where id=" + this.Request["id"].ToString();

        cn.mdb_exe(sql);
        //this.Response.Write(sql);
        this.Response.Redirect("NewList.aspx");
    }
}
