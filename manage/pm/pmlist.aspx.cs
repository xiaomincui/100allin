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

public partial class manage_pm_pmlist : System.Web.UI.Page
{
    public string ltime1 = "";
    public string ltime2 = "";
    public string realname = "";
    public string companyname = "";

    public string p = "1";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //txt_realname.Attributes.Add("onkeyup", "autowords(this.id,event);");
            //txt_realname.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}");

            check check1 = new check();

            GetRequest GetRequest1 = new GetRequest();
            p = check1.CheckNumber(GetRequest1.GetRequestQueryString("p", "1"));

            ltime1 = check1.CheckInput(GetRequest1.GetRequestQueryString("ltime1", ""));
            ltime2 = check1.CheckInput(GetRequest1.GetRequestQueryString("ltime2", ""));
            realname = check1.CheckInput(GetRequest1.GetRequestQueryString("realname", ""));
            companyname = check1.CheckInput(GetRequest1.GetRequestQueryString("companyname", ""));

            txtDate1.Text = Server.UrlDecode(ltime1);
            txtDate2.Text = Server.UrlDecode(ltime2);
            txt_realname.Text = Server.UrlDecode(realname);
            txt_companyname.Text = Server.UrlDecode(companyname);

            LoadRecord(p);

        }


    }

    //载入列表信息 
    public void LoadRecord(string page)
    {

        check ck = new check();

        page = ck.CheckInput(page);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //item是(页码-1)x10，用来计算分页用 
        int item = 0;
        item = (Convert.ToInt32(page) - 1) * 10;

        //搜索的select语句 
        sql = "select top 10 ";
        sql = sql + "userid,Regtime,username,realname,companyname,companytype,Login2_Locus1,Login2_Locus2,phone,movephone,fax,star_allin,star_user ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "userid,Regtime,username,realname,companyname,companytype,Login2_Locus1,Login2_Locus2,phone,movephone,fax,star_allin,star_user ";
        sql = sql + "FROM ";
        sql = sql + "TB_USER ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        if (ltime1 != "")
        {
            sql = sql + "AND Regtime >= '" + ltime1 + " 00:00:00' ";
        }
        if (ltime2 != "")
        {
            sql = sql + "AND Regtime <= '" + ltime2 + " 23:59:59' ";
        }
        if (realname != "")
        {
            sql = sql + "AND realname like '%" + realname + "%' ";
        }
        if (companyname != "")
        {
            sql = sql + "AND companyname like '%" + companyname + "%' ";
        }

        sql = sql + ") AS T ";
        sql = sql + "WHERE userid NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " userid ";
        sql = sql + "FROM ";
        sql = sql + "TB_USER ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        if (ltime1 != "")
        {
            sql = sql + "AND Regtime >= '" + ltime1 + " 00:00:00' ";
        }
        if (ltime2 != "")
        {
            sql = sql + "AND Regtime <= '" + ltime2 + " 23:59:59' ";
        }
        if (realname != "")
        {
            sql = sql + "AND realname like '%" + realname + "%' ";
        }
        if (companyname != "")
        {
            sql = sql + "AND companyname like '%" + companyname + "%' ";
        }
        sql = sql + "ORDER BY Regtime DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY Regtime DESC ";

        //Response.Write(sql);

        ds = cn.mdb_ds(sql, "yunjia");

        Repeater1.DataSource = ds.Tables["yunjia"].DefaultView;
        Repeater1.DataBind();

        //计算页数 
        LoadTotalCount();
    }


    //计算页数 
    public void LoadTotalCount()
    {
        check ck = new check();

        //访问数据库，统计记录条数 
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "COUNT(*) as T ";
        sql = sql + "FROM ";
        sql = sql + "TB_USER ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        if (ltime1 != "")
        {
            sql = sql + "AND Regtime >= '" + ltime1 + " 00:00:00' ";
        }
        if (ltime2 != "")
        {
            sql = sql + "AND Regtime <= '" + ltime2 + " 23:59:59' ";
        }
        if (realname != "")
        {
            sql = sql + "AND realname like '%" + realname + "%' ";
        }
        if (companyname != "")
        {
            sql = sql + "AND companyname like '%" + companyname + "%' ";
        }

        ds = cn.mdb_ds(sql, "count");


        //计算出页数 
        int item = 0;
        item = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());


        int fakeitem = 0;
        fakeitem = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());

        int page = 0;
        if (item % 10 > 0 | item == 0)
        {
            page = item / 10 + 1;
        }
        else
        {
            page = item / 10;
        }


        //以下为页码控制栏相关 
        string s = "";
        int cp = 1;
        if ((Request.QueryString["p"] != null))
        {
            cp = Convert.ToInt32(Request.QueryString["p"].ToString());
        }
        int tp = page;

        //If tp >= 100 Then 
        // tp = 100 
        //End If 



        string base_url = "/manage/user/userlist.aspx?ltime1=" + Server.UrlEncode(ltime1) + "&ltime2=" + Server.UrlEncode(ltime2) + "&realname=" + Server.UrlEncode(realname) + "&companyname=" + Server.UrlEncode(companyname) + "&p=";

        string end_url = "";

        if (cp == 1)
        {
            s = s + "<span class=\"disabled\">|<</span> ";
            s = s + "<span class=\"disabled\"><</span> ";
            s = s + "<span class=\"current\">1</span> ";
            int i = 0;

            int di = 0;

            if (tp < 10)
            {
                di = tp;
            }
            else
            {
                di = 10;
            }

            for (i = 2; i <= di; i++)
            {
                s = s + "<a href=\"" + base_url + "" + i.ToString() + end_url + "\"><span>" + i.ToString() + "</span></a> ";

            }
        }
        else
        {
            s = s + "<a href=\"" + base_url + "1" + end_url + "\"><span>|<</span></a> ";
            s = s + "<a href=\"" + base_url + (cp - 1).ToString() + end_url + "\"><span><</span></a> ";

            int i = 0;
            int si = 1;
            int di = 1;

            if (cp <= 5)
            {
                si = 1;
            }
            else
            {
                if (tp - cp < 5)
                {
                    if (tp - 9 < 1)
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


            for (i = si; i <= cp - 1; i++)
            {
                s = s + "<a href=\"" + base_url + i.ToString() + end_url + "\"><span>" + i.ToString() + "</span></a> ";
            }

            s = s + "<span class=\"current\">" + cp.ToString() + "</span> ";


            if (cp + 5 >= tp)
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


            for (i = cp + 1; i <= di; i++)
            {
                s = s + "<a href=\"" + base_url + i.ToString() + end_url + "\"><span>" + i.ToString() + "</span></a> ";
            }
        }


        if (cp == tp)
        {
            s = s + "<span class=\"disabled\">></span> ";
            s = s + "<span class=\"disabled\">></span> ";
        }
        else
        {
            s = s + "<a href=\"" + base_url + (cp + 1).ToString() + end_url + "\"><span>></span></a> ";
            s = s + "<a href=\"" + base_url + tp.ToString() + end_url + "\"><span>>|</a> ";
        }

        Label8.Text = s;
        //以上为页码控制栏相关 

        //'最后改写总页码标签 
        //lblTotalItem.Text = item.ToString() 
        //hidTotalItem.Text = fakeitem.ToString();
        lblTotalPage.Text = tp.ToString();
        hidTotalPage.Value = tp.ToString();
        lblCurrentPage.Text = cp.ToString();

        if (item == 0)
        {
            phNorecord.Visible = true;
        }
    }


    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }


    protected void btnHidDel_Click(object sender, EventArgs e)
    {
        //删除被选择的记录
        delete();
        //重新载入当前页
        LoadRecord(p);
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string ltime1 = Server.UrlEncode(txtDate1.Text);
        string ltime2 = Server.UrlEncode(txtDate2.Text);
        string realname = Server.UrlEncode(txt_realname.Text);
        string companyname = Server.UrlEncode(txt_companyname.Text);

        Response.Redirect("userlist.aspx?ltime1=" + ltime1 + "&ltime2=" + ltime2 + "&realname=" + realname + "&companyname=" + companyname);
    }

    public void delete()
    {
        //删除信息
        //要删除的纪录的ID，保存在delList隐藏控件内
        string id = delList.Text;
        if (id != "")
        {
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";
            sql = sql + "delete from TB_USER where userid in (" + id + ")";
            cn.mdb_exe(sql);
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('删除成功')", true);

            //清空delList
            delList.Text = "";
        }
        else
        {
            //没有选择任何要删除的ID，弹出此对话框
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('未选择任何要删除的项目')", true);
        }
    }


    public string GetCompanyType(string s)
    {
        string ss = "";
        if (s == "1")
        {
            ss = "货主";
        }
        else if (s == "2")
        {
            ss = "货代";
        }
        else if (s == "3")
        {
            ss = "船东";
        }
        else if (s == "4")
        {
            ss = "其他";
        }
        else if (s == "5")
        {
            ss = "船代";
        }
        else if (s == "6")
        {
            ss = "快递";
        }
        else if (s == "7")
        {
            ss = "场站";
        }
        else if (s == "8")
        {
            ss = "仓储";
        }
        else if (s == "9")
        {
            ss = "集卡";
        }
        else if (s == "10")
        {
            ss = "报关";
        }
        else if (s == "2")
        {
            ss = "货代";
        }

        return ss;
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
