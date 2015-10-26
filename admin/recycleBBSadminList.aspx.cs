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
        string CompanyName = ck.CheckInput(hidTxtDestport.Text);
        string type = ck.CheckInput(hidTxtType.Text);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //item是(页码-1)x10，用来计算分页用
        int item = (Convert.ToInt32(page) - 1) * 15;


        sql = "select top 15 ";
        sql = sql + "id,title,releasename,Data,PostDate,EditDate,message,restorename,UpdateDate,hits,types,istop ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "TB_BBS.id,TB_BBS.title,a.UserName as releasename,TB_BBS.Data,TB_BBS.PostDate,TB_BBS.EditDate,count(TB_Message.BBSID) as message,b.UserName as restorename,TB_BBS.UpdateDate,TB_BBS.hits,TB_BBS.types,TB_BBS.istop ";
        sql = sql + "FROM ";
        sql = sql + "TB_BBS,TB_User a,TB_User b,TB_Message ";
        sql = sql + "WHERE ";
        sql = sql + "TB_BBS.UserID=a.UserID and TB_Message.BBSID=*TB_BBS.id and DeleSign=1 and TB_BBS.types<>5 ";
        if (CompanyName != "")
        {
            sql = sql + "and TB_BBS.restoreName=b.UserID ";
        }
        else
        {
            sql = sql + "and TB_BBS.restoreName*=b.UserID ";
        }

        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND TB_BBS.id = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND TB_BBS.title like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND a.UserName like '%" + RealName + "%' ";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND b.UserName like '%" + CompanyName + "%' ";
        }
        if (type != "")
        {
            DataSet dstypetemp = cn.mdb_ds("select * from TB_BBSList where name='" + type + "'", "typetemp");
            sql = sql + "AND TB_BBS.types=" + dstypetemp.Tables["typetemp"].Rows[0]["id"] + " ";
        }

        //if (Request.Cookies["bbsadmin_id"] == null)
        //{

        //}
        //else
        //{
        //    if (Request.Cookies["bbsadmin_id"].Value.ToString() == "")
        //    {

        //    }
        //    else
        //    {
        //        sql = sql + "AND TB_BBS.types in (select types from TB_User,TB_BBSLevel where TB_User.UserID*=TB_BBSLevel.UserID and TB_User.UserID=" + Request.Cookies["bbsadmin_id"].Value + ")";

        //    }
        //}

            
        sql = sql + "group by TB_BBS.id,TB_BBS.title,a.UserName,TB_BBS.Data,TB_BBS.PostDate,TB_BBS.EditDate,b.UserName,TB_BBS.UpdateDate,TB_BBS.hits,TB_BBS.types,TB_BBS.istop ";







        sql = sql + ") AS T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " TB_BBS.id ";
        sql = sql + "FROM ";
        sql = sql + "TB_BBS,TB_User a,TB_User b,TB_Message ";
        sql = sql + "WHERE ";
        sql = sql + "TB_BBS.UserID=a.UserID and TB_Message.BBSID=*TB_BBS.id and DeleSign=1 and TB_BBS.types<>5 ";

        if (CompanyName != "")
        {
            sql = sql + "and TB_BBS.restoreName=b.UserID ";
        }
        else
        {
            sql = sql + "and TB_BBS.restoreName*=b.UserID ";
        }


        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND TB_BBS.id = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND TB_BBS.title like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND a.UserName like '%" + RealName + "%' ";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND b.UserName like '%" + CompanyName + "%' ";
        }

        if (type != "")
        {
            DataSet dstypetemp = cn.mdb_ds("select * from TB_BBSList where name='" + type + "'", "typetemp");
            sql = sql + "AND TB_BBS.types=" + dstypetemp.Tables["typetemp"].Rows[0]["id"] + " ";
        }


        //if (Request.Cookies["bbsadmin_id"] == null)
        //{

        //}
        //else
        //{
        //    if (Request.Cookies["bbsadmin_id"].Value.ToString() == "")
        //    {

        //    }
        //    else
        //    {
        //        sql = sql + "AND TB_BBS.types in (select types from TB_User,TB_BBSLevel where TB_User.UserID*=TB_BBSLevel.UserID and TB_User.UserID=" + Request.Cookies["bbsadmin_id"].Value + ")";
        //    }
        //}


        sql = sql + "group by TB_BBS.id,TB_BBS.UpdateDate,TB_BBS.istop ";
        sql = sql + "ORDER BY istop DESC,TB_BBS.UpdateDate DESC,TB_BBS.id DESC ";
        sql = sql + ") ";
        sql = sql + "ORDER BY istop DESC,UpdateDate DESC,id DESC";


        
        ds = cn.mdb_ds(sql, "yunjia");
        
        GridView1.DataSource = ds.Tables["yunjia"].DefaultView;
        GridView1.DataBind();

        //给表格加上框
        GridView1.Attributes.Add("bordercolor ", "#D9D9D9");

        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            DropDownList ddl = (DropDownList)GridView1.Rows[i].FindControl("DropDownList2");
            //ddl.SelectedIndex = Convert.ToInt32(ds.Tables["yunjia"].Rows[i]["types"]) - 1;
            ddl.SelectedValue = ds.Tables["yunjia"].Rows[i]["types"].ToString();
            
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
        string CompanyName = ck.CheckInput(hidTxtDestport.Text);
        string type = ck.CheckInput(hidTxtType.Text);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "select count(*) from ";
        sql = sql + "(SELECT distinct TB_BBS.id FROM ";
        sql = sql + "TB_BBS,TB_User a,TB_User b,TB_Message WHERE ";
        sql = sql + "TB_BBS.UserID=a.UserID and TB_Message.BBSID=*TB_BBS.id and DeleSign=1 and TB_BBS.types<>5 ";

        if (CompanyName != "")
        {
            sql = sql + "and TB_BBS.restoreName=b.UserID ";
        }
        else
        {
            sql = sql + "and TB_BBS.restoreName*=b.UserID ";
        }

        


        //加入筛选条件
        if (UserID != "")
        {
            sql = sql + "AND TB_BBS.id = " + UserID;
        }
        if (UserName != "")
        {
            sql = sql + "AND TB_BBS.title like '%" + UserName + "%' ";
        }
        if (RealName != "")
        {
            sql = sql + "AND a.UserName like '%" + RealName + "%' ";
        }
        if (CompanyName != "")
        {
            sql = sql + "AND b.UserName like '%" + CompanyName + "%' ";
        }
        if (type != "")
        {
            DataSet dstypetemp = cn.mdb_ds("select * from TB_BBSList where name='" + type + "'", "typetemp");
            sql = sql + "AND TB_BBS.types=" + dstypetemp.Tables["typetemp"].Rows[0]["id"] + " ";
        }


        //if (Request.Cookies["bbsadmin_id"] == null)
        //{

        //}
        //else
        //{
        //    if (Request.Cookies["bbsadmin_id"].Value.ToString() == "")
        //    {

        //    }
        //    else
        //    {
        //        sql = sql + "AND TB_BBS.types in (select types from TB_User,TB_BBSLevel where TB_User.UserID*=TB_BBSLevel.UserID and TB_User.UserID=" + Request.Cookies["bbsadmin_id"].Value + ")";

        //    }
        //}

        sql = sql + ") as t";




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
        if (id != "")
        {
            data_conn cn = new data_conn();

            string body = "尊敬的用户:<br/>";
            body += "感谢您参与我们的论坛.<br/>";
            body += "由于您在发布的帖子违反本论坛协议而被管理员删除.敬请谅解详情请见<a herf=\"www.100allin.com\">www.100allin.com</a><br/>";
            body += "您在使用过程中，如有任何问题或建议，请随时联系傲赢网客户服务人员，我们将热忱为您服务。顺颂商祺！";
            DataSet dsBBS = cn.mdb_ds("select UserEmail from TB_User,TB_BBS where TB_User.Userid=TB_BBS.Userid and TB_BBS.id in (" + id + ")", "deleteBBSEmail");

            EmailSend email = new EmailSend();
            for (int i = 0; i <= dsBBS.Tables["deleteBBSEmail"].Rows.Count - 1; i++)
            {
                try
                {

                }
                catch (Exception e)
                {
                    email.send((string)dsBBS.Tables["deleteBBSEmail"].Rows[i]["UserEmail"].ToString(), body);
                }
            }



            DataSet ds = new DataSet();
            string sql = "";
            //sql = sql + "delete from TB_BBS where id in (" + id + ")";
            //cn.mdb_exe(sql);
            //sql = "delete from TB_Message where BBSID in (" + id + ")";
            //cn.mdb_exe(sql);
            sql = sql + "update TB_BBS set DeleSign=0 where id in (" + id + ")";
            cn.mdb_exe(sql);

            //string[] arrayId = id.Split(',');

            //for (int i = 0; i < arrayId.Length; i++)
            //{
            //    cn.mdb_exe("insert into TB_BBSAdminIncident (BBSID,AdminID,Meno,EditTime,Types) values (" + arrayId[i] + "," + Request.Cookies["bbsadmin_id"].Value + ",'" + this.txtMeno.Text + "',getDate(),3)");
            //}



            MessageBox("opsuccess", "恢复成功");



            //清空delList
            delList.Text = "";
        }
        else
        {
            //没有选择任何要删除的ID，弹出此对话框
            MessageBox("opfail", "未选择任何要恢复的项目");
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
        hidTxtDestport.Text = txtDestport.Text;
        hidTxtType.Text = DropDownList1.SelectedItem.Text ;
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
                cn.mdb_exe("update TB_BBS set types=" + region + " where id=" + lbl.Text);
                //cn.mdb_exe("insert into TB_BBSAdminIncident (BBSID,AdminID,Meno,EditTime,Types) values (" + lbl.Text + "," + Request.Cookies["bbsadmin_id"].Value + ",'" + this.txtMeno.Text + "',getDate(),2)");
                LoadRecord(lblCurrentPage.Text);
            }
        }





    }
    protected void ckbtop_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox Drp = (CheckBox)sender;

        bool boolregion = Drp.Checked;
        string region;
        if (boolregion)
        {
            region = "1";
        }
        else
        {
            region = "0";
        }

        CheckBox ddl = sender as CheckBox;
        if (ddl != null)
        {
            TableCell cell = ddl.Parent as TableCell;
            if (cell != null)
            {
                Label lbl = cell.FindControl("Label2") as Label;

                data_conn cn = new data_conn();
                cn.mdb_exe("update TB_BBS set istop=" + region + " where id=" + lbl.Text);
                //cn.mdb_exe("insert into TB_BBSAdminIncident (BBSID,AdminID,Meno,EditTime,Types) values (" + lbl.Text + "," + Request.Cookies["bbsadmin_id"].Value + ",'" + this.txtMeno.Text + "',getDate(),1)");
                LoadRecord(lblCurrentPage.Text);
            }
        }




    }

    
}
