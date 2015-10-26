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
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

public partial class topic_order20091104_try : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AllinOrder AllinOrder1 = new AllinOrder();
            GetRequest GetRequest1 = new GetRequest();

            string u = GetRequest1.GetRequestCookies("user_id", "0");

            if (u == "0")
            {

            }
            else
            {
                if (AllinOrder1.GetOrderTry(u) == "success")
                {
                    Response.Redirect("tryalready.aspx");
                }
                else
                {
                    AllinOrder1.SetOrderTry(u);
                    Response.Redirect("trysuccess.aspx");
                }

            }
        }

    }


   


    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        string username = ck.CheckInput(txtUsername.Value);
        string password = ck.CheckInput(txtPassword.Value);
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

            AllinOrder AllinOrder1 = new AllinOrder();
            GetRequest GetRequest1 = new GetRequest();

            string u = GetRequest1.GetRequestCookies("user_id", "0");

            if (AllinOrder1.GetOrderTry(u) == "success")
            {
                Response.Redirect("tryalready.aspx");
            }
            else
            {
                AllinOrder1.SetOrderTry(u);
                Response.Redirect("trysuccess.aspx");
            }

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

    public static bool isEmail(string inputEmail)
    {
        
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputEmail))
            return (true);
        else
            return (false);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "";
        sql = sql + "select * ";
        sql = sql + "from TB_User ";
        sql = sql + "where UserName = '" + ck.CheckInput(UserName.Value) + "'";
        DataSet ds = new DataSet();
        ds = cn.mdb_ds(sql, "T_User");

        if (ds.Tables["T_User"].Rows.Count > 0)
        {
            MessageBox("opfail", "用户名已有人使用");
            return;
        }
        else if (UserPassword.Value.Length < 6 || UserPassword.Value.Length > 15)
        {
            MessageBox("opfail", "密码长度必须在6～15个字符之间");
            return;
        }
        else if (Company.Value == "" || RealName.Value == "" || Phone.Value == "" || UserEmail.Value == "")
        {
            MessageBox("opfail", "必填项不能为空");
            return;
        }
        else if (!isEmail(UserEmail.Value))
        {
            MessageBox("opfail", "邮箱格式不正确");
            return;
        }
        else if (UserPassword.Value != UserPassword2.Value)
        {
            MessageBox("opfail", "2次密码不一致");
            return;
        }
        else if (!Checkbox1.Checked)
        {

            MessageBox("opfail", "请仔细阅读并同意服务条款");
            return;
        }







        string recommendUserID;
        if (this.Request.Cookies["recommendUserID"] == null)
        {
            recommendUserID = "0";
        }
        else
        {
            if (this.Request.Cookies["recommendUserID"].Value == "")
            {
                recommendUserID = "0";
            }
            else
            {
                recommendUserID = Request.Cookies["recommendUserID"].Value;
            }
        }

        if (this.Request.Cookies["UID"] == null)
        {

        }
        else
        {
            if (Request.Cookies["UID"].Value == "")
            {

            }
            else
            {
                data_conn Uidcn = new data_conn();
                DataSet Uidds = Uidcn.mdb_ds("select UserID from TB_User where UCenterHomeUid=" + Request.Cookies["UID"].Value, "uid");
                if (Uidds.Tables["uid"].Rows.Count == 1)
                {
                    recommendUserID = Uidds.Tables["uid"].Rows[0][0].ToString();
                    mysqldata_conn mycn = new mysqldata_conn();
                    mycn.mdb_exe("update uchome_space set credit=credit+10 where uid=" + Request.Cookies["UID"].Value);
                }
            }
        }


        sql = "";
        sql += "INSERT INTO ";
        sql += "TB_User ";
        sql += "(";
        sql += "UserName, ";
        sql += "UserPassword, ";
        sql += "UserEmail, ";
        sql += "UserPoint, ";
        sql += "RealName, ";
        sql += "IfPass, ";
        sql += "ifvip, ";
        sql += "ifmanage, ";
        sql += "CompanyName, ";
        sql += "Phone, ";
        sql += "Regtime)";
        sql += "VALUES ";
        sql += "(";

        sql += "'" + ck.CheckInput(UserName.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(UserPassword.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(UserEmail.Value.ToString()) + "', ";
        sql += "0, ";
        sql += "'" + ck.CheckInput(RealName.Value.ToString()) + "', ";

        sql += "1, ";
        sql += "1, ";
        sql += "0, ";
        sql += "'" + ck.CheckInput(Company.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Phone.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(DateTime.Now.ToString()) + "' ";
        sql += ")";
        cn.mdb_exe(sql);
        sql = "SELECT * FROM TB_User WHERE UserName = '" + ck.CheckInput(UserName.Value.ToString()) + "'";

        ds = cn.mdb_ds(sql, "user");

        string sql_account = "insert into TB_ORDER_ACCOUNT (userid) VALUES (" + ds.Tables["user"].Rows[0]["UserID"].ToString() + ")";
        cn.mdb_exe(sql_account);
        //增加账户信息

        AllinOrder AllinOrder1 = new AllinOrder();
        AllinOrder1.SetOrderTry(ds.Tables["user"].Rows[0]["UserID"].ToString());

        if (ds.Tables["user"].Rows.Count != 0)
        {
            try
            {
                points p = new points();
                p.AddNewPoints(ds.Tables["user"].Rows[0]["UserID"].ToString());
            }
            catch (Exception ex)
            {

            }

            string userid = ds.Tables["user"].Rows[0]["UserID"].ToString();
            string usernm = ds.Tables["user"].Rows[0]["UserName"].ToString();
            string ifvip = ds.Tables["user"].Rows[0]["ifvip"].ToString();
            string ifmanage = ds.Tables["user"].Rows[0]["ifmanage"].ToString();
            string realname = ds.Tables["user"].Rows[0]["realname"].ToString();
            string useremail = ds.Tables["user"].Rows[0]["useremail"].ToString();

            Response.Cookies["user_id"].Value = userid;
            Response.Cookies["user_name"].Value = Server.UrlEncode(usernm);
            Response.Cookies["ifvip"].Value = ifvip;
            Response.Cookies["ifmanage"].Value = ifmanage;

            Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["user_name"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["ifvip"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["ifmanage"].Expires = DateTime.Now.AddDays(365);


            Response.Cookies["realname"].Value = Server.UrlEncode(realname);
            Response.Cookies["useremail"].Value = Server.UrlEncode(useremail);

            Response.Cookies["realname"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["useremail"].Expires = DateTime.Now.AddDays(365);


            if (recommendUserID != "0")
            {
                cn.mdb_exe("insert into T_FRIEND (UID,FID) values (" + userid + "," + recommendUserID + ")");
                cn.mdb_exe("insert into T_FRIEND (UID,FID) values (" + recommendUserID + "," + userid + ")");
                Mark mark = new Mark();
                mark.MarkOperate(Convert.ToInt32(recommendUserID), 10, "推荐会员", Convert.ToInt32(userid));
            }

            mysqldata_conn mysqlcn = new mysqldata_conn();
            DataSet dscount = mysqlcn.mdb_ds("select * from uc_members where username='" + usernm + "'", "ucenter");

            if (dscount.Tables["ucenter"].Rows.Count == 0)
            {
                Random r = new Random();
                string salt = r.Next().ToString().Substring(0, 6);
                string username = usernm;
                string password = MD5(MD5(ds.Tables["user"].Rows[0]["UserPassword"].ToString()) + salt);
                string email = ds.Tables["user"].Rows[0]["UserEmail"].ToString();
                string myid = "";
                string myidkey = "";
                string regip = Page.Request.UserHostAddress;
                string regdate = UnixTimestamp();
                string lastloginip = "0";
                string lastlogintime = "0";


                string id = this.insert(username, "8fc24ae194289b94e36272a5f9882611", email, myid, myidkey, regip, regdate, lastloginip, lastlogintime, "594882");

                if (id != "")
                {
                    mysqlcn.mdb_exe("insert into uchome_member (uid,username,password) values (" + id + ",'','" + MD5(id + "|" + UnixTimestamp()) + "')");
                    mysqlcn.mdb_exe("insert into uc_memberfields (uid,blacklist) values (" + id + ",'')");

                    string myemail;
                    string qq;
                    string msn;
                    if (ds.Tables["user"].Rows[0]["UserEmail"].ToString() != "")
                    {
                        myemail = ds.Tables["user"].Rows[0]["UserEmail"].ToString();
                    }
                    else
                    {
                        myemail = "";
                    }


                    qq = "";
                    msn = "";


                    mysqlcn.mdb_exe("insert into uchome_spacefield (uid,email,qq,msn,blood,birthprovince,birthcity,resideprovince,residecity,note,spacenote,authstr,theme,css,privacy,friend,feedfriend,sendmail) values (" + id + ",'" + myemail + "','" + qq + "','" + msn + "','','','','','','','','','','','','','','')");


                    //插入实名
                    string namestatus = "0";

                    //实名

                    mysqlcn.mdb_exe("insert into uchome_space (uid,groupid,username,name,namestatus,domain,dateline,ip) values (" + id + ",5,'" + username + "',''," + namestatus + ",''," + UnixTimestamp() + ",'" + Page.Request.UserHostAddress + "')");
                    cn.mdb_exe("update TB_User set UCenterHomeUid=" + id + " where UserId=" + userid);


                    //在ucenter中添加推荐好友

                    if (Request.Cookies["UID"] == null)
                    {

                    }
                    else
                    {
                        if (Request.Cookies["UID"].Value == "")
                        {

                        }

                        else
                        {


                            string gid = "0";
                            if (this.Request.Cookies["g"] == null)
                            {

                            }
                            else
                            {
                                if (Request.Cookies["g"].Value == "")
                                {

                                }
                                else
                                {
                                    gid = Request.Cookies["g"].Value;
                                    try
                                    {
                                        int g = Convert.ToInt32(gid);

                                        if (g > 0 && g < 8)
                                        {
                                            gid = g.ToString();
                                        }
                                        else
                                        {
                                            gid = "0";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        gid = "0";
                                    }
                                }




                            }

                            DataSet myUidds = mysqlcn.mdb_ds("select username from uc_members where uid=" + Request.Cookies["UID"].Value, "uid");
                            mysqlcn.mdb_exe("insert into uchome_friend (uid,fuid,fusername,status,gid,note,dateline) values (" + id + "," + Request.Cookies["UID"].Value + ",'" + myUidds.Tables["uid"].Rows[0][0].ToString() + "',1,0,''," + UnixTimestamp() + ")");
                            mysqlcn.mdb_exe("insert into uchome_friend (uid,fuid,fusername,status,gid,note,dateline) values (" + Request.Cookies["UID"].Value + "," + id + ",'" + username + "',1," + gid + ",''," + UnixTimestamp() + ")");
                            mysqlcn.mdb_exe("insert into uc_friends (uid,friendid,direction,comment) values (" + id + "," + Request.Cookies["UID"].Value + ",3,'')");
                            mysqlcn.mdb_exe("insert into uc_friends (uid,friendid,direction,comment) values (" + Request.Cookies["UID"].Value + "," + id + ",3,'')");
                        }
                    }


                }



            }
            Response.Cookies["useremail"].Value = UserEmail.Value.ToString();

            try
            {
                SendEmail(UserName.Value.ToString(), UserPassword.Value.ToString(), UserEmail.Value.ToString(), "GB");
            }
            catch (Exception ex)
            {
                Response.Redirect("trysuccess.aspx");
            }

        }






    }

    public string MD5(string str)
    {
        Byte[] b = System.Text.Encoding.Default.GetBytes(str);
        b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
        string ret = "";
        for (int i = 0; i < b.Length; i++)
        {
            ret += b[i].ToString("x").PadLeft(2, '0');
        }
        return ret;

    }

    public string UnixTimestamp()
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
        TimeSpan toNow = dtNow.Subtract(dtStart);
        string timeStamp = toNow.Ticks.ToString();
        return timeStamp.Substring(0, timeStamp.Length - 7);
    }

    public string insert(string username, string password, string email, string myid, string myidkey, string regip, string regdate, string lastloginip, string lastlogintime, string salt)
    {
        string sql = "";
        try
        {
            MySqlConnection connection1 = new MySqlConnection("Database=allin;Data Source = localhost;User Id = sasa;Password = takeeasy822822");
            mysqldata_conn mysqlcn = new mysqldata_conn();

            MySqlCommand command1 = new MySqlCommand();
            connection1.Open();
            MySqlDataAdapter da1 = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            sql = "insert into uc_members (username,password,email,myid,myidkey,regip,regdate,lastloginip,lastlogintime,salt) values ('" + username + "','" + password + "','" + email + "','" + myid + "','" + myidkey + "','" + regip + "'," + regdate + "," + lastloginip + "," + lastlogintime + ",'" + salt + "')";

            command1 = new MySqlCommand(sql, connection1);
            command1.ExecuteNonQuery();
            command1 = new MySqlCommand("SELECT LAST_INSERT_ID()", connection1);
            da1.SelectCommand = command1;


            da1.Fill(ds, "aa");
            connection1.Close();
            return ds.Tables["aa"].Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
            this.Response.Write(sql);
            return "";
        }
    }

    public void SendEmail(string name, string password, string email, string type)
    {
        string code = "";
        switch (type)
        {
            case "GB":
                code = "gb2312";
                break;
            case "UTF":
                code = "utf-8";
                break;
            default:
                code = "gb2312";
                break;
        }
        jmail.Message JMail = new jmail.Message();
        JMail.Charset = code;
        JMail.Logging = true;
        JMail.ContentType = "text/html";
        JMail.AddHeader("Originating-IP", Request.ServerVariables["REMOTE_ADDR"]);
        JMail.MailServerUserName = "cus@100allin.com";
        JMail.MailServerPassWord = "888888";
        JMail.From = "cus@100allin.com";
        JMail.FromName = "环球运费网";
        JMail.Subject = "您已成功注册环球运费网会员";

        JMail.Body = "<body> ";
        JMail.Body += "<table border=0 cellspacing=3 cellpadding=0 width=540 bgcolor=#F0690F align=center> ";
        JMail.Body += "<tbody> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td bgcolor=#ffffff> ";
        JMail.Body += "<table width=90% height=80 border=0 align=center cellpadding=0 cellspacing=0> ";
        JMail.Body += "<tbody> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td> ";
        JMail.Body += "<a href=http://www.100allin.com target=_blank><img border=0 src=http://www.100allin.com/images/logo.gif width=182 height=72 /></a> ";
        JMail.Body += "<strong> ";
        JMail.Body += "<font size=3 color=#29728D>专业</font><font size=3 color=#FF6600>运价</font><font size=3 color=#29728D>搜索查询和发布</font> ";
        JMail.Body += "</strong> ";
        JMail.Body += "</td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "</tbody> ";
        JMail.Body += "</table> ";
        JMail.Body += "<table border=0 cellspacing=0 cellpadding=13 width=90% bgcolor=#fffdcf align=center> ";
        JMail.Body += "<tbody> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td><font size=2><strong>尊敬的用户，您好！</strong> ";
        JMail.Body += "<p>感谢您注册环球运费网，以下是您注册的详细信息：</p></font> ";
        JMail.Body += "<table border=0 cellspacing=0 cellpadding=0 width=100% bgcolor=#fffdcf align=center> ";
        JMail.Body += "<tbody> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td width=51%><font size=2><p>您的用户名是：<strong>" + name + "</strong> </p> ";
        JMail.Body += "<p>您的密码是:<strong>" + password + "</strong></p></td> ";
        JMail.Body += "<td width=49%><a href=http://www.100allin.com></a></font></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "</tbody> ";
        JMail.Body += "</table></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "</tbody> ";
        JMail.Body += "</table> ";
        JMail.Body += "<br /> ";
        JMail.Body += "<table width=90% height=25 border=0 align=center cellpadding=0 cellspacing=0 bgcolor=#F0690F> ";
        JMail.Body += "<tbody> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td width=13>&nbsp;</td> ";
        JMail.Body += "<td width=468><font size=2>注册成功后，您可以享受环球运费网提供的多项优质免费服务：</font></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "</tbody> ";
        JMail.Body += "</table> ";
        JMail.Body += "<table border=0 cellspacing=1 cellpadding=5 width=90% align=center> ";
        JMail.Body += "<tbody> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td width=50 height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/up.gif width=48 height=48 /></td> ";
        JMail.Body += "<td width=408 bgcolor=#e9e9e9><font size=2><strong>免费 发布海空运价信息</strong><br /> ";
        JMail.Body += "发布运价完全免费,批量上传功能让你更快更多的发布运价</font></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/search.gif width=48 height=48 /></td> ";
        JMail.Body += "<td bgcolor=#e9e9e9><font size=2><strong>免费 搜索发布货盘信息</strong><br /> ";
        JMail.Body += "几千外贸客户资源,更多更好货盘等你来拿</font></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/chat.gif width=48 height=48 /></td> ";
        JMail.Body += "<td bgcolor=#e9e9e9><font size=2><strong>即时 与您的商友沟通</strong><br /> ";
        JMail.Body += "聊天工具免下载免安装,随时随地与用户进行沟通</font></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "</tbody> ";
        JMail.Body += "</table> ";
        JMail.Body += "<br /> ";
        JMail.Body += "<br /> ";
        JMail.Body += "<table border=0 cellspacing=0 cellpadding=0 width=90% align=center> ";
        JMail.Body += "<tbody> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td><font size=2><p>您在使用过程中，如有任何问题或建议，请随时联系环球运费网客户服务人员，我们将热忱为您服务。 <br /> ";
        JMail.Body += "</p></font></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "</tbody> ";
        JMail.Body += "</table> ";
        JMail.Body += "<br /> ";
        JMail.Body += "<table border=0 cellspacing=0 cellpadding=0 width=90% align=center> ";
        JMail.Body += "<tbody> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td align=center><font size=2>【温馨提示】<br /> ";
        JMail.Body += "<font size=2 color=#CC0000><strong>为保证您正常接收邮件，环球运费网建议您将此邮件地址加入到地址簿中。</strong></font><br /> ";
        JMail.Body += "</div></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "</tbody> ";
        JMail.Body += "</table></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "<tr> ";
        JMail.Body += "<td bgcolor=#FF6600 height=50 align=center><font size=2>环球运费网(<a href=http://www.100allin.com>http://www.100allin.com</a>)<br /> ";
        JMail.Body += "客服电话/传真：021-53853033/3022　邮箱：allin@100allin.com</font></td> ";
        JMail.Body += "</tr> ";
        JMail.Body += "</tbody>  ";
        JMail.Body += "</table>  ";
        JMail.Body += "</body> ";
        JMail.AddRecipient(email, "接收者", "123");
        JMail.Priority = 3;
        JMail.Send("mail.100allin.com", false);
        JMail.Close();
        JMail = null;
        Response.Redirect("regnormal.aspx");

    }
}
