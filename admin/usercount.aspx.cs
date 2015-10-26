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

public partial class admin_usercount : System.Web.UI.Page
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
            sqldate1 = sqldate1 + "AND Regtime >= '" + date1 + "' ";
        }

        if (date2 != "")
        {
            date2 = date2 + " 23:59:59";
            sqldate2 = sqldate2 + "AND Regtime <= '" + date2 + "' ";
        }


        string sql = "";

        sql = "SELECT '全部' AS u, COUNT(*) AS c FROM tb_user ";
        sql = sql + "where 1=1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '货代' as u, COUNT(*) AS c FROM tb_user ";
        sql = sql + "where tb_user.CompanyType = 2 and importtype = 0 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '货代导入' as u, COUNT(*) AS c FROM tb_user ";
        sql = sql + "where tb_user.CompanyType = 2 and importtype = 1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '船公司' as u, COUNT(*) AS c FROM tb_user ";
        sql = sql + "where tb_user.CompanyType = 3 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '直客自注册' as u, COUNT(*) AS c FROM tb_user ";
        sql = sql + "where tb_user.CompanyType = 1 and importtype = 0 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '直客导入' as u, COUNT(*) AS c FROM tb_user ";
        sql = sql + "where tb_user.CompanyType = 1 and importtype = 1 ";
        sql = sql + sqldate1;
        sql = sql + sqldate2;
        sql = sql + "union all ";
        sql = sql + "select '其他' as u, COUNT(*) AS c FROM tb_user ";
        sql = sql + "where tb_user.CompanyType = 4 ";
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
