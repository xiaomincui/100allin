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
using System.Text.RegularExpressions;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadRecord();
            checklogin();
        }



        //GetRequest GetRequest1 = new GetRequest();
        //string uvid = "0";
        //if (GetRequest1.GetRequestCookies("uvid", "0") == "0")
        //{
        //    data_conn cn = new data_conn();
        //    DataSet ds = new DataSet();
        //    string sql = "INSERT INTO TB_UV_LIST (uvtime) values (getdate());select @@identity";
        //    ds = cn.mdb_ds(sql, "uvid");
        //    uvid = ds.Tables["uvid"].Rows[0][0].ToString();

        //    Response.Cookies["uvid"].Value = uvid;
        //    Response.Cookies["uvid"].Expires = DateTime.Now.AddDays(365);
        //}
        //else
        //{
        //    uvid = GetRequest1.GetRequestCookies("uvid", "0");
        //}


    }


    public void loadRecord()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        string sql;
        //

        //sql = "select * ";
        //sql = sql + "FROM  ";
        //sql = sql + "V_热门_整箱运价 ";
        //ds = cn.mdb_ds(sql, "bbs");
        //RptFclHot.DataSource = ds.Tables["bbs"].DefaultView;
        //RptFclHot.DataBind();

        //sql = "select * ";
        //sql = sql + "FROM  ";
        //sql = sql + "V_热门_空运运价 ";
        //ds = cn.mdb_ds(sql, "bbs");
        //RptAirHot.DataSource = ds.Tables["bbs"].DefaultView;
        //RptAirHot.DataBind();

        sql = "select top 6 ";
        sql = sql + "id,startport,destport,title,hangxianmiaoshu,companyname,UserID,price20gp,price40gp,price40hq ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_整箱运价 ";
        ds2 = cn.mdb_ds(sql, "bbs");
        ds3 = cn.mdb_ds(sql, "bbs");


        ds2.Tables["bbs"].Rows[1].Delete(); 
        ds2.Tables["bbs"].Rows[2].Delete();
        ds2.Tables["bbs"].Rows[3].Delete();
        ds2.Tables["bbs"].Rows[4].Delete();

        ds3.Tables["bbs"].Rows[0].Delete();
        ds3.Tables["bbs"].Rows[1].Delete();

        Rptfcl2.DataSource = ds2.Tables["bbs"].DefaultView;
        Rptfcl2.DataBind();

        Rptfcl3.DataSource = ds3.Tables["bbs"].DefaultView;
        Rptfcl3.DataBind();

        //
        sql = "select top 4 ";
        sql = sql + "id,startport,destport,title,hangxianmiaoshu,companyname,UserID,pricegp,pricegpv ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_拼箱运价 ";
        ds = cn.mdb_ds(sql, "bbs");
        Rptlcl.DataSource = ds.Tables["bbs"].DefaultView;
        Rptlcl.DataBind();

        //
        sql = "select top 4 ";
        sql = sql + "id,startport,destport,title,hangxianmiaoshu,companyname,UserID,price_p45,price_p100,price_p300,price_p500,price_p1000 ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_空运运价 ";
        ds = cn.mdb_ds(sql, "bbs");
        Rptair.DataSource = ds.Tables["bbs"].DefaultView;
        Rptair.DataBind();


        sql = "select top 11 ";
        sql = sql + "id,title,postdate ";
        sql = sql + "FROM TB_BBS WHERE (types = 5) ORDER BY Postdate DESC ";
        ds = cn.mdb_ds(sql, "bbs");
        RptaHangYunDongTai.DataSource = ds.Tables["bbs"].DefaultView;
        RptaHangYunDongTai.DataBind();


        sql = "SELECT TOP 4 ";
        sql = sql + "* ";
        sql = sql + "FROM ";
        sql = sql + "TB_COUNT_NEED ";
        sql = sql + "ORDER BY ID ";

        ds = cn.mdb_ds(sql, "bbs");
        RptPriceNeed.DataSource = ds.Tables["bbs"].DefaultView;
        RptPriceNeed.DataBind();


        sql = "select ratesimple from TB_NEWRATE";
        ds = cn.mdb_ds(sql, "rate");

        string[] ratexxs = new string[4];

        string ratexx;
        ratexx = ds.Tables["rate"].Rows[0][0].ToString();

        ratexxs = ratexx.Split('|');

        try
        {
            ltrRate1.Text = (Convert.ToDouble(ratexxs[0]) / 100).ToString();
            ltrRate2.Text = (100 / Convert.ToDouble(ratexxs[0])).ToString("f4");
            //ltrRate3.Text = Math.Round((Convert.ToDouble(ratexxs[2])), 4).ToString("f4");
            //ltrRate4.Text = Math.Round((Convert.ToDouble(ratexxs[3])), 4).ToString("f3");
        }
        catch
        {

        }

    }


    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

    public string setprice(string p)
    {
        p = p.ToUpper().Replace("USD", "").Replace("$", "").Replace("KG", "").Replace("/", "").Trim();
        return p;
    }

    public string fclstyle(int r)
    {
        string s = "3";
        if (r <= 1)
        {
            s = "2";
        }
        else
        {
            s = "3";
        }
        return s;
    }

    public string bbsstyle(int r)
    {
        string s = "4";
        if (r <= 3)
        {
            return (r + 1).ToString();
        }
        else
        {
            return s;
        }

    }

    public void checklogin()
    {
        //如果用户登陆信息正确，显示用户信息窗口及用户名
        if (this.Request.Cookies["user_id"] == null)
        {
            PlaceHolder2.Visible = false;
            PlaceHolder1.Visible = true;
        }
        else
        {
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";

            sql = sql + "SELECT ";
            sql = sql + "Userpassword, ";
            sql = sql + "companytype, ";
            sql = sql + "Realname ";
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
                PlaceHolder2.Visible = false;
                PlaceHolder1.Visible = true;
            }
            else
            {
                loginTime();
                PlaceHolder2.Visible = true;
                PlaceHolder1.Visible = false;

                if (ds.Tables["user"].Rows.Count > 0)
                {
                    Literal2.Text = Server.UrlDecode(ds.Tables["user"].Rows[0]["realname"].ToString());
                    if (ds.Tables["user"].Rows[0]["companytype"].ToString() == "")
                    {
                        Literal7.Text = "default";
                        Literal3.Text = "<label class=\"lv0\">初级会员</label>";
                    }
                    else
                    {
                        Literal7.Text = this.Request.Cookies["user_id"].Value.ToString();
                        Literal3.Text = "<label class=\"lv1\">普通会员</label>";
                    }

                    Literal4.Text = "0";
                    Literal5.Text = "0";
                    Literal6.Text = "0";

                    sql = "select count(id) from tb_yunjia where yunjialeixing = 8 and UserID = '" + this.Request.Cookies["user_id"].Value.ToString() + "' ";
                    ds = cn.mdb_ds(sql, "pricecount");
                    Literal4.Text = ds.Tables["pricecount"].Rows[0][0].ToString();

                    sql = "select count(id) from tb_yunjia where yunjialeixing = 9 and UserID = '" + this.Request.Cookies["user_id"].Value.ToString() + "' ";
                    ds = cn.mdb_ds(sql, "pricecount");
                    Literal5.Text = ds.Tables["pricecount"].Rows[0][0].ToString();

                    sql = "select count(id) from t_airinfo where UserID = '" + this.Request.Cookies["user_id"].Value.ToString() + "' ";
                    ds = cn.mdb_ds(sql, "pricecount");
                    Literal6.Text = ds.Tables["pricecount"].Rows[0][0].ToString();
                }

            }
        }
    }


    protected void ImageButton1_Click(object sender, EventArgs e)
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
            Response.Redirect("/accounts/loginerr.aspx?redirect_url=http%3a%2f%2fwww.100allin.com%2f");
        }
        else
        {
            if (username == "")
            {
                Response.Redirect("/accounts/loginerr.aspx?redirect_url=http%3a%2f%2fwww.100allin.com%2f");
            }
            if (password == "")
            {
                Response.Redirect("/accounts/loginerr.aspx?redirect_url=http%3a%2f%2fwww.100allin.com%2f");
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
            //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('登录成功')", true);
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

            Response.Redirect("/");


        }
        else
        {
            Response.Redirect("/accounts/loginerr.aspx?redirect_url=http%3a%2f%2fwww.100allin.com%2f");
        }
    }

    //protected void MessageBox(string strKey, string strInfo)
    //{

    //    if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
    //    {
    //        string strjs = "alert('" + strInfo + "');";
    //        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
    //    }
    //}

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Response.Cookies["user_id"].Value = "";
    //    Response.Cookies["user_name"].Value = "";
    //    Response.Cookies["user_password"].Value = "";
    //    Response.Cookies["realname"].Value = "";
    //    Response.Cookies["companyname"].Value = "";
    //    Response.Cookies["phone"].Value = "";
    //    Response.Cookies["useremail"].Value = "";
    //    Response.Redirect("/");
    //}

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


    public static string GetFirstString(string stringToSub, int length)
    {
        //\u4e00-\u9fa5 中文区
        //\uff00-\uffef 逗号区
        //\u3000-\u303f 句号区
        //\u2000-\u206f 引号区
        //\u25a0-\u25ff 几何图形区
        Regex regex = new Regex("[\u4e00-\u9fa5\uff00-\uffef\u3000-\u303f\u2000-\u206f\u25a0-\u25ff]+", RegexOptions.Compiled);
        char[] stringChar = stringToSub.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;
        bool isCut = false;
        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch((stringChar[i]).ToString()))
            {
                sb.Append(stringChar[i]);
                nLength += 2;
            }
            else
            {
                sb.Append(stringChar[i]);
                nLength = nLength + 1;
            }

            if (nLength >= length)
            {
                isCut = true;
                break;
            }
        }

        if (isCut)
            return sb.ToString() + "..";
        else
            return sb.ToString();
    }

    //public static bool IsOdd(int n)
    //{
    //    return Convert.ToBoolean(n % 2);
    //}

}
