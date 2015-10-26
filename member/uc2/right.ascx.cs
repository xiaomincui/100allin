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
using System.Text.RegularExpressions;
using System.Text;

public partial class member_uc_right : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        string u = "0";

        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        sql = "SELECT UCenterHomeUid FROM TB_User WHERE userid = " + u;

        //Response.Write(sql);

        ds = cn.mdb_ds(sql, "tb_user");

        string uid = "0";
        
        uid = ds.Tables["tb_user"].Rows[0][0].ToString();

        mysqldata_conn mysqlcn = new mysqldata_conn();


        //以下为获得“我的好友”
        sql = "SELECT friendid FROM uc_friends WHERE uid = " + uid;

        ds = mysqlcn.mdb_ds(sql, "uc_friends");

        ltrMyFriendCount.Text = ds.Tables["uc_friends"].Rows.Count.ToString();

        string uidlist = "";

        for (int i = 0; i < ds.Tables["uc_friends"].Rows.Count; i++)
        {
            if (uid != "")
            {
                uidlist += ds.Tables["uc_friends"].Rows[i][0].ToString() + ",";
            }
            
        }

        uidlist += "999999";

        sql = "SELECT TOP 3 * FROM TB_User WHERE UCenterHomeUid in (" + uidlist + ") ORDER BY USERID";

        ds = cn.mdb_ds(sql, "myfriends");



        RptMyFriends.DataSource = ds.Tables["myfriends"].DefaultView;
        RptMyFriends.DataBind();


        //以下为获得“最近来访”
        sql = "SELECT vuid FROM uchome_visitor WHERE uid = " + uid + " ORDER BY dateline DESC ";

        //Response.Write(sql);

        ds = mysqlcn.mdb_ds(sql, "uchome_visitor");

        ltrVisitFriendCount.Text = ds.Tables["uchome_visitor"].Rows.Count.ToString();

        uidlist = "";

        for (int i = 0; i < ds.Tables["uchome_visitor"].Rows.Count; i++)
        {
            if (uid != "")
            {
                uidlist += ds.Tables["uchome_visitor"].Rows[i][0].ToString() + ",";
            }
        }

        uidlist += "999999";

        sql = "SELECT TOP 3 * FROM TB_User WHERE UCenterHomeUid in (" + uidlist + ") ";
        sql += "ORDER BY PATINDEX('% ' + CONVERT(nvarchar(4000), UCenterHomeUid) + ' %', ' ' + CONVERT(nvarchar(4000), REPLACE('" + uidlist + "',',', ' , ')) + ' ')";

        //Response.Write(sql);

        ds = cn.mdb_ds(sql, "visitfriends");


        RptVisitFriends.DataSource = ds.Tables["visitfriends"].DefaultView;
        RptVisitFriends.DataBind();
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
            }
        }
        return outputstring;
    }//获得指定Cookies参数

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
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
}
