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

public partial class admin_sales_hitindex : System.Web.UI.Page
{
    public string ltime1 = "";
    public string ltime2 = "";
    public string type = "8";
    public string u = "0";
    public string top = "0";
    public string f1 = "0";
    check check1 = new check();
    GetRequest GetRequest1 = new GetRequest();
    public int hitcount = 0;
    public int hitmax = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            ltime1 = check1.CheckInput(GetRequest1.GetRequestQueryString("ltime1", ""));
            ltime2 = check1.CheckInput(GetRequest1.GetRequestQueryString("ltime2", ""));
            type = check1.CheckInput(GetRequest1.GetRequestQueryString("type", "8"));
            u = check1.CheckInput(GetRequest1.GetRequestQueryString("u", "0"));
            top = check1.CheckInput(GetRequest1.GetRequestQueryString("top", "0"));
            f1 = check1.CheckInput(GetRequest1.GetRequestQueryString("f1", "0"));

            if (ltime1 == "")
            {
                BasicDatePicker1_TextBox.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                BasicDatePicker1_TextBox.Value = ltime1;
            }
            if (ltime2 == "")
            {
                BasicDatePicker2_TextBox.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                BasicDatePicker2_TextBox.Value = ltime2;
            }

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
        string date3 = "";
        string date4 = "";

        string sqldate1 = "";
        string sqldate2 = "";
        string sqldate3 = "";
        string sqldate4 = "";

        string ftype = "8";

        date1 = BasicDatePicker1_TextBox.Value.ToString();
        date2 = BasicDatePicker2_TextBox.Value.ToString();
        date3 = BasicDatePicker1_TextBox.Value.ToString();
        date4 = BasicDatePicker2_TextBox.Value.ToString();

        if (date1 != "")
        {
            date3 = date3 + " 00:00:00";
            sqldate3 = sqldate3 + "AND nowtime >= '" + date3 + "' ";
            sqldate1 = sqldate1 + "AND dateparts >= '" + date1 + "' ";
        }

        if (date2 != "")
        {
            date4 = date4 + " 23:59:59";
            sqldate4 = sqldate4 + "AND nowtime <= '" + date4 + "' ";
            sqldate2 = sqldate2 + "AND dateparts <= '" + date2 + "' ";
        }


        string sql = "";

        if (f1 == "0")
        {
            if (type == "8" | type == "0")
            {
                Literal1.Text = "整箱运价" + " <a href=\"hitindex.aspx?u=" + u + "&type=9&ltime1=" + BasicDatePicker1_TextBox.Value + "&ltime2=" + BasicDatePicker2_TextBox.Value + "\">拼箱运价</a>" + " <a href=\"hitindex.aspx?u=" + u + "&type=10&ltime1=" + BasicDatePicker1_TextBox.Value + "&ltime2=" + BasicDatePicker2_TextBox.Value + "\">空运运价</a>";
            }

            if (type == "9")
            {
                Literal1.Text = "<a href=\"hitindex.aspx?u=" + u + "&type=8&ltime1=" + BasicDatePicker1_TextBox.Value + "&ltime2=" + BasicDatePicker2_TextBox.Value + "\">整箱运价</a>" + " 拼箱运价" + " <a href=\"hitindex.aspx?u=" + u + "&type=10&ltime1=" + BasicDatePicker1_TextBox.Value + "&ltime2=" + BasicDatePicker2_TextBox.Value + "\">空运运价</a>";
            }

            if (type == "10")
            {
                Literal1.Text = "<a href=\"hitindex.aspx?u=" + u + "&type=8&ltime1=" + BasicDatePicker1_TextBox.Value + "&ltime2=" + BasicDatePicker2_TextBox.Value + "\">整箱运价</a>" + " <a href=\"hitindex.aspx?u=" + u + "&type=9&ltime1=" + BasicDatePicker1_TextBox.Value + "&ltime2=" + BasicDatePicker2_TextBox.Value + "\">拼箱运价</a>" + " 空运运价";
            }

            sql = "SELECT dateparts,(CASE WHEN C IS NULL THEN 0 ELSE C END) AS c ";
            sql = sql + "FROM (SELECT CONVERT(varchar(20), NowTime, 23) AS dateday, ";
            sql = sql + "COUNT(CONVERT(varchar(20), NowTime, 23)) AS c ";
            sql = sql + "FROM TB_FREIGHT_VIEWRECORD ";
            sql = sql + "WHERE (yuserid = " + u + ") AND (freight_type = " + type + ") ";
            sql = sql + "GROUP BY CONVERT(varchar(20), NowTime, 23)) T1 RIGHT OUTER JOIN ";
            sql = sql + "(SELECT CONVERT(varchar(20), the_date, 23) AS dateparts ";
            sql = sql + "FROM TB_Time_Dimension AS dateparts) T2 ON T1.dateday = T2.dateparts WHERE 1=1 ";
            sql = sql + sqldate1;
            sql = sql + sqldate2;
            sql = sql + "order by dateparts ";
        }
        else
        {
            PlaceHolder1.Visible = false;
            


            string[] k;
            k = new string[100];
            AllinFreight AllinFreight1 = new AllinFreight();
            k = AllinFreight1.GetFreightDetail("8", f1, "0");

            string avg = "";
            Literal3.Text = "相关运价：" + k[35];
            Literal3.Text += " (" + k[2] + "," + k[3] + "起运，该条航线全站平均点击量(该功能建设中)" + avg + ")";

            sql = "SELECT dateparts,(CASE WHEN C IS NULL THEN 0 ELSE C END) AS c ";
            sql = sql + "FROM (SELECT CONVERT(varchar(20), NowTime, 23) AS dateday, ";
            sql = sql + "COUNT(CONVERT(varchar(20), NowTime, 23)) AS c ";
            sql = sql + "FROM TB_FREIGHT_VIEWRECORD ";
            sql = sql + "WHERE (freight_code = " + f1 + ") AND (freight_type = " + type + ") ";
            sql = sql + "GROUP BY CONVERT(varchar(20), NowTime, 23)) T1 RIGHT OUTER JOIN ";
            sql = sql + "(SELECT CONVERT(varchar(20), the_date, 23) AS dateparts ";
            sql = sql + "FROM TB_Time_Dimension AS dateparts) T2 ON T1.dateday = T2.dateparts WHERE 1=1 ";
            sql = sql + sqldate1;
            sql = sql + sqldate2;
            sql = sql + "order by dateparts ";


            if (GetRequest1.GetRequestCookies("admin_group", "3").ToString() != "3")
            {
                string sqldetail = "";
                PlaceHolder2.Visible = true;
                sqldetail = "";
                sqldetail += "SELECT TB_FREIGHT_VIEWRECORD.NowTime,TB_USER.Realname,TB_USER.Companyname ";
                sqldetail += "FROM TB_FREIGHT_VIEWRECORD INNER JOIN TB_USER ON TB_FREIGHT_VIEWRECORD.userid = TB_USER.userid ";
                sqldetail += "WHERE (freight_code = " + f1 + ") AND (freight_type = " + type + ") ";
                sqldetail = sqldetail + sqldate3;
                sqldetail = sqldetail + sqldate4;
                sqldetail = sqldetail + "ORDER BY TB_FREIGHT_VIEWRECORD.id DESC ";
                ds = cn.mdb_ds(sqldetail, "view1");
                //Response.Write(sqldetail);
                Repeater3.DataSource = ds.Tables["view1"].DefaultView;
                Repeater3.DataBind();
            }
        }



        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "view");

 

        for (int i = 0; i < ds.Tables["view"].Rows.Count; i++)
        {
            if (hitmax < Convert.ToInt32(ds.Tables["view"].Rows[i]["c"].ToString()))
            {
                hitmax = Convert.ToInt32(ds.Tables["view"].Rows[i]["c"].ToString());
            }
            hitcount += Convert.ToInt32(ds.Tables["view"].Rows[i]["c"].ToString());
        }

        Literal2.Text = hitcount.ToString();

        Repeater1.DataSource = ds.Tables["view"].DefaultView;
        Repeater1.DataBind();




        if (top == "0")
        { 
        
        }


        sql = "";
        sql += "SELECT TB_FREIGHT_VIEWRECORD.freight_code as id,title,postdate,enddate,hangxianmiaoshu,startport,order_adv,count(TB_FREIGHT_VIEWRECORD.freight_code) as c,'?f1='+ convert(nvarchar(50),TB_FREIGHT_VIEWRECORD.freight_code,112) + '&type=" + type + "&ltime1=" + ltime1 + "&ltime2=" + ltime2 + "' AS qs  ";
        sql += "FROM TB_FREIGHT_VIEWRECORD left join TB_Yunjia on TB_Yunjia.id = TB_FREIGHT_VIEWRECORD.freight_code ";
        sql += "WHERE (yuserid = " + u + ") AND (freight_type = " + type + ") ";
        sql = sql + sqldate3;
        sql = sql + sqldate4;
        sql = sql + "group by TB_FREIGHT_VIEWRECORD.freight_code,title,postdate,enddate,hangxianmiaoshu,startport,order_adv ";
        sql = sql + "ORDER BY postdate ";
        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "view");

        Repeater2.DataSource = ds.Tables["view"].DefaultView;
        Repeater2.DataBind();

        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        u = check1.CheckInput(GetRequest1.GetRequestQueryString("u", "0"));
        type = check1.CheckInput(GetRequest1.GetRequestQueryString("type", "8"));
        top = check1.CheckInput(GetRequest1.GetRequestQueryString("top", "0"));
        Response.Redirect("hitindex.aspx?u=" + u + "&type=" + type + "&top=" + top + "&ltime1=" + BasicDatePicker1_TextBox.Value + "&ltime2=" + BasicDatePicker2_TextBox.Value);
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
