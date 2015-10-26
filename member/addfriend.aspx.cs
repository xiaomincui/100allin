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

public partial class member_addfriend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
	login lg = new login();
        lg.login();
        order order1 = new order();
        check ck = new check();
        string u = ck.CheckNumber(order1.GetRequestQueryString("u", "0"));
        string myu = ck.CheckNumber(order1.GetRequestCookies("user_id", ""));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "SELECT * FROM TB_USER WHERE userid = " + u;

        ds = cn.mdb_ds(sql, "user");

        Label1.Text = ds.Tables["user"].Rows[0]["companyname"].ToString();
        Label9.Text = ds.Tables["user"].Rows[0]["postnumber"].ToString();
        Label11.Text = ds.Tables["user"].Rows[0]["address"].ToString();

        Label4.Text = "<span><a href=\"/company/" + setkey(u) + "\" style='font-size:14px; font-weight:bold; color:#FF6600;' target=\"_blank\">" + ds.Tables["user"].Rows[0]["realname"].ToString() + "</a></span>";
        Literal25.Text = "<a href=\"/member/pm_detail.aspx?pid=1&cid=" + u + "\" target=\"_blank\"><img src=\"/images/fcl/bot_1.jpg\"  border=\"0\" style= 'margin-top: 12px;'/></a>";

        if ((bool)ds.Tables["user"].Rows[0]["HeadURL"] == true)
        {
            imghead.Src = "/member/Head/" + ds.Tables["user"].Rows[0]["UserID"].ToString() + ".jpg";
        }
        else
        {
            imghead.Src = "/member/Head/default.jpg";
        }



        LtrStars1.Text = Star1(ds.Tables["user"].Rows[0]["star_allin"].ToString());
        LtrStars2.Text = Star2(ds.Tables["user"].Rows[0]["star_user"].ToString());

        try
        {
            ImageButton1.ImageUrl = "/images/get/company_tel.aspx?u=" + setkey(u);
            ImageButton3.ImageUrl = "/images/get/company_email.aspx?u=" + setkey(u);
            ImageButton4.ImageUrl = "/images/get/company_mobile.aspx?u=" + setkey(u);
        }
        catch
        {

        }



        AllinUser AllinUser1 = new AllinUser();

        mysqldata_conn mycn = new mysqldata_conn();
        sql = "SELECT uid FROM uc_friends WHERE uid = " + AllinUser1.GetUserDetail(myu)[10] + " AND friendid = " + ds.Tables["user"].Rows[0]["UCenterHomeUid"].ToString();
	//Response.Write(sql);
        DataSet dsu = new DataSet();
        dsu = mycn.mdb_ds(sql, "ufriend");

        if (dsu.Tables["ufriend"].Rows.Count > 0)
        {
            ImageButton2.Visible = false;
            Label2.Visible = true;
        }

    }

    public static string Star1(string s)
    {
        int ss = 0;
        ss = Convert.ToInt32(s);
        string w = null;
        w = "";

        switch (s)
        {
            case "1":
                w = "<img src=\"/images/fcl/ay_1.jpg\" border=\"0\" class=\"yt\">";
                break;
            case "2":
                w = "<img src=\"/images/fcl/ay_2.jpg\" border=\"0\" class=\"yt\">";
                break;
            case "3":
                w = "<img src=\"/images/fcl/ay_3.gif\" border=\"0\" class=\"yt\">";
                break;
            case "4":
                w = "<img src=\"/images/fcl/ay_4.jpg\" border=\"0\" class=\"yt\">";
                break;
            case "5":
                w = "<img src=\"/images/fcl/ay_5.jpg\" border=\"0\" class=\"yt\">";

                break;
        }

        return w.ToString();
    }

    public static string Star2(string s)
    {
        int ss = 0;
        ss = Convert.ToInt32(s);
        string w = null;
        w = "";

        for (int i = 0; i <= ss - 1; i++)
        {
            w = w + "<img src=\"/images/fcl/star.gif\" border=\"0\" alt=\"信誉等级：" + s + "级\" >";
        }

        if (ss == 0)
        {
            w = "-";
        }

        return w.ToString();
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        check ck = new check();
        order order1 = new order();
        string u = ck.CheckNumber(order1.GetRequestQueryString("u", "0"));

        mysqldata_conn mycn = new mysqldata_conn();
        data_conn cn=new data_conn ();
        DataSet ds = cn.mdb_ds("select * from TB_User where UserID=" + u,"UCenterHomeUid");
        string fuid = ds.Tables["UCenterHomeUid"].Rows[0]["UCenterHomeUid"].ToString();
        //Response.Write("select * from TB_User where UserID=" + Request.Cookies["user_id"].Value.ToString());
        ds = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies["user_id"].Value.ToString(), "UCenterHomeUid");
        string uid = ds.Tables["UCenterHomeUid"].Rows[0]["UCenterHomeUid"].ToString();
        string fuername = ds.Tables["UCenterHomeUid"].Rows[0]["UCenterHomeUid"].ToString();
        mycn.mdb_exe("insert into uchome_friend (uid,fuid,fusername,status,dateline) values (" + uid + "," + fuid + ",'',1," + UnixTimestamp() + ")");

        mycn.mdb_exe("insert into uc_friends (uid,friendid,direction) values (" + uid + "," + fuid + ",3)");
        mycn.mdb_exe("insert into uc_friends (uid,friendid,direction) values (" + fuid + "," + uid + ",3)");

        ScriptManager.RegisterStartupScript(ImageButton2, ImageButton2.GetType(), "Alert", "alert('好友添加成功');window.location.href='friend.aspx'", true);

    }

    public string UnixTimestamp()
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
        TimeSpan toNow = dtNow.Subtract(dtStart);
        string timeStamp = toNow.Ticks.ToString();
        return timeStamp.Substring(0, timeStamp.Length - 7);
    }

}
