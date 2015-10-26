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

public partial class pro_order_new : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        login lg = new login();
        lg.login();

        Random rd = new Random();

        ltrGongZuoBianHao.Text = "FCL" + DateTime.Now.ToString("yyMMddHHmm") + GetFourDigits(Convert.ToInt32(10000 * rd.NextDouble()).ToString());


        LoadFreightData();
    }

    protected void LoadFreightData()
    {
        check ck = new check();
        pro_data_conn cn = new pro_data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //获取运价信息
        string yid = "";
        yid = ck.CheckNumber(GetRequestQueryString("yid", "0"));
        sql = "SELECT * FROM tb_yunjia WHERE id = " +　yid;
        ds = cn.mdb_ds(sql, "yunjia");
        ltrYid.Text = "<a href=\"/fcl/" + setkey(yid) + "_0.html\" target=\"_blank\">" + yid + "</a>";
        ltrYid2.Text = yid;
        ltrStartPort.Text = ds.Tables["yunjia"].Rows[0]["Startport"].ToString();
        ltrDestPort.Text = ds.Tables["yunjia"].Rows[0]["Destport1"].ToString();
        ltrCarrier.Text = ds.Tables["yunjia"].Rows[0]["shipcompany1"].ToString();
        ltrEndDate.Text = Convert.ToDateTime(ds.Tables["yunjia"].Rows[0]["enddate"].ToString()).ToString("yyyy-MM-dd");
        ltrUserid.Text = ds.Tables["yunjia"].Rows[0]["userid"].ToString();



        //获取本人信息
        string userid = "";
        userid = ck.CheckNumber(GetRequestCookies("user_id","0"));
        sql = "SELECT * FROM tb_user WHERE userid = " + userid;
        ds = cn.mdb_ds(sql, "user");
        ltrUserEmail.Text = ds.Tables["user"].Rows[0]["UserEmail"].ToString();
        ltrRealName.Text = ds.Tables["user"].Rows[0]["RealName"].ToString();
        ltrMovePhone.Text = ds.Tables["user"].Rows[0]["MovePhone"].ToString();
        ltrPhone.Text = ds.Tables["user"].Rows[0]["Phone"].ToString();
        ltrFax.Text = ds.Tables["user"].Rows[0]["Fax"].ToString();

    }

    public string GetRequestQueryString(string q, string d)
    {
        string outputstring = d;
        if (Request.QueryString[q] != null)
        {
            if (Request.QueryString[q].ToString() != "")
            {
                outputstring = Request.QueryString[q].ToString();
            }
        }
        return outputstring;
    }//获得网页字符串参数

    public string GetRequestCookies(string c, string d)
    {
        string outputstring = d;
        if (Request.Cookies[c] != null)
        {
            if (Request.Cookies[c].Value.ToString() != "")
            {
                outputstring = Request.Cookies[c].Value.ToString();
            }
        }
        return outputstring;
    }//获得指定Cookies参数


    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

    protected string GetFourDigits(string d)
    {
        int id = Convert.ToInt32(d);
        string sd = d;

        if (id < 10)
        {
            sd = "000" + sd;
        }
        else
        {
            if (id < 100)
            {
                sd = "00" + sd;
            }
            else
            {
                if (id < 1000)
                {
                    sd = "0" + sd;
                }
            }
        }
        return sd;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        pro_data_conn cn = new pro_data_conn();
        DataSet ds = new DataSet();
        string sql = "";


        string order_status = "1";
        string order_code = ltrGongZuoBianHao.Text;
        string order_shipper = ck.CheckNumber(GetRequestCookies("user_id", "0"));
        string order_forward = ck.CheckNumber(ltrUserid.Text);
        string shipper_name = ck.CheckInput(txtShipperName.Value);
        string cargo_name = ck.CheckInput(txtCargoName.Value);
        string measurement = ck.CheckInput(txtMeasurement.Value);
        string carrier_name = ck.CheckInput(ltrCarrier.Text);
        string startport = ck.CheckInput(ltrStartPort.Text);
        string destport = ck.CheckInput(ltrDestPort.Text);
        string container_20gp = ck.CheckNumber(txtContainer_20gp.Value);
        string container_40gp = ck.CheckNumber(txtContainer_40gp.Value);
        string container_40hq = ck.CheckNumber(txtContainer_40hq.Value);
        string freight_type = "8";
        string freight_code = ltrYid2.Text;


        sql += "INSERT INTO TB_ORDER ";
        sql += "( ";
        sql += "date_create, ";
        sql += "order_status, ";
        sql += "order_code, ";
        sql += "order_shipper, ";
        sql += "order_forward, ";
        sql += "shipper_name, ";
        sql += "cargo_name, ";
        sql += "measurement, ";
        sql += "carrier_name, ";
        sql += "startport, ";
        sql += "destport, ";
        sql += "container_20gp, ";
        sql += "container_40gp, ";
        sql += "container_40hq, ";
        sql += "freight_type, ";
        sql += "freight_code ";
        sql += ") ";
        sql += "VALUES ";
        sql += "( ";
        sql += "GetDate(), ";
        sql += "" + order_status + ", ";
        sql += "'" + order_code + "', ";
        sql += "" + order_shipper + ", ";
        sql += "" + order_forward + ", ";
        sql += "'" + shipper_name + "', ";
        sql += "'" + cargo_name + "', ";
        sql += "'" + measurement + "', ";
        sql += "'" + carrier_name + "', ";
        sql += "'" + startport + "', ";
        sql += "'" + destport + "', ";
        sql += "" + container_20gp + ", ";
        sql += "" + container_40gp + ", ";
        sql += "" + container_40hq + ", ";
        sql += "" + freight_type + ", ";
        sql += "" + freight_code + " ";
        sql += ") ";

        //Response.Write(sql);
        cn.mdb_exe(sql);

        Response.Redirect("success.aspx");
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        check ck = new check();
        pro_data_conn cn = new pro_data_conn();
        DataSet ds = new DataSet();
        string sql = "";


        string order_status = "2";
        string order_code = ltrGongZuoBianHao.Text;
        string order_shipper = ck.CheckNumber(GetRequestCookies("user_id", "0"));
        string order_forward = ck.CheckNumber(ltrUserid.Text);
        string shipper_name = ck.CheckInput(txtShipperName.Value);
        string cargo_name = ck.CheckInput(txtCargoName.Value);
        string measurement = ck.CheckInput(txtMeasurement.Value);
        string carrier_name = ck.CheckInput(ltrCarrier.Text);
        string startport = ck.CheckInput(ltrStartPort.Text);
        string destport = ck.CheckInput(ltrDestPort.Text);
        string container_20gp = ck.CheckNumber(txtContainer_20gp.Value);
        string container_40gp = ck.CheckNumber(txtContainer_40gp.Value);
        string container_40hq = ck.CheckNumber(txtContainer_40hq.Value);
        string freight_type = "8";
        string freight_code = ltrYid2.Text;


        sql += "INSERT INTO TB_ORDER ";
        sql += "( ";
        sql += "date_create, ";
        sql += "order_status, ";
        sql += "order_code, ";
        sql += "order_shipper, ";
        sql += "order_forward, ";
        sql += "shipper_name, ";
        sql += "cargo_name, ";
        sql += "measurement, ";
        sql += "carrier_name, ";
        sql += "startport, ";
        sql += "destport, ";
        sql += "container_20gp, ";
        sql += "container_40gp, ";
        sql += "container_40hq, ";
        sql += "freight_type, ";
        sql += "freight_code ";
        sql += ") ";
        sql += "VALUES ";
        sql += "( ";
        sql += "GetDate(), ";
        sql += "" + order_status + ", ";
        sql += "'" + order_code + "', ";
        sql += "" + order_shipper + ", ";
        sql += "" + order_forward + ", ";
        sql += "'" + shipper_name + "', ";
        sql += "'" + cargo_name + "', ";
        sql += "'" + measurement + "', ";
        sql += "'" + carrier_name + "', ";
        sql += "'" + startport + "', ";
        sql += "'" + destport + "', ";
        sql += "" + container_20gp + ", ";
        sql += "" + container_40gp + ", ";
        sql += "" + container_40hq + ", ";
        sql += "" + freight_type + ", ";
        sql += "" + freight_code + " ";
        sql += ") ";

        //Response.Write(sql);
        cn.mdb_exe(sql);

        Response.Redirect("success.aspx");
    }
}
