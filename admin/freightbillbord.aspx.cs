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

public partial class admin_freightbillbord : System.Web.UI.Page
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

        sql = "select tb_user.userid,tb_user.username,tb_user.realname,tb_user.companyname,a.c ";
        sql += "from tb_user, ";
        sql += "(select userid,count(userid) as c from ";
        sql += "(select tb_yunjiainfo.id as yid,tb_yunjia.userid as userid,tb_yunjia.postdate as postdate ";
        sql += "from tb_yunjia,tb_yunjiainfo ";
        sql += "where tb_yunjia.id = tb_yunjiainfo.yunjiaid ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql += "union all ";
        sql += "select T_AIRPRICE.id as yid,T_AIRINFO.userid as userid,T_AIRINFO.postdate as postdate ";
        sql += "from T_AIRINFO,T_AIRPRICE ";
        sql += "where T_AIRINFO.id = T_AIRPRICE.airid ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql += ") t ";
        sql += "group by userid) a ";
        sql += "where tb_user.userid = a.userid and c >= 20 ";
        sql += "order by c desc ";



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
