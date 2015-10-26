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

public partial class message_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select TB_BBS.*,TB_User.* from TB_BBS,TB_User where id=" + this.Request["id"]+" and TB_BBS.UserId*=TB_User.UserId", "bbs");
        if (ds.Tables["bbs"].Rows[0]["Data"].ToString() != "")
        {
            this.Label1.Text = ds.Tables["bbs"].Rows[0]["Data"].ToString();
        }
        else
        {
            this.Label1.Visible = false;
        }
        laltitlename.Text = ds.Tables["bbs"].Rows[0]["UserName"].ToString();
        if ((bool)ds.Tables["bbs"].Rows[0]["HeadURL"] == true)
        {
            this.Image1.ImageUrl = "../member/Head/" + ds.Tables["bbs"].Rows[0]["UserID"] + ".jpg";
        }
        else
        {
            this.Image1.ImageUrl = "../member/Head/default.jpg";
        }
        

        if (!IsPostBack)
        {
            LoadRecord(lblCurrentPage.Text);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.Request.Cookies["user_id"] == null)
        {

        }
        else
        {
            if (this.Request.Cookies["user_id"].Value == "")
            {

            }
            else
            {
                data_conn cn = new data_conn();
                DataSet ds;
                ds = cn.mdb_ds("select overMessage from TB_BBS where id=" + this.Request["id"], "overMessage");

                if ((bool)ds.Tables["overMessage"].Rows[0]["overMessage"]!=false )
                {
                    TimeSpan TS = new TimeSpan();
                    TimeSpan time = new TimeSpan();

                    ds = cn.mdb_ds("select top 1 postdate from TB_message where UserID=" + this.Request.Cookies["user_id"].Value + " and BBSID=" + this.Request["id"] + "order by PostDate desc", "table");
                    //防止这个帖子暂时没有人会，设置i为true
                    bool i = false;
                    if (ds.Tables["table"].Rows.Count == 0)
                    {
                        i = true;
                    }
                    else
                    {
                        time = new TimeSpan(0);
                        TS = DateTime.Now.AddSeconds(-10) - DateTime.Parse(ds.Tables["table"].Rows[0][0].ToString());
                    }

                    //当前人没有回过这个贴，或者上一个回帖时间大于10秒
                    if (TS.CompareTo(time) == 1 || i)
                    {
                        string text = this.TextBox1.Text.Replace("\r", "<br>");
                        text = text.Replace(" ", "&nbsp");
                        cn.mdb_exe("insert into TB_Message (UserID,PostDate,Data,type,BBSID) values (" + this.Request.Cookies["user_id"].Value + ",getdate(),'" + text + "',1," + this.Request["id"] + ")");
                        cn.mdb_exe("update TB_BBS set UpdateDate=getdate() where id=" + this.Request["id"]);
                        TextBox1.Text = "";
                    }
                    else
                    {
                        this.Response.Write("对不起，你不能在10秒钟之内连续发回复");
                    }
                }
                else
                {
                    this.Response.Write("对不起，此帖已经结贴");
                }



                


                
                
            }
            
        }
        LoadRecord(lblCurrentPage.Text);

    }

    //根据参数id，搜索出当前这个帖子的所有留言，显示在repeater1中
    public void LoadRecord(string page)
    {
        data_conn cn = new data_conn();
        
        int item = (Convert.ToInt32(page) - 1) * 10;
        string sql = "";
        sql = "select top 10 ";
        sql = sql + "id,UserID,Data,PostDate,EditDate,UserName,HeadURL ";
        sql = sql + "FROM (SELECT ";
        sql = sql + "TB_Message.id,TB_Message.UserID,TB_Message.Data,TB_Message.PostDate,TB_Message.EditDate,TB_User.UserName,TB_User.HeadURL ";
        sql = sql + "FROM ";
        sql = sql + "TB_Message,TB_User ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 and TB_User.UserID=TB_Message.UserID ";
        sql = sql + "and BBSID=" + this.Request["id"] + " ";

        sql = sql + ") AS T ";
        sql = sql + "WHERE id NOT IN ";
        sql = sql + "(SELECT TOP " + item.ToString() + " id ";
        sql = sql + "FROM ";
        sql = sql + "TB_Message ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        sql = sql + "and BBSID=" + this.Request["id"] + " ";
        sql = sql + "ORDER BY TB_Message.id  ";
        sql = sql + ") ";
        sql = sql + "ORDER BY id ";

        DataSet ds = cn.mdb_ds(sql, "bbs");

        Repeater1.DataSource = ds.Tables["bbs"].DefaultView;
        Repeater1.DataBind();
        LoadTotalCount();
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
        string sql = "";


        sql = sql + "SELECT ";
        sql = sql + "count(*) as T ";
        sql = sql + "FROM ";
        sql = sql + "TB_Message ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 ";
        sql = sql + "and BBSID=" + this.Request["id"] + " ";


        ds = cn.mdb_ds(sql, "count");


        //计算出页数
        int item;
        item = (int)ds.Tables["count"].Rows[0][0];
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

        lblTotalPage.Text = page.ToString();
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
        lblCurrentPage.Text = Convert.ToString(ddlPageSelect.SelectedIndex + 1);
        LoadRecord(lblCurrentPage.Text);
        ddlPageSelect.SelectedIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;
    }

    public void MessageBox(string strKey, string strInfo)
    {
        if (!ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("BBSadminMessage.aspx?id=" + this.Request["id"].ToString());
        
    }
}
