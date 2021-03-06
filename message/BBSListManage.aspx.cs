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

public partial class message_BBSListManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.Cookies["user_id"] == null)
        {

            Response.Cookies["url"].Value = Request.Url.ToString();
            this.Response.Redirect("../member/reg.aspx");
        }
        else
        {
            if (this.Request.Cookies["user_id"].Value.ToString() == "")
            {
                Response.Cookies["url"].Value = Request.Url.ToString();
                this.Response.Redirect("../member/reg.aspx");
            }
        }

        if (!IsPostBack)
        {
            LoadRecord(lblCurrentPage.Text);
        }
    }


    public void LoadRecord(string page)
    {
        //SELECT TB_BBS.id,TB_BBS.title,TB_User.UserName,TB_BBS.Data,TB_BBS.PostDate,TB_BBS.EditDate FROM TB_BBS,TB_User where TB_BBS.UserID=TB_User.UserID
        
        data_conn cn = new data_conn();
        DataSet ds;
        int item = (Convert.ToInt32(page) - 1) * 15;
        string sql = "";
        sql = "select top 15 ";
        sql = sql + "id,title,releasename,Data,PostDate,EditDate,message,restorename,UpdateDate,hits,bbsUserid ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "TB_BBS.id,TB_BBS.title,a.UserName as releasename,TB_BBS.Data,TB_BBS.PostDate,TB_BBS.EditDate,count(TB_Message.BBSID) as message,b.UserName as restorename,TB_BBS.UpdateDate,TB_BBS.hits,TB_BBS.UserID as bbsUserid ";
        sql = sql + "FROM ";
        sql = sql + "TB_BBS,TB_User a,TB_User b,TB_Message ";
        sql = sql + "WHERE ";
        sql = sql + "TB_BBS.UserID=a.UserID and TB_Message.BBSID=*TB_BBS.id and TB_BBS.restoreName*=b.UserID and TB_BBS.UserID=" + Request.Cookies["user_id"].Value.ToString();
        sql = sql + "group by TB_BBS.id,TB_BBS.title,a.UserName,TB_BBS.Data,TB_BBS.PostDate,TB_BBS.EditDate,b.UserName,TB_BBS.UpdateDate,TB_BBS.hits,TB_BBS.UserID ";
        
        sql = sql + ") AS T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " id ";
        sql = sql + "FROM ";
        sql = sql + "TB_BBS ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 and UserID=" + Request.Cookies["user_id"].Value.ToString();
        sql = sql + " ORDER BY TB_BBS.UpdateDate DESC,TB_BBS.id  ";
        sql = sql + ") ";
        sql = sql + "ORDER BY UpdateDate DESC,id  ";

        ds = cn.mdb_ds(sql, "bbs");

        GridView1.DataSource = ds.Tables["bbs"].DefaultView;
        GridView1.DataBind();
        GridView1.Attributes.Add("bordercolor ", "#A6D4E6");
        LoadTotalCount();
    }

    protected void lnkFirstPage_Click(object sender, EventArgs e)
    {
        if( Convert.ToInt32(lblCurrentPage.Text) != 1)
        {

            lblCurrentPage.Text = "1";
            LoadRecord(lblCurrentPage.Text);
            ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;
        }
        else
        {
            MessageBox("opfail", "已经是第一页");
        }
    }
    protected void lnkPrePage_Click(object sender, EventArgs e)
    {
        if(Convert.ToInt32(lblCurrentPage.Text) > 1)
        {
            lblCurrentPage.Text = (Convert.ToInt32(lblCurrentPage.Text) - 1).ToString();
            LoadRecord(lblCurrentPage.Text);
            ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;
        }
        else
        {
            MessageBox("opfail", "已经是第一页");
        }
    }
    protected void lnkNextPage_Click(object sender, EventArgs e)
    {
            if( Convert.ToInt32(lblCurrentPage.Text) < Convert.ToInt32(lblTotalPage.Text))
            {
                lblCurrentPage.Text = (Convert.ToInt32(lblCurrentPage.Text) + 1).ToString();
                LoadRecord(lblCurrentPage.Text);
                ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;
            }
            else
            {
                MessageBox("opfail", "已经是最后页");
            }

    }
    protected void lnkLastPage_Click(object sender, EventArgs e)
    {
        if(Convert.ToInt32(lblCurrentPage.Text) != Convert.ToInt32(lblTotalPage.Text))
        {
            lblCurrentPage.Text = lblTotalPage.Text;
            LoadRecord(lblCurrentPage.Text);
            ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;
        }
        else
        {
            MessageBox("opfail", "已经是最后页");
        }
    }


    public void MessageBox(string strKey,string strInfo)
    {
        if(!ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs="alert('" + strInfo + "');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }




    //计算页数
    public void LoadTotalCount()
    {

        //先动态删除下拉页码表所有的页码
        ddlPageSelect.Items.Clear();

        check ck = new check();


        //访问数据库，统计记录条数
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string  sql = "";


        sql = sql + "SELECT ";
        sql = sql + "count(*) as T ";
        sql = sql + "FROM ";
        sql = sql + "TB_BBS ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 and UserID=" + Request.Cookies["user_id"].Value.ToString();



        ds = cn.mdb_ds(sql, "count");


       //计算出页数
        int item;
        item = (int)ds.Tables["count"].Rows[0][0];
        int page;
        if( item % 15 > 0 || item == 0 )
        {   
            page = item / 15 + 1;
        }
        else
        {
            page = item / 15;
        }



        //填充下拉页码框
        for(int i =0; i<page;i++)
        {
            ListItem l = new ListItem("第" + (i + 1).ToString()+ "页", (i + 1).ToString());
            ddlPageSelect.Items.Add(l);
        }


        //最后改写总页码标签
        lblTotalItem.Text = item.ToString();
     
        lblTotalPage.Text = page.ToString();
    }

    protected void ddlPageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        lblCurrentPage.Text = Convert.ToString(ddlPageSelect.SelectedIndex + 1);
        LoadRecord(lblCurrentPage.Text);
        ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;
    }
}
