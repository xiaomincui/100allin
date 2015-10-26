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

    //船公司参数
    string l = "";
    //航线参数
    string n = "";
    //页码参数
    string p = "";

    string[] arrayLetter ={ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["l"] != null)
            {
                GetRequest g = new GetRequest();
                l = g.GetRequestQueryString("l", "");
                n = g.GetRequestQueryString("n", "");
                p = g.GetRequestQueryString("p", "1");


                //seo部分
                string nkey = "";
                string lkey = "";
                string nkey2 = "";
                if (l != "")
                {
                    lkey = l;
                }
                else if (n != "")
                {
                    nkey = n + "字母开头";
                }

                if (n != "")
                {
                    nkey2 = n + "字母开头";
                }

                

                Littitle.Text = "<title>" + lkey + nkey + "船公司," + lkey + nkey + "船公司信息," + lkey + nkey + "船公司联系方式," + lkey + nkey + "船公司查询" + "-环球运费网</title>";
                Litkey.Text = "<meta name=\"keywords\" content=\"" + nkey2 + " " + lkey + " " + "船公司-环球运费网\" />";
                Litdes.Text = "<meta name=\"description\" content=\"" + "环球运费网提供" + lkey + nkey + "船公司的介绍," + lkey + nkey + "船公司电话," + lkey + nkey + "船公司网址," + lkey + nkey + "船公司介绍等详细信息查询" + "\" />";
                //seo结束

                
                txtkey.Value = l;
                string strLetter = "";

                n = n.ToUpper();
                for (int i = 0; i < arrayLetter.Length; i++)
                {
                    if (arrayLetter[i] == n)
                    {
                        strLetter += "<a href=\"/carrier/list-" + Server.UrlEncode(l) + "-" + arrayLetter[i] + "------1.html\"><span style='color:Red'>" + arrayLetter[i] + "</span></a> ";
                    }
                    else
                    {
                        strLetter += "<a href=\"/carrier/list-" + Server.UrlEncode(l) + "-" + arrayLetter[i] + "------1.html\">" + arrayLetter[i] + "</a> ";
                    }
                }
                lclletter.Text = strLetter;

                LoadRecord(p);
            }
            else
            {
                string strLetter = "";
                for (int i = 0; i < arrayLetter.Length; i++)
                {
                    strLetter += "<a href=\"/carrier/list--" + arrayLetter[i] + "------1.html\">" + arrayLetter[i] + "</a> ";
                }
                lclletter.Text = strLetter;
                LoadRecord("1");
            }
        }
    }

    

    public void LoadRecord(string page)
    {
        int item = (Convert.ToInt32(page) - 1) * 15;

        string strsql = "";
        string condition = "";

        strsql += "select top 15 * from (select * from ";
        strsql += "TB_Ship ";
        strsql += "where 1=1 ";

        if (l != "")
        {
            condition += "and (name_cn_s like '%" + l + "%' or name_cn like '%" + l + "%' or name_en like '%" + l + "%' or name_en_s like '%" + l + "%') ";
        }
        if (n != "")
        {
            condition += "and name_en like '" + n + "%'";
        }

        strsql += condition;

        strsql += ") as T where id not in ";
        strsql += "(select top " + item.ToString() + " id from TB_Ship ";
        strsql += "where 1=1 ";

        strsql += condition;

        strsql += "ORDER BY name_en )";
        strsql += "order by name_en";

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
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select top 5 * from TB_Search_Ship order by Num desc", "hot");
        //Repeater2.DataSource = ds.Tables["hot"].DefaultView;
        //Repeater2.DataBind();
    }

    public void LoadTotalCount()
    {
        string strsql = "";
        data_conn cn = new data_conn();
        strsql += "SELECT count(id) as T from TB_Ship where 1=1 ";
        if (l != "")
        {
            strsql += "and (name_cn_s like '%" + l + "%' or name_cn like '%" + l + "%' or name_en like '%" + l + "%' or name_en_s like '%" + l + "%') ";
        }
        if (n != "")
        {
            strsql += "and name_en like '" + n + "%'";
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

        if (tp >= 100)
        {
            tp = 100;
        }

        string base_url = "/carrier/list-" + Server.UrlEncode(l) + "-" + n + "------";

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
            cn.mdb_exe("search_ship '" + txtkey.Value + "'");


            GetRequest g = new GetRequest();
            Response.Redirect("/carrier/list-" + txtkey.Value + "-" + g.GetRequestQueryString("", "") + "------1.html");
        }
        else
        {
            Response.Redirect("/carrier/");
        }
    }
}
