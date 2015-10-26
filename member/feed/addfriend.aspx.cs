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

public partial class member_feed_addfriend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        order order1 = new order();
        check ck = new check();
        string u = ck.CheckNumber(order1.GetRequestQueryString("u", "0"));

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
}
