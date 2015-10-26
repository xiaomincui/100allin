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

public partial class manage_priceneed_pricelist : System.Web.UI.Page
{
    public string city = "";

    //起运港参数 
    public string sp = "";
    //目的港参数 
    public string dp = "";
    //航线参数 
    public string l = "";
    //页码参数 
    public string p = "";
    //排序参数 
    public string order = "0";
    //船公司参数 
    public string cr = ""; 

    protected void Page_Load(object sender, EventArgs e)
    {


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";
        check check1 = new check();


        GetRequest GetRequest1 = new GetRequest();
        p = check1.CheckNumber(GetRequest1.GetRequestQueryString("p", "1"));

        sp = check1.CheckInput(GetRequest1.GetRequestQueryString("sp", ""));
        dp = check1.CheckInput(GetRequest1.GetRequestQueryString("dp", ""));
        l = check1.CheckInput(GetRequest1.GetRequestQueryString("l", ""));
        cr = check1.CheckInput(GetRequest1.GetRequestQueryString("cr", ""));


        LoadRecord(p); 
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
        item = (Convert.ToInt32(page) - 1) * 20;

        //搜索的select语句 
        sql = "select top 20 ";
        sql = sql + "SID,STIME,STARTPORT,DESTPORT,CARRIER,LINE,STYPE,REALNAME,COMPANYNAME,USEREMAIL ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "SID,STIME,STARTPORT,DESTPORT,CARRIER,LINE,STYPE,REALNAME,COMPANYNAME,USEREMAIL ";
        sql = sql + "FROM ";
        sql = sql + "V_LOST_PRICE ";
        sql = sql + "WHERE ";
        sql = sql + "1=1";
        if (!string.IsNullOrEmpty(sp))
        {
            sql = sql + "AND (STARTPORT = '" + sp + "' OR STARTPORT_2 = '" + sp + "')";
        }
        if (!string.IsNullOrEmpty(dp))
        {
            sql = sql + "AND (DESTPORT = '" + dp + "' OR DESTPORT_2 = '" + dp + "')";
        }

        sql = sql + ") AS T ";
        sql = sql + "WHERE SID NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " SID ";
        sql = sql + "FROM ";
        sql = sql + "V_LOST_PRICE ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        if (!string.IsNullOrEmpty(sp))
        {
            sql = sql + "AND (STARTPORT = '" + sp + "' OR STARTPORT_2 = '" + sp + "')";
        }
        if (!string.IsNullOrEmpty(dp))
        {
            sql = sql + "AND (DESTPORT = '" + dp + "' OR DESTPORT_2 = '" + dp + "')";
        }

        sql = sql + "ORDER BY STIME DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY STIME DESC ";

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
        sql = sql + "V_LOST_PRICE ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        if (!string.IsNullOrEmpty(sp))
        {
            sql = sql + "AND (STARTPORT = '" + sp + "' OR STARTPORT_2 = '" + sp + "')";
        }
        if (!string.IsNullOrEmpty(dp))
        {
            sql = sql + "AND (DESTPORT = '" + dp + "' OR DESTPORT_2 = '" + dp + "')";
        }

        ds = cn.mdb_ds(sql, "count");


        //计算出页数 
        int item = 0;
        item = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());


        int fakeitem = 0;
        fakeitem = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());

        int page = 0;
        if (item % 20 > 0 | item == 0)
        {
            page = item / 20 + 1;
        }
        else
        {
            page = item / 20;
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


        string base_url = "/manage/priceneed/pricelist.aspx?sp=" + Server.UrlEncode(sp) + "&dp=" + Server.UrlEncode(dp) + "&l=" + Server.UrlEncode(l) + "&cr=" + Server.UrlEncode(cr) + "&p=";

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
            sql = sql + "delete from TB_LOST_PRICE where sid in (" + id + ")";
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

}
