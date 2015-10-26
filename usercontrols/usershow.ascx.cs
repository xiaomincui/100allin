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

public partial class usercontrols_usershow : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDetailAll();
        LoadDetailUpgrade();
        LoadDetailPrice();
        LoadDetailNewuser();
        LoadDetailChatroom();
        LoadDetailBBS();
    }

    public string DateFormat(string d)
    {
        string outputtime = d;

        try
        {
            DateTime t = Convert.ToDateTime(d);

            DateTime dt = DateTime.Now;

            Int64 timespan1 = 0;

            timespan1 = Convert.ToInt64(dt.ToFileTime().ToString()) - Convert.ToInt64(t.ToFileTime().ToString());

            timespan1 = timespan1 / 10000000;

            

            //outputtime = timespan1.ToString();

            if (timespan1 < 60)
            {
                outputtime = timespan1.ToString() + "秒前";
            }
            else
            {
                if (timespan1 >= 60 & timespan1 < 3600)
                {
                    timespan1 = timespan1 / 60;
                    outputtime = timespan1.ToString() + "分钟前";

                }
                else
                {
                    if (timespan1 >= 3600 & timespan1 < 86400)
                    {
                        timespan1 = timespan1 / 3600;
                        outputtime = timespan1.ToString() + "小时前";

                    }
                    else
                    {
                        outputtime = d.ToString();
                    }
                }
            }

        }
        catch 
        { 
        
        }


        return outputtime;
    }

    public void LoadDetailAll()
    {
        data_conn cn = new data_conn();
        DataSet ds;

        string sql = "";
        sql = sql + "SELECT TOP 5 * ";
        sql = sql + "FROM ";
        sql = sql + "V_SHOW_ALL ";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "inroomchat");

        DataList1.DataSource = ds.Tables["inroomchat"].DefaultView;
        DataList1.DataBind();

    }

    public void LoadDetailUpgrade()
    {
        data_conn cn = new data_conn();
        DataSet ds;

        string sql = "";
        sql = sql + "SELECT TOP 5 * ";
        sql = sql + "FROM ";
        sql = sql + "V_SHOW_UPGRADE ";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "inroomchat");

        DataList2.DataSource = ds.Tables["inroomchat"].DefaultView;
        DataList2.DataBind();

    }

    public void LoadDetailPrice()
    {
        data_conn cn = new data_conn();
        DataSet ds;

        string sql = "";
        sql = sql + "SELECT TOP 5 * ";
        sql = sql + "FROM ";
        sql = sql + "V_SHOW_PRICE ";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "inroomchat");

        DataList3.DataSource = ds.Tables["inroomchat"].DefaultView;
        DataList3.DataBind();

    }


    public void LoadDetailNewuser()
    {
        data_conn cn = new data_conn();
        DataSet ds;

        string sql = "";
        sql = sql + "SELECT TOP 5 * ";
        sql = sql + "FROM ";
        sql = sql + "V_SHOW_NEWUSER ";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "inroomchat");

        DataList4.DataSource = ds.Tables["inroomchat"].DefaultView;
        DataList4.DataBind();

    }

    public void LoadDetailBBS()
    {
        data_conn cn = new data_conn();
        DataSet ds;

        string sql = "";
        sql = sql + "SELECT TOP 5 * ";
        sql = sql + "FROM ";
        sql = sql + "V_SHOW_BBS ";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "inroomchat");

        DataList5.DataSource = ds.Tables["inroomchat"].DefaultView;
        DataList5.DataBind();

    }

    public void LoadDetailChatroom()
    {
        data_conn cn = new data_conn();
        DataSet ds;

        string sql = "";
        sql = sql + "SELECT TOP 5 * ";
        sql = sql + "FROM ";
        sql = sql + "V_SHOW_CHATROOM ";


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "inroomchat");

        DataList6.DataSource = ds.Tables["inroomchat"].DefaultView;
        DataList6.DataBind();

    }
}
