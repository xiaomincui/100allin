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

public partial class usercontrols_userloginchat : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //如果用户登陆信息正确，显示用户信息窗口及用户名
        if (this.Request.Cookies["user_id"] == null)
        {
            pnlHuiyuan.Visible = false;
            pnlDenglu.Visible = true;
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {
                pnlHuiyuan.Visible = false;
                pnlDenglu.Visible = true;
            }
            else
            {
                if (Page.IsPostBack != true)
                {
                    loginTime();
                }
                pnlHuiyuan.Visible = true;
                pnlDenglu.Visible = false;
                lblUserName.Text = Server.UrlDecode(this.Request.Cookies["user_name"].Value.ToString());
            }
        }



        //定义所有输入框按回车跳到下一格
        txtUsername.Attributes.Add("onkeydown", "KeyDown(event);");
        txtPassword.Attributes.Add("onkeydown", "KeyDown(event);");
        chkAutoLogin.Attributes.Add("onkeydown", "KeyDown(event);");
    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies["user_id"].Value = "";
        Response.Cookies["user_name"].Value = "";
        Response.Redirect(lblUrl.Value.ToString());
    }


    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        check ck = new check();
        string username = ck.CheckInput(txtUsername.Text);
        string password = ck.CheckInput(txtPassword.Text);
        string autologin = "1";

        if (chkAutoLogin.Checked == true)
        {
            autologin = "1";
        }
        else
        {
            autologin = "0";
        }

        if (username == "" && password == "")
        {
            MessageBox("opfail", "未填写用户名和密码");
        }
        else
        {
            if (username == "")
            {
                MessageBox("opfail", "未填写用户名");
            }
            if (password == "")
            {
                MessageBox("opfail", "未填写密码");
            }
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "UserID,UserName,ifvip,ifmanage ";
        sql = sql + "FROM ";
        sql = sql + "TB_User ";
        sql = sql + "WHERE ";
        sql = sql + "UserName = '" + username + "' ";
        sql = sql + "AND UserPassword = '" + password + "' ";

        ds = cn.mdb_ds(sql, "user");

        if (ds.Tables["user"].Rows.Count > 0)
        {
            string userid = ds.Tables["user"].Rows[0][0].ToString();
            string usernm = ds.Tables["user"].Rows[0][1].ToString();
            string ifvip = ds.Tables["user"].Rows[0]["ifvip"].ToString();
            string ifmanage = ds.Tables["user"].Rows[0]["ifmanage"].ToString();

            Response.Cookies["user_id"].Value = userid;
            Response.Cookies["user_name"].Value = Server.UrlEncode(usernm);
            Response.Cookies["ifvip"].Value = ifvip;
            Response.Cookies["ifmanage"].Value = ifmanage;

            if (autologin == "1")
            {
                Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["user_name"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["ifvip"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["ifmanage"].Expires = DateTime.Now.AddDays(365);
            }
            Response.Redirect(lblUrl.Value.ToString());

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

    protected void loginTime()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "UPDATE ";
        sql = sql + "TB_User ";
        sql = sql + "SET ";
        sql = sql + "CurrentLogin = '" + DateTime.Now.ToString() + "', ";
        sql = sql + "LastLogin = CurrentLogin ";
        sql = sql + "WHERE UserID = " + this.Request.Cookies["user_id"].Value.ToString();

        cn.mdb_exe(sql);
    }
}
