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
        //string username = FormsAuthentication.HashPasswordForStoringInConfigFile(ck.CheckInput(txtName.Text.ToString()), "MD5");
        //string password = FormsAuthentication.HashPasswordForStoringInConfigFile(ck.CheckInput(txtPass.Text.ToString()), "MD5");
        string username = ck.CheckInput(txtName.Text.ToString());
        string password = ck.CheckInput(txtPass.Text.ToString());
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //定义SQL语句，查询某一用户发布的3种运价及货盘各自的总数
        sql = sql + "SELECT * FROM TB_ADMIN_ACCOUNT ";
        sql = sql + "WHERE aname = '" + username + "' ";
        sql = sql + "AND apassword = '" + password + "' ";
        ds = cn.mdb_ds(sql, "count");

        if (ds.Tables["count"].Rows.Count > 0)
        {
            Response.Cookies["admin"].Value = "yes";
            Response.Cookies["admin_id"].Value = ds.Tables["count"].Rows[0]["aid"].ToString();
            Response.Cookies["admin_group"].Value = Server.UrlEncode(ds.Tables["count"].Rows[0]["agroup"].ToString());
            Response.Cookies["admin_name"].Value = Server.UrlEncode(ds.Tables["count"].Rows[0]["aname"].ToString());
            Response.Redirect("/admin/");
        }
        else 
        {
            Response.Cookies["admin"].Value = "no";
            Response.Redirect("/admin/");
            MessageBox("error", "用户名或密码错误");
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
