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

public partial class test_services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {
            loadtitle();
            loadRecord();
            checklogin();
        }
        if (Request.Cookies["user_id"] != null)
        {
            if (Request.Cookies["user_id"].Value.ToString() != "")
            {
                if (Request.Cookies["realname"] == null)
                {
                    data_conn cn = new data_conn();
                    DataSet ds = new DataSet();

                    string sql = "";
                    sql = sql + "SELECT ";
                    sql = sql + "Realname ";
                    sql = sql + "FROM ";
                    sql = sql + "TB_User ";
                    sql = sql + "WHERE ";
                    sql = sql + "UserID = '" + this.Request.Cookies["user_id"].Value.ToString() + "' ";


                    ds = cn.mdb_ds(sql, "user");

                    if (ds.Tables["user"].Rows.Count > 0)
                    {
                        Response.Cookies["realname"].Value = ds.Tables["user"].Rows[0][0].ToString();
                        Response.Cookies["realname"].Expires = Response.Cookies["user_id"].Expires;
                    }

                }


                Label8.Text = "<span style=\"color:#000000;\">欢迎您！" + Server.UrlDecode(Request.Cookies["realname"].Value.ToString()) + "</span> " + "<a href=\"/accounts/logout.aspx\">[退出登录]</a>"; ;
            }
            else
            {
                Label8.Text = "欢迎您！<a href=\"/accounts/login.aspx\">[登录]</a>"; ;
            }
        }
        else
        {
            Label8.Text = "欢迎您！<a href=\"/accounts/login.aspx\">[登录]</a>";
        }

        txtStartport.Attributes.Add("onfocus", "focus_input('txtStartport','');");
        txtStartport.Attributes.Add("onblur", "blur_input('txtStartport','起运港');");
        txtDestport.Attributes.Add("onfocus", "focus_input('txtDestport','');");
        txtDestport.Attributes.Add("onblur", "blur_input('txtDestport','目的港');");
        txtCarrier.Attributes.Add("onfocus", "focus_input('txtCarrier','');");
        txtCarrier.Attributes.Add("onblur", "blur_input('txtCarrier','船公司');");
        txtStartport.Attributes.Add("onkeydown", "KeyDown(event);");
        txtDestport.Attributes.Add("onkeydown", "KeyDown(event);");
        txtCarrier.Attributes.Add("onkeydown", "KeyDown(event);");

        txtStartport2.Attributes.Add("onfocus", "focus_input('txtStartport2','');");
        txtStartport2.Attributes.Add("onblur", "blur_input('txtStartport2','起运港');");
        txtDestport2.Attributes.Add("onfocus", "focus_input('txtDestport2','');");
        txtDestport2.Attributes.Add("onblur", "blur_input('txtDestport2','目的港');");
        txtCarrier2.Attributes.Add("onfocus", "focus_input('txtCarrier2','');");
        txtCarrier2.Attributes.Add("onblur", "blur_input('txtCarrier2','船公司');");
        txtStartport2.Attributes.Add("onkeydown", "KeyDown(event);");
        txtDestport2.Attributes.Add("onkeydown", "KeyDown(event);");
        txtCarrier2.Attributes.Add("onkeydown", "KeyDown(event);");

        txtStartport3.Attributes.Add("onfocus", "focus_input('txtStartport3','');");
        txtStartport3.Attributes.Add("onblur", "blur_input('txtStartport3','起运地');");
        txtDestport3.Attributes.Add("onfocus", "focus_input('txtDestport3','');");
        txtDestport3.Attributes.Add("onblur", "blur_input('txtDestport3','目的地');");
        txtStartport3.Attributes.Add("onkeydown", "KeyDown(event);");
        txtDestport3.Attributes.Add("onkeydown", "KeyDown(event);");


        txtCompanyName.Attributes.Add("onfocus", "focus_input('txtCompanyName','');");
        txtCompanyName.Attributes.Add("onblur", "blur_input('txtCompanyName','公司名称');");
        //txtStartport2.Attributes.Add("onkeydown", "KeyDown(event);");
        //txtDestport2.Attributes.Add("onkeydown", "KeyDown(event);");

        //if (Request.Cookies["user_lan"] != null)
        //{
        //    if (Request.Cookies["user_lan"].Value == "0")
        //    {
        //        usernewtop1_LinkButton1.Text = "繁體中文";
        //    }
        //    else
        //    {
        //        usernewtop1_LinkButton1.Text = "简体中文";
        //    }
        //}
        //else
        //{
        //    usernewtop1_LinkButton1.Text = "繁體中文";
        //}
    }

    public void loadtitle()
    {
        data_conn cn = new data_conn();
        string sql = "select * from TB_index CROSS JOIN TB_PRICECOUNT ";
        DataSet ds = cn.mdb_ds(sql, "bbs");
        rpttitle.DataSource = ds.Tables["bbs"].DefaultView;
        rpttitle.DataBind();

        DataSet ds1 = cn.mdb_ds("select * from TB_IMGIndex where id=1", "ds1");

        LitIMG.Text = "<a href='" + ds1.Tables["ds1"].Rows[0]["txtlink"].ToString() + "' target='_blank'><img width='85px' height='65px' src='/images/index/pic_1.gif' /></a>";
        Litclick.Text = "<a href='" + ds1.Tables["ds1"].Rows[0]["txtlink"].ToString() + "' target='_blank'>[详细]</a>";
        labtext.Text = GetFirstString(ds1.Tables["ds1"].Rows[0]["txttext"].ToString(), 28);
        LitTitle.Text = "<a href='" + ds1.Tables["ds1"].Rows[0]["txtlink"].ToString() + "' target='_blank'><span class='orange bold'>" + GetFirstString(ds1.Tables["ds1"].Rows[0]["txttitle"].ToString(), 16) + "</span></a>";

        //DataSet ds2 = cn.mdb_ds("select * from TB_IMGIndex where id=2", "ds2");
        //LitIMG1.Text = "<a href=" + ds2.Tables["ds2"].Rows[0]["txtlink"].ToString() + " target='_blank'><img src='/images/index/pic_2.gif' width='60px' height='60px' /></a>";

        //DataSet ds3 = cn.mdb_ds("select * from TB_IMGIndex where id=3", "ds3");
        //LitIMG2.Text = "<a href=" + ds3.Tables["ds3"].Rows[0]["txtlink"].ToString() + " target='_blank'><img src='/images/index/pic_3.gif' width='60px' height='60px' /></a>";

    }

    public void loadRecord()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql;
        //
        sql = "select top 5 ";
        sql = sql + "id,startport,title,hangxianmiaoshu,companyname,UserID ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_整箱运价 ";
        ds = cn.mdb_ds(sql, "bbs");
        Rptfcl.DataSource = ds.Tables["bbs"].DefaultView;
        Rptfcl.DataBind();

        //
        sql = "select top 5 ";
        sql = sql + "id,startport,title,hangxianmiaoshu,companyname,UserID ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_拼箱运价 ";
        ds = cn.mdb_ds(sql, "bbs");
        Rptlcl.DataSource = ds.Tables["bbs"].DefaultView;
        Rptlcl.DataBind();

        //
        sql = "select top 5 ";
        sql = sql + "id,startport,title,hangxianmiaoshu,companyname,UserID ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_空运运价 ";
        ds = cn.mdb_ds(sql, "bbs");
        Rptair.DataSource = ds.Tables["bbs"].DefaultView;
        Rptair.DataBind();

        //sql = "SELECT TOP 8 * FROM TB_BBSImage";
        //ds = cn.mdb_ds(sql, "bbs");
        //RptImage.DataSource = ds.Tables["bbs"].DefaultView;
        //RptImage.DataBind();

        //sql = "SELECT TOP 10 * FROM TB_BBS ORDER BY PostDate DESC";
        //ds = cn.mdb_ds(sql, "bbs");
        //RptBBS.DataSource = ds.Tables["bbs"].DefaultView;
        //RptBBS.DataBind();

        sql = "SELECT * FROM TB_User WHERE star_allin > 0 ORDER BY star_allin DESC";
        ds = cn.mdb_ds(sql, "bbs");
        RptOrder.DataSource = ds.Tables["bbs"].DefaultView;
        RptOrder.DataBind();


        sql = "select top 5 ";
        sql = sql + "id,title,postdate ";
        sql = sql + "FROM TB_BBS WHERE (types = 5) ORDER BY Postdate DESC ";
        ds = cn.mdb_ds(sql, "bbs");
        RptaHangYunDongTai.DataSource = ds.Tables["bbs"].DefaultView;
        RptaHangYunDongTai.DataBind();


        sql = "SELECT TOP 24 ";
        sql = sql + "* ";
        sql = sql + "FROM ";
        sql = sql + "TB_COUNT_NEED ";
        sql = sql + "ORDER BY ID ";

        ds = cn.mdb_ds(sql, "bbs");
        RptaPriceNeed.DataSource = ds.Tables["bbs"].DefaultView;
        RptaPriceNeed.DataBind();


        sql = "select ratesimple from TB_NEWRATE";
        ds = cn.mdb_ds(sql, "rate");

        string[] ratexxs = new string[4];

        string ratexx;
        ratexx = ds.Tables["rate"].Rows[0][0].ToString();

        ratexxs = ratexx.Split('|');

        ltrRate1.Text = (Convert.ToDouble(ratexxs[0]) / 100).ToString();
        ltrRate2.Text = (Convert.ToDouble(ratexxs[1]) / 100).ToString();
        ltrRate3.Text = ratexxs[2];
        ltrRate4.Text = ratexxs[3];

    }


    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
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
                    Label1.Text = Server.UrlDecode(ds.Tables["user"].Rows[0]["realname"].ToString());

                    check ck = new check();
                    pm p = new pm();
                    string newpm = p.getnewpm(ck.CheckNumber(Request.Cookies["user_id"].Value.ToString()));

                    ltrLiuyan.Text = newpm;
                }

            }
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
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

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies["user_id"].Value = "";
        Response.Cookies["user_name"].Value = "";
        Response.Cookies["user_password"].Value = "";
        Response.Cookies["realname"].Value = "";
        Response.Cookies["companyname"].Value = "";
        Response.Cookies["phone"].Value = "";
        Response.Cookies["useremail"].Value = "";
        Response.Redirect("/");
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

    protected void Rptair_ItemDataBound(object sender, EventArgs e)
    {
        //check ck = new check();

        //if (Rptair.Items.Count != 0)
        //{
        //    DataSet ds;
        //    data_conn conn = new data_conn();
        //    Literal a;

        //    a = (Literal)Rptair.Items[0].FindControl("Literal1");
        //    string ids = a.Text;
        //    for (int i = 1; i < Rptair.Items.Count; i++)
        //    {
        //        a = (Literal)Rptair.Items[i].FindControl("Literal1");
        //        ids += "," + a.Text;
        //    }
        //    ds = conn.mdb_ds("select AIRID,DESTPORT,PRICE_M,PRICE_N,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000 from T_AIRPRICE where AIRID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table");
        //    string str = "";
        //    for (int i = 0; i < Rptair.Items.Count; i++)
        //    {
        //        string point = "";

        //        int count;
        //        a = (Literal)Rptair.Items[i].FindControl("Literal1");
        //        if (ds.Tables["table"].Select("AIRID=" + a.Text).Length > 20)
        //        {
        //            count = 19;
        //            point = "$$......######";
        //        }
        //        else
        //        {
        //            count = ds.Tables["table"].Select("AIRID=" + a.Text).Length - 1;
        //        }
        //        for (int j = 0; j < count + 1; j++)
        //        {

        //            for (int k = 1; k < 9; k++)
        //            {
        //                str += ds.Tables["table"].Select("AIRID=" + a.Text)[j].ItemArray[k].ToString();
        //                if (k != 8)
        //                {
        //                    str += "##";
        //                }
        //            }
        //            if (j != ds.Tables["table"].Select("AIRID=" + a.Text).Length - 1)
        //            {
        //                str += "$$";
        //            }
        //        }
        //        str += point;
        //        if (i != Rptair.Items.Count - 1)
        //        {
        //            str += "**";
        //        }
        //    }
        //    Hidden3.Value = str;


        //    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //    a = (Literal)Rptair.Items[0].FindControl("Literal2");
        //    ids = a.Text;
        //    for (int i = 1; i < Rptair.Items.Count; i++)
        //    {
        //        a = (Literal)Rptair.Items[i].FindControl("Literal2");
        //        ids += "," + a.Text;
        //    }
        //    ds = conn.mdb_ds("select CompanyName,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail,UserID from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table");
        //    str = "";
        //    for (int i = 0; i < Rptair.Items.Count; i++)
        //    {
        //        string point = "";
        //        int j;
        //        int count;
        //        a = (Literal)Rptair.Items[i].FindControl("Literal2");
        //        if (ds.Tables["table"].Select("UserID=" + a.Text).Length == 1)
        //        {
        //            str += "公司名称" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[0].ToString();
        //            str += "$$";
        //            str += "电话号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[1].ToString();
        //            str += "$$";
        //            str += "传真号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[2].ToString();
        //            str += "$$";
        //            str += "手机号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[3].ToString();
        //            str += "$$";
        //            str += "MSN" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[4].ToString();
        //            str += "$$";
        //            str += "QQ" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[5].ToString();
        //            str += "$$";
        //            str += "电子邮箱" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[6].ToString();
        //        }

        //        if (i != Rptair.Items.Count - 1)
        //        {
        //            str += "**";
        //        }
        //    }
        //    Hiddennn3.Value = str;
        //}
    }

    protected void Rptlcl_ItemDataBound(object sender, EventArgs e)
    {
        //check ck = new check();
        //if (Rptlcl.Items.Count != 0)
        //{
        //    DataSet ds;
        //    data_conn conn = new data_conn();
        //    Literal a;

        //    a = (Literal)Rptlcl.Items[0].FindControl("Literal1");
        //    string ids = a.Text;
        //    for (int i = 1; i < Rptlcl.Items.Count; i++)
        //    {
        //        a = (Literal)Rptlcl.Items[i].FindControl("Literal1");
        //        ids += "," + a.Text;
        //    }
        //    ds = conn.mdb_ds("select YunJiaID,DESTPORT,pricegp from TB_YunJiaInfo where YunJiaID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table");
        //    string str = "";
        //    for (int i = 0; i < Rptlcl.Items.Count; i++)
        //    {
        //        string point = "";

        //        int count;
        //        a = (Literal)Rptlcl.Items[i].FindControl("Literal1");
        //        if (ds.Tables["table"].Select("YunJiaID=" + a.Text).Length > 20)
        //        {
        //            count = 19;
        //            point = "$$......######";
        //        }
        //        else
        //        {
        //            count = ds.Tables["table"].Select("YunJiaID=" + a.Text).Length - 1;
        //        }
        //        for (int j = 0; j < count + 1; j++)
        //        {

        //            for (int k = 1; k < 3; k++)
        //            {
        //                str += ds.Tables["table"].Select("YunJiaID=" + a.Text)[j].ItemArray[k].ToString();
        //                if (k != 2)
        //                {
        //                    str += "##";
        //                }
        //            }
        //            if (j != ds.Tables["table"].Select("YunJiaID=" + a.Text).Length - 1)
        //            {
        //                str += "$$";
        //            }
        //        }
        //        str += point;
        //        if (i != Rptlcl.Items.Count - 1)
        //        {
        //            str += "**";
        //        }
        //    }
        //    Hidden2.Value = str;
        //    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //    a = (Literal)Rptlcl.Items[0].FindControl("Literal2");
        //    ids = a.Text;
        //    for (int i = 1; i < Rptlcl.Items.Count; i++)
        //    {
        //        a = (Literal)Rptlcl.Items[i].FindControl("Literal2");
        //        ids += "," + a.Text;
        //    }
        //    ds = conn.mdb_ds("select CompanyName,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail,UserID from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table");
        //    str = "";

        //    for (int i = 0; i < Rptlcl.Items.Count; i++)
        //    {
        //        string point = "";
        //        int j;
        //        int count;
        //        a = (Literal)Rptlcl.Items[i].FindControl("Literal2");
        //        if (ds.Tables["table"].Select("UserID=" + a.Text).Length == 1)
        //        {
        //            str += "公司名称" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[0].ToString();
        //            str += "$$";
        //            str += "电话号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[1].ToString();
        //            str += "$$";
        //            str += "传真号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[2].ToString();
        //            str += "$$";
        //            str += "手机号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[3].ToString();
        //            str += "$$";
        //            str += "MSN" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[4].ToString();
        //            str += "$$";
        //            str += "QQ" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[5].ToString();
        //            str += "$$";
        //            str += "电子邮箱" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[6].ToString();
        //        }

        //        if (i != Rptlcl.Items.Count - 1)
        //        {
        //            str += "**";
        //        }
        //    }
        //    Hiddennn2.Value = str;
        //}
    }

    protected void Rptfcl_ItemDataBound(object sender, EventArgs e)
    {
        //check ck = new check();
        //if (Rptfcl.Items.Count != 0)
        //{
        //    DataSet ds;
        //    data_conn conn = new data_conn();
        //    Literal a;

        //    a = (Literal)Rptfcl.Items[0].FindControl("Literal1");
        //    string ids = a.Text;
        //    for (int i = 1; i < Rptfcl.Items.Count; i++)
        //    {
        //        a = (Literal)Rptfcl.Items[i].FindControl("Literal1");
        //        ids += "," + a.Text;
        //    }
        //    ds = conn.mdb_ds("select YunJiaID,DESTPORT,price20gp,price40gp,price40hq from TB_YunJiaInfo where YunJiaID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table");
        //    string str = "";
        //    for (int i = 0; i < Rptfcl.Items.Count; i++)
        //    {
        //        string point = "";

        //        int count;
        //        a = (Literal)Rptfcl.Items[i].FindControl("Literal1");
        //        if (ds.Tables["table"].Select("YunJiaID=" + a.Text).Length > 20)
        //        {
        //            count = 19;
        //            point = "$$......######";
        //        }
        //        else
        //        {
        //            count = ds.Tables["table"].Select("YunJiaID=" + a.Text).Length - 1;
        //        }
        //        for (int j = 0; j < count + 1; j++)
        //        {

        //            for (int k = 1; k < 5; k++)
        //            {
        //                str += ds.Tables["table"].Select("YunJiaID=" + a.Text)[j].ItemArray[k].ToString();
        //                if (k != 4)
        //                {
        //                    str += "##";
        //                }
        //            }
        //            if (j != ds.Tables["table"].Select("YunJiaID=" + a.Text).Length - 1)
        //            {
        //                str += "$$";
        //            }
        //        }
        //        str += point;
        //        if (i != Rptfcl.Items.Count - 1)
        //        {
        //            str += "**";
        //        }
        //    }
        //    Hidden1.Value = str;
        //    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //    a = (Literal)Rptfcl.Items[0].FindControl("Literal2");
        //    ids = a.Text;
        //    for (int i = 1; i < Rptfcl.Items.Count; i++)
        //    {
        //        a = (Literal)Rptfcl.Items[i].FindControl("Literal2");
        //        ids += "," + a.Text;
        //    }
        //    ds = conn.mdb_ds("select CompanyName,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail,UserID from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table");
        //    str = "";
        //    for (int i = 0; i < Rptfcl.Items.Count; i++)
        //    {
        //        string point = "";
        //        int j;
        //        int count;
        //        a = (Literal)Rptfcl.Items[i].FindControl("Literal2");
        //        if (ds.Tables["table"].Select("UserID=" + a.Text).Length == 1)
        //        {
        //            str += "公司名称" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[0].ToString();
        //            str += "$$";
        //            str += "电话号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[1].ToString();
        //            str += "$$";
        //            str += "传真号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[2].ToString();
        //            str += "$$";
        //            str += "手机号码" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[3].ToString();
        //            str += "$$";
        //            str += "MSN" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[4].ToString();
        //            str += "$$";
        //            str += "QQ" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[5].ToString();
        //            str += "$$";
        //            str += "电子邮箱" + "##" + ds.Tables["table"].Select("UserID=" + a.Text)[0].ItemArray[6].ToString();
        //        }

        //        if (i != Rptfcl.Items.Count - 1)
        //        {
        //            str += "**";
        //        }
        //    }
        //    Hiddennn1.Value = str;
        //}
    }

    //protected void usernewtop1_LinkButton1_Click(object sender, EventArgs e)
    //{
    //    if (Request.Cookies["user_lan"] != null)
    //    {
    //        if (Request.Cookies["user_lan"].Value == "0")       
    //        {
    //            Response.Cookies["user_lan"].Value = "1";
    //        }
    //        else
    //        {
    //            Response.Cookies["user_lan"].Value = "0";
    //        }
    //        Response.Cookies["user_lan"].Expires = DateTime.Now.AddDays(365);
    //    }
    //    else
    //    {
    //        Response.Cookies["user_lan"].Value = "1";
    //        Response.Cookies["user_lan"].Expires = DateTime.Now.AddDays(365);
    //    }

    //    Response.Redirect(Request.ServerVariables["HTTP_REFERER"]);
    //}

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

    public static bool IsOdd(int n)
    {
        return Convert.ToBoolean(n % 2);
    }

}
