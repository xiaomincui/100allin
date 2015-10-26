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

public partial class member_pm : System.Web.UI.Page
{
    public string pagecontrol_string;
    public string pagecontrol_prev;
    public string pagecontrol_next;

    protected void Page_Load(object sender, EventArgs e)
    {
        login lg = new login();
        lg.login();

        LoadRecord();
    }

    public void LoadRecord()
    {
        check ck = new check();
        string u = "0";

        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        string p = "1";
        if (Request.QueryString["p"] != null)
        {
            p = ck.CheckInput(Request.QueryString["p"].ToString());
        }

        int item = 0;
        item = (Convert.ToInt32(p) - 1) * 10;

        //无目的港搜索的select语句 

        sql = "select top 10 ";
        if (Request.QueryString["filter"] == "my")
        {
            sql = sql + "mid,readed,chater as listener,listener as chater,txt,chattime,chattype,chater_username as listener_username,listener_username as chater_username,chater_head as listener_head,listener_head as chater_head ";
        }
        else
        {
            sql = sql + "mid,readed,chater,listener,txt,chattime,chattype,chater_username,listener_username,chater_head,listener_head ";
        }

        sql = sql + "FROM (SELECT ";
        sql = sql + "mid,readed,chater,listener,txt,chattime,chattype,chater_username,listener_username,chater_head,listener_head ";
        sql = sql + "FROM ";
        sql = sql + "V_PM ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";

        if (Request.QueryString["filter"] == "new")
        {
            sql = sql + "AND readed = 0 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "all")
        {
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "private")
        {
            sql = sql + "AND chater <> 41 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "system")
        {
            sql = sql + "AND chater = 41 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "my")
        {
            sql = sql + "AND chater = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (string.IsNullOrEmpty(Request.QueryString["filter"]))
        {
            sql = sql + "AND readed = 0 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        sql = sql + ") AS T ";
        sql = sql + "WHERE mid NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " mid ";
        sql = sql + "FROM ";
        sql = sql + "V_PM ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        if (Request.QueryString["filter"] == "new")
        {
            sql = sql + "AND readed = 0 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "all")
        {
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "private")
        {
            sql = sql + "AND chater <> 41 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "system")
        {
            sql = sql + "AND chater = 41 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "my")
        {
            sql = sql + "AND chater = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (string.IsNullOrEmpty(Request.QueryString["filter"]))
        {
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        sql = sql + "ORDER BY mid DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY mid DESC ";

        ds = cn.mdb_ds(sql, "pm");

        RptPm.DataSource = ds.Tables["pm"].DefaultView;
        RptPm.DataBind();

        //分页开始
        sql = "";
        sql += "SELECT mid FROM V_PM WHERE 1=1 ";
        if (Request.QueryString["filter"] == "new")
        {
            sql = sql + "AND readed = 0 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "all")
        {
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "private")
        {
            sql = sql + "AND chater <> 41 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "system")
        {
            sql = sql + "AND chater = 41 ";
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (Request.QueryString["filter"] == "my")
        {
            sql = sql + "AND chater = " + this.Request.Cookies["user_id"].Value.ToString();
        }

        if (string.IsNullOrEmpty(Request.QueryString["filter"]))
        {
            sql = sql + "AND listener = " + this.Request.Cookies["user_id"].Value.ToString();
        }
        ds = cn.mdb_ds(sql, "ordercount");


        string base_url = "";
        if (string.IsNullOrEmpty(Request.QueryString["filter"]))
        {
            base_url = "pm.aspx?p=";
        }
        else
        {
            base_url = "pm.aspx?filter=" + Request.QueryString["filter"].ToString() + "&p=";
        }

        string end_url = "";

        int cp = Convert.ToInt32(p);
        int tp = 1;
        int count = Convert.ToInt32(ds.Tables["ordercount"].Rows.Count.ToString());

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
            s = s + "<span class=\"nolink\">首页</span>";
            s = s + "<span class=\"nolink\">上一页</span>";
            pagecontrol_prev = "<span class=\"nolink\">上一页</span>";
            s = s + "<span class=\"current\">1</span>";
            for (int i = 2; i <= (tp < 10 ? tp : 10); i++)
            {
                s = s + "<a href=\"" + base_url + "" + i + end_url + "\"><span>" + i + "</span></a>";
            }
        }
        else
        {
            s = s + "<a href=\"" + base_url + "1" + end_url + "\"><span>首页</span></a>";
            s = s + "<a href=\"" + base_url + (cp - 1) + end_url + "\"><span>上一页</span></a>";
            pagecontrol_prev = "<a href=\"" + base_url + (cp - 1) + end_url + "\"><span>上一页&nbsp;</span></a>";
            for (int i = (cp <= 5 ? 1 : (tp - cp < 5 ? (tp - 9 < 1 ? 1 : tp - 9) : cp - 4)); i <= cp - 1; i++)
            {
                s = s + "<a href=\"" + base_url + i + end_url + "\"><span>" + i + "</span></a>";
            }

            s = s + "<span class=\"current\">" + cp + "</span>";

            for (int i = cp + 1; i <= (cp + 5 >= tp ? tp : (cp <= 5 ? (tp >= 10 ? 10 : tp) : cp + 5)); i++)
            {
                s = s + "<a href=\"" + base_url + i + end_url + "\"><span>" + i + "</span></a>";
            }
        }


        if (cp == tp)
        {
            s = s + "<span class=\"nolink\">下一页</span>";
            pagecontrol_next = "<span class=\"nolink\">下一页</span>";
            s = s + "<span class=\"nolink\">尾页</span>";
        }
        else
        {
            s = s + "<a href=\"" + base_url + (cp + 1) + end_url + "\"><span>下一页</span></a>";
            pagecontrol_next = "<a href=\"" + base_url + (cp + 1) + end_url + "\"><span>下一页</span></a>";
            s = s + "<a href=\"" + base_url + tp + end_url + "\"><span>尾页</span></a>";
        }
        pagecontrol_string = s;

        pagecontrol_string = "共" + count.ToString() + "条留言 " + pagecontrol_string;

        //分页结束
    }

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

    protected void btnHidDel_Click(object sender, EventArgs e)
    {
        string id = delList.Text;
        data_conn cn = new data_conn();
        string sql = "";
        sql = "delete from TB_PM where mid in (" + id + ")";
        cn.mdb_exe(sql);

        delList.Text = "";
        LoadRecord();
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('该条留言已删除')", true);
        
    }


    ///   <summary>
    ///   去除HTML标记
    ///   </summary>
    ///   <param   name="NoHTML">包括HTML的源码   </param>
    ///   <returns>已经去除后的文字</returns>   
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



}
