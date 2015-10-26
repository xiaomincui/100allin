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

public partial class ship_shiplist : System.Web.UI.Page
{

    //搜索参数
    string l = "";
    //航线参数
    string n = "";
    //页码参数
    string p = "";
    //国家参数
    string c = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRequest g = new GetRequest();
        l = g.GetRequestQueryString("l", "");
        n = g.GetRequestQueryString("n", "");
        p = g.GetRequestQueryString("p", "");
        c = g.GetRequestQueryString("c", "");

        string lkey = "";
        string nkey = "";
        string ckey = "";

        if (n != "")
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select TB_Y_Line.Line,TB_Y_Line.id,count(TB_Y_Port.id) as count from TB_Y_Port,TB_Y_Line where TB_Y_Port.int_Line=TB_Y_Line.id group by  TB_Y_Line.Line,TB_Y_Line.id order by count desc", "line");
            Repeater4.DataSource = ds.Tables["line"].DefaultView;
            Repeater4.DataBind();
            divLine.Visible = true;
            if (n != "0")
            {
                DataSet ds2 = cn.mdb_ds("select * from TB_Y_Line where id=" + n, "Line");
                Literal3.Text = "<div style=\"font-size:small; margin:0px 20px 10px 20px; line-height:20px;\"><strong>" + ds2.Tables["Line"].Rows[0]["Line"].ToString() + "简介</strong><br /><br />" + ds2.Tables["Line"].Rows[0]["intro"].ToString() + "</div>";
                nkey = ds2.Tables["Line"].Rows[0]["Line"].ToString();


            }


        }
        else
        {
            divLine.Visible = false;
        }

        if (c != "")
        {


            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select top 35 TB_Y_Country.country,TB_Y_Country.id,count(TB_Y_Port.id) as count from TB_Y_Port,TB_Y_Country where TB_Y_Port.int_country=TB_Y_Country.id group by  TB_Y_Country.country,TB_Y_Country.id order by count desc", "Country");
            Repeater5.DataSource = ds.Tables["Country"].DefaultView;
            Repeater5.DataBind();
            divCountry.Visible = true;

            DataSet ds1 = cn.mdb_ds("select TB_Y_Country.country,TB_Y_Country.id,count(TB_Y_Port.id) as count from TB_Y_Port,TB_Y_Country where TB_Y_Port.int_country=TB_Y_Country.id group by  TB_Y_Country.country,TB_Y_Country.id order by count desc", "Country");
            Repeater6.DataSource = ds1.Tables["Country"].DefaultView;
            Repeater6.DataBind();


            if (ds.Tables["Country"].Select("id=" + c).Length == 0 && c != "0")
            {
                Literal2.Text = "(" + trimString(ds1.Tables["Country"].Select("id=" + c)[0]["country"].ToString(), 4) + ")";
            }
            if (c != "0")
            {
                DataSet ds2 = cn.mdb_ds("select * from TB_Y_Country where id=" + c, "country");

                Literal3.Text = "<div style=\"font-size:small; margin:0px 20px 10px 20px; line-height:20px;\"><strong>" + ds2.Tables["country"].Rows[0]["country"].ToString() + "简介</strong><br />" + ds2.Tables["country"].Rows[0]["intro"].ToString() + "</div>";
                ckey = ds2.Tables["country"].Rows[0]["country"].ToString() + "," + ds2.Tables["country"].Rows[0]["country_en"].ToString();
            }
        }
        else
        {
            divCountry.Visible = false;
            divCountry1.Visible = false;
        }



        if (!IsPostBack)
        {
            if (Request.QueryString["l"] != null)
            {
                
               

                

                
               

                LoadRecord(p);
            }
            else
            {

                LoadRecord("1");
            }



            //seo部分

            Littitle.Text = "<title>" + lkey + nkey + ckey + "港口介绍,港口代码," + lkey + nkey + ckey + "港口查询" + "-环球运费网</title>";
            Litkey.Text = "<meta name=\"keywords\" content=\"" + lkey + nkey + ckey + "港口介绍,港口代码-环球运费网\" />";
            Litdes.Text = "<meta name=\"description\" content=\"" + "环球运费网提供最全的" + lkey + nkey + ckey + "港口介绍,港口代码," + lkey + nkey + ckey + "港口详细信息查询" + "\" />";
            //seo结束
        }
    }

    

    public void LoadRecord(string page)
    {
        int item = (Convert.ToInt32(page) - 1) * 15;

        string strsql = "";
        string condition = "";

        strsql += "select top 15 * from (select * from ";
        strsql += "TB_Y_Port ";
        strsql += "where 1=1 ";

        l = l.ToUpper();

        if (l != "")
        {
            condition += "and (portname_en like '%" + l + "%' or portname like '%" + l + "%' or country_en like '%" + l + "%' or country like '%" + l + "%' or Line like '%" + l + "%' or portNum like '%" + l + "%') ";
        }
        if (n != "" && n != "0")
        {
            condition += " and int_Line=" + n;
        }
        if (c != "" && c != "0")
        {
            condition += " and int_country=" + c;
        }

        strsql += condition;

        strsql += ") as T where id not in ";
        strsql += "(select top " + item.ToString() + " id from TB_Y_Port ";
        strsql += "where 1=1 ";

        strsql += condition;

        strsql += "ORDER BY portNum )";
        strsql += "order by portNum";

        

        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds(strsql, "ship");

        Repeater1.DataSource = ds.Tables["ship"].DefaultView;
        Repeater1.DataBind();

        //计算页数
        LoadTotalCount();
        //LoadHotShip();
    }

    public void LoadHotShip()
    {
        //data_conn cn = new data_conn();
        //DataSet ds = cn.mdb_ds("select top 5 * from TB_Search_Ports order by Num desc", "hot");
        //Repeater2.DataSource = ds.Tables["hot"].DefaultView;
        //Repeater2.DataBind();
        //Repeater3.DataSource = ds.Tables["hot"].DefaultView;
        //Repeater3.DataBind();

    }

    public void LoadTotalCount()
    {
        string strsql = "";
        data_conn cn = new data_conn();
        strsql += "SELECT count(id) as T from TB_Y_Port where 1=1 ";
        if (l != "")
        {
            strsql += "and (portname_en like '%" + l + "%' or portname like '%" + l + "%' or country_en like '%" + l + "%' or country like '%" + l + "%' or Line like '%" + l + "%' or portNum like '%" + l + "%') ";
        }
        if (n != "" && n != "0")
        {
            strsql += " and int_Line=" + n;
        }

        if (c != "" && c != "0")
        {
            strsql += " and int_country=" + c;
        }

        DataSet ds = cn.mdb_ds(strsql, "count");

        int item = Convert.ToInt32(ds.Tables["count"].Rows[0][0]);
        int page;
        if (item % 15 > 0 || item == 0)
        {
            page = (item / 15) + 1;
        }
        else
        {
            page = (item / 15);
        }






        //以下为页码控制栏相关
        string s = "";
        int cp = 1;
        if (Request.QueryString["p"] != null)
        {
            cp = Convert.ToInt32(Request.QueryString["p"].ToString());
        }
        int tp = page;

        //if (tp >= 100)
        //{
        //    tp = 100;
        //}

        string base_url = "/ports/list-" + Server.UrlEncode(l) + "-" + n + "-" + c + "-----";

        string end_url = ".html";

        if (cp == 1)
        {
            s = s + "<span class='disabled'><img src='/images/fcl/jt5.gif' width='9' height='9'  border=0 /></span> ";
            s = s + "<span class='disabled'><img src='/images/fcl/jt6.GIF' border=0  /></span> ";
            s = s + "<span class='current'>1</span> ";

            int di = 0;

            if (tp < 10)
            {
                di = tp;
            }
            else
            {
                di = 10;
            }

            for (int i = 2; i < di + 1; i++)
            {
                s = s + "<a href='" + base_url + i.ToString() + end_url + "'><span>" + i.ToString() + "</span></a> ";
            }
        }
        else
        {
            s = s + "<a href=\"" + base_url + "1.html\"><span><img src='/images/fcl/jt5.gif' width='9' height='9'  border=0 /></span></a> ";
            s = s + "<a href='" + base_url + (cp - 1).ToString() + end_url + "'><span><img src='/images/fcl/jt6.GIF' border=0  /></span></a> ";

            int si = 1;
            int di = 1;

            if (cp <= 5)
            {
                si = 1;
            }
            else
            {
                if ((tp - cp) < 5)
                {
                    if ((tp - 9) < 1)
                    {
                        si = 1;
                    }
                    else
                    {
                        si = tp - 9;
                    }
                }
                else
                {
                    si = cp - 4;
                }
            }

            for (int i = si; i < cp; i++)
            {
                s = s + "<a href=\"" + base_url + i.ToString() + end_url + "\"><span>" + i.ToString() + "</span></a> ";
            }


            s = s + "<span class=\"current\">" + cp.ToString() + "</span> ";


            if ((cp + 5) >= tp)
            {
                di = tp;
            }
            else
            {
                if (cp <= 5)
                {
                    if (tp >= 10)
                    {
                        di = 10;
                    }
                    else
                    {
                        di = tp;
                    }
                }
                else
                {
                    di = cp + 5;
                }
            }

            for (int i = cp + 1; i < di + 1; i++)
            {
                s = s + "<a href=\"" + base_url + i.ToString() + end_url + "\"><span>" + i.ToString() + "</span></a> ";
            }

        }


        if (cp == tp)
        {
            s = s + "<span class=\"disabled\">下一页</span> ";
            s = s + "<span class=\"disabled\"><img src='/images/fcl/jt7.gif' width='9' height='9' border=0 /></span> ";
        }
        else
        {
            s = s + "<a href=\"" + base_url + (cp + 1).ToString() + end_url + "\"><span>下一页</span></a> ";
            s = s + "<a href=\"" + base_url + tp.ToString() + end_url + "\"><span><img src='/images/fcl/jt7.gif' width='9' height='9' border=0 /></span></a> ";
        }



        Literal1.Text = s;



    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtkey.Value != "")
        {
            data_conn cn = new data_conn();
            cn.mdb_exe("search_ports '" + txtkey.Value + "'");


            GetRequest g = new GetRequest();
            Response.Redirect("/ports/list-" + txtkey.Value + "-" + g.GetRequestQueryString("", "") + "------1.html");
        }
        else
        {
            Response.Redirect("/ports/");
        }
    }

    public string trimString(string a,int n)
    {
        if (a.Length > n)
        {
            return a.Substring(0, n) + "..";
        }
        else
        {
            return a;
        }

    }
}
