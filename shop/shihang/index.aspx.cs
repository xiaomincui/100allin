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
    public string l = "";
    public string p = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRequest GetRequest1 = new GetRequest();
            cr = GetRequest1.GetRequestQueryString("cr", "");
            l = GetRequest1.GetRequestQueryString("l", "");
            p = GetRequest1.GetRequestQueryString("p", "1");
            loadRecord();
        }
    }


    public void loadRecord()
    {
        string line = "";
        string carrier = "";
        Literal3.Text = "全部航线";

        string[] LineHotArray = new string[9];
        LineHotArray[0] = "美加线,1";
        LineHotArray[1] = "非洲线,6";
        LineHotArray[2] = "中东印巴线,8";
        LineHotArray[3] = "中南美线,3";
        LineHotArray[4] = "欧地线,2";
        LineHotArray[5] = "日韩线,4";
        LineHotArray[6] = "近洋线,5";
        LineHotArray[7] = "澳洲线,7";
        LineHotArray[8] = "红海线,9";

        if (l == "")
        {
            Literal1.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">全部</b>";
            line = "";
            Literal3.Text = "全部航线";
        }
        else
        {
            Literal1.Text += "&nbsp;&nbsp;" + "<a href = \"index.aspx?l=&cr=" + cr + "\">全部</a>";
        }
        for (int i = 0; i < LineHotArray.Length - 1; i++)
        {
            if (LineHotArray[i].IndexOf(l) != -1 & l != "")
            {
                Literal1.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">" + LineHotArray[i].Split(',')[0] + "</b>";
                line = LineHotArray[i].Split(',')[0];
                Literal3.Text = LineHotArray[i].Split(',')[0];
            }
            else
            {

                Literal1.Text += "&nbsp;&nbsp;" + "<a href = \"index.aspx?l=" + LineHotArray[i].Split(',')[1] + "&cr=" + cr + "\">" + LineHotArray[i].Split(',')[0] + "</a>";
            }
        }



        string[] lblCarrierArray = new string[12];
        lblCarrierArray[0] = "地中海,MSC";
        lblCarrierArray[1] = "马航,MISC";
        lblCarrierArray[2] = "南飞轮船,SAFMRINE";
        lblCarrierArray[3] = "东方海外,OOCL";
        lblCarrierArray[4] = "MCC运输,MCC";
        lblCarrierArray[5] = "高丽,KMTC";
        lblCarrierArray[6] = "商船三井,MOL";
        lblCarrierArray[7] = "达贸,DELMAS";
        lblCarrierArray[8] = "以星,ZIM";
        lblCarrierArray[9] = "韩国泛海,PAN OCEAN";
        lblCarrierArray[10] = "汉堡,HBS";
        lblCarrierArray[11] = "海南泛洋,POS";

        if (cr == "")
        {
            //Literal2.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">全部</b>";
            carrier = "";
            Literal4.Text = "EMC";
        }
        else
        {
            //Literal2.Text += "&nbsp;&nbsp;" + "<a href = \"index.aspx?l=" + l + "&cr=\">全部</a>";
        }

        for (int i = 0; i < lblCarrierArray.Length - 1; i++)
        {
            if (lblCarrierArray[i].IndexOf(cr) != -1 & cr != "")
            {
                //Literal2.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">" + lblCarrierArray[i].Split(',')[0] + "</b>";
                carrier = lblCarrierArray[i].Split(',')[1];
                Literal4.Text = lblCarrierArray[i].Split(',')[0];
            }
            else
            {

                //Literal2.Text += "&nbsp;&nbsp;" + "<a href = \"index.aspx?l=" + l + "&cr=" + lblCarrierArray[i].Split(',')[1] + "\">" + lblCarrierArray[i].Split(',')[0] + "</a>";
            }
        }
        
        int item = (Convert.ToInt32(p) - 1) * 20;


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql;
        //

        sql = "select top 20 ";
        sql = sql + "id,did,sid,destport,price20gp,price40gp,price40hq,price45hq,shipcompany,postdatex ";
        sql = sql + "from (select ";
        sql = sql + "id,yunjiainfoid as did,yunjiaid as sid,destport,price20gp,price40gp,price40hq,price45hq,shipcompany,postdatex ";
        sql = sql + "from  ";
        sql = sql + "TB_YunjiaInfo_Effective_8 ";
        sql = sql + "where useridx = 105346 and shipcompany like '%emc%' ";
        if (line != "")
        {
            sql = sql + "and hangxianmiaoshux = '" + line + "' ";
        }

        //sql = sql + "order by postdatex desc ";
        sql = sql + ") as T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(select top " + item.ToString() + " id ";
        sql = sql + "from ";
        sql = sql + "TB_YunjiaInfo_Effective_8 ";
        sql = sql + "where useridx = 105346 and shipcompany like '%emc%' ";
        if (line != "")
        {
            sql = sql + "and hangxianmiaoshux = '" + line + "' ";
        }

        sql = sql + "order by postdatex desc ";
        sql = sql + ") ";
        sql = sql + "order by postdatex desc ";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "yunjia");
        Repeater1.DataSource = ds.Tables["yunjia"].DefaultView;
        Repeater1.DataBind();


        sql = "SELECT COUNT(*) FROM TB_YunjiaInfo_Effective_8 ";
        sql = sql + "where useridx = 105346 and shipcompany like '%emc%' ";
        if (line != "")
        {
            sql = sql + "and hangxianmiaoshux = '" + line + "' ";
        }


        ds = cn.mdb_ds(sql, "newscount");


        string base_url = "index.aspx?l=" +l + "&cr=" + cr + "&p=";
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


    }



    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

}
