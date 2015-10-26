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
            if (Request.Cookies["admin_group"].Value == "3")
            {
                GridView1.Columns[9].Visible = false;
            }
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

        //取搜索条件，搜索条件保存在隐藏的label内
        string UserID = ck.CheckInput(hidTxtYunjiaid.Text);
        string UserName = ck.CheckInput(hidTxtLine.Text);
        string RealName = ck.CheckInput(hidTxtStartport.Text);
        string CompanyName = ck.CheckInput(hidTxtDestport.Text);

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
        int item = (Convert.ToInt32(page) - 1) * 30;



        sql = "select top 30 ";
        sql = sql + "id,title,UserName,CompanyName,LINE,enddate,StartPort,ifpass,PostDate ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "T_AIRINFO.id,T_AIRINFO.title ,tb_user.UserName,tb_user.CompanyName,T_AIRINFO.LINE,T_AIRINFO.enddate,T_AIRINFO.StartPort,T_AIRINFO.ifpass,T_AIRINFO.PostDate ";
        sql = sql + "FROM ";
        sql = sql + "tb_user,T_AIRINFO ";
        sql = sql + "WHERE ";
        sql = sql + "TB_User.UserID=T_AIRINFO.UserID ";

        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND T_AIRINFO.id = " + UserID + " ";
        }
        if (UserName != "")
        {
            sql = sql + "AND T_AIRINFO.StartPort like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "and id in (select id from T_AIRINFO where '" + RealName + "'" + DropDownList1.SelectedItem.Value + "enddate )";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND UserName like '%" + CompanyName + "%' ";
        }
        if (uid != "")
        {
            sql = sql + "AND (T_AIRINFO.userid = " + uid + " or T_AIRINFO.userid2 =" + uid + ") ";
        }


        sql = sql + ") AS T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " id ";
        sql = sql + "FROM ";
        sql = sql + "tb_user,T_AIRINFO ";
        sql = sql + "WHERE ";
        sql = sql + "TB_User.UserID=T_AIRINFO.UserID ";

        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND T_AIRINFO.id = " + UserID + " ";
        }
        if (UserName != "")
        {
            sql = sql + "AND T_AIRINFO.StartPort like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "and id in (select id from T_AIRINFO where '" + RealName + "'" + DropDownList1.SelectedItem.Value + "enddate )";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND UserName like '%" + CompanyName + "%' ";
        }
        if (uid != "")
        {
            sql = sql + "AND (T_AIRINFO.userid = " + uid + " or T_AIRINFO.userid2 =" + uid + ") ";
        }


        sql = sql + "ORDER BY T_AIRINFO.ifpass ASC,T_AIRINFO.PostDate DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY ifpass ASC,PostDate DESC ";

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
        sql = sql + "tb_user,T_AIRINFO ";
        sql = sql + "WHERE ";
        sql = sql + "TB_User.UserID=T_AIRINFO.UserID ";

        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND T_AIRINFO.id = " + UserID + " ";
        }
        if (UserName != "")
        {
            sql = sql + "AND T_AIRINFO.StartPort like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "and id in (select id from T_AIRINFO where '" + RealName + "'" + DropDownList1.SelectedItem.Value + "enddate )";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND tb_user.UserName like '%" + CompanyName + "%' ";
        }
        if (uid != "")
        {
            sql = sql + "AND (T_AIRINFO.userid = " + uid + " or T_AIRINFO.userid2 =" + uid + ") ";
        }

        ds = cn.mdb_ds(sql, "count");

        //计算出页数
        int item  = Convert.ToInt32(ds.Tables["count"].Rows[0][0].ToString());
        int page;
        if (item % 30 > 0 || item == 0)
        {
            page = item / 30 + 1;
        }
        else
        {
            page = item / 30;
        }

        //填充下拉页码框
        for (int i = 0; i< page; i++)
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
        if (id!="")
        {
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";
            sql = sql + "delete from T_AIRINFO where id in (" + id + ")";
            cn.mdb_exe(sql);
	    sql = "";
            sql = sql + "delete from TB_Yunjia_Effective_10 where airid in (" + id + ")";
            cn.mdb_exe(sql);
	    sql = "";
        sql = sql + "delete from TB_YunjiaInfo_Effective_10 where airid in (" + id + ")";
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

    protected void btnHidPass_Click(object sender, EventArgs e)
    {
        //删除被选择的记录
        pass();
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


    public void pass()
    {
        //删除信息
        //要删除的纪录的ID，保存在delList隐藏控件内
        string id = delList.Text;
        if (id != "")
        {
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "";
            sql = sql + "update T_AIRINFO set ifpass = 1 where id in (" + id + ")";
            cn.mdb_exe(sql);
            sql = "";
            sql = sql + "update TB_Yunjia_Effective_10 set ifpass = 1 where AIRID in (" + id + ")";
            cn.mdb_exe(sql);
            //Response.Write(sql);
            MessageBox("opsuccess", "审核成功");

            //清空delList
            delList.Text = "";
        }
        else
        {
            //没有选择任何要删除的ID，弹出此对话框
            MessageBox("opfail", "未选择任何要审核的项目");
        }
    }

    protected void btnHidSearch_Click(object sender, EventArgs e)
    {
        //搜索条件保存在label控件内
        hidTxtYunjiaid.Text = txtYunjiaid.Text;
        hidTxtLine.Text = txtLine.Text;
        hidTxtStartport.Text = txtenddate.Value;
        hidTxtDestport.Text = txtDestport.Text;

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

        //重新搜索，页码置1
        lblCurrentPage.Text = "1";
        LoadRecord(lblCurrentPage.Text);

        pnlSearchIntro.CssClass = "hidden";
    }

    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
