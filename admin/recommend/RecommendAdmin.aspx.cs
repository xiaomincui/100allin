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

public partial class admin_userlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (Page.IsPostBack == false)
        {
            LoadRecord(lblCurrentPage.Text);
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F7FB';");  //当鼠标停留时更改背景色 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';"); //当鼠标移开时还原背景色       
        }
    }

    public void LoadUser()
    {
        data_conn cn = new data_conn();
        DataSet ds;
        ds = cn.mdb_ds("select sum(mark) from TB_Mark where Userid=" + this.Request["RecommendUserID"], "sum");
        if (ds.Tables["sum"].Rows[0][0].ToString() == "")
        {
            Label6.Text = "0";
        }
        else
        {
            Label6.Text = ds.Tables["sum"].Rows[0][0].ToString();
        }
        
        ds = cn.mdb_ds("select Username from TB_User where Userid=" + this.Request["RecommendUserID"], "name");
        Label3.Text = ds.Tables["name"].Rows[0][0].ToString();
    }

     //载入列表信息
    public void LoadRecord(string page)
    {
        LoadUser();
        check ck = new check();


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //item是(页码-1)x10，用来计算分页用
        int item = (Convert.ToInt32(page) - 1) * 15;

        
        //改到这里
        sql = "select top 15 ";
        sql = sql + "id,mark,reason,MarkTime,Username ";
        sql = sql + "FROM (";
        sql = sql + "select TB_Mark.id,TB_Mark.mark,TB_Mark.reason,TB_Mark.MarkTime,TB_User.* from TB_Mark,TB_User where TB_User.Userid=*TB_Mark.RecommendUserID and TB_Mark.Userid=" + this.Request["RecommendUserID"];



       




        sql = sql + ") AS T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " TB_Mark.id ";
        sql = sql + "FROM ";
        sql = sql + "TB_Mark ";
        sql = sql + "WHERE ";
        sql = sql + "TB_Mark.Userid=" + this.Request["RecommendUserID"];




        sql = sql + " ORDER BY TB_Mark.id DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY id DESC";


        //this.Response.Write(sql);
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


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "select count(*) from ";
        
        sql = sql + "TB_Mark WHERE ";
        sql = sql + "TB_Mark.Userid=" + this.Request["RecommendUserID"];



      



        ds = cn.mdb_ds(sql, "count");

        //计算出页数
        int item  = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());
        int page;
        if (item % 15 > 0 || item == 0)
        {
            page = item / 15 + 1;
        }
        else
        {
            page = item / 15;
        }

        //填充下拉页码框
        for (int i = 0; i< page; i++)
        {
            ListItem l = new ListItem("第" + (i + 1).ToString() + "页", (i + 1).ToString());
            ddlPageSelect.Items.Add(l);
        }

        //最后改写总页码标签
        lblTotalItem.Text = item.ToString();
        
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
        if (id!="")
        {
            data_conn cn = new data_conn();






            
            string sql = "";
            sql = sql + "delete from TB_Mark where id in (" + id + ")";
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
        if (Convert.ToInt32(lblCurrentPage.Text.ToString())!=1)
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

        if (Convert.ToInt32(lblCurrentPage.Text.ToString())>1)
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
        if (Convert.ToInt32(lblCurrentPage.Text.ToString())<Convert.ToInt32(lblTotalPage.Text.ToString()))
        {
            lblCurrentPage.Text = (Convert.ToInt32(lblCurrentPage.Text.ToString()) + 1).ToString();
            LoadRecord(lblCurrentPage.Text);
            ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text.ToString()) - 1;
        }
        else
        {
            MessageBox("opfail", "已经是第一页");
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
            MessageBox("opfail", "已经是第一页");
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


    protected void Button1_Click(object sender, EventArgs e)
    {
        double amount;
        try
        {
            amount = Convert.ToDouble(this.txtAmount.Text);
        }
        catch (Exception a)
        {
            MessageBox("opfail", "金额为数字");
            return;
        }

        if (amount + Convert.ToDouble(Label6.Text) < 0)
        {
            MessageBox("opfail", "没有这么多的金额");
            return;
        }
        if (this.txtReason.Text.Length > 200)
        {
            MessageBox("opfail", "原因太长");
            return;
        }
        data_conn cn = new data_conn();
        cn.mdb_exe("insert into TB_Mark (UserID,mark,reason,MarkTime) values (" + this.Request["RecommendUserID"] + "," + amount.ToString() + ",'" + this.txtReason.Text + "',getdate())");
        LoadRecord(lblCurrentPage.Text);
        
    }
}
