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

public partial class member_AddNew : System.Web.UI.Page
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
            TextBox1.Text = DateTime.Now.ToString();
        }

        if (this.Request.Cookies["user_id"] == null)
        {

            Response.Cookies["url"].Value = Request.Url.ToString();
            this.Response.Redirect("../member/reg.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value.ToString() == "")
            {
                Response.Cookies["url"].Value = Request.Url.ToString();
                this.Response.Redirect("../member/reg.aspx");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Label1.Text = Editor1.Text;
        check ck = new check();

        data_conn cn = new data_conn();
        string sql = "insert into TB_BBS (title,UserID,Data,PostDate,hits,UpdateDate,types) values ('" + txtTitle.Text + "',41,'" + ck.CheckRecord(Editor1.Text) + "','" + TextBox1.Text + "',0,getdate(),5)";
        //this.Response.Write(sql);
        cn.mdb_exe(sql);

        this.Response.Redirect("NewList.aspx");
    }
}
