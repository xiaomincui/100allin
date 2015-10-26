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
using cn.com.webxml.www;

public partial class usercontrols_userloginhome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //检查密码的cookies
        if (this.Request.Cookies["user_password"] == null)
        {
            Response.Cookies["user_password"].Value = "";
            Response.Cookies["user_password"].Expires = DateTime.Now.AddDays(365);
        }
        
        
        //如果用户登陆信息正确，显示用户信息窗口及用户名
        if (this.Request.Cookies["user_id"] == null)
        {
            pnlHuiyuan.Visible = false;
            pnlChat.Visible = false;
            pnlDenglu.Visible = true;
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {
                pnlHuiyuan.Visible = false;
                pnlChat.Visible = false;
                pnlDenglu.Visible = true;
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

                loginTime();
                pnlHuiyuan.Visible = true;
                pnlChat.Visible = true;
                pnlDenglu.Visible = false;
                lblUserName.Text = Server.UrlDecode(this.Request.Cookies["user_name"].Value.ToString());
            }
        }

        //定义表单的提交方向
        ImageButton2.Attributes.Add("onclick", "document.getElementById('form1').target = '_self';");
        LinkButton1.Attributes.Add("onclick", "document.getElementById('form1').target = '_self';");

        //定义所有输入框按回车跳到下一格
        txtUsername.Attributes.Add("onkeydown", "KeyDown(event);");
        txtPassword.Attributes.Add("onkeydown", "KeyDown(event);");
        chkAutoLogin.Attributes.Add("onkeydown", "KeyDown(event);");

        try
        {
            LoadRage();
        }
        catch
        { 
        
        }
        
        //LoadBBS();
    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies["user_id"].Value = "";
        Response.Cookies["user_name"].Value = "";
        Response.Cookies["user_password"].Value = "";
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
            Response.Cookies["user_password"].Value = password;
            Response.Cookies["ifvip"].Value = ifvip;
            Response.Cookies["ifmanage"].Value = ifmanage;

            if (autologin == "1")
            {
                Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["user_name"].Expires = DateTime.Now.AddDays(365);
                Response.Cookies["user_password"].Expires = DateTime.Now.AddDays(365);
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

    protected void LoadRage()
    {
        //先查找数据库内的汇率更新时间,如果更新时间不是当天,则下载web服务上的汇率表

        string ntime = System.DateTime.Now.ToString("yyyy-MM-dd");
        double rate = 0;
        double rate2 = 0;

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "symbol,updatetime,baseprice ";
        sql = sql + "FROM ";
        sql = sql + "TB_RATE ";
        sql = sql + "WHERE ";
        sql = sql + "updatetime = '" + ntime + "'";

        ds = cn.mdb_ds(sql, "updatetime");

        if (ds.Tables["updatetime"].Rows.Count != 0)
        {
            for (int i = 0; i <= ds.Tables["updatetime"].Rows.Count - 1; i++)
            {
                if (ds.Tables["updatetime"].Rows[i]["symbol"].ToString() == "USD")
                {
                    rate = Convert.ToDouble(ds.Tables["updatetime"].Rows[i]["baseprice"].ToString()) / 100;
                    lblRate.Text = rate.ToString();
                }

                if (ds.Tables["updatetime"].Rows[i]["symbol"].ToString() == "XEU")
                {
                    rate2 = Convert.ToDouble(ds.Tables["updatetime"].Rows[i]["baseprice"].ToString()) / 100;
                    lblRate2.Text = rate2.ToString();
                }
            }
        }
        else
        {
            PickupRage();

            ds = cn.mdb_ds(sql, "updatetime");

            for (int i = 0; i <= ds.Tables["updatetime"].Rows.Count - 1; i++)
            {
                if (ds.Tables["updatetime"].Rows[i]["symbol"].ToString() == "USD")
                {
                    rate = Convert.ToDouble(ds.Tables["updatetime"].Rows[i]["baseprice"].ToString()) / 100;
                    lblRate.Text = rate.ToString();
                }

                if (ds.Tables["updatetime"].Rows[i]["symbol"].ToString() == "XEU")
                {
                    rate2 = Convert.ToDouble(ds.Tables["updatetime"].Rows[i]["baseprice"].ToString()) / 100;
                    lblRate2.Text = rate2.ToString();
                }
            }

        }

    }

    protected void PickupRage()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        ForexRmbRateWebService rmbrate = new ForexRmbRateWebService();
        DataSet dswebsvr = new DataSet();
        dswebsvr = rmbrate.getForexRmbRate();

        int dswebsvrcount = dswebsvr.Tables[0].Rows.Count - 1;

        for (int i = 0; i <= dswebsvrcount; i++)
        {
            string sqlinsert = "";
            sqlinsert = sqlinsert + "INSERT INTO ";
            sqlinsert = sqlinsert + "TB_RATE ";
            sqlinsert = sqlinsert + "( ";
            sqlinsert = sqlinsert + "Symbol, ";
            sqlinsert = sqlinsert + "Name, ";
            sqlinsert = sqlinsert + "mBuyPrice, ";
            sqlinsert = sqlinsert + "fBuyPrice, ";
            sqlinsert = sqlinsert + "SellPrice, ";
            sqlinsert = sqlinsert + "BasePrice, ";
            sqlinsert = sqlinsert + "updatetime ";
            sqlinsert = sqlinsert + ") ";
            sqlinsert = sqlinsert + "VALUES ";
            sqlinsert = sqlinsert + "( ";
            sqlinsert = sqlinsert + "'" + dswebsvr.Tables[0].Rows[i]["Symbol"].ToString() + "', ";
            sqlinsert = sqlinsert + "'" + dswebsvr.Tables[0].Rows[i]["Name"].ToString() + "', ";
            sqlinsert = sqlinsert + "'" + dswebsvr.Tables[0].Rows[i]["mBuyPrice"].ToString() + "', ";
            sqlinsert = sqlinsert + "'" + dswebsvr.Tables[0].Rows[i]["fBuyPrice"].ToString() + "', ";
            sqlinsert = sqlinsert + "'" + dswebsvr.Tables[0].Rows[i]["SellPrice"].ToString() + "', ";
            sqlinsert = sqlinsert + "'" + dswebsvr.Tables[0].Rows[i]["BasePrice"].ToString() + "', ";
            sqlinsert = sqlinsert + "'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' ";
            sqlinsert = sqlinsert + ") ";

            cn.mdb_exe(sqlinsert);
        }

    }

}
