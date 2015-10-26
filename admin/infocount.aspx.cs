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

public partial class admin_infocount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            BasicDatePicker2_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            LoadRecord();
        }
    }

    protected void LoadRecord()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        check ck = new check();

        string date1 = "";
        string date2 = "";

        string sqldate1 = "";
        string sqldate2 = "";

        date1 = BasicDatePicker1_TextBox.Value.ToString();
        date2 = BasicDatePicker2_TextBox.Value.ToString();

        if (date1 != "")
        {
            date1 = date1 + " 00:00:00";
            sqldate1 = sqldate1 + "AND PostDate >= '" + date1 + "' ";
        }

        if (date2 != "")
        {
            date2 = date2 + " 23:59:59";
            sqldate2 = sqldate2 + "AND PostDate <= '" + date2 + "' ";
        }


        string sql = "";

        sql = "select '整箱海运运价' as t,count(*) as c from tb_yunjia where yunjialeixing = 8 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '拼箱海运运价' as t,count(*) as c from tb_yunjia where yunjialeixing = 9 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '空运海运运价' as t,count(*) as c from T_AIRINFO ";
        sql = sql + "where 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '货盘' as t,count(*) as c from TB_AIRGOODS ";
        sql = sql + "where 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '公司库信息' as t,count(*) as c from Company ";
        sql = sql + "where 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '论坛帖子' as t,count(*) as c from TB_BBS ";
        sql = sql + "where 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;


        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "TB_BrowseRecord");

        Repeater1.DataSource = ds.Tables["TB_BrowseRecord"].DefaultView;
        Repeater1.DataBind();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadRecord();
    }
}
