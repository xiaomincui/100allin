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

public partial class member_pm_detail_all : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        login lg = new login();
        lg.login();

        LoadRecord();
    }

    public void LoadRecord()
    {
        check ck = new check();
        string id = "0";

        id = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        string cid = "0";
        cid = ck.CheckNumber(GetRequestQueryString("cid", "0"));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        int item = 0;

        //无目的港搜索的select语句 

        sql = sql + "SELECT ";
        sql = sql + "mid,readed,chater,listener,txt,chattime,chattype,chater_username,listener_username,chater_head,listener_head, ";

        if (cid == "41")
        {
            sql = sql + "'<b style=''color:red''>' + " + "chater_username " + " + '</b>' as chater_username ";
        }
        else
        {
            sql = sql + "chater_username ";
        }

        sql = sql + "FROM ";
        sql = sql + "V_PM ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        sql = sql + " AND (listener = " + id;
        sql = sql + " AND chater = " + cid;
        sql = sql + " ) OR (listener = " + cid;
        sql = sql + " AND chater = " + id;
        sql = sql + ")";


        ds = cn.mdb_ds(sql, "pm");

        RptPm.DataSource = ds.Tables["pm"].DefaultView;
        RptPm.DataBind();

        sql = "SELECT ";
        sql = sql + "RealName ";
        sql = sql + "FROM ";
        sql = sql + "TB_User ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        sql = sql + " AND userid = " + cid;

        ds = cn.mdb_ds(sql, "user");

        Literal1.Text = ds.Tables["user"].Rows[0]["RealName"].ToString();

        if (cid == "41")
        {
            Literal1.Text = "<b style='color:red'>" + Literal1.Text + "</b>";
        }

        sql = "update V_PM set readed = 1 where listener = " + id;
        sql = sql + " AND chater = " + cid;

        cn.mdb_exe(sql);
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

    protected string Encode(string str)
    {
        str = str.Replace("&", "&amp;");
        str = str.Replace("'", "''");
        str = str.Replace("\\", "&amp;");
        str = str.Replace(" ", "&nbsp;");
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt;");
        str = str.Replace("\r\n", "<br />");
        return str;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        pm p = new pm();
        check ck = new check();
        string id = "0";
        id = ck.CheckNumber(GetRequestCookies("user_id", "0"));
        string cid = "0";
        cid = ck.CheckNumber(GetRequestQueryString("cid", "0"));
        if (TextBox1.Text.Length > 200)
        {
            Label2.Text = "一次发送不能超过200字哦";
            Label2.Visible = true;
        }
        else
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                Label2.Text = "请输入留言内容";
                Label2.Visible = true;
                TextBox1.Text = "";
            }
            else
            {
                p.sendpm(id, cid, Encode(TextBox1.Text), "1");
                //ScriptManager.RegisterStartupScript(Button1, Button1.GetType(), "Alert", "alert('" & Encode(TextBox1.Text) & "')", True) 
                TextBox1.Text = "";
                LoadRecord();
                Label2.Visible = false;
            }
        }
    }
}
