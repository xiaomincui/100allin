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

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        check ck = new check();

        data_conn bbscn = new data_conn();
        DataSet bbsds = new DataSet();
        string bbssql = "select * from TB_User,TB_BBSLevel where TB_User.UserID=TB_BBSLevel.UserID and UserName='" + ck.CheckInput(txtName.Text.ToString()) + "' and UserPassword='" + ck.CheckInput(txtPass.Text.ToString()) + "'";
        bbsds = bbscn.mdb_ds(bbssql, "bbsuser");
        if (bbsds.Tables["bbsuser"].Rows.Count > 0)
        {
            Response.Cookies["bbsadmin"].Value = "yes";

            Response.Cookies["bbsadmin_id"].Value = bbsds.Tables["bbsuser"].Rows[0]["UserID"].ToString();
            //Response.Cookies["user_name"].Value = Server.UrlEncode(usernm);

            //Response.Cookies["bbslevel"].Value = bbsds.Tables["bbsuser"].Rows[0]["bbsadmin"].ToString();
            Response.Redirect("/bbsmessage/BBSadminList.aspx");
        }
        else
        {
            //Response.Cookies["bbsadmin"].Value = "no";
            //Response.Redirect("/admin/bbsadmin/BBSadminList.aspx");
            //MessageBox("error", "用户名或密码错误");
        }



        
    }

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }
}
