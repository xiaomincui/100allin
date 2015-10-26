using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class member_index : System.Web.UI.Page
{
    AllinUser AllinUser1 = new AllinUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        login lg = new login();
        lg.login();

        check ck = new check();
        string u = "0";

        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        sql = "SELECT Fax,MovePhone,Usermsn,Userqq,Address,PostNumber,introduction,Realname FROM TB_User WHERE userid = " + u;

        ds = cn.mdb_ds(sql, "tb_user");


        //显示名字和头像
        ltrMyName.Text = ds.Tables["tb_user"].Rows[0]["Realname"].ToString();

        //Response.Write(Server.MapPath("/member/head/") + u + ".jpg");
        if (System.IO.File.Exists(Server.MapPath("/member/head/") + u + ".jpg") == true)
        {
            ltrHead.Text = u;
        }
        else
        {
            ltrHead.Text = "default";
        }

        //显示资料完整度
        int infopercent = 0;

        if (ds.Tables["tb_user"].Rows[0]["Fax"].ToString() != "")
        {
            infopercent += 20;
        }

        if (ds.Tables["tb_user"].Rows[0]["MovePhone"].ToString() != "")
        {
            infopercent += 20;
        }

        if (ds.Tables["tb_user"].Rows[0]["Usermsn"].ToString() != "")
        {
            infopercent += 10;
        }

        if (ds.Tables["tb_user"].Rows[0]["Userqq"].ToString() != "")
        {
            infopercent += 10;
        }

        if (ds.Tables["tb_user"].Rows[0]["Address"].ToString() != "")
        {
            infopercent += 20;
        }

        if (ds.Tables["tb_user"].Rows[0]["PostNumber"].ToString() != "")
        {
            infopercent += 10;
        }

        if (ds.Tables["tb_user"].Rows[0]["introduction"].ToString() != "")
        {
            infopercent += 10;
        }

        ltrPercent.Text = infopercent.ToString();

        ltrPercentLength.Text = "<img src=\"images/tt.gif\" width=\"" + (infopercent*200/100).ToString() +"\" height=\"10\" />";

        ltrPreviewCompany.Text = "<a href=\"/company/" + setkey(u) + "/\" target=\"_blank\"><strong>预览</strong></a>";

        //显示未读消息
        sql = "select count(mid) as count from TB_PM where readed = 0 and listener = " + u;

        ds = cn.mdb_ds(sql, "tb_pm");

        ltrNewMessage.Text = ds.Tables["tb_pm"].Rows[0]["count"].ToString();


        sql = "select count(oid) as count from TB_ORDER where (order_status = 2 or order_status = 4) and order_forward = " + u;

        ds = cn.mdb_ds(sql, "TB_ORDER");

        ltrNewBooking.Text = ds.Tables["TB_ORDER"].Rows[0]["count"].ToString();

        sql = "select credit,overage from TB_ORDER_ACCOUNT where userid = " + u;

        ds = cn.mdb_ds(sql, "TB_ORDER_ACCOUNT");

        ltrOverage.Text = ds.Tables["TB_ORDER_ACCOUNT"].Rows[0]["overage"].ToString() + " / " + ds.Tables["TB_ORDER_ACCOUNT"].Rows[0]["credit"].ToString();

        ltrOverageTips.Text = "<a href=\"/member/order/pay_sel.aspx\">立即预存</a>";

        if (Convert.ToDouble(ds.Tables["TB_ORDER_ACCOUNT"].Rows[0]["overage"].ToString()) < 1000)
        {
            ltrOverageTips.Text = "您的订舱费余额已不多，提醒您<a href=\"/member/order/pay_sel.aspx\">立即预存</a>";
        }

        if (Convert.ToDouble(ds.Tables["TB_ORDER_ACCOUNT"].Rows[0]["credit"].ToString()) == 0)
        {
            ltrOverageTips.Text = "还不是安运通会员？提醒您<a href=\"/member/order/pay_sel.aspx\">立即预存</a>";
        }

        sql = "";

        sql = "SELECT UCenterHomeUid FROM TB_User WHERE userid = " + u;

        //Response.Write(sql);

        ds = cn.mdb_ds(sql, "tb_user");

        string uid = "0";

        uid = ds.Tables["tb_user"].Rows[0][0].ToString();

        if (uid == "")
        {
            uid = "0";
        }

        mysqldata_conn mysqlcn = new mysqldata_conn();

        //以下为获得“我的好友”
        sql = "SELECT friendid FROM uc_friends WHERE uid = " + uid;

        ds = mysqlcn.mdb_ds(sql, "uc_friends");


        string uidlist = "0,";

        for (int i = 0; i < ds.Tables["uc_friends"].Rows.Count; i++)
        {
            if (uid != "")
            {
                uidlist += ds.Tables["uc_friends"].Rows[i][0].ToString() + ",";
            }
        }

        uidlist += "0";

        sql = "SELECT TOP 4 * FROM V_SHOW_ALL WHERE UCenterHomeUid in (" + uidlist + ") ORDER BY POSTDATE DESC";

        ds = cn.mdb_ds(sql, "myfriends");


        Repeater1.DataSource = ds.Tables["myfriends"].DefaultView;
        Repeater1.DataBind();


        sql = "SELECT TOP 4 * FROM V_SHOW_ALL WHERE userid = " + u + " ORDER BY POSTDATE DESC";

        ds = cn.mdb_ds(sql, "mydongtai");


        Repeater2.DataSource = ds.Tables["mydongtai"].DefaultView;
        Repeater2.DataBind();


        string[] udetail;
        udetail = AllinUser1.GetUserDetail(u);

        if (udetail[11] == "0")
        {
            PlaceHolder2.Visible = true;
        }
        else
        {
            PlaceHolder2.Visible = false;
        }

        PlaceHolder3.Visible = false;

        string[][] fn=new string[8][];

        fn[0] = new string[] { "宁波市", "宁波港---美加线", "1400", "<a href=\"http://www.100allin.com/topic/supplier20101122/ningbo.aspx\" target=\"_blank\">http://www.100allin.com/topic/supplier20101122/ningbo.aspx</a>" };
        fn[1] = new string[] { "大连市", "大连港---日韩线", "1000", "<a href=\"http://www.100allin.com/topic/supplier20101122/dalian.aspx\" target=\"_blank\">http://www.100allin.com/topic/supplier20101122/dalian.aspx</a>" };
        fn[2] = new string[] { "厦门市", "厦门港---美加线", "1200", "<a href=\"http://www.100allin.com/topic/supplier20101122/xiamen.aspx\" target=\"_blank\">http://www.100allin.com/topic/supplier20101122/xiamen.aspx</a>" };
        fn[3] = new string[] { "广州市", "广州港---中东印巴线", "1000", "<a href=\"http://www.100allin.com/topic/supplier20101122/guangzhou.aspx\" target=\"_blank\">http://www.100allin.com/topic/supplier20101122/guangzhou.aspx</a>" };
        fn[4] = new string[] { "青岛市", "青岛港---中南美线", "1000", "<a href=\"http://www.100allin.com/topic/supplier20101122/qingdao.aspx\" target=\"_blank\">http://www.100allin.com/topic/supplier20101122/qingdao.aspx</a>" };
        fn[5] = new string[] { "天津市", "天津港---中南美线", "1200", "<a href=\"http://www.100allin.com/topic/supplier20101122/tianjin.aspx\" target=\"_blank\">http://www.100allin.com/topic/supplier20101122/tianjin.aspx</a>" };
        fn[6] = new string[] { "深圳市", "深圳港---美加线", "2400", "<a href=\"http://www.100allin.com/topic/supplier20101122/shenzhen.aspx\" target=\"_blank\">http://www.100allin.com/topic/supplier20101122/shenzhen.aspx</a>" };
        fn[7] = new string[] { "上海市", "上海港---澳洲线", "1500", "<a href=\"http://www.100allin.com/topic/supplier20101122/shanghai.aspx\" target=\"_blank\">http://www.100allin.com/topic/supplier20101122/shanghai.aspx</a>" };

        for (int i = 0; i <= 7; i++)
        {
            if (udetail[62] == fn[i][0])
            {
                PlaceHolder3.Visible = true;
                Literal0.Text = fn[i][0].Replace("市","");
                Literal1.Text = fn[i][1];
                Literal2.Text = fn[i][2];
                Literal3.Text = fn[i][3];
            }
        }



    }

    public string GetRequestQueryString(string q, string d)
    {
        string outputstring = d;
        if (Request.QueryString[q] != null)
        {
            if (Request.QueryString[q].ToString() != "")
            {
                outputstring = Request.QueryString[q].ToString();
            }
        }
        return outputstring;
    }//获得网页字符串参数



    public string GetRequestCookies(string c, string d)
    {
        string outputstring = d;
        if (Request.Cookies[c] != null)
        {
            if (Request.Cookies[c].Value.ToString() != "")
            {
                outputstring = Request.Cookies[c].Value.ToString();
                data_conn cd1 = new data_conn();
            }
        }
        return outputstring;
    }//获得指定Cookies参数

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
