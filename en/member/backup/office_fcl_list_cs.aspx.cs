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

public partial class en_office : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //取保存在Cookies中的用户编号id
        string id = "";
        if (Request.Cookies["user_id"] != null)
        {
            if (!Page.IsPostBack)
            {
                id = Request.Cookies["user_id"].Value.ToString();
                LoadRecord(lblCurrentPage.Text);
            }
        }
        else
        {
            //如果用户未登录，则跳转到网站首页
            Response.Redirect("/en/");
        }
    }

    //载入列表信息
    public void LoadRecord(string page)
    {

        check ck = new check();
        //取搜索条件，搜索条件保存在隐藏的label内
        string yunjiaid = ck.CheckInput(hidTxtYunjiaid.Text);
        string line = ck.CheckInput(hidTxtLine.Text);
        string startport = ck.CheckInput(hidTxtStartport.Text);
        string destport = ck.CheckInput(hidTxtDestport.Text);


        //取保存在Cookies中的用户编号id
        string id = "";
        if (Request.Cookies["user_id"] != null)
        {
            id = Request.Cookies["user_id"].Value.ToString();
        }
        else
        {
            //如果用户未登录，则跳转到网站首页
            Response.Redirect("/en/");
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //跳转
        check check = new check();
        DataSet ds2;
        data_conn3 conn = new data_conn3();
        sql = "select * from TB_User where UserID=" + check.CheckNumber(Request.Cookies["user_id"].Value.ToString());
        ds2 = conn.mdb_ds(sql, "table");

        if (Convert.ToInt32(ds2.Tables["table"].Rows[0]["User_Level"].ToString()) == 0)
        {
            Response.Redirect("../accounts/regnormal.aspx");
        }

        //item是(页码-1)x10，用来计算分页用
        int item;
        item = (Convert.ToInt32(page) - 1) * 10;


        if (destport == "")
        {
            //无目的港搜索的select语句
            sql = "select top 10 ";
            sql = sql + "id,startport,title,hangxianmiaoshu,";
            sql = sql + "postdate,";
            sql = sql + "enddate ";
            sql = sql + "FROM (SELECT ";
            sql = sql + "id,startport,title,hangxianmiaoshu,";
            sql = sql + "postdate,";
            sql = sql + "CONVERT(varchar(10), enddate, 120) as enddate ";
            sql = sql + "FROM ";
            sql = sql + "tb_yunjia ";
            sql = sql + "WHERE ";
            sql = sql + "1=1 ";
            sql = sql + "AND (userid = " + id + " or userid2 = " + id + ") ";
            sql = sql + "AND yunjialeixing = 9 ";

            //加入筛选条件，编号，航线，启运港
            if (yunjiaid != "")
            {
                sql = sql + "AND tb_yunjia.id = " + yunjiaid + " ";
            }
            if (line != "")
            {
                sql = sql + "AND hangxianmiaoshu = '" + line + "' ";
            }
            if (startport != "")
            {
                sql = sql + "AND startport like '%" + startport + "%' ";
            }


            sql = sql + ") AS T ";
            sql = sql + "WHERE id NOT IN ";
            sql = sql + "(SELECT TOP " + item.ToString() + " id ";
            sql = sql + "FROM ";
            sql = sql + "tb_yunjia ";
            sql = sql + "WHERE ";
            sql = sql + "1=1 ";
            sql = sql + "AND (userid = " + id + " or userid2 = " + id + ") ";
            sql = sql + "AND yunjialeixing = 9 ";

            //加入筛选条件，编号，航线，启运港
            if (yunjiaid != "")
            {
                sql = sql + "AND tb_yunjia.id = " + yunjiaid + " ";
            }
            if (line != "")
            {
                sql = sql + "AND hangxianmiaoshu = '" + line + "' ";
            }
            if (startport != "")
            {
                sql = sql + "AND startport like '%" + startport + "%' ";
            }




            sql = sql + "ORDER BY tb_yunjia.postdate DESC ";
            sql = sql + ") ";
            sql = sql + "ORDER BY postdate DESC ";

        }
        else
        {
            //有目的港搜索的select语句
            sql = "select top 10 ";
            sql = sql + "id,startport,title,hangxianmiaoshu,";
            sql = sql + "postdate,";
            sql = sql + "enddate ";
            sql = sql + "FROM (SELECT ";
            sql = sql + "DISTINCT tb_yunjia.id as id,tb_yunjia.startport as startport,title,hangxianmiaoshu,";
            sql = sql + "postdate,";
            sql = sql + "CONVERT(varchar(10), enddate, 120) as enddate ";
            sql = sql + "FROM ";
            sql = sql + "tb_yunjia,tb_yunjiainfo ";
            sql = sql + "WHERE ";
            sql = sql + "1=1 AND tb_yunjia.id = tb_yunjiainfo.yunjiaid ";
            sql = sql + "AND (userid = " + id + " or userid2 = " + id + ") ";
            sql = sql + "AND yunjialeixing = 9 ";

            //加入筛选条件，编号，航线，启运港
            if (yunjiaid != "")
            {
                sql = sql + "AND tb_yunjia.id = " + yunjiaid + " ";
            }
            if (line != "")
            {
                sql = sql + "AND hangxianmiaoshu = '" + line + "' ";
            }
            if (startport != "")
            {
                sql = sql + "AND tb_yunjia.startport like '%" + startport + "%' ";
            }
            if (destport != "")
            {
                sql = sql + "AND tb_yunjiainfo.destport like '%" + destport + "%' ";
            }
            sql = sql + ") AS T ";

            sql = sql + "WHERE id NOT IN ";
            sql = sql + "(SELECT id FROM";
            sql = sql + "(SELECT DISTINCT TOP " + item.ToString() + " tb_yunjia.id AS id,postdate ";
            sql = sql + "FROM ";
            sql = sql + "tb_yunjia,tb_yunjiainfo ";
            sql = sql + "WHERE ";
            sql = sql + "1=1 AND tb_yunjia.id = tb_yunjiainfo.yunjiaid ";
            sql = sql + "AND (userid = " + id + " or userid2 = " + id + ") ";
            sql = sql + "AND yunjialeixing = 9 ";

            //加入筛选条件，编号，航线，启运港
            if (yunjiaid != "")
            {
                sql = sql + "AND tb_yunjia.id = " + yunjiaid + " ";
            }
            if (line != "")
            {
                sql = sql + "AND hangxianmiaoshu = '" + line + "' ";
            }
            if (startport != "")
            {
                sql = sql + "AND tb_yunjia.startport like '%" + startport + "%' ";
            }
            if (destport != "")
            {
                sql = sql + "AND tb_yunjiainfo.destport like '%" + destport + "%' ";
            }

            sql = sql + "ORDER BY tb_yunjia.postdate DESC ";
            sql = sql + ") AS T ";
            sql = sql + ") ";
            sql = sql + "ORDER BY postdate DESC ";

        }

        ds = cn.mdb_ds(sql, "yunjia");

        Repeater1.DataSource = ds.Tables["yunjia"].DefaultView;
        Repeater1.DataBind();



        //计算页数
        LoadTotalCount();
    }


    public void LoadTotalCount()
    {
        //取保存在Cookies中的用户编号id
        string id = "";
        if ((this.Request.Cookies["user_id"] != null))
        {
            id = this.Request.Cookies["user_id"].Value.ToString();
        }
        else
        {
            //如果用户未登录，则跳转到网站首页
            Response.Redirect("/");
        }

        //先动态删除下拉页码表所有的页码
        ddlPageSelect.Items.Clear();

        check ck = new check();
        //取搜索条件，搜索条件保存在隐藏的label内
        string yunjiaid = ck.CheckInput(hidTxtYunjiaid.Text);
        string line = ck.CheckInput(hidTxtLine.Text);
        string startport = ck.CheckInput(hidTxtStartport.Text);
        string destport = ck.CheckInput(hidTxtDestport.Text);


        //访问数据库，统计记录条数
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";


        if (string.IsNullOrEmpty(destport))
        {
            sql = sql + "SELECT ";
            sql = sql + "count(*) as T ";
            sql = sql + "FROM ";
            sql = sql + "tb_yunjia ";
            sql = sql + "WHERE ";
            sql = sql + "1=1 ";
            sql = sql + "AND (userid = " + id + " or userid2 = " + id + ") ";
            sql = sql + "AND yunjialeixing = 9 ";

            if (!string.IsNullOrEmpty(yunjiaid))
            {
                sql = sql + "AND tb_yunjia.id = " + yunjiaid + " ";
            }
            if (!string.IsNullOrEmpty(line))
            {
                sql = sql + "AND hangxianmiaoshu = '" + line + "' ";
            }
            if (!string.IsNullOrEmpty(startport))
            {
                sql = sql + "AND startport like '%" + startport + "%' ";
            }

        }
        else
        {
            sql = sql + "SELECT ";
            sql = sql + "count(DISTINCT  tb_yunjia.id) as T ";
            sql = sql + "FROM ";
            sql = sql + "tb_yunjia,tb_yunjiainfo ";
            sql = sql + "WHERE ";
            sql = sql + "1=1 AND tb_yunjia.id = tb_yunjiainfo.yunjiaid ";
            sql = sql + "AND (userid = " + id + " or userid2 = " + id + ") ";
            sql = sql + "AND yunjialeixing = 9 ";

            if (!string.IsNullOrEmpty(yunjiaid))
            {
                sql = sql + "AND tb_yunjia.id = " + yunjiaid + " ";
            }
            if (!string.IsNullOrEmpty(line))
            {
                sql = sql + "AND hangxianmiaoshu = '" + line + "' ";
            }
            if (!string.IsNullOrEmpty(startport))
            {
                sql = sql + "AND tb_yunjia.startport like '%" + startport + "%' ";
            }
            if (!string.IsNullOrEmpty(destport))
            {
                sql = sql + "AND tb_yunjiainfo.destport like '%" + destport + "%' ";
            }

        }


        ds = cn.mdb_ds(sql, "count");


        //计算出页数
        int item = 0;
        item = Convert.ToInt32(ds.Tables["count"].Rows[0][0]);
        int page = 0;
        if (item % 10 > 0 | item == 0)
        {
            page = item / 10 + 1;
        }
        else
        {
            page = item / 10;
        }



        //填充下拉页码框
        for (int i = 0; i <= page - 1; i++)
        {
            ListItem l = new ListItem("第" + (i + 1).ToString() + "页", (i + 1).ToString());
            ddlPageSelect.Items.Add(l);
        }

        //最后改写总页码标签
        lblTotalItem.Text = item.ToString();
        hidTotalItem.Text = item.ToString();
        lblTotalPage.Text = page.ToString();
    }

    public void delete()
    {
        //删除信息
        //要删除的纪录的ID，保存在delList隐藏控件内
        string id = delList.Text;
        if (!string.IsNullOrEmpty(id))
        {
            data_conn cn = new data_conn();
            string sql = null;
            sql = "";
            sql = sql + "delete from tb_yunjia where ID in (" + id + ")";
            cn.mdb_exe(sql);
            sql = "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.lclcount = (SELECT COUNT(tb_yunjia.id) AS yunjiacount FROM tb_yunjia,tb_yunjiainfo WHERE (yunjialeixing = 9) AND tb_yunjia.id = tb_yunjiainfo.yunjiaid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1";
            cn.mdb_exe(sql);
            MessageBox("opsuccess", "删除成功");

            //清空delList
            delList.Text = "";

            //同步topnew
            topnew tp = new topnew();
            tp.CheckTopNew("9", this.Request.Cookies["user_id"].Value.ToString());
        }
        else
        {
            //没有选择任何要删除的ID，弹出此对话框
            MessageBox("opfail", "未选择任何要删除的项目");
        }
    }



    protected void lnkFirstPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblCurrentPage.Text) != 1)
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
        if (Convert.ToInt32(lblCurrentPage.Text) > 1)
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
        if (Convert.ToInt32(lblCurrentPage.Text) < Convert.ToInt32(lblTotalPage.Text))
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
        if (Convert.ToInt32(lblCurrentPage.Text) != Convert.ToInt32(lblTotalPage.Text))
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
    protected void ddlPageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCurrentPage.Text = ddlPageSelect.SelectedIndex.ToString() + 1;
        LoadRecord(lblCurrentPage.Text);
        ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;

    }
    protected void btnHidDel_Click(object sender, EventArgs e)
    {
        //删除被选择的记录
        delete();
        //重新载入当前页
        LoadRecord(lblCurrentPage.Text);

        //如果当前页码大于总页码，不合理，于是载入前一页
        if (Convert.ToInt32(lblCurrentPage.Text) > Convert.ToInt32(lblTotalPage.Text))
        {
            lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
            LoadRecord(lblCurrentPage.Text);
        }
        else
        {
            LoadRecord(lblCurrentPage.Text);
        }

    }
    protected void btnHidUpdate_Click(object sender, EventArgs e)
    {
        update();
        //重新载入当前页
        LoadRecord(lblCurrentPage.Text);

        //如果当前页码大于总页码，不合理，于是载入前一页
        if (Convert.ToInt32(lblCurrentPage.Text) > Convert.ToInt32(lblTotalPage.Text))
        {
            lblCurrentPage.Text = Convert.ToString(Convert.ToInt32(lblCurrentPage.Text) - 1);
            LoadRecord(lblCurrentPage.Text);
        }
        else
        {
            LoadRecord(lblCurrentPage.Text);
        }

    }

    public void MessageBox(string strKey, string strInfo)
    {
        if (!ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

    public void update()
    {
        //更新信息
        //要更新的纪录的ID，保存在delList隐藏控件内
        string id = delList.Text;
        if (!string.IsNullOrEmpty(id))
        {
            data_conn cn = new data_conn();

            string enddate = "";
            DateTime dt = DateTime.Now;
            DateTime startMonth = dt.AddDays(1 - dt.Day);
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);

            if (DateTime.Now.Day >= 15)
            {
                enddate = endMonth.ToString().Split(' ')[0];
            }
            else
            {
                enddate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15";
            }

            string sql = null;
            sql = "";
            sql = sql + "update tb_yunjia set PostDate=getdate(),enddate='" + enddate + "' where ID in (" + id + ")";
            cn.mdb_exe(sql);
            sql = "";
            sql = sql + "update TB_YunJiaInfo set PostDatex=getdate(),enddatex='" + enddate + "' where ID in (" + id + ")";
            cn.mdb_exe(sql);
            sql = "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.fclcount = (SELECT COUNT(tb_yunjia.id) AS yunjiacount FROM tb_yunjia,tb_yunjiainfo WHERE (yunjialeixing = 9) AND tb_yunjia.id = tb_yunjiainfo.yunjiaid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1";
            cn.mdb_exe(sql);
            MessageBox("opsuccess", "更新成功");

            //清空delList
            delList.Text = "";

            //同步topnew
            topnew tp = new topnew();
            tp.CheckTopNew("9", this.Request.Cookies["user_id"].Value.ToString());
        }
        else
        {
            //没有选择任何要删除的ID，弹出此对话框
            MessageBox("opfail", "未选择任何要更新的项目");
        }

    }

}
