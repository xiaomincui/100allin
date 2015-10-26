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

public partial class en_login_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void MessageBox(string strKey, string strInfo)
    {
        if (!ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "";
        sql = sql + "select * ";
        sql = sql + "from TB_User ";
        sql = sql + "where UserName = '" + ck.CheckInput(UserName.Value) + "'";
        DataSet ds = new DataSet();
        ds = cn.mdb_ds(sql, "T_User");




        if (WordsIScn(UserName.Value) && WordsIScn(Text1.Value) && WordsIScn(Text2.Value) && WordsIScn(Text3.Value) && WordsIScn(Text4.Value) && WordsIScn(Text5.Value) && WordsIScn(Text6.Value) && WordsIScn(Text7.Value) && WordsIScn(Text8.Value) && WordsIScn(Text9.Value) && WordsIScn(Text10.Value) && WordsIScn(Text11.Value) && WordsIScn(Text12.Value) && WordsIScn(Text13.Value) && WordsIScn(Text14.Value) && WordsIScn(TEXTAREA1.Value))
        {
            
        }
        else
        {
            MessageBox("opfail", "不能出现中文字符");
            return;
        }

        if (ds.Tables["T_User"].Rows.Count > 0)
        {
            MessageBox("opfail", "该用户名已被使用");
            return;
        }

        if (Text1.Value != Text2.Value)
        {
            MessageBox("opfail", "两遍输入的密码不相同");
            return;
        }

        if (!Checkbox1.Checked)
        {
            MessageBox("opfail", "Please read the service terms and agree");
            return;
        }

        if (UserName.Value == "" || Text1.Value == "" || Text2.Value == "" || Text3.Value == "" || Text5.Value == "" || DropDownList1.SelectedValue == "" || Text6.Value == "" || Text8.Value == "" || Text11.Value == "" || Text12.Value == "")
        {
            MessageBox("opfail", "*号为必填项");
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
        sql += "RealName, ";
        sql += "First_Name, ";
        sql += "Last_Name, ";
        sql += "EN_CompanyName, ";
        sql += "CompanyType, ";//int  
        sql += "Phone, ";
        sql += "Fax, ";
        sql += "UserEmail, ";
        sql += "Usermsn, ";
        sql += "Website, ";
        sql += "EN_Country, ";
        sql += "EN_City, ";
        sql += "EN_Address, ";
        sql += "PostNumber, ";
        sql += "EN_Company_profile, ";
        sql += "UserPoint, ";
        sql += "IfPass, ";
        sql += "ifvip, ";
        sql += "ifmanage, ";
        sql += "ifEn, ";
        sql += "Regtime)";
        sql += "VALUES ";
        sql += "(";

        sql += "'" + ck.CheckInput(UserName.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text1.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text3.Value.ToString()) + " " + ck.CheckInput(Text4.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text3.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text4.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text5.Value.ToString()) + "', ";
        sql += "" + ck.CheckInput(DropDownList1.SelectedValue) + ", ";
        sql += "'" + ck.CheckInput(Text6.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text7.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text8.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text9.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text10.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text11.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text12.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text13.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(Text14.Value.ToString()) + "', ";
        sql += "'" + ck.CheckInput(TEXTAREA1.Value.ToString()) + "', ";
        sql += "0, ";
        sql += "1, ";
        sql += "1, ";
        sql += "0, ";
        sql += "1, ";
        sql += "'" + ck.CheckInput(DateTime.Now.ToString()) + "' ";
        sql += ")";
        cn.mdb_exe(sql);
        sql = "SELECT * FROM TB_User WHERE UserName = '" + ck.CheckInput(UserName.Value.ToString()) + "'";

        ds = cn.mdb_ds(sql, "user");

        string sql_account = "insert into TB_ORDER_ACCOUNT (userid) VALUES (" + ds.Tables["user"].Rows[0]["UserID"].ToString() + ")";
        cn.mdb_exe(sql_account);
        //增加账户信息

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
                else
                {
                    Response.Write("safasdfasdf");
                }



            }
            Response.Cookies["useremail"].Value = Text8.Value.ToString();


            Response.Redirect("/en/login_2.aspx");


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
        //try
        //{
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
        //}
        //catch (Exception ex)
        //{
        //    this.Response.Write(sql);
        //    return "";
        //}
    }



    public bool WordsIScn(string words)
    {
        if (words == "")
        {
            return true;
        }
        string TmmP;
        for (int i = 0; i < words.Length; i++)
        {
            TmmP = words.Substring(i, 1);
            byte[] sarr = System.Text.Encoding.GetEncoding("gb2312").GetBytes(TmmP);
            if (sarr.Length == 2)
            {
                return false;
            }
        }
        return true;
    }

}
