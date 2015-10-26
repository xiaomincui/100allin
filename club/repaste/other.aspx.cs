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

public partial class club_repaste_other : System.Web.UI.Page
{
    public string pagecontrol_string;

    protected void Page_Load(object sender, EventArgs e)
    {
        login login1 = new login();
        login1.login();

        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();
        string p = "";
        p = check1.CheckNumber(GetRequest1.GetRequestQueryString("p", "1"));

        string u = "";
        u = check1.CheckNumber(GetRequest1.GetRequestQueryString("uid", "0"));

        int item = 0;
        item = (Convert.ToInt32(p) - 1) * 10;

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";
        sql += "SELECT TOP 10 * ";
        sql += "FROM (SELECT * FROM V_REPASTE_INDEX WHERE userid2 = " + u + ") AS T WHERE rid NOT IN ";
        sql += "(SELECT TOP " + item.ToString() + " rid FROM V_REPASTE_INDEX WHERE userid2 = " + u + " ORDER BY rid DESC) ORDER BY rid DESC";


        ds = cn.mdb_ds(sql, "repaste");
        Repeater1.DataSource = ds.Tables["repaste"].DefaultView;
        Repeater1.DataBind();


        sql = "SELECT rid as c FROM V_REPASTE_INDEX WHERE userid2 = " + u;
        ds = cn.mdb_ds(sql, "repaste");

        string base_url = "other.aspx?uid=" + u + "&p=";

        string end_url = "";

        int cp = Convert.ToInt32(p);
        int tp = 1;
        int count = 0;
        count = ds.Tables["repaste"].Rows.Count;

        if (count % 10 > 0 || count == 0)
        {
            tp = count / 10 + 1;
        }
        else
        {
            tp = count / 10;
        }


        string s = "";
        if (cp == 1)
        {
            //s = s + " <span class=\"selected2\">首页</span> ";
            //s = s + " <span class=\"selected2\">上一页</span> ";
            s = s + " <span class=\"selected2\">1</span> ";
            for (int i = 2; i <= (tp < 10 ? tp : 10); i++)
            {
                s = s + " <a href=\"" + base_url + "" + i + end_url + "\"><span>" + i + "</span></a> ";
            }
        }
        else
        {
            s = s + " <a href=\"" + base_url + "1" + end_url + "\"><span>首页</span></a> ";
            s = s + " <a href=\"" + base_url + (cp - 1) + end_url + "\"><span>上一页</span></a> ";
            for (int i = (cp <= 5 ? 1 : (tp - cp < 5 ? (tp - 9 < 1 ? 1 : tp - 9) : cp - 4)); i <= cp - 1; i++)
            {
                s = s + " <a href=\"" + base_url + i + end_url + "\"><span>" + i + "</span></a> ";
            }

            s = s + " <span class=\"selected2\">" + cp + "</span> ";

            for (int i = cp + 1; i <= (cp + 5 >= tp ? tp : (cp <= 5 ? (tp >= 10 ? 10 : tp) : cp + 5)); i++)
            {
                s = s + " <a href=\"" + base_url + i + end_url + "\"><span>" + i + "</span></a> ";
            }
        }


        if (cp == tp)
        {
            //s = s + " <span class=\"selected2\">下一页</span> ";
            //s = s + " <span class=\"selected2\">尾页</span> ";
        }
        else
        {
            s = s + " <a href=\"" + base_url + (cp + 1) + end_url + "\">下一页</a> ";
            s = s + " <a href=\"" + base_url + tp + end_url + "\">尾页</a> ";
        }
        pagecontrol_string = s;


        string[] udetail;
        AllinUser AllinUser1 = new AllinUser();
        udetail = AllinUser1.GetUserDetail(u);

        Literal1.Text = udetail[3];

    }




    public string NoHTML(string Htmlstring)
    {
        //删除脚本   
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML   
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
        return Htmlstring;
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
