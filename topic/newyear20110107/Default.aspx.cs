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

public partial class topic_newyear20110107_Default : System.Web.UI.Page
{
    public string pagecontrol_string;
    public string pagecontrol_prev;
    public string pagecontrol_next;
    public string success;

    protected void Page_Load(object sender, EventArgs e)
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();
        string p = check1.CheckNumber(GetRequest1.GetRequestQueryString("p", "1"));
        success = check1.CheckNumber(GetRequest1.GetRequestQueryString("success", "0"));

        int item = (Convert.ToInt32(p) - 1) * 5;
        if (item < 0)
        {
            item = 0;
        }

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql;

        sql = "SELECT TOP 5 ";
        sql = sql + "* ";
        sql = sql + "FROM ";
        sql = sql + "TB_NEWYEARMERRY2011 ";
        sql = sql + "WHERE nid NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " nid ";
        sql = sql + "FROM ";
        sql = sql + "TB_NEWYEARMERRY2011 ";
        sql = sql + "ORDER BY nid DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY nid DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "zhufu");
        Rptzhufu.DataSource = ds.Tables["zhufu"].DefaultView;
        Rptzhufu.DataBind();


        sql = "";
        sql = "SELECT COUNT(*) FROM TB_NEWYEARMERRY2011 ";
        ds = cn.mdb_ds(sql, "zhufu");

        string base_url = "default.aspx?p=";
        string end_url = "";


        int cp = Convert.ToInt32(p);
        int tp = 1;
        int count = Convert.ToInt32(ds.Tables["zhufu"].Rows[0][0].ToString());

        if (count % 5 > 0 || count == 0)
        {
            tp = count / 5 + 1;
        }
        else
        {
            tp = count / 5;
        }

        string s = "";
        if (cp == 1)
        {
            s = s + "<span class=\"disabled\">首页</span>";
            s = s + "<span class=\"disabled\">上一页</span>";
            pagecontrol_prev = "<span class=\"disabled\">上一页</span>";
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
            s = s + "<span class=\"disabled\">下一页</span>";
            pagecontrol_next = "<span class=\"nolink\">下一页</span>";
            s = s + "<span class=\"disabled\">尾页</span>";
        }
        else
        {
            s = s + "<a href=\"" + base_url + (cp + 1) + end_url + "\"><span>下一页</span></a>";
            pagecontrol_next = "<a href=\"" + base_url + (cp + 1) + end_url + "\"><span>下一页</span></a>";
            s = s + "<a href=\"" + base_url + tp + end_url + "\"><span>尾页</span></a>";
        }
        pagecontrol_string = s;

    }


    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
