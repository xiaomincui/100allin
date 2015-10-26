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

public partial class tools_hs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        if (!IsPostBack)
        {
            if (this.Request["id"] == null || this.Request["id"] == "")
            {
                LoadRecord("1", "");
            }
            else
            {
                LoadRecord(ck.CheckNumber(this.Request["id"].ToString()), "");
            }

        }
        

    }

    public void LoadRecord(string page,string search)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        
        string sql = "";
        int item = (Convert.ToInt32(page) - 1) * 100;

        sql += "select top 100 * from ";
        sql += "(select id,number,name from TB_HS ";

        sql += "where 1=1 ";
        if (search != "")
        {
            sql += "and (number like '%" + search + "%' or name like '%" + search + "%') ";
        }

        sql += ") as T ";
        sql += "where id not in ";
        sql += "(select top " + item + " id from TB_HS ";
        sql += "where 1=1 ";
        if (search != "")
        {
            sql += "and (number like '%" + search + "%' or name like '%" + search + "%') ";
        }

        sql += "order BY TB_HS.id DESC) ";
        sql += "ORDER BY id DESC";

        

        DataSet ds = cn.mdb_ds(sql, "HS");


        Repeater1.DataSource = ds.Tables["HS"].DefaultView;
        Repeater1.DataBind();
        LoadTotalCount();
    }

    public void LoadTotalCount()
    {
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select count(*) from TB_HS", "count");
        int count = Convert.ToInt32(ds.Tables["count"].Rows[0][0]) / 100 + 1;

        string page = "";
        for (int i = 0; i < count; i++)
        {
            page += "<a href='hs.aspx?id=" + Convert.ToString(i + 1) + "'>" + Convert.ToString(i + 1) + "</a> ";
        }

        if (this.Request["id"] == null || this.Request["id"] == "")
        {
            page += "<a href='hs.aspx?id=2'>下一页</a>";
        }
        else if (this.Request["id"].ToString() == Convert.ToString(count))
        {

        }
        else
        {
            page += "<a href='hs.aspx?id=" + Convert.ToString(Convert.ToInt32(this.Request["id"]) + 1) + "'>下一页</a>";
        }


        if (this.Request["id"] == null || this.Request["id"] == "")
        {
            page = page.Replace("<a href='hs.aspx?id=1'>1</a> ", "<strong style='font-size:14px;'>1</strong> ");
        }
        else
        {
            page = page.Replace("<a href='hs.aspx?id=" + this.Request["id"].ToString() + "'>" + this.Request["id"].ToString() + "</a> ", "<strong style='font-size:14px;'>" + this.Request["id"].ToString() + "</strong> ");
        }


        Literal1.Text = page;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();

        LoadRecord("1", ck.CheckInput(this.TextBox2.Text));
    }
}
