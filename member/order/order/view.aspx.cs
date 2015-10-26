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

public partial class pro_order_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        login lg = new login();
        lg.login();

        LoadOrderData();
    }

    protected void LoadOrderData()
    {
        check ck = new check();
        pro_data_conn cn = new pro_data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        //获取运价信息
        string orderid = "";
        orderid = ck.CheckInput(GetRequestQueryString("orderid", "0"));
        sql = "SELECT * FROM tb_order WHERE order_code = '" + orderid + "'";
        ds = cn.mdb_ds(sql, "order");

        ltrYid.Text = "<a href=\"/fcl/" + setkey(ds.Tables["order"].Rows[0]["freight_code"].ToString()) + "_0.html\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["freight_code"].ToString() + "</a>";
        ltrYid2.Text = ds.Tables["order"].Rows[0]["freight_code"].ToString();
        ltrStartPort.Text = ds.Tables["order"].Rows[0]["startport"].ToString();
        ltrDestPort.Text = ds.Tables["order"].Rows[0]["destport"].ToString();
        ltrCarrier.Text = ds.Tables["order"].Rows[0]["carrier_name"].ToString();
        //ltrEndDate.Text = Convert.ToDateTime(ds.Tables["order"].Rows[0]["enddate"].ToString()).ToString("yyyy-MM-dd");
        ltrUserid.Text = ds.Tables["order"].Rows[0]["order_forward"].ToString();

        txtShipperName.Value = ds.Tables["order"].Rows[0]["shipper_name"].ToString();
        txtCargoName.Value = ds.Tables["order"].Rows[0]["cargo_name"].ToString();
        txtMeasurement.Value = ds.Tables["order"].Rows[0]["measurement"].ToString();
        ltrGongZuoBianHao.Text = ds.Tables["order"].Rows[0]["order_code"].ToString();

        txtContainer_20gp.Value = ds.Tables["order"].Rows[0]["container_20gp"].ToString();
        txtContainer_40gp.Value = ds.Tables["order"].Rows[0]["container_40gp"].ToString();
        txtContainer_40hq.Value = ds.Tables["order"].Rows[0]["container_40hq"].ToString();


        //获取本人信息
        string userid = "";
        userid = ck.CheckNumber(GetRequestCookies("user_id", "0"));
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

    }

}
