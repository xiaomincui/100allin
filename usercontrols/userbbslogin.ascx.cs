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

public partial class usercontrols_userbbslogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            checklogin();
        }
    }

    public void checklogin()
    {
        //如果用户登陆信息正确，显示用户信息窗口及用户名
        if (this.Request.Cookies["user_id"] == null)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
        }
        else
        {

            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";

            sql = sql + "SELECT ";
            sql = sql + "Userpassword ";
            sql = sql + "FROM ";
            sql = sql + "TB_User ";
            sql = sql + "WHERE ";
            sql = sql + "UserID = '" + this.Request.Cookies["user_id"].Value.ToString() + "' ";

            ds = cn.mdb_ds(sql, "user");

            if (ds.Tables["user"].Rows.Count > 0)
            {
                Response.Cookies["user_password"].Value = ds.Tables["user"].Rows[0][0].ToString();

            }

            if (this.Request.Cookies["user_id"].Value == "")
            {
                Panel2.Visible = false;
                Panel1.Visible = true;
            }
            else
            {
                Panel2.Visible = true;
                Panel1.Visible = false;
                Label1.Text = Server.UrlDecode(this.Request.Cookies["user_name"].Value.ToString());


                if (System.IO.File.Exists(Server.MapPath("/member/Head/" + this.Request.Cookies["user_id"].Value + ".jpg")))
                {
                    imghead.Src = "/member/Head/" + this.Request.Cookies["user_id"].Value + ".jpg";
                }
                else
                {
                    imghead.Src = "/member/Head/default.jpg";
                }
            }
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
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
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('未填写用户名和密码')", true);
        }
        else
        {
            if (username == "")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('未填写用户名')", true);
            }
            if (password == "")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('未填写密码')", true);
            }
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "UserID,username,ifvip,ifmanage,realname,companyname,phone,useremail,CompanyType ";
        sql = sql + "FROM ";
        sql = sql + "TB_User ";
        sql = sql + "WHERE ";
        sql = sql + "UserName = '" + username + "' ";
        sql = sql + "AND UserPassword = '" + password + "' ";

        ds = cn.mdb_ds(sql, "user");

        if (ds.Tables["user"].Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('登录成功')", true);
            //System.Threading.Thread.Sleep(1000);
            //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "document.write(\"script src='/home/newlogin.php'></script>\")", true);
            string userid = ds.Tables["user"].Rows[0][0].ToString();
            string usernm = ds.Tables["user"].Rows[0][1].ToString();
            string ifvip = ds.Tables["user"].Rows[0]["ifvip"].ToString();
            string ifmanage = ds.Tables["user"].Rows[0]["ifmanage"].ToString();

            Response.Cookies["user_id"].Value = userid;
            Response.Cookies["user_name"].Value = Server.UrlEncode(usernm);
            Response.Cookies["user_password"].Value = password;
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
                Response.Cookies["user_password"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["ifvip"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["ifmanage"].Expires = DateTime.Now.AddDays(365);

                Response.Cookies["realname"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["companyname"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["phone"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["useremail"].Expires = DateTime.Now.AddDays(365);
            }
            Panel2.Visible = true;
            Panel1.Visible = false;

            Label1.Text = username;

            if (System.IO.File.Exists(Server.MapPath("/member/Head/" + userid + ".jpg")))
            {
                imghead.Src = "/member/Head/" + userid + ".jpg";
            }
            else
            {
                imghead.Src = "/member/Head/default.jpg";
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('对不起，用户名或密码填写错误')", true);
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('您已安全退出')", true);
        Response.Cookies["user_id"].Value = "";
        Response.Cookies["user_name"].Value = "";
        Response.Cookies["user_password"].Value = "";
        Response.Cookies["realname"].Value = "";
        Response.Cookies["companyname"].Value = "";
        Response.Cookies["phone"].Value = "";
        Response.Cookies["useremail"].Value = "";
        Panel2.Visible = false;
        Panel1.Visible = true;
    }
}
