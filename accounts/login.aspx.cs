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

public partial class accounts_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.ServerVariables["HTTP_REFERER"] != null)
            {
                if (Request.QueryString["redirect_url"] == null)
                {
                    Response.Redirect("login.aspx?redirect_url=" + Server.UrlEncode(Request.ServerVariables["HTTP_REFERER"].ToString()));

                }
                else
                {
                    if (Request.QueryString["redirect_url"] == "")
                    {
                        Response.Redirect("login.aspx?redirect_url=" + Server.UrlEncode(Request.ServerVariables["HTTP_REFERER"].ToString()));
                    }
                }
            }        
        }
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        string username1 = ck.CheckInput(username.Value);
        string password1 = ck.CheckInput(password.Value);
        string autologin = "1";

        //if (chkAutoLogin.Checked == true)
        //{
        //    autologin = "1";
        //}
        //else
        //{
        //    autologin = "0";
        //}

        if (username1 == "" && password1 == "")
        {
            MessageBox("opfail", "未填写用户名和密码");
        }
        else
        {
            if (username1 == "")
            {
                MessageBox("opfail", "未填写用户名");
            }
            if (password1 == "")
            {
                MessageBox("opfail", "未填写密码");
            }
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "UserID,username,ifvip,ifmanage,realname,companyname,phone,useremail ";
        sql = sql + "FROM ";
        sql = sql + "TB_User ";
        sql = sql + "WHERE ";
        sql = sql + "username = '" + username1 + "' ";
        sql = sql + "AND Userpassword = '" + password1 + "' ";

        ds = cn.mdb_ds(sql, "user");

        if (ds.Tables["user"].Rows.Count > 0)
        {
            string userid = ds.Tables["user"].Rows[0][0].ToString();
            string usernm = ds.Tables["user"].Rows[0][1].ToString();
            string ifvip = ds.Tables["user"].Rows[0]["ifvip"].ToString();
            string ifmanage = ds.Tables["user"].Rows[0]["ifmanage"].ToString();

            Response.Cookies["user_id"].Value = userid;
            Response.Cookies["user_name"].Value = Server.UrlEncode(usernm);
            Response.Cookies["user_password1"].Value = password1;
            Response.Cookies["ifvip"].Value = ifvip;
            Response.Cookies["ifmanage"].Value = ifmanage;

            string realname = ds.Tables["user"].Rows[0]["realname"].ToString();
            string companyname = ds.Tables["user"].Rows[0]["companyname"].ToString();
            string phone = ds.Tables["user"].Rows[0]["phone"].ToString();
            string useremail = ds.Tables["user"].Rows[0]["useremail"].ToString();

            Response.Cookies["realname"].Value = Server.UrlEncode(realname);
            Response.Cookies["companyname"].Value = Server.UrlEncode(companyname);
            Response.Cookies["phone"].Value = Server.UrlEncode(phone);
            Response.Cookies["useremail"].Value = Server.UrlEncode(useremail);

            if (autologin == "1")
            {
                Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["user_name"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["user_password1"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["ifvip"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["ifmanage"].Expires = DateTime.Now.AddDays(365);

                Response.Cookies["realname"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["companyname"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["phone"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["useremail"].Expires = DateTime.Now.AddDays(365);
            }


            if (Request.QueryString["redirect_url"] == null)
            {
                Response.Redirect("/");   
            }
            if (Request.QueryString["redirect_url"] == "")
            {
                Response.Redirect("/");
            }
           
            Response.Redirect(Server.UrlDecode(Request.QueryString["redirect_url"]));
        }
        else
        {
            MessageBox("opfail", "用户名或密码填写错误");
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
