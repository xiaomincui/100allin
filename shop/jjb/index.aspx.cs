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


public partial class shop_bloom_index : System.Web.UI.Page
{
    public string pagecontrol_string;
    public string pagecontrol_prev;
    public string pagecontrol_next;
    public string cr = "";
    public string p = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRequest GetRequest1 = new GetRequest();
            cr = GetRequest1.GetRequestQueryString("cr", "");
            p = GetRequest1.GetRequestQueryString("p", "1");
            loadRecord();
        }
    }

    public void loadRecord()
    {
        
        int item = (Convert.ToInt32(p) - 1) * 20;

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql;
        //

        sql = "select top 20 ";
        sql = sql + "id,did,sid,destport,price_p45,price_p100,price_p300,price_p500,price_p1000,distance,departurewkd,postdatex,titlex ";
        sql = sql + "from (select ";
        sql = sql + "id,airpriceid as did,airid as sid,destport,price_p45,price_p100,price_p300,price_p500,price_p1000,distance,departurewkd,postdatex,titlex ";
        sql = sql + "from  ";
        sql = sql + "TB_YunjiaInfo_Effective_10 ";
        sql = sql + "where useridx = 122117 ";
        if (cr != "")
        {
            sql = sql + "and titlex like '%" + cr + "%' ";
        }
        //sql = sql + "order by postdatex desc ";
        sql = sql + ") as T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(select top " + item.ToString() + " id ";
        sql = sql + "from ";
        sql = sql + "TB_YunjiaInfo_Effective_10 ";
        sql = sql + "where useridx = 122117 ";
        if (cr != "")
        {
            sql = sql + "and titlex like '%" + cr + "%' ";
        }
        sql = sql + "order by postdatex desc ";
        sql = sql + ") ";
        sql = sql + "order by postdatex desc ";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "yunjia");
        Repeater1.DataSource = ds.Tables["yunjia"].DefaultView;
        Repeater1.DataBind();


        sql = "SELECT COUNT(*) FROM TB_YunjiaInfo_Effective_10 ";
        sql = sql + "where useridx = 122117 ";
        if (cr != "")
        {
            sql = sql + "and titlex like '%" + cr + "%' ";
        }

        ds = cn.mdb_ds(sql, "newscount");

        string base_url = "index.aspx?cr=" + cr + "&p=";
        string end_url = "";

        int cp = Convert.ToInt32(p);
        int tp = 1;
        int count = Convert.ToInt32(ds.Tables["newscount"].Rows[0][0].ToString());

        if (count % 20 > 0 || count == 0)
        {
            tp = count / 20 + 1;
        }
        else
        {
            tp = count / 20;
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



        sql = "SELECT distinct title FROM TB_Yunjia_Effective_10 ";
        sql = sql + "where userid = 122117 ";

        ds = cn.mdb_ds(sql, "newscount");

        string airline = "";

        if (cr == "")
        {
            airline = "<b style=\"color:#DD0000;\">全部</b>&nbsp;&nbsp;&nbsp;&nbsp;";
        }
        else
        {
            airline = "<a href=\"/shop/jjb/\" style=\"color:#018AB8;\"><b>全部</b></a>&nbsp;&nbsp;&nbsp;&nbsp;";
        }

        for (int i = 0; i < ds.Tables["newscount"].Rows.Count; i++)
        {
            if (selectairline(ds.Tables["newscount"].Rows[i][0].ToString()) != "")
            {
                if (cr == selectairline(ds.Tables["newscount"].Rows[i][0].ToString()))
                {
                    airline += "<b style=\"color:#DD0000;\">" + selectairline(ds.Tables["newscount"].Rows[i][0].ToString()) + "</b>&nbsp;&nbsp;&nbsp;&nbsp;";
                }
                else
                {
                    airline += "<a href=\"/shop/jjb/index.aspx?cr=" + selectairline(ds.Tables["newscount"].Rows[i][0].ToString()) + "\" style=\"color:#018AB8;\"><b>" + selectairline(ds.Tables["newscount"].Rows[i][0].ToString()) + "</b></a>&nbsp;&nbsp;&nbsp;&nbsp;";
                }
            }
        }


        Literal1.Text = airline;


    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }


    public string selectairline(string input)
    {
        string output = "";

        string[] LineHotArray = new string[6];
        LineHotArray[0] = "EY";
        LineHotArray[1] = "UW";
        LineHotArray[2] = "SV";
        LineHotArray[3] = "QR";
        LineHotArray[4] = "HX";
        LineHotArray[5] = "GA";

        for (int i = 0; i < LineHotArray.Length - 1; i++)
        {
            if (input.IndexOf(LineHotArray[i]) != -1 & input != "")
            {
                output = LineHotArray[i].ToString();
            }
        }
        
        return output;
    }
}