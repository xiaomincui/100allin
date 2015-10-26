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

public partial class admin_sales_myprecustomer : System.Web.UI.Page
{
    public string admin_id = "0";
    public string admin_name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRequest GetRequest1 = new GetRequest();
        admin_id = GetRequest1.GetRequestCookies("admin_id", "0");
        admin_name = GetRequest1.GetRequestCookies("admin_name", "");

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
        string UserID = ck.CheckInput(hidTxtYunjiaid.Text);
        string UserName = ck.CheckInput(hidTxtLine.Text);
        string RealName = ck.CheckInput(hidTxtStartport.Text);
        string CompanyName = ck.CheckInput(hidTxtDestport.Text);
        string Email = ck.CheckInput(hidTxtEmail.Text);
        string Tel = ck.CheckInput(hidTxtTel.Text);
        string Mobile = ck.CheckInput(hidTxtMobile.Text);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //item是(页码-1)x10，用来计算分页用
        int item = (Convert.ToInt32(page) - 1) * 10;



        sql = "select top 10 ";
        sql = sql + "UserID,UserName,RealName,CompanyName,CompanyType,Phone,MovePhone,Regtime,mcount,importer ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "V_ADMIN_PREUSERLIST.UserID,V_ADMIN_PREUSERLIST.importer,UserName,RealName,CompanyName,CompanyType,Phone,MovePhone,Regtime,count(fid) as mcount ";
        sql = sql + "FROM ";
        sql = sql + "V_ADMIN_PREUSERLIST  ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        sql = sql + "AND importer = '" + admin_name + "' ";

        //sql = sql + "AND Regtime > '2010-4-15 0:00:00' ";

        //加入筛选条件
        if (this.DropDownList1.SelectedValue != "全部")
        {
            sql = sql + "AND V_ADMIN_PREUSERLIST.verify = " + this.DropDownList1.SelectedValue;
        }
        if (UserID != "")
        {
            sql = sql + "AND V_ADMIN_PREUSERLIST.UserID = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND UserName like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND RealName like '%" + RealName + "%' ";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND CompanyName like '%" + CompanyName + "%' ";
        }
        if (Email != "")
        {
            sql = sql + "AND Useremail like '%" + Email + "%' ";
        }
        if (Tel != "")
        {
            sql = sql + "AND Phone like '%" + Tel + "%' ";
        }
        if (Mobile != "")
        {
            sql = sql + "AND MovePhone like '%" + Mobile + "%' ";
        }


        sql = sql + " group by V_ADMIN_PREUSERLIST.UserID,UserName,RealName,CompanyName,CompanyType,Phone,MovePhone,Regtime,V_ADMIN_PREUSERLIST.importer ";

        sql = sql + ") AS T ";
        sql = sql + "WHERE UserID NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " UserID ";
        sql = sql + "FROM ";
        sql = sql + "V_ADMIN_PREUSERLIST ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        sql = sql + "AND importer = '" + admin_name + "' ";

        //sql = sql + "AND Regtime > '2010-4-15 0:00:00' ";
        //加入筛选条件
        if (this.DropDownList1.SelectedValue != "全部")
        {
            sql = sql + "AND V_ADMIN_PREUSERLIST.verify = " + this.DropDownList1.SelectedValue;
        }
        if (UserID != "")
        {
            sql = sql + "AND UserID = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND UserName like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND RealName like '%" + RealName + "%' ";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND CompanyName like '%" + CompanyName + "%' ";
        }
        if (Email != "")
        {
            sql = sql + "AND Useremail like '%" + Email + "%' ";
        }
        if (Tel != "")
        {
            sql = sql + "AND Phone like '%" + Tel + "%' ";
        }
        if (Mobile != "")
        {
            sql = sql + "AND MovePhone like '%" + Mobile + "%' ";
        }


        sql = sql + "ORDER BY V_ADMIN_PREUSERLIST.UserID DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY UserID DESC ";
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
        //取搜索条件，搜索条件保存在隐藏的label内
        string UserID = ck.CheckInput(hidTxtYunjiaid.Text);
        string UserName = ck.CheckInput(hidTxtLine.Text);
        string RealName = ck.CheckInput(hidTxtStartport.Text);
        string CompanyName = ck.CheckInput(hidTxtDestport.Text);
        string Email = ck.CheckInput(hidTxtEmail.Text);
        string Tel = ck.CheckInput(hidTxtTel.Text);
        string Mobile = ck.CheckInput(hidTxtMobile.Text);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "count(*) as T ";
        sql = sql + "FROM ";
        sql = sql + "V_ADMIN_PREUSERLIST ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        sql = sql + "AND importer = '" + admin_name + "' ";

        //加入筛选条件
        if (this.DropDownList1.SelectedValue != "全部")
        {
            sql = sql + "AND V_ADMIN_PREUSERLIST.verify = " + this.DropDownList1.SelectedValue;
        }
        if (UserID != "")
        {
            sql = sql + "AND UserID = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND UserName like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND RealName like '%" + RealName + "%' ";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND CompanyName like '%" + CompanyName + "%' ";
        }
        if (Email != "")
        {
            sql = sql + "AND Useremail like '%" + Email + "%' ";
        }
        if (Tel != "")
        {
            sql = sql + "AND Phone like '%" + Tel + "%' ";
        }
        if (Mobile != "")
        {
            sql = sql + "AND MovePhone like '%" + Mobile + "%' ";
        }


        ds = cn.mdb_ds(sql, "count");

        //计算出页数
        int item = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());
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
        for (int i = 0; i < page; i++)
        {
            ListItem l = new ListItem("第" + (i + 1).ToString() + "页", (i + 1).ToString());
            ddlPageSelect.Items.Add(l);
        }

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
            sql = sql + "delete from tb_user where userid in (" + id + ")";
            cn.mdb_exe(sql);
            sql = "update TB_BBS set DeleSign=1 where UserID in (" + id + ")";
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

    protected void btnHidSearch_Click(object sender, EventArgs e)
    {
        //搜索条件保存在label控件内
        hidTxtYunjiaid.Text = txtYunjiaid.Text;
        hidTxtLine.Text = txtLine.Text;
        hidTxtStartport.Text = txtStartport.Text;
        hidTxtDestport.Text = txtDestport.Text;
        hidTxtEmail.Text = txtEmail.Text;
        hidTxtTel.Text = txtTel.Text;
        hidTxtMobile.Text = txtMobile.Text;

        //重新搜索，页码置1
        lblCurrentPage.Text = "1";
        LoadRecord(lblCurrentPage.Text);

        pnlSearchIntro.CssClass = "";
    }

    protected void lnkShowAll_Click(object sender, EventArgs e)
    {
        //搜索条件保存在label控件内
        hidTxtYunjiaid.Text = "";
        hidTxtLine.Text = "";
        hidTxtStartport.Text = "";
        hidTxtDestport.Text = "";
        hidTxtEmail.Text = "";
        hidTxtTel.Text = "";
        hidTxtMobile.Text = "";

        //重新搜索，页码置1
        lblCurrentPage.Text = "1";
        LoadRecord(lblCurrentPage.Text);

        pnlSearchIntro.CssClass = "hidden";
    }
}
