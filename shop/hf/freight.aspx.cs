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

public partial class shop_hf_freight : System.Web.UI.Page
{
    public string pagecontrol_string;
    public string pagecontrol_prev;
    public string pagecontrol_next;
    public string destport = "";
    public string line = "";
    public string type = "";
    public string p = "";

    public string fs = "";
    public string ls = "";
    public string ll = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRequest GetRequest1 = new GetRequest();
            destport = GetRequest1.GetRequestQueryString("destport", "");
            line = GetRequest1.GetRequestQueryString("line", "");
            type = GetRequest1.GetRequestQueryString("type", "");
            p = GetRequest1.GetRequestQueryString("p", "1");


            if (type == "")
            {
                loadRecord();
                PlaceHolder1.Visible = true;
            }

            if (type == "fs")
            {
                loadRecord1();
                PlaceHolder2.Visible = true;
            }

            if (type == "ls")
            {
                loadRecord();
                PlaceHolder1.Visible = true;
            }

            if (type == "ll")
            {
                loadRecord2();
                PlaceHolder1.Visible = true;
            }
        }
    }


    public void loadRecord()
    {
        string lcldestport1 = "";
        string lcldestport2 = "";

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

 
        Literal1.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ll\">全部</a>";

        for (int i = 0; i < LineHotArray.Length - 1; i++)
        {
            Literal1.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ll&line=" + LineHotArray[i].Split(',')[1] + "&ls=" + ls + "\">" + LineHotArray[i].Split(',')[0] + "</a>";
        }

        string[] lblCarrierArray = new string[17];
        lblCarrierArray[0] = "大阪,OSAKA";
        lblCarrierArray[1] = "神户,KOBE";
        lblCarrierArray[2] = "名古屋,NAGOYA";
        lblCarrierArray[3] = "横滨,YOKOHAMA";
        lblCarrierArray[4] = "东京,TOKYO";
        lblCarrierArray[5] = "博多,HAKATA";
        lblCarrierArray[6] = "门司,MOJI";
        lblCarrierArray[7] = "胡志明市,HO CHI MINH";
        lblCarrierArray[8] = "曼谷,BANGKOK";
        lblCarrierArray[9] = "林查班,LAEM CHABANG";
        lblCarrierArray[10] = "马尼拉,MANILA";
        lblCarrierArray[11] = "香港,HONGKONG";
        lblCarrierArray[12] = "海防,HAIPANG";
        lblCarrierArray[13] = "基隆,KEELUNG";
        lblCarrierArray[14] = "台中,TAICHUNG";
        lblCarrierArray[15] = "高雄,KAOHSIUNG";


        if (destport == "")
        {
            Literal2.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">全部</b>";
            lcldestport1 = "";
            lcldestport2 = "";
        }
        else
        {
            Literal2.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ls\">全部</a>";
        }

        Literal3.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=fs\">全部</a>";

        for (int i = 0; i < lblCarrierArray.Length - 1; i++)
        {
            Literal3.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=fs&destport=" + lblCarrierArray[i].Split(',')[1] + "\">" + lblCarrierArray[i].Split(',')[0] + "(" + lblCarrierArray[i].Split(',')[1] + ")" + "</a>";
            if (lblCarrierArray[i].IndexOf(destport) != -1 & destport != "")
            {
                Literal2.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">" + lblCarrierArray[i].Split(',')[0] + "(" + lblCarrierArray[i].Split(',')[1] + ")" + "</b>";
                lcldestport1 = lblCarrierArray[i].Split(',')[0];
                lcldestport2 = lblCarrierArray[i].Split(',')[1];
            }
            else
            {

                Literal2.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ls&destport=" + lblCarrierArray[i].Split(',')[1] + "\">" + lblCarrierArray[i].Split(',')[0] + "(" + lblCarrierArray[i].Split(',')[1] + ")" + "</a>";
            }
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        int item = (Convert.ToInt32(p) - 1) * 20;

        string sql = "";

        string sql1 = "";


        sql1 = "and (destport like '%" + lcldestport1 + "%' or destport like '%" + lcldestport2 + "%') ";


        sql = "select top 20 ";
        sql = sql + "id,did,sid,userid,title,startport,destport,hangxianmiaoshu,pricegp,pricegpv,shipcompany,postdate,enddate ";
        sql = sql + "from (select ";
        sql = sql + "id,0 as did,yunjiaid as sid,useridx as userid,titlex as title,startportx as startport,destport,hangxianmiaoshux as hangxianmiaoshu,pricegp as pricegp,pricegpv as pricegpv,shipcompany as shipcompany,postdatex as postdate,enddatex as enddate ";
        sql = sql + "from  ";
        sql = sql + "TB_YunjiaInfo_Effective_9 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }
        sql = sql + ") as T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(select top " + item.ToString() + " id ";
        sql = sql + "from ";
        sql = sql + "TB_YunjiaInfo_Effective_9 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }
        sql = sql + "order by postdate desc ";
        sql = sql + ") ";
        sql = sql + "order by postdate desc ";

        //Response.Write(sql);


        ds = cn.mdb_ds(sql, "xhf");

        Repeater1.DataSource = ds.Tables["xhf"].DefaultView;
        Repeater1.DataBind();



        sql = "SELECT COUNT(*) FROM TB_YunjiaInfo_Effective_9 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }


        ds = cn.mdb_ds(sql, "newscount");


        string base_url = "freight.aspx?fs=" + fs + "&ls=" + ls + "&ll=" + ll + "&p=";
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


    public void loadRecord1()
    {
        string fcldesttport1 = "";
        string fcldesttport2 = "";

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


        Literal1.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ll\">全部</a>";

        for (int i = 0; i < LineHotArray.Length - 1; i++)
        {
            Literal1.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ll&line=" + LineHotArray[i].Split(',')[1] + "&ls=" + ls + "\">" + LineHotArray[i].Split(',')[0] + "</a>";
        }

        string[] lblDestportArray = new string[13];
        lblDestportArray[0] = "大阪,OSAKA";
        lblDestportArray[1] = "神户,KOBE";
        lblDestportArray[2] = "名古屋,NAGOYA";
        lblDestportArray[3] = "横滨,YOKOHAMA";
        lblDestportArray[4] = "东京,TOKYO";
        lblDestportArray[5] = "博多,BODO";
        lblDestportArray[6] = "门司,MOJI";
        lblDestportArray[7] = "胡志明市,HO CHI MINH";
        lblDestportArray[8] = "曼谷,BANGKOK";
        lblDestportArray[9] = "林查班,LAEM CHABANG";
        lblDestportArray[10] = "马尼拉,MANILA";
        lblDestportArray[11] = "香港,HONGKONG";
        lblDestportArray[12] = "海防,HAIPANG";


        if (destport == "")
        {
            Literal3.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">全部</b>";
            fcldesttport1 = "";
            fcldesttport2 = "";
        }
        else
        {
            Literal3.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=fs\">全部</a>";
        }

        Literal2.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ls\">全部</a>";

        for (int i = 0; i < lblDestportArray.Length - 1; i++)
        {
            Literal2.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ls&destport=" + lblDestportArray[i].Split(',')[1] + "\">" + lblDestportArray[i].Split(',')[0] + "(" + lblDestportArray[i].Split(',')[1] + ")" + "</a>";
            if (lblDestportArray[i].IndexOf(destport) != -1 & destport != "")
            {
                Literal3.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">" + lblDestportArray[i].Split(',')[0] + "(" + lblDestportArray[i].Split(',')[1] + ")" + "</b>";
                fcldesttport1 = lblDestportArray[i].Split(',')[0];
                fcldesttport2 = lblDestportArray[i].Split(',')[1];
            }
            else
            {

                Literal3.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=fs&destport=" + lblDestportArray[i].Split(',')[1] + "\">" + lblDestportArray[i].Split(',')[0] + "(" + lblDestportArray[i].Split(',')[1] + ")" + "</a>";
            }
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        int item = (Convert.ToInt32(p) - 1) * 20;

        string sql = "";
        string sql1 = "";

        if (destport != "" & destport != "all")
        {
            sql1 = "and (destport like '%" + fcldesttport1 + "%' or destport like '%" + fcldesttport2 + "%') ";
        }

        sql = "select top 20 ";
        sql = sql + "id,did,sid,userid,title,startport,destport,hangxianmiaoshu,price20gp,price40gp,price40hq,price45hq,shipcompany,postdate,enddate ";
        sql = sql + "from (select ";
        sql = sql + "id,0 as did,yunjiaid as sid,useridx as userid,titlex as title,startportx as startport,destport,hangxianmiaoshux as hangxianmiaoshu,price20gp as price20gp,price40gp as price40gp,price40hq as price40hq,price45hq as price45hq,shipcompany as shipcompany,postdatex as postdate,enddatex as enddate ";
        sql = sql + "from  ";
        sql = sql + "TB_YunjiaInfo_Effective_8 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }
        sql = sql + ") as T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(select top " + item.ToString() + " id ";
        sql = sql + "from ";
        sql = sql + "TB_YunjiaInfo_Effective_8 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }
        sql = sql + "order by postdate desc ";
        sql = sql + ") ";
        sql = sql + "order by postdate desc ";

        //Response.Write(sql);


        ds = cn.mdb_ds(sql, "xhf");

        Repeater2.DataSource = ds.Tables["xhf"].DefaultView;
        Repeater2.DataBind();



        sql = "SELECT COUNT(*) FROM TB_YunjiaInfo_Effective_8 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }


        ds = cn.mdb_ds(sql, "newscount");


        string base_url = "freight.aspx?type=" + type + "&destport=" + destport + "&p=";
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


    public void loadRecord2()
    {

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

        if (line == "")
        {
            Literal1.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">全部</b>";
            line = "";

        }
        else
        {
            Literal1.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ll\">全部</a>";
        }
        for (int i = 0; i < LineHotArray.Length - 1; i++)
        {
            if (LineHotArray[i].IndexOf(line) != -1 & line != "")
            {
                Literal1.Text += "&nbsp;&nbsp;" + "<b style=\"color:#FF6600\">" + LineHotArray[i].Split(',')[0] + "</b>";
                line = LineHotArray[i].Split(',')[0];

            }
            else
            {

                Literal1.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ll&line=" + LineHotArray[i].Split(',')[1] + "\">" + LineHotArray[i].Split(',')[0] + "</a>";
            }
        }



        string[] lblCarrierArray = new string[13];
        lblCarrierArray[0] = "大阪,OSAKA";
        lblCarrierArray[1] = "神户,KOBE";
        lblCarrierArray[2] = "名古屋,NAGOYA";
        lblCarrierArray[3] = "横滨,YOKOHAMA";
        lblCarrierArray[4] = "东京,TOKYO";
        lblCarrierArray[5] = "博多,BODO";
        lblCarrierArray[6] = "门司,MOJI";
        lblCarrierArray[7] = "胡志明市,HO CHI MINH";
        lblCarrierArray[8] = "曼谷,BANGKOK";
        lblCarrierArray[9] = "林查班,LAEM CHABANG";
        lblCarrierArray[10] = "马尼拉,MANILA";
        lblCarrierArray[11] = "香港,HONGKONG";
        lblCarrierArray[12] = "海防,HAIPANG";

        Literal2.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ls\">全部</a>";
        Literal3.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=fs\">全部</a>";

        for (int i = 0; i < lblCarrierArray.Length - 1; i++)
        {
            Literal2.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=ls&destport" + lblCarrierArray[i].Split(',')[1] + "\">" + lblCarrierArray[i].Split(',')[0] + "(" + lblCarrierArray[i].Split(',')[1] + ")" + "</a>";
            Literal3.Text += "&nbsp;&nbsp;" + "<a href = \"freight.aspx?type=fs&destport" + lblCarrierArray[i].Split(',')[1] + "\">" + lblCarrierArray[i].Split(',')[0] + "(" + lblCarrierArray[i].Split(',')[1] + ")" + "</a>";
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        int item = (Convert.ToInt32(p) - 1) * 20;

        string sql = "";

        string sql1 = "";

        if (line != "" & line != "all")
        {
            sql1 = "and hangxianmiaoshux = '" + line + "' ";
        }


        sql = "select top 20 ";
        sql = sql + "id,did,sid,userid,title,startport,destport,hangxianmiaoshu,pricegp,pricegpv,shipcompany,postdate,enddate ";
        sql = sql + "from (select ";
        sql = sql + "id,0 as did,yunjiaid as sid,useridx as userid,titlex as title,startportx as startport,destport,hangxianmiaoshux as hangxianmiaoshu,pricegp as pricegp,pricegpv as pricegpv,shipcompany as shipcompany,postdatex as postdate,enddatex as enddate ";
        sql = sql + "from  ";
        sql = sql + "TB_YunjiaInfo_Effective_9 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }
        sql = sql + ") as T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(select top " + item.ToString() + " id ";
        sql = sql + "from ";
        sql = sql + "TB_YunjiaInfo_Effective_9 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }
        sql = sql + "order by postdate desc ";
        sql = sql + ") ";
        sql = sql + "order by postdate desc ";

        //Response.Write(sql);


        ds = cn.mdb_ds(sql, "xhf");

        Repeater1.DataSource = ds.Tables["xhf"].DefaultView;
        Repeater1.DataBind();



        sql = "SELECT COUNT(*) FROM TB_YunjiaInfo_Effective_9 ";
        sql = sql + "where useridx = 2061 ";
        if (sql1 != "")
        {
            sql = sql + sql1;
        }


        ds = cn.mdb_ds(sql, "newscount");


        string base_url = "freight.aspx?fs=" + fs + "&ls=" + ls + "&ll=" + ll + "&p=";
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
