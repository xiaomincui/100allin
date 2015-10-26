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

        //取搜索条件，搜索条件保存在隐藏的label内
        string UserID = ck.CheckInput(hidTxtYunjiaid.Text);
        string UserName = ck.CheckInput(hidTxtLine.Text);
        string RealName = ck.CheckInput(hidTxtStartport.Text);
        string type = ck.CheckInput(hidTxtType.Text);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //item是(页码-1)x10，用来计算分页用
        int item = (Convert.ToInt32(page) - 1) * 15;


        sql = "select top 15 ";
        sql = sql + "id,link,linkname,types ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "id,link,linkname,types ";
        sql = sql + "FROM ";
        sql = sql + "TB_Link ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";


        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND TB_Link.id = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND TB_Link.link like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND TB_Link.linkname like '%" + RealName + "%' ";
        }
        if (type != "")
        {
            sql = sql + "AND TB_Link.types=" + type + " ";
        }

       







        sql = sql + ") AS T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " TB_Link.id ";
        sql = sql + "FROM ";
        sql = sql + "TB_Link ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";




        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND TB_Link.id = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND TB_Link.link like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND TB_Link.linkname like '%" + RealName + "%' ";
        }
        if (type != "")
        {
            sql = sql + "AND TB_Link.types=" + type + " ";
        }



        sql = sql + "ORDER BY TB_Link.id DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY id DESC";



        ds = cn.mdb_ds(sql, "yunjia");
        
        GridView1.DataSource = ds.Tables["yunjia"].DefaultView;
        GridView1.DataBind();

        //给表格加上框
        GridView1.Attributes.Add("bordercolor ", "#D9D9D9");

        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            DropDownList ddl = (DropDownList)GridView1.Rows[i].FindControl("DropDownList2");
            ddl.SelectedIndex = Convert.ToInt32(ds.Tables["yunjia"].Rows[i]["types"]) - 1;
            //Response.Write(Convert.ToInt32(ds.Tables["yunjia"].Rows[i]["types"]));
        }




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
        
        string type = ck.CheckInput(hidTxtType.Text);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";


        sql = sql + "SELECT count(*) FROM ";
        sql = sql + "TB_Link WHERE ";
        sql = sql + "1=1 ";






        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND TB_Link.id = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND TB_Link.link like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND TB_Link.linkname like '%" + RealName + "%' ";
        }
        if (type != "")
        {
            sql = sql + "AND TB_Link.types=" + type + " ";
        }




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
            sql = sql + "delete from TB_Link where id in (" + id + ")";
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

    protected void btnHidSearch_Click(object sender, EventArgs e)
    {
        //搜索条件保存在label控件内
        hidTxtYunjiaid.Text = txtYunjiaid.Text;
        hidTxtLine.Text = txtLine.Text;
        hidTxtStartport.Text = txtStartport.Text;
        
        hidTxtType.Text = DropDownList1.SelectedItem.Value ;
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
        
        hidTxtType.Text = "";
        //重新搜索，页码置1
        lblCurrentPage.Text = "1";
        LoadRecord(lblCurrentPage.Text);
        pnlSearchIntro.CssClass = "hidden";
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList Drp = (DropDownList)sender;
        string region = Drp.SelectedItem.Value;
        

        DropDownList ddl = sender as DropDownList;
        if (ddl != null)
        {
            TableCell cell = ddl.Parent as TableCell;
            if (cell != null)
            {
                Label lbl = cell.FindControl("Label2") as Label;
                
                data_conn cn = new data_conn();
                cn.mdb_exe("update TB_Link set types=" + region + " where id=" + lbl.Text);
                LoadRecord(lblCurrentPage.Text);
            }
        }


    }
    //protected void ckbtop_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox Drp = (CheckBox)sender;

    //    bool boolregion = Drp.Checked;
    //    string region;
    //    if (boolregion)
    //    {
    //        region = "1";
    //    }
    //    else
    //    {
    //        region = "0";
    //    }

    //    CheckBox ddl = sender as CheckBox;
    //    if (ddl != null)
    //    {
    //        TableCell cell = ddl.Parent as TableCell;
    //        if (cell != null)
    //        {
    //            Label lbl = cell.FindControl("Label2") as Label;

    //            data_conn cn = new data_conn();
    //            cn.mdb_exe("update TB_BBS set istop=" + region + " where id=" + lbl.Text);
    //            LoadRecord(lblCurrentPage.Text);
    //        }
    //    }
    //}
    protected void Button3_Click(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        string sql = "insert into TB_Link (link,linkname,types) values ('" + TextBox1.Text + "','" + TextBox2.Text + "'," + DropDownList3.SelectedItem.Value + ")";
        cn.mdb_exe(sql);
        LoadRecord(lblCurrentPage.Text);
    }
}
