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

public partial class manage_priceneed_linelist : System.Web.UI.Page
{
    public string ltype = "";
    public string ltime1 = "";
    public string ltime2 = "";
    public string lftype = "";
    public string startport = "";
    public string line = "";
    public string lhidden = "";

    public string p = "1";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txt_lstartport.Attributes.Add("onkeyup", "autowords(this.id,event);");
            txt_lstartport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}");

            for (int i = 0; i < rbl_lftype.Items.Count; i++)
            {
                rbl_lftype.Items[i].Attributes.Add("onclick", "selectftype();");
            }

            rbl_line2.Attributes.Add("style", "display:none;");


            check check1 = new check();

            GetRequest GetRequest1 = new GetRequest();
            p = check1.CheckNumber(GetRequest1.GetRequestQueryString("p", "1"));

            ltype = check1.CheckInput(GetRequest1.GetRequestQueryString("ltype", ""));
            ltime1 = check1.CheckInput(GetRequest1.GetRequestQueryString("ltime1", ""));
            ltime2 = check1.CheckInput(GetRequest1.GetRequestQueryString("ltime2", ""));
            lftype = check1.CheckInput(GetRequest1.GetRequestQueryString("lftype", ""));
            startport = check1.CheckInput(GetRequest1.GetRequestQueryString("startport", ""));
            line = check1.CheckInput(GetRequest1.GetRequestQueryString("line", ""));
            lhidden = check1.CheckInput(GetRequest1.GetRequestQueryString("lhidden", ""));


            rbl_ltype.SelectedValue = Server.UrlDecode(ltype);
            txtDate1.Text = Server.UrlDecode(ltime1);
            txtDate2.Text = Server.UrlDecode(ltime2);
            rbl_lftype.SelectedValue = Server.UrlDecode(lftype);
            txt_lstartport.Text = Server.UrlDecode(startport);

            if (lftype == "10")
            {
                rbl_line2.SelectedValue = line;
                rbl_line2.Attributes.Remove("style");
                rbl_line1.Attributes.Add("style", "display:none;");
            }
            else
            {
                rbl_line1.SelectedValue = line;
            }

            rbl_hidden.SelectedValue = Server.UrlDecode(lhidden);

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
        item = (Convert.ToInt32(page) - 1) * 20;

        //搜索的select语句 
        sql = "select top 20 ";
        sql = sql + "lid,startport,line,ltime,lftype,ltype,lorder,lhot,lhidden ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "lid,startport,line,ltime,lftype,ltype,lorder,lhot,lhidden ";
        sql = sql + "FROM ";
        sql = sql + "TB_LOST_LINE ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        
        if (ltype != "")
        {
            sql = sql + "AND ltype = " + ltype + " ";
        }
        if (ltime1 != "")
        {
            sql = sql + "AND ltime >= '" + ltime1 + " 00:00:00' ";
        }
        if (ltime2 != "")
        {
            sql = sql + "AND ltime <= '" + ltime2 + " 23:59:59' ";
        }
        if (lftype != "")
        {
            sql = sql + "AND lftype = " + lftype + " ";
        }
        if (startport != "")
        {
            sql = sql + "AND startport like '%" + startport + "%' ";
        }
        if (line != "")
        {
            sql = sql + "AND line = '" + line + "' ";
        }
        if (lhidden != "")
        {
            sql = sql + "AND lhidden = " + lhidden + " ";
        }

        sql = sql + ") AS T ";
        sql = sql + "WHERE lid NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " lid ";
        sql = sql + "FROM ";
        sql = sql + "TB_LOST_LINE ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        if (ltype != "")
        {
            sql = sql + "AND ltype = " + ltype + " ";
        }
        if (ltime1 != "")
        {
            sql = sql + "AND ltime >= '" + ltime1 + " 00:00:00' ";
        }
        if (ltime2 != "")
        {
            sql = sql + "AND ltime <= '" + ltime2 + " 23:59:59' ";
        }
        if (lftype != "")
        {
            sql = sql + "AND lftype = " + lftype + " ";
        }
        if (startport != "")
        {
            sql = sql + "AND startport like '%" + startport + "%' ";
        }
        if (line != "")
        {
            sql = sql + "AND line = '" + line + "' ";
        }
        if (lhidden != "")
        {
            sql = sql + "AND lhidden = " + lhidden + " ";
        }

        sql = sql + "ORDER BY lorder DESC,lhot DESC,ltime DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY lorder DESC,lhot DESC,ltime DESC ";

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
        sql = sql + "TB_LOST_LINE ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        if (ltype != "")
        {
            sql = sql + "AND ltype = " + ltype + " ";
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



        string base_url = "/manage/priceneed/linelist.aspx?ltype=" + Server.UrlEncode(ltype) + "&ltime1=" + Server.UrlEncode(ltime1) + "&ltime2=" + Server.UrlEncode(ltime2) + "&lftype=" + Server.UrlEncode(lftype) + "&startport=" + Server.UrlEncode(startport) + "&line=" + Server.UrlEncode(line) + "&lhidden=" + Server.UrlEncode(lhidden) + "&p=";

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
        string ltype = Server.UrlEncode(rbl_ltype.SelectedValue);
        string ltime1 = Server.UrlEncode(txtDate1.Text);
        string ltime2 = Server.UrlEncode(txtDate2.Text);
        string lftype = Server.UrlEncode(rbl_lftype.SelectedValue);
        string startport = Server.UrlEncode(txt_lstartport.Text);
        string line = Server.UrlEncode(rbl_line1.SelectedValue);
        if (lftype == "10")
        {
            line = Server.UrlEncode(rbl_line2.SelectedValue);
        }
        else
        {
            line = Server.UrlEncode(rbl_line1.SelectedValue);
        }
        string lhidden = Server.UrlEncode(rbl_hidden.SelectedValue);

        Response.Redirect("linelist.aspx?ltype=" + ltype + "&ltime1=" + ltime1 + "&ltime2=" + ltime2 + "&lftype=" + lftype + "&startport=" + startport + "&line=" + line + "&lhidden=" + lhidden);
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
            sql = sql + "delete from TB_LOST_LINE where lid in (" + id + ")";
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
