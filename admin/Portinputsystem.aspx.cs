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
        if (Page.IsPostBack == false)
        {
            data_conn cn = new data_conn();
            LoadRecord("1");
            LoadList();

            DataSet ds2 = cn.mdb_ds("select * from TB_CollectPort where PortLocation=0", "port");
            for (int i = 0; i < ds2.Tables["port"].Rows.Count; i++)
            {
                DropDownList3.Items.Add(new ListItem(ds2.Tables["port"].Rows[i]["location"].ToString(), ds2.Tables["port"].Rows[i]["id"].ToString()));
            }



        }
    }


    public void LoadList()
    {
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select * from TB_CollectPort where PortLocation=0", "Port");
        ListBox1.Items.Clear();
        ListBox1.Items.Add(new ListItem("全部", ""));
        for(int i=0;i<ds.Tables["Port"].Rows.Count ;i++)
        {
            ListBox1.Items.Add(new ListItem(ds.Tables["Port"].Rows[i]["EnglishName"].ToString() + "," + ds.Tables["Port"].Rows[i]["location"].ToString(), ds.Tables["Port"].Rows[i]["id"].ToString()));
        }
        
    }

    public void LoadList2()
    {
        data_conn cn = new data_conn();
        string sql = "";
        sql += "select distinct EnglishName,location,TB_CollectPort.id from TB_CollectPort,TB_CollectPortRelation where TB_CollectPort.id=TB_CollectPortRelation.EndPortID ";
        if (ListBox1.SelectedValue != "")
        {
            sql += "and TB_CollectPortRelation.StartPortID=" + ListBox1.SelectedValue + " ";
        }

        if (ListBox3.SelectedValue != "")
        {
            sql += "and substring(TB_CollectPort.EnglishName,1,1)='" + ListBox3.SelectedValue + "'";
        }


        DataSet ds = cn.mdb_ds(sql, "Port");
        ListBox2.Items.Clear();
        for (int i = 0; i < ds.Tables["Port"].Rows.Count; i++)
        {
            ListBox2.Items.Add(new ListItem(ds.Tables["Port"].Rows[i]["EnglishName"].ToString() + "," + ds.Tables["Port"].Rows[i]["location"].ToString(), ds.Tables["Port"].Rows[i]["id"].ToString()));
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();

        DataSet ds = cn.mdb_ds("select * from TB_CollectPort where numID='" + strID.Value + "'", "t1");
        if (DropDownList1.SelectedValue == "0")
        {
            if (ds.Tables["t1"].Rows.Count != 0)
            {
                this.MessageBox("", "编号已经存在");
            }
            else
            {
                cn.mdb_exe("insert into TB_CollectPort (location,EnglishName,numID,countryName,PortLocation) values ('" + strPortcn.Value + "','" + strPorten.Value + "','" + strID.Value + "',''," + DropDownList1.SelectedValue + ")");

                

                DropDownList3.Items.Clear();
                DropDownList3.Items.Add(new ListItem("请选择", "0"));
                DataSet ds2 = cn.mdb_ds("select * from TB_CollectPort where PortLocation=0", "port");
                for (int i = 0; i < ds2.Tables["port"].Rows.Count; i++)
                {
                    DropDownList3.Items.Add(new ListItem(ds2.Tables["port"].Rows[i]["location"].ToString(), ds2.Tables["port"].Rows[i]["id"].ToString()));
                }
                


            }

            strPortcn.Value = "";
            strPorten.Value = "";
            strID.Value = "";
            //strcountry.Value = "";
            DropDownList1.SelectedValue = "0";
        }
        else
        {
            if (ds.Tables["t1"].Rows.Count != 0)
            {
                DataSet ds2 = cn.mdb_ds("select * from TB_CollectPortRelation where StartPortID=" + DropDownList3.SelectedValue + " and EndPortID=" + ds.Tables["t1"].Rows[0]["id"].ToString(), "t2");
                if (ds2.Tables["t2"].Rows.Count != 0)
                {
                    this.MessageBox("", "编号已经存在");
                }
                else
                {
                    cn.mdb_exe("insert into TB_CollectPortRelation (StartPortID,EndPortID) values (" + DropDownList3.SelectedValue + "," + ds.Tables["t1"].Rows[0]["id"].ToString()+")");
                }
            }
            else
            {
                string id = cn.mdb_exe_return("insert into TB_CollectPort (location,EnglishName,numID,countryName,PortLocation) values ('" + strPortcn.Value + "','" + strPorten.Value + "','" + strID.Value + "',''," + DropDownList1.SelectedValue + ")");

                cn.mdb_exe("insert into TB_CollectPortRelation (StartPortID,EndPortID) values (" + DropDownList3.SelectedValue + "," + id + ")");

                

               
            }

            strPortcn.Value = "";
            strPorten.Value = "";
            strID.Value = "";
        }

        LoadList();
        LoadList2();
        LoadRecord("1");

    }


    //载入列表信息
    public void LoadRecord(string page)
    {
        check ck = new check();

        //取搜索条件，搜索条件保存在隐藏的label内
        string strlocation = ck.CheckInput(hidPortcn.Text);
        string strEnglishName = ck.CheckInput(hidPorten.Text);
        string strnumID = ck.CheckInput(hidID.Text);
        //string strcountryName = ck.CheckInput(hidTxtDestport.Text);
        string strPortLocation;
        if (hidddl.Text == "目的港")
        {
            strPortLocation = "1";
        }
        else if ((hidddl.Text == "启运港"))
        {
            strPortLocation = "0";
        }
        else
        {
            strPortLocation = "全部";
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //item是(页码-1)x10，用来计算分页用
        int item = (Convert.ToInt32(page) - 1) * 10;



        sql = "select top 10 ";
        sql = sql + "* ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "* ";
        sql = sql + "FROM ";
        sql = sql + "TB_CollectPort  ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";

        //sql = sql + "AND Regtime > '2010-4-15 0:00:00' ";

        //加入筛选条件




        if (strlocation != "")
        {
            sql = sql + "AND location like '%" + strlocation + "%' ";
        }
        if (strEnglishName != "")
        {
            sql = sql + "AND EnglishName like '%" + strEnglishName + "%' ";
        }
        if (strnumID != "")
        {
            sql = sql + "AND numID = '" + strnumID + "' ";
        }
        if (strPortLocation != "全部")
        {
            sql = sql + "AND PortLocation = " + strPortLocation;
        }






        sql = sql + ") AS T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " id ";
        sql = sql + "FROM ";
        sql = sql + "TB_CollectPort ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";





        //sql = sql + "AND Regtime > '2010-4-15 0:00:00' ";
        //加入筛选条件
        if (strlocation != "")
        {
            sql = sql + "AND location like '%" + strlocation + "%' ";
        }
        if (strEnglishName != "")
        {
            sql = sql + "AND EnglishName like '%" + strEnglishName + "%' ";
        }
        if (strnumID != "")
        {
            sql = sql + "AND numID = '" + strnumID + "' ";
        }
        if (strPortLocation != "全部")
        {
            sql = sql + "AND PortLocation = " + strPortLocation;
        }


        sql = sql + "ORDER BY id DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY id DESC ";
        //this.Response.Write(sql);
        ds = cn.mdb_ds(sql, "yunjia");



        //Response.Write(sql);
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
        string strlocation = ck.CheckInput(txtPortcn.Text);
        string strEnglishName = ck.CheckInput(txtPorten.Text);
        string strnumID = ck.CheckInput(txtID.Text);
        //string strcountryName = ck.CheckInput(hidTxtDestport.Text);
        string strPortLocation = ck.CheckInput(DropDownList2.SelectedValue);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT ";
        sql = sql + "count(*) as T ";
        sql = sql + "FROM ";
        sql = sql + "TB_CollectPort ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";

        //加入筛选条件
        if (strlocation != "")
        {
            sql = sql + "AND location like '%" + strlocation + "%' ";
        }
        if (strEnglishName != "")
        {
            sql = sql + "AND EnglishName like '%" + strEnglishName + "%' ";
        }
        if (strnumID != "")
        {
            sql = sql + "AND numID = '" + strnumID + "' ";
        }
        if (strPortLocation != "全部")
        {
            sql = sql + "AND PortLocation = " + strPortLocation;
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



    protected void lnkShowAll_Click(object sender, EventArgs e)
    {
        //搜索条件保存在label控件内
        hidID.Text = "";
        hidPortcn.Text = "";
        hidPorten.Text = "";
        hidddl.Text = "";


        //重新搜索，页码置1
        lblCurrentPage.Text = "1";
        LoadRecord(lblCurrentPage.Text);

        pnlSearchIntro.CssClass = "hidden";
    }
    protected void btnHidSearch_Click(object sender, EventArgs e)
    {
        //搜索条件保存在label控件内
        hidID.Text = txtID.Text;
        hidPortcn.Text = txtPortcn.Text;
        hidPorten.Text = txtPorten.Text;
        hidddl.Text = DropDownList2.SelectedItem.Text;



        //重新搜索，页码置1
        lblCurrentPage.Text = "1";
        LoadRecord(lblCurrentPage.Text);

        pnlSearchIntro.CssClass = "";
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
            sql = sql + "delete from TB_CollectPort where id in (" + id + ")";
            cn.mdb_exe(sql);
            sql = sql + "delete from TB_CollectPortRelation where StartPortID in (" + id + ") or EndPortID in (" + id + ")";
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F7FB';");  //当鼠标停留时更改背景色 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';"); //当鼠标移开时还原背景色       
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


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView1.EditIndex = -1;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "0")
        {
            PlaceHolder1.Visible = false;
        }
        else
        {
            PlaceHolder1.Visible = true;
            
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadList2();
    }
    protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadList2();
    }
}
