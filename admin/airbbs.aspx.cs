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
using System.Web.Security;

public partial class admin_userlist : System.Web.UI.Page
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
        if(e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F7FB';");  //当鼠标停留时更改背景色 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';"); //当鼠标移开时还原背景色       
        }
    }

     //载入列表信息
    public void LoadRecord(string page)
    {
        check ck = new check();


        
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //item是(页码-1)x10，用来计算分页用
        int item = (Convert.ToInt32(page) - 1) * 10;

        

        sql = "select top 10 ";
        sql = sql + "id,UserID ,PostDate,Data,username ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "TB_Message.id,TB_Message.UserID ,TB_Message.PostDate,TB_Message.Data,TB_User.username ";
        sql = sql + "FROM ";
        sql = sql + "TB_Message,TB_User ";
        sql = sql + "WHERE ";
        sql = sql + "TB_Message.UserID*=TB_User.UserID and BBSID=" + this.Request["id"] + " and type=3 ";




        sql = sql + ") AS T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " id ";
        sql = sql + "FROM ";
        sql = sql + "TB_Message ";
        sql = sql + "WHERE ";
        sql = sql + "BBSID=" + this.Request["id"] + " and type=3 ";


        sql = sql + "ORDER BY TB_Message.PostDate DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY PostDate DESC";

        ds = cn.mdb_ds(sql, "yunjia");

        GridView1.DataSource = ds.Tables["yunjia"].DefaultView;
        GridView1.DataKeyNames = new string[] { "id" };//主键

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

        sql = sql + "SELECT ";
        sql = sql + "count(*) as T ";
        sql = sql + "FROM ";
        sql = sql + "TB_Message ";
        sql = sql + "WHERE ";
        sql = sql + "BBSID=" + this.Request["id"] + " and type=3 ";


        ds = cn.mdb_ds(sql, "count");

        //计算出页数
        int item  = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());
        int page;
        if (item % 10 > 0 || item == 0)
        {
            page = item / 10 + 1;
        }
        else
        {
            page = item / 10;
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

   

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        LoadRecord(lblCurrentPage.Text);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        data_conn cn = new data_conn();
        string sqlstr = "delete from TB_Message where id=" + GridView1.DataKeys[e.RowIndex].Value.ToString();
        cn.mdb_exe(sqlstr);
        LoadRecord(lblCurrentPage.Text);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        LoadRecord(lblCurrentPage.Text);
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        
        data_conn cn = new data_conn();
        string sqlstr = "update TB_Message set Data='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox1"))).Text + "' where id=" + GridView1.DataKeys[e.RowIndex].Value.ToString();
        
        cn.mdb_exe(sqlstr);
        GridView1.EditIndex = -1;
        LoadRecord(lblCurrentPage.Text);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("fcllist.aspx");
    }
}
