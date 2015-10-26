﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_searchwordslist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //LoadUser();
        if (Page.IsPostBack == false)
        {
            LoadRecord(lblCurrentPage.Text);
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F7FB';");  //当鼠标停留时更改背景色 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';"); //当鼠标移开时还原背景色       
        }
    }

    //载入列表信息
    public void LoadRecord(string page)
    {
        check ck = new check();

        //取搜索条件，搜索条件保存在隐藏的label内
        //string UserID = ck.CheckInput(hidTxtYunjiaid.Text);
        //string UserName = ck.CheckInput(hidTxtLine.Text);
        //string RealName = ck.CheckInput(hidTxtStartport.Text);
        //string CompanyName = ck.CheckInput(hidTxtDestport.Text);

        string success = ck.CheckInput(hidddlSuccess.Text);
        string stype = ck.CheckInput(hidddlStype.Text);
        string line = ck.CheckInput(hidddlLine.Text);
        string startport = ck.CheckInput(hidTxtStartport.Text);
        string destport = ck.CheckInput(hidTxtDestport.Text);

        string startdate = BasicDatePicker1_TextBox.Value;
        string enddate = BasicDatePicker2_TextBox.Value;

        if (startdate != "")
        {
            startdate = startdate + " 00:00:00";
        }

        if (enddate != "")
        {
            enddate = enddate + " 23:59:59";
        }

        string uid = "";

        if (Request.QueryString["uid"] != null)
        {
            if (Request.QueryString["uid"].ToString() != "")
            {
                uid = ck.CheckInput(Request.QueryString["uid"].ToString());
            }
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //item是(页码-1)x10，用来计算分页用
        int item = (Convert.ToInt32(page) - 1) * 20;

        sql = "select top 20 ";
        sql = sql + "suserid,sid,stype,line,startport,destport,success,sop,username,companyname,stime ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "TB_SEA_SEARCHWORDS.suserid,";
        sql = sql + "TB_SEA_SEARCHWORDS.sid,";
        sql = sql + "TB_SEA_SEARCHWORDS.stype,";
        sql = sql + "TB_SEA_SEARCHWORDS.line,";
        sql = sql + "TB_SEA_SEARCHWORDS.startport,";
        sql = sql + "TB_SEA_SEARCHWORDS.destport,";
        sql = sql + "TB_SEA_SEARCHWORDS.success,";
        sql = sql + "TB_SEA_SEARCHWORDS.sop,";
        sql = sql + "tb_user.username,";
        sql = sql + "tb_user.companyname,";
        sql = sql + "TB_SEA_SEARCHWORDS.stime ";
        sql = sql + "FROM ";
        sql = sql + "tb_user,TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE ";
        sql = sql + "TB_User.UserID=TB_SEA_SEARCHWORDS.SUSERID ";

        //加入筛选条件
        if (success != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.success = " + success + " ";
        }

        if (stype != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.stype = " + stype + " ";
        }

        if (line != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.line = '" + line + "' ";
        }

        if (startport != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.startport = '" + startport + "' ";
        }

        if (destport != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.destport = '" + destport + "' ";
        }
        if (uid != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.SUSERID = " + uid;
        }

        if (startdate != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.STIME >= '" + startdate + "' ";
        }

        if (enddate != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.STIME <= '" + enddate + "' ";
        }


        sql = sql + ") AS T ";
        sql = sql + "WHERE sid NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " sid ";
        sql = sql + "FROM ";
        sql = sql + "tb_user,TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE ";
        sql = sql + "TB_User.UserID=TB_SEA_SEARCHWORDS.SUSERID ";

        //加入筛选条件
        if (success != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.success = " + success + " ";
        }

        if (stype != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.stype = " + stype + " ";
        }

        if (line != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.line = '" + line + "' ";
        }

        if (startport != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.startport = '" + startport + "' ";
        }

        if (destport != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.destport = '" + destport + "' ";
        }
        if (uid != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.SUSERID = " + uid;
        }

        if (startdate != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.STIME >= '" + startdate + "' ";
        }

        if (enddate != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.STIME <= '" + enddate + "' ";
        }

        sql = sql + "ORDER BY TB_SEA_SEARCHWORDS.stime DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY stime DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "yunjia");

        GridView1.DataSource = ds.Tables["yunjia"].DefaultView;
        GridView1.DataBind();

        //给表格加上框
        GridView1.Attributes.Add("bordercolor ", "#D9D9D9");

        //计算页数
        LoadTotalCount();

    }

    //计算页数
    public void LoadTotalCount()
    {
        //先动态删除下拉页码表所有的页码
        ddlPageSelect.Items.Clear();

        check ck = new check();
        //取搜索条件，搜索条件保存在隐藏的label内
        string success = ck.CheckInput(hidddlSuccess.Text);
        string stype = ck.CheckInput(hidddlStype.Text);
        string line = ck.CheckInput(hidddlLine.Text);
        string startport = ck.CheckInput(hidTxtStartport.Text);
        string destport = ck.CheckInput(hidTxtDestport.Text);

        string startdate = BasicDatePicker1_TextBox.Value;
        string enddate = BasicDatePicker2_TextBox.Value;

        if (startdate != "")
        {
            startdate = startdate + " 00:00:00";
        }

        if (enddate != "")
        {
            enddate = enddate + " 23:59:59";
        }

        string uid = "";

        if (Request.QueryString["uid"] != null)
        {
            if (Request.QueryString["uid"].ToString() != "")
            {
                uid = ck.CheckInput(Request.QueryString["uid"].ToString());
            }
        }

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "count(*) as T ";
        sql = sql + "FROM ";
        sql = sql + "tb_user,TB_SEA_SEARCHWORDS ";
        sql = sql + "WHERE ";
        sql = sql + "TB_User.UserID=TB_SEA_SEARCHWORDS.SUSERID ";

        ////加入筛选条件
        if (success != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.success = " + success + " ";
        }

        if (stype != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.stype = " + stype + " ";
        }

        if (line != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.line = '" + line + "' ";
        }

        if (startport != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.startport = '" + startport + "' ";
        }

        if (destport != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.destport = '" + destport + "' ";
        }
        if (uid != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.SUSERID = " + uid;
        }

        if (startdate != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.STIME >= '" + startdate + "' ";
        }

        if (enddate != "")
        {
            sql = sql + "AND TB_SEA_SEARCHWORDS.STIME <= '" + enddate + "' ";
        }

        ds = cn.mdb_ds(sql, "count");

        //计算出页数
        int item = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());
        int page;
        if (item % 20 > 0 || item == 0)
        {
            page = item / 20 + 1;
        }
        else
        {
            page = item / 20;
        }

        //填充下拉页码框
        for (int i = 0; i < page; i++)
        {
            ListItem l = new ListItem("第" + (i + 1).ToString() + "页", (i + 1).ToString());
            ddlPageSelect.Items.Add(l);
        }

        //修复页码下拉
        ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;

        //最后改写总页码标签
        lblTotalItem.Text = item.ToString();
        hidTotalItem.Text = item.ToString();
        lblTotalPage.Text = page.ToString();
    }

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
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
            sql = sql + "delete from TB_SEA_SEARCHWORDS where sid in (" + id + ")";
            cn.mdb_exe(sql);
            MessageBox("opsuccess", "删除成功");

            //清空delList
            delList.Text = "";
        }
        else
        {
            //没有选择任何要删除的ID，弹出此对话框
            MessageBox("opfail", "未选择任何要删除的项目");
        }
    }
    protected void lnkFirstPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblCurrentPage.Text.ToString()) != 1)
        {
            lblCurrentPage.Text = "1";
            LoadRecord(lblCurrentPage.Text);
            ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text.ToString()) - 1;
        }
        else
        {
            MessageBox("opfail", "已经是第一页");
        }
    }
    protected void lnkPrePage_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(lblCurrentPage.Text.ToString()) > 1)
        {
            lblCurrentPage.Text = (Convert.ToInt32(lblCurrentPage.Text.ToString()) - 1).ToString();
            LoadRecord(lblCurrentPage.Text);
            ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text.ToString()) - 1;
        }
        else
        {
            MessageBox("opfail", "已经是第一页");
        }
    }

    protected void lnkNextPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblCurrentPage.Text.ToString()) < Convert.ToInt32(lblTotalPage.Text.ToString()))
        {
            lblCurrentPage.Text = (Convert.ToInt32(lblCurrentPage.Text.ToString()) + 1).ToString();
            LoadRecord(lblCurrentPage.Text);
            ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text.ToString()) - 1;
        }
        else
        {
            MessageBox("opfail", "已经是最后一页");
        }
    }
    protected void lnkLastPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblCurrentPage.Text.ToString()) != Convert.ToInt32(lblTotalPage.Text.ToString()))
        {
            lblCurrentPage.Text = lblTotalPage.Text;
            LoadRecord(lblCurrentPage.Text);
            ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text.ToString()) - 1;
        }
        else
        {
            MessageBox("opfail", "已经是最后一页");
        }
    }
    protected void ddlPageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        int p = ddlPageSelect.SelectedIndex + 1;
        lblCurrentPage.Text = p.ToString();
        LoadRecord(lblCurrentPage.Text);
        ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text.ToString()) - 1;
    }

    protected void btnHidDel_Click(object sender, EventArgs e)
    {
        //删除被选择的记录
        delete();
        //重新载入当前页
        LoadRecord(lblCurrentPage.Text);

        //如果当前页码大于总页码，不合理，于是载入前一页

        if (Convert.ToInt32(lblCurrentPage.Text.ToString()) > Convert.ToInt32(lblTotalPage.Text.ToString()))
        {
            lblCurrentPage.Text = (Convert.ToInt32(lblCurrentPage.Text.ToString()) - 1).ToString();
            LoadRecord(lblCurrentPage.Text);
        }
        else
        {
            LoadRecord(lblCurrentPage.Text);
        }
    }

    protected void btnHidSearch_Click(object sender, EventArgs e)
    {
        //搜索条件保存在label控件内
        hidddlSuccess.Text = ddlSuccess.Text;
        hidddlStype.Text = ddlStype.Text;
        hidddlLine.Text = ddlLine.Text;
        hidTxtStartport.Text = txtStartport.Text;
        hidTxtDestport.Text = txtDestport.Text;

        //ddlSuccess.SelectedValue;

        //重新搜索，页码置1
        lblCurrentPage.Text = "1";
        LoadRecord(lblCurrentPage.Text);

        pnlSearchIntro.CssClass = "";
    }

    protected void lnkShowAll_Click(object sender, EventArgs e)
    {
        //搜索条件保存在label控件内
        hidddlSuccess.Text = "";
        hidddlStype.Text = "";
        hidddlLine.Text = "";
        hidTxtStartport.Text = "";
        hidTxtDestport.Text = "";

        ddlSuccess.SelectedIndex = 0;
        ddlStype.SelectedIndex = 0;
        ddlLine.SelectedIndex = 0;
        txtStartport.Text = "";
        txtDestport.Text = "";

        BasicDatePicker1_TextBox.Value = "";
        BasicDatePicker2_TextBox.Value = "";


        //重新搜索，页码置1
        lblCurrentPage.Text = "1";
        LoadRecord(lblCurrentPage.Text);

        pnlSearchIntro.CssClass = "hidden";
    }
}