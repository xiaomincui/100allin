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

public partial class topic_order20091104_product_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        sql = sql + "SELECT TOP 5 ";
        sql = sql + "iflocus,";
        sql = sql + "ifadv,";
        sql = sql + "userid,";
        sql = sql + "Realname,";
        sql = sql + "Companyname,";
        sql = sql + "Phone,";
        sql = sql + "HeadURL,";
        sql = sql + "star_allin, ";
        sql = sql + "star_user, ";
        sql = sql + "Login2_Locus1,";
        sql = sql + "Login2_Locus2,";
        sql = sql + "Login2_Adventage_Type_fcl,";
        sql = sql + "Login2_Adventage_Type_lcl,";
        sql = sql + "Login2_Adventage_Type_air, ";
        sql = sql + "Login2_Adventage_Line, ";
        sql = sql + "Login2_Adventage_Line2 ";
        sql = sql + "FROM ";
        sql = sql + "V_COMPANY_USER ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 AND ifcompanyshow = 1 ";
        sql = sql + "AND CompanyType = 2 ";
        sql = sql + "ORDER BY star_allin DESC,ifadv DESC,userid DESC ";


        ds = cn.mdb_ds(sql, "company");
        RptUser.DataSource = ds.Tables["company"].DefaultView;
        RptUser.DataBind();

    }

    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
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
}
