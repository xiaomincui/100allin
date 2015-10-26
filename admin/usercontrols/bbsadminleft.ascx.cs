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

public partial class admin_usercontrols_adminleft : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //如果用户登陆信息正确，显示管理页面
        if (this.Request.Cookies["bbsadmin"] == null)
        {
            Server.Transfer("/bbsmessage/login.aspx");
        }
        else
        {
            if (this.Request.Cookies["bbsadmin"].Value == "yes")
            {
                data_conn cn = new data_conn();
                DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies["bbsadmin_id"].Value, "user");
                
                LitName.Text = ds.Tables["user"].Rows[0]["UserName"].ToString();
            }
            else
            {
                Server.Transfer("/bbsmessage/login.aspx");
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies["bbsadmin"].Value = "";
        Response.Cookies["bbsadmin_id"].Value = "";
        Response.Redirect("/bbsmessage/login.aspx");
    }
}
