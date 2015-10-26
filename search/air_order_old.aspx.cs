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

public partial class search_air_order : System.Web.UI.Page
{
    public string pub_f = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        login l = new login();
        l.login();

        ltrLoginName.Text = GetRequestCookies("user_name", "");

        if (!Page.IsPostBack)
        {
            switch (GetRequestQueryString("filter", "0"))
            {
                case "new":
                    PlaceHolder2.Visible = true;
                    PlaceHolder1.Visible = false;
                    PlaceHolder5.Visible = false;
                    PlaceHolder6.Visible = false;
                    PlaceHolder7.Visible = true;
                    PlaceHolder3.Visible = true;
                    LoadNewOrder();
                    break;
                case "view":
                    PlaceHolder1.Visible = true;
                    PlaceHolder2.Visible = false;
                    PlaceHolder5.Visible = false;
                    PlaceHolder6.Visible = false;
                    PlaceHolder7.Visible = true;
                    LoadSavedOrder();
                    break;
                case "edit":
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = false;
                    PlaceHolder5.Visible = true;
                    PlaceHolder6.Visible = true;
                    PlaceHolder7.Visible = false;
                    LoadEditOrder();
                    break;
                default:
                    Response.Redirect("/search/err.aspx");
                    break;
            }
        }
    }

    public void LoadNewOrder()
    {
        Random rd = new Random();
        txtCode.Value = "AIR" + DateTime.Now.ToString("yyMMddHHmm") + GetFourDigits(Convert.ToInt32(10000 * rd.NextDouble()).ToString());

        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();



        string sql = "";

        if (ck.CheckNumber(Request.QueryString["ydid"]) == "0")
        {
            sql += "SELECT * FROM T_AIRINFO,T_AIRPRICE ";
            sql += "WHERE T_AIRINFO.id = T_AIRPRICE.airid ";
            sql += "AND T_AIRINFO.id = " + ck.CheckNumber(Request.QueryString["yid"]) + " ";
            sql += "ORDER BY T_AIRPRICE.id desc";
        }
        else
        {
            sql += "SELECT * FROM T_AIRINFO,T_AIRPRICE ";
            sql += "WHERE T_AIRINFO.id = T_AIRPRICE.airid ";
            sql += "AND T_AIRPRICE.id = " + ck.CheckNumber(Request.QueryString["ydid"]);
        }



        ds = cn.mdb_ds(sql, "yunjia");

        ltrEndDate.Text = Convert.ToDateTime(ds.Tables["yunjia"].Rows[0]["enddate"].ToString()).ToString("yyyy-MM-dd");

        ltrFreight.Text = "<a href=\"/fcl/" + key(ck.CheckNumber(Request.QueryString["yid"])) + "_" + ck.CheckNumber(Request.QueryString["ydid"]) + ".html\" target=\"_blank\">" + ds.Tables["yunjia"].Rows[0]["title"].ToString() + "</a>";

        ltrFreightDetail.Text = "<b style=\"font-size:14px; font-weight:bold;\">";
        ltrFreightDetail.Text += "M：<b style=\"color:#FF0000;\">" + ds.Tables["yunjia"].Rows[0]["PRICE_M"].ToString() + "</b>&nbsp;&nbsp;";
        ltrFreightDetail.Text += "N：<b style=\"color:#FF0000;\">" + ds.Tables["yunjia"].Rows[0]["PRICE_N"].ToString() + "</b>&nbsp;&nbsp;";
        ltrFreightDetail.Text += "+45：<b id='f20gp' style=\"color:#FF0000;\">" + ds.Tables["yunjia"].Rows[0]["PRICE_P45"].ToString() + "</b>&nbsp;&nbsp;";
        ltrFreightDetail.Text += "+100：<b id='f40gp' style=\"color:#FF0000;\">" + ds.Tables["yunjia"].Rows[0]["PRICE_P100"].ToString() + "</b>&nbsp;&nbsp;";
        ltrFreightDetail.Text += "+300：<b style=\"color:#FF0000;\">" + ds.Tables["yunjia"].Rows[0]["PRICE_P300"].ToString() + "</b>&nbsp;&nbsp;";
        ltrFreightDetail.Text += "+500：<b style=\"color:#FF0000;\">" + ds.Tables["yunjia"].Rows[0]["PRICE_P500"].ToString() + "</b>&nbsp;&nbsp;";
        ltrFreightDetail.Text += "+1000：<b id='f40hq' style=\"color:#FF0000;\">" + ds.Tables["yunjia"].Rows[0]["PRICE_P1000"].ToString() + "</b>";
        ltrFreightDetail.Text += "</b>";

        //txtcarrier_name.Value = ds.Tables["yunjia"].Rows[0]["shipcompany"].ToString();

        string u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        sql = "";
        sql += "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + u;

        ds = cn.mdb_ds(sql, "account");

        txtbank.Value = ds.Tables["account"].Rows[0]["bank"].ToString();
        txtbankname.Value = ds.Tables["account"].Rows[0]["bankname"].ToString();
        txtbankaccount.Value = ds.Tables["account"].Rows[0]["bankaccount"].ToString();
        txtotheraccount.Value = ds.Tables["account"].Rows[0]["otheraccount"].ToString();

        sql = "";
        sql += "SELECT * FROM TB_USER WHERE userid = " + u;

        ds = cn.mdb_ds(sql, "user");

        txtCompanyName.Value = ds.Tables["user"].Rows[0]["CompanyName"].ToString();
        txtEmail.Value = ds.Tables["user"].Rows[0]["UserEmail"].ToString();
        txtContactor.Value = ds.Tables["user"].Rows[0]["Realname"].ToString();
        txtMobile.Value = ds.Tables["user"].Rows[0]["MovePhone"].ToString();
        txtTel.Value = ds.Tables["user"].Rows[0]["Phone"].ToString();
        txtFax.Value = ds.Tables["user"].Rows[0]["Fax"].ToString();
    }//载入新订单

    public void LoadEditOrder()
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        string sql = "";

        sql += "SELECT * FROM TB_ORDER,TB_ORDER_STATUS WHERE TB_ORDER.order_status = TB_ORDER_STATUS.sid AND order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "order");

        if (u != ds.Tables["order"].Rows[0]["order_shipper"].ToString())
        {
            Response.Redirect("/search/err.aspx");
        }//不是买方的用户无修改订单！

        if (ds.Tables["order"].Rows[0]["order_status"].ToString() != "2" & ds.Tables["order"].Rows[0]["order_status"].ToString() != "3" & ds.Tables["order"].Rows[0]["order_status"].ToString() != "6")
        {
            Response.Redirect("/search/err.aspx");
        }//排除不能修改的订单状态！

        ltrOrderStatus.Text = "<div style=\"padding:20px; margin-top:10px; font-size:14px; line-height:30px;  background:#FFFCF3;border:1px solid #F7E4A5;\">修改订舱单<br/>当您修改完订舱单后系统将提醒对方商户，请最好与对方商户对您的修改内容进行确认</div>";

        txtPubf.Text = ds.Tables["order"].Rows[0]["order_forward"].ToString();
        txtCode.Value = ds.Tables["order"].Rows[0]["order_code"].ToString();
        txtShipper.Value = ds.Tables["order"].Rows[0]["Shipper"].ToString();
        txtConsignee.Value = ds.Tables["order"].Rows[0]["Consignee"].ToString();
        txtNotifyParty.Value = ds.Tables["order"].Rows[0]["NotifyParty"].ToString();
        txtCompanyName.Value = ds.Tables["order"].Rows[0]["CompanyName"].ToString();
        txtEmail.Value = ds.Tables["order"].Rows[0]["Email"].ToString();
        txtContactor.Value = ds.Tables["order"].Rows[0]["Contactor"].ToString();
        txtMobile.Value = ds.Tables["order"].Rows[0]["Mobile"].ToString();
        txtTel.Value = ds.Tables["order"].Rows[0]["Tel"].ToString();
        txtFax.Value = ds.Tables["order"].Rows[0]["Fax"].ToString();
        txtstartport.Value = ds.Tables["order"].Rows[0]["startport"].ToString();
        txtmidport.Value = ds.Tables["order"].Rows[0]["midport"].ToString();
        txtdestport.Value = ds.Tables["order"].Rows[0]["destport"].ToString();
        txtMarksNumbers.Value = ds.Tables["order"].Rows[0]["MarksNumbers"].ToString();
        txtNumbersofPackages.Value = ds.Tables["order"].Rows[0]["NumbersofPackages"].ToString();
        txtDescription.Value = ds.Tables["order"].Rows[0]["Description"].ToString();
        txtGrossWeight.Value = ds.Tables["order"].Rows[0]["GrossWeight"].ToString();
        txtMeasurement.Value = ds.Tables["order"].Rows[0]["Measurement"].ToString();
        txtkaihangri.Value = Convert.ToDateTime(ds.Tables["order"].Rows[0]["kaihangri"].ToString()).ToString("yyyy-M-d");
        txtcarrier_name.Value = ds.Tables["order"].Rows[0]["carrier_name"].ToString();

        ltrSMS.Text = "<a href=\"/member/pm_detail.aspx?cid=" + ds.Tables["order"].Rows[0]["order_forward"].ToString() + "\" id=\"linkSMS\" target=\"_blank\"></a>";

        if (ds.Tables["order"].Rows[0]["zhuangxiangri"].ToString() == "1900-1-1 0:00:00")
        {
            txtzhuangxiangri.Value = "";

        }
        else
        {
            txtzhuangxiangri.Value = Convert.ToDateTime(ds.Tables["order"].Rows[0]["zhuangxiangri"].ToString()).ToString("yyyy-M-d");
        }

        if (ds.Tables["order"].Rows[0]["jieguanri"].ToString() == "1900-1-1 0:00:00")
        {
            txtjieguanri.Value = "";
        }
        else
        {
            txtjieguanri.Value = Convert.ToDateTime(ds.Tables["order"].Rows[0]["jieguanri"].ToString()).ToString("yyyy-M-d");
        }


        txt20gp.Value = ds.Tables["order"].Rows[0]["air_kgs"].ToString();
        txt40gp.Value = ds.Tables["order"].Rows[0]["container_40gp"].ToString();
        txt40hq.Value = ds.Tables["order"].Rows[0]["container_40hq"].ToString();

        txtbeizhu.Value = ds.Tables["order"].Rows[0]["beizhu"].ToString();


        sql = "";

        if (ds.Tables["order"].Rows[0]["freight_code1"].ToString() == "0")
        {
            sql += "SELECT * FROM T_AIRINFO,T_AIRPRICE ";
            sql += "WHERE T_AIRINFO.id = T_AIRPRICE.airid ";
            sql += "AND T_AIRINFO.id = " + ds.Tables["order"].Rows[0]["freight_code"].ToString() + " ";
            sql += "ORDER BY T_AIRPRICE.id desc";
        }
        else
        {
            sql += "SELECT * FROM T_AIRINFO,T_AIRPRICE ";
            sql += "WHERE T_AIRINFO.id = T_AIRPRICE.airid ";
            sql += "AND T_AIRPRICE.id = " + ds.Tables["order"].Rows[0]["freight_code1"].ToString();
        }

        DataSet ds1 = new DataSet();
        ds1 = cn.mdb_ds(sql, "yunjia");

        ltrFreight.Text = "<a href=\"/fcl/" + key(ds.Tables["order"].Rows[0]["freight_code"].ToString()) + "_" + ds.Tables["order"].Rows[0]["freight_code1"].ToString() + ".html\" target=\"_blank\">" + ds1.Tables["yunjia"].Rows[0]["title"].ToString() + "</a>";

        ltrFreightDetail.Text = "<b style=\"font-size:14px; font-weight:bold;\"><b id='f20gp' style=\"color:#FF0000;\">" + ds1.Tables["yunjia"].Rows[0]["PRICE_P45"].ToString() + "</b>&nbsp;/&nbsp;<b id='f40gp' style=\"color:#FF0000;\">" + ds1.Tables["yunjia"].Rows[0]["PRICE_P100"].ToString() + "</b>&nbsp;&nbsp;&nbsp;&nbsp;<b id='f40hq' style=\"color:#FF0000;\">" + ds1.Tables["yunjia"].Rows[0]["PRICE_P300"].ToString() + "</b></b>";

        sql = "";
        sql += "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + u;

        ds = cn.mdb_ds(sql, "account");

        txtbank.Value = ds.Tables["account"].Rows[0]["bank"].ToString();
        txtbankname.Value = ds.Tables["account"].Rows[0]["bankname"].ToString();
        txtbankaccount.Value = ds.Tables["account"].Rows[0]["bankaccount"].ToString();
        txtotheraccount.Value = ds.Tables["account"].Rows[0]["otheraccount"].ToString();

        //ltrHyf.Text = (Convert.ToInt32(txt20gp.Value) * Convert.ToInt32(ds1.Tables["yunjia"].Rows[0]["price20gp"].ToString()) + Convert.ToInt32(txt40gp.Value) * Convert.ToInt32(ds1.Tables["yunjia"].Rows[0]["price40gp"].ToString()) + Convert.ToInt32(txt40hq.Value) * Convert.ToInt32(ds1.Tables["yunjia"].Rows[0]["PRICE_P300"].ToString())).ToString();
    }//载入要修改的订单

    public void LoadSavedOrder()
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        string sql = "";

        sql += "SELECT * FROM TB_ORDER,TB_ORDER_STATUS WHERE TB_ORDER.order_status = TB_ORDER_STATUS.sid AND order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "order");

        if (u != ds.Tables["order"].Rows[0]["order_shipper"].ToString() & u != ds.Tables["order"].Rows[0]["order_forward"].ToString())
        {
            Response.Redirect("/search/err.aspx");
        }//不是买卖双方的用户无法查看该订单！

        if (u == ds.Tables["order"].Rows[0]["order_shipper"].ToString())
        {
            PlaceHolder3.Visible = true;
            PlaceHolder1.Visible = false;
            ltrOrderStatus.Text = "<div style=\"padding:20px; margin-top:10px; font-size:14px; line-height:30px; text-align:left; background:#FFFCF3;border:1px solid #F7E4A5;\">" + ds.Tables["order"].Rows[0]["status_txt_shipper"].ToString().Replace("{1}", ck.CheckInput(GetRequestQueryString("orderid", "0"))).Replace("{9}", "air") + "</div>";
        }//订舱方显示的文本

        if (u == ds.Tables["order"].Rows[0]["order_forward"].ToString())
        {
            PlaceHolder4.Visible = true;
            ltrOrderStatus.Text = "<div style=\"padding:20px; margin-top:10px; font-size:14px; line-height:30px; text-align:left; background:#FFFCF3;border:1px solid #F7E4A5;\">" + ds.Tables["order"].Rows[0]["status_txt_forward"].ToString().Replace("{1}", ck.CheckInput(GetRequestQueryString("orderid", "0"))).Replace("{9}", "air") + "</div>";
        }//承运方显示的文本

        if (ds.Tables["order"].Rows[0]["order_status"].ToString() != "2")
        {
            PlaceHolder2.Visible = false;
            PlaceHolder1.Visible = false;
        }

        txtShipper.Attributes["readonly"] = "readonly";
        txtConsignee.Attributes["readonly"] = "readonly";
        txtNotifyParty.Attributes["readonly"] = "readonly";
        txtCompanyName.Attributes["readonly"] = "readonly";
        txtEmail.Attributes["readonly"] = "readonly";
        txtContactor.Attributes["readonly"] = "readonly";
        txtMobile.Attributes["readonly"] = "readonly";
        txtTel.Attributes["readonly"] = "readonly";
        txtFax.Attributes["readonly"] = "readonly";
        txtstartport.Attributes["readonly"] = "readonly";
        txtmidport.Attributes["readonly"] = "readonly";
        txtdestport.Attributes["readonly"] = "readonly";
        txtMarksNumbers.Attributes["readonly"] = "readonly";
        txtNumbersofPackages.Attributes["readonly"] = "readonly";
        txtDescription.Attributes["readonly"] = "readonly";
        txtGrossWeight.Attributes["readonly"] = "readonly";
        txtMeasurement.Attributes["readonly"] = "readonly";
        txtcarrier_name.Attributes["readonly"] = "readonly";
        txt20gp.Attributes["readonly"] = "readonly";
        txt40gp.Attributes["readonly"] = "readonly";
        txt40hq.Attributes["readonly"] = "readonly";
        txtbeizhu.Attributes["readonly"] = "readonly";

        txtCode.Value = ds.Tables["order"].Rows[0]["order_code"].ToString();
        txtShipper.Value = ds.Tables["order"].Rows[0]["Shipper"].ToString();
        txtConsignee.Value = ds.Tables["order"].Rows[0]["Consignee"].ToString();
        txtNotifyParty.Value = ds.Tables["order"].Rows[0]["NotifyParty"].ToString();
        txtCompanyName.Value = ds.Tables["order"].Rows[0]["CompanyName"].ToString();
        txtEmail.Value = ds.Tables["order"].Rows[0]["Email"].ToString();
        txtContactor.Value = ds.Tables["order"].Rows[0]["Contactor"].ToString();
        txtMobile.Value = ds.Tables["order"].Rows[0]["Mobile"].ToString();
        txtTel.Value = ds.Tables["order"].Rows[0]["Tel"].ToString();
        txtFax.Value = ds.Tables["order"].Rows[0]["Fax"].ToString();
        txtstartport.Value = ds.Tables["order"].Rows[0]["startport"].ToString();
        txtmidport.Value = ds.Tables["order"].Rows[0]["midport"].ToString();
        txtdestport.Value = ds.Tables["order"].Rows[0]["destport"].ToString();
        txtMarksNumbers.Value = ds.Tables["order"].Rows[0]["MarksNumbers"].ToString();
        txtNumbersofPackages.Value = ds.Tables["order"].Rows[0]["NumbersofPackages"].ToString();
        txtDescription.Value = ds.Tables["order"].Rows[0]["Description"].ToString();
        txtGrossWeight.Value = ds.Tables["order"].Rows[0]["GrossWeight"].ToString();
        txtMeasurement.Value = ds.Tables["order"].Rows[0]["Measurement"].ToString();
        txtkaihangri.Value = Convert.ToDateTime(ds.Tables["order"].Rows[0]["kaihangri"].ToString()).ToString("yyyy-M-d");
        txtcarrier_name.Value = ds.Tables["order"].Rows[0]["carrier_name"].ToString();

        ltrSMS.Text = "<a href=\"/member/pm_detail.aspx?cid=" + ds.Tables["order"].Rows[0]["order_forward"].ToString() + "\" id=\"linkSMS\" target=\"_blank\"></a>";

        if (ds.Tables["order"].Rows[0]["zhuangxiangri"].ToString() == "1900-1-1 0:00:00")
        {
            txtzhuangxiangri.Value = "";
        }
        else
        {
            txtzhuangxiangri.Value = Convert.ToDateTime(ds.Tables["order"].Rows[0]["zhuangxiangri"].ToString()).ToString("yyyy-M-d");
        }

        if (ds.Tables["order"].Rows[0]["jieguanri"].ToString() == "1900-1-1 0:00:00")
        {
            txtjieguanri.Value = "";
        }
        else
        {
            txtjieguanri.Value = Convert.ToDateTime(ds.Tables["order"].Rows[0]["jieguanri"].ToString()).ToString("yyyy-M-d");
        }

        txt20gp.Value = ds.Tables["order"].Rows[0]["air_kgs"].ToString();
        txt40gp.Value = ds.Tables["order"].Rows[0]["container_40gp"].ToString();
        txt40hq.Value = ds.Tables["order"].Rows[0]["container_40hq"].ToString();

        txtbeizhu.Value = ds.Tables["order"].Rows[0]["beizhu"].ToString();

        sql = "";

        if (ds.Tables["order"].Rows[0]["freight_code1"].ToString() == "0")
        {
            sql += "SELECT * FROM T_AIRINFO,T_AIRPRICE ";
            sql += "WHERE T_AIRINFO.id = T_AIRPRICE.airid ";
            sql += "AND T_AIRINFO.id = " + ds.Tables["order"].Rows[0]["freight_code"].ToString() + " ";
            sql += "ORDER BY T_AIRPRICE.id desc";
        }
        else
        {
            sql += "SELECT * FROM T_AIRINFO,T_AIRPRICE ";
            sql += "WHERE T_AIRINFO.id = T_AIRPRICE.airid ";
            sql += "AND T_AIRPRICE.id = " + ds.Tables["order"].Rows[0]["freight_code1"].ToString();
        }

        DataSet ds1 = new DataSet();
        ds1 = cn.mdb_ds(sql, "yunjia");

        ltrFreight.Text = "<a href=\"/fcl/" + key(ds.Tables["order"].Rows[0]["freight_code"].ToString()) + "_" + ds.Tables["order"].Rows[0]["freight_code1"].ToString() + ".html\" target=\"_blank\">" + ds1.Tables["yunjia"].Rows[0]["title"].ToString() + "</a>";

        ltrFreightDetail.Text = "<b style=\"font-size:14px; font-weight:bold;\"><b id='f20gp' style=\"color:#FF0000;\">" + ds1.Tables["yunjia"].Rows[0]["PRICE_P45"].ToString() + "</b>&nbsp;/&nbsp;<b id='f40gp' style=\"color:#FF0000;\">" + ds1.Tables["yunjia"].Rows[0]["PRICE_P100"].ToString() + "</b>&nbsp;&nbsp;&nbsp;&nbsp;<b id='f40hq' style=\"color:#FF0000;\">" + ds1.Tables["yunjia"].Rows[0]["PRICE_P300"].ToString() + "</b></b>";

        sql = "";
        sql += "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + u;

        ds = cn.mdb_ds(sql, "account");

        txtbank.Value = ds.Tables["account"].Rows[0]["bank"].ToString();
        txtbankname.Value = ds.Tables["account"].Rows[0]["bankname"].ToString();
        txtbankaccount.Value = ds.Tables["account"].Rows[0]["bankaccount"].ToString();
        txtotheraccount.Value = ds.Tables["account"].Rows[0]["otheraccount"].ToString();

        //ltrHyf.Text = (Convert.ToInt32(txt20gp.Value) * Convert.ToInt32(ds1.Tables["yunjia"].Rows[0]["price20gp"].ToString()) + Convert.ToInt32(txt40gp.Value) * Convert.ToInt32(ds1.Tables["yunjia"].Rows[0]["price40gp"].ToString()) + Convert.ToInt32(txt40hq.Value) * Convert.ToInt32(ds1.Tables["yunjia"].Rows[0]["PRICE_P300"].ToString())).ToString();

    }//查看订单

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SaveRecord(2);
        Response.Redirect("order_success.aspx?type=2&orderid=" + txtCode.Value);

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord(1);
        Response.Redirect("order_success.aspx?type=1&orderid=" + txtCode.Value);
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        SaveRecord(3);
        Response.Redirect("order_success.aspx?type=edit&orderid=" + txtCode.Value);
    }

    public void SaveRecord(int q)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string u = ck.CheckNumber(GetRequestCookies("user_id", "0"));
        string f = ck.CheckNumber(GetRequestQueryString("f", "0"));
        string yid = ck.CheckNumber(GetRequestQueryString("yid", "0"));
        string ydid = ck.CheckNumber(GetRequestQueryString("ydid", "0"));

        string sql = "";

        string price20gp = "0";
        string price40gp = "0";
        string price40hq = "0";

        if (txt20gp.Value != "")
        {
            price20gp = ck.CheckInput(txt20gp.Value);
        }

        if (txt40gp.Value != "")
        {
            price40gp = ck.CheckInput(txt40gp.Value);
        }

        if (txt40hq.Value != "")
        {
            price40hq = ck.CheckInput(txt40hq.Value);
        }

        sql = "";
        sql += "INSERT INTO TB_ORDER ";
        sql += "( ";
        sql += "date_create, ";
        sql += "order_status, ";
        sql += "order_code, ";

        sql += "order_shipper, ";
        sql += "order_forward, ";
        sql += "freight_type, ";
        sql += "freight_code, ";
        sql += "freight_code1, ";

        sql += "Shipper, ";
        sql += "Consignee, ";
        sql += "NotifyParty, ";
        sql += "CompanyName, ";
        sql += "Email, ";
        sql += "Contactor, ";
        sql += "Mobile, ";
        sql += "Tel, ";
        sql += "Fax, ";
        sql += "startport, ";
        sql += "midport, ";
        sql += "destport, ";
        sql += "MarksNumbers, ";
        sql += "NumbersofPackages, ";
        sql += "Description, ";
        sql += "GrossWeight, ";
        sql += "Measurement, ";
        sql += "kaihangri, ";
        sql += "carrier_name, ";
        sql += "zhuangxiangri, ";
        sql += "jieguanri, ";
        sql += "air_kgs, ";
        sql += "beizhu ";
        sql += ") ";
        sql += "VALUES ";
        sql += "( ";
        sql += "GetDate(), ";
        sql += "" + q + ", ";
        sql += "'" + ck.CheckInput(txtCode.Value) + "', ";

        sql += "" + u + ", ";
        sql += "" + f + ", ";
        sql += "10, ";
        sql += "" + yid + ", ";
        sql += "" + ydid + ", ";

        sql += "'" + ck.CheckInput(txtShipper.Value) + "', ";
        sql += "'" + ck.CheckInput(txtConsignee.Value) + "', ";
        sql += "'" + ck.CheckInput(txtNotifyParty.Value) + "', ";
        sql += "'" + ck.CheckInput(txtCompanyName.Value) + "', ";
        sql += "'" + ck.CheckInput(txtEmail.Value) + "', ";
        sql += "'" + ck.CheckInput(txtContactor.Value) + "', ";
        sql += "'" + ck.CheckInput(txtMobile.Value) + "', ";
        sql += "'" + ck.CheckInput(txtTel.Value) + "', ";
        sql += "'" + ck.CheckInput(txtFax.Value) + "', ";
        sql += "'" + ck.CheckInput(txtstartport.Value) + "', ";
        sql += "'" + ck.CheckInput(txtmidport.Value) + "', ";
        sql += "'" + ck.CheckInput(txtdestport.Value) + "', ";
        sql += "'" + ck.CheckInput(txtMarksNumbers.Value) + "', ";
        sql += "'" + ck.CheckInput(txtNumbersofPackages.Value) + "', ";
        sql += "'" + ck.CheckInput(txtDescription.Value) + "', ";
        sql += "'" + ck.CheckInput(txtGrossWeight.Value) + "', ";
        sql += "'" + ck.CheckInput(txtMeasurement.Value) + "', ";
        sql += "'" + ck.CheckInput(txtkaihangri.Value) + "', ";
        sql += "'" + ck.CheckInput(txtcarrier_name.Value) + "', ";
        sql += "'" + ck.CheckInput(txtzhuangxiangri.Value) + "', ";
        sql += "'" + ck.CheckInput(txtjieguanri.Value) + "', ";
        sql += "" + price20gp + ", ";
        sql += "'" + ck.CheckInput(txtbeizhu.Value) + "' ";
        sql += ") ";

        if (q == 3)
        {
            sql = "";
            sql += "UPDATE TB_ORDER SET ";
            sql += "Shipper = '" + ck.CheckInput(txtShipper.Value) + "', ";
            sql += "Consignee = '" + ck.CheckInput(txtConsignee.Value) + "', ";
            sql += "NotifyParty = '" + ck.CheckInput(txtNotifyParty.Value) + "', ";
            sql += "CompanyName = '" + ck.CheckInput(txtCompanyName.Value) + "', ";
            sql += "Email = '" + ck.CheckInput(txtEmail.Value) + "', ";
            sql += "Contactor = '" + ck.CheckInput(txtContactor.Value) + "', ";
            sql += "Mobile = '" + ck.CheckInput(txtMobile.Value) + "', ";
            sql += "Tel = '" + ck.CheckInput(txtTel.Value) + "', ";
            sql += "Fax = '" + ck.CheckInput(txtFax.Value) + "', ";
            sql += "startport = '" + ck.CheckInput(txtstartport.Value) + "', ";
            sql += "midport = '" + ck.CheckInput(txtmidport.Value) + "', ";
            sql += "destport = '" + ck.CheckInput(txtdestport.Value) + "', ";
            sql += "MarksNumbers = '" + ck.CheckInput(txtMarksNumbers.Value) + "', ";
            sql += "NumbersofPackages = '" + ck.CheckInput(txtNumbersofPackages.Value) + "', ";
            sql += "Description = '" + ck.CheckInput(txtDescription.Value) + "', ";
            sql += "GrossWeight = '" + ck.CheckInput(txtGrossWeight.Value) + "', ";
            sql += "Measurement = '" + ck.CheckInput(txtMeasurement.Value) + "', ";
            sql += "kaihangri = '" + ck.CheckInput(txtkaihangri.Value) + "', ";
            sql += "carrier_name = '" + ck.CheckInput(txtcarrier_name.Value) + "', ";
            sql += "zhuangxiangri = '" + ck.CheckInput(txtzhuangxiangri.Value) + "', ";
            sql += "jieguanri = '" + ck.CheckInput(txtjieguanri.Value) + "', ";
            sql += "air_kgs = " + price20gp + ", ";
            sql += "beizhu = '" + ck.CheckInput(txtbeizhu.Value) + "' ";
        }

        //Response.Write(sql);
        cn.mdb_exe(sql);

        sql = "";
        sql += "UPDATE TB_ORDER_ACCOUNT SET ";
        sql += "bank = '" + ck.CheckInput(txtbank.Value) + "', ";
        sql += "bankname = '" + ck.CheckInput(txtbankname.Value) + "', ";
        sql += "bankaccount = '" + ck.CheckInput(txtbankaccount.Value) + "', ";
        sql += "otheraccount = '" + ck.CheckInput(txtotheraccount.Value) + "' ";
        sql += "WHERE userid = " + u;

        //Response.Write(sql);
        cn.mdb_exe(sql);


        if (q == 2)
        {
            pm p = new pm();
            string txt = "";
            txt = "<a href=\"/company/" + setkey(u) + "/\" target=\"_blank\">" + ck.CheckInput(txtCompanyName.Value) + "</a>给您发送了一份线上订舱委托书，订舱编号:<a href=\"/search/air_order.aspx?filter=view&orderid=" + txtCode.Value + "\" target=\"_blank\">" + ck.CheckInput(txtCode.Value) + "</a> ,请您尽快答复，以免错失商机！";
            p.sendpm("41", f.ToString(), txt, "1");
        }

        if (q == 3)
        {
            pm p = new pm();
            string txt = "";
            txt = "<a href=\"/company/" + setkey(u) + "/\" target=\"_blank\">" + ck.CheckInput(txtCompanyName.Value) + "</a>修改了订单<a href=\"/search/air_order.aspx?filter=view&orderid=" + txtCode.Value + "\" target=\"_blank\">" + ck.CheckInput(txtCode.Value) + "</a>，提醒您重新查看该订单！";
            p.sendpm("41", txtPubf.Text, txt, "1");

        }
    }//保存，发送或修改订单

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
                data_conn cd1 = new data_conn();
            }
        }
        return outputstring;
    }//获得指定Cookies参数

    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "2", "3");
        SetOrderStatus("3");
        Response.Redirect("order_success.aspx?type=accept&orderid=" + txtCode.Value);
    }//接受订舱

    protected void btnReject_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "2", "6");
        SetOrderStatus("6");
        Response.Redirect("order_success.aspx?type=reject&orderid=" + txtCode.Value);
    }//拒绝订舱

    protected void SetOrderStatus(string status)
    {
        System.Threading.Thread.Sleep(2000);
        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Value);

        data_conn cn = new data_conn();
        string sql = "";

        sql += "UPDATE TB_ORDER SET order_status = " + status + " WHERE order_code = '" + order_code + "'";

        cn.mdb_exe(sql);

        //Response.Write(sql);
    }//设置状态参数

    protected void SetOrderDetail(string a, string c1, string c2)
    {
        //a是行为的角色，1为货主，2为货代，0为系统
        //c1是操作之前的状态号
        //c2是操作之后的状态号码
        //数组中参数{x}将被具体角色替换，{1}将被货主公司名替换，
        //{2}将被货代公司名替换，{3}将被订单号替换，{4}将被操作时间替换，
        //{5}将被拒绝理由替换，{6}将被个人信息替换，{7}将被重新选择替换，
        //{8}货主信息费，{9}货代信息费

        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Value);

        string[] op_array = new string[29];

        op_array[0] = "1|0|1|订舱方 {1} 保存订单";
        op_array[1] = "1|0|2|订舱方 {1} 提交订舱单，等待承运方答复";

        op_array[2] = "1|1|2|订舱方 {1} 提交订舱单，等待承运方答复";

        op_array[3] = "2|2|3|承运方 {2} 接受订舱";

        op_array[4] = "2|2|6|承运方 {2} 不接受订舱，理由是 {5} ，申请系统审核";
        op_array[5] = "2|6|2|承运方 {2} 取消不接受订舱";
        op_array[6] = "0|6|11|系统通过了承运方 {2} 的不接受订舱申请，该订单作废";
        op_array[7] = "0|6|2|系统未通过承运方 {2} 的不接受订舱申请，该订单恢复原状态";
        op_array[8] = "1|12|2|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[9] = "1|2|7|订舱方 {1} 撤消了该订舱单";
        op_array[10] = "1|7|2|订舱方 {1} 取消撤消该订舱单，重新等待承运方答复";
        op_array[11] = "0|7|12|系统通过了订舱方 {1} 的撤消订舱申请，该订单作废";
        op_array[12] = "0|7|2|系统未通过订舱方 {1} 的撤消订舱申请，该订单恢复原状态";
        op_array[13] = "1|12|2|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[14] = "1|3|4|订舱方 {1} 确认出运";

        op_array[15] = "1|3|8|订舱方 {1} 撤消了该订舱单";
        op_array[16] = "1|8|3|订舱方 {1} 取消撤消该订舱单，重新等待承运方答复";
        op_array[17] = "0|8|13|系统通过了订舱方 {1} 的撤消订舱申请，该订单作废";
        op_array[18] = "0|8|3|系统未通过订舱方 {1} 的撤消订舱申请，该订单恢复原状态";
        op_array[19] = "1|13|8|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[20] = "2|3|5|承运方 {2} 确认出运，交易结束";

        op_array[21] = "2|4|5|承运方 {2} 同意完成，交易结束";

        op_array[22] = "1|4|9|订舱方 {1} 撤消了该订舱单";
        op_array[23] = "1|9|4|订舱方 {1} 取消撤消该订舱单，重新等待承运方答复";
        op_array[24] = "0|9|14|系统通过了订舱方 {1} 的撤消订舱申请，该订单作废";
        op_array[25] = "0|9|4|系统未通过订舱方 {1} 的撤消订舱申请，该订单恢复原状态";
        op_array[26] = "1|14|9|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[27] = "1|1|10|订舱方 {1} 删除该订舱单";
        op_array[28] = "1|10|1|订舱方 {1} 恢复该订舱单";

        string detail_txt = "";

        for (int i = 0; i < op_array.Length; i++)
        {
            if (a == op_array[i].Split('|')[0].ToString() & c1 == op_array[i].Split('|')[1].ToString() & c2 == op_array[i].Split('|')[2].ToString())
            {
                detail_txt = op_array[i].Split('|')[3].ToString();
            }
        }//确认当前的状态数组

        string sql = "";

        sql += "SELECT  ";
        sql += "TB_ORDER.date_create, ";
        sql += "TB_ORDER.order_code, ";
        sql += "UA.userid AS aid, ";
        sql += "UB.userid AS bid, ";
        sql += "UA.CompanyName AS aname, ";
        sql += "UB.CompanyName AS bname ";
        sql += "FROM TB_ORDER,TB_USER UA,TB_USER UB ";
        sql += "WHERE 1=1 ";
        sql += "AND TB_ORDER.order_shipper = UA.userid ";
        sql += "AND TB_ORDER.order_forward = UB.userid ";
        sql += "AND TB_ORDER.order_code = '" + order_code + "'";

        //a是货主，b是货代

        //Response.Write(sql);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        ds = cn.mdb_ds(sql, "order");

        detail_txt = detail_txt.Replace("{1}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["aid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["aname"].ToString() + "</a>");
        detail_txt = detail_txt.Replace("{2}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["bid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["bname"].ToString() + "</a>");
        detail_txt = detail_txt.Replace("{3}", txtRejectReason.Value);

        //生成交易记录
        sql = "INSERT INTO TB_ORDER_DETAIL (order_code,detail_txt,detail_date) VALUES ('" + order_code + "','" + detail_txt + "',GetDate())";
        cn.mdb_exe(sql);

        if (c2 == "5")
        {
            sql = "SELECT * FROM TB_ORDER WHERE order_code = '" + order_code + "'";

            DataSet ds1 = new DataSet();

            ds1 = cn.mdb_ds(sql, "account");

            double base_fee = 0;

            base_fee = Convert.ToDouble(ds1.Tables["account"].Rows[0]["air_kgs"].ToString()) * 10;

            //改变用户帐户表内帐户余额，货代-，货主+
            sql = "UPDATE TB_ORDER_ACCOUNT SET overage = overage + " + base_fee + " WHERE userid = " + ds.Tables["order"].Rows[0]["aid"].ToString();
            cn.mdb_exe(sql);
            sql = "UPDATE TB_ORDER_ACCOUNT SET overage = overage - " + base_fee * 2 + " WHERE userid = " + ds.Tables["order"].Rows[0]["bid"].ToString();
            cn.mdb_exe(sql);

            sql = "INSERT INTO TB_ORDER_ACCOUNT_DETAIL (detail_date,order_code,userid,otherid,status,fee,overage) VALUES ";
            sql += "(getdate(),'" + order_code + "'," + ds.Tables["order"].Rows[0]["aid"].ToString() + ", " + ds.Tables["order"].Rows[0]["bid"].ToString() + ",'订舱成功'," + (base_fee) + ",0)";
            cn.mdb_exe(sql);

            sql = "INSERT INTO TB_ORDER_ACCOUNT_DETAIL (detail_date,order_code,userid,otherid,status,fee,overage) VALUES ";
            sql += "(getdate(),'" + order_code + "'," + ds.Tables["order"].Rows[0]["bid"].ToString() + ", " + ds.Tables["order"].Rows[0]["aid"].ToString() + ",'订舱成功'," + (0 - base_fee * 2) + ",0)";
            cn.mdb_exe(sql);

            pm p = new pm();
            string txt = "";
            txt = "订单<a href=\"/search/air_order.aspx?filter=view&orderid=" + order_code + "\" target=\"_blank\">" + order_code + "</a>交易完成，您的信息费增加" + base_fee.ToString() + "元。";
            p.sendpm("41", ds.Tables["order"].Rows[0]["aid"].ToString(), txt, "1");

            txt = "订单<a href=\"/search/air_order.aspx?filter=view&orderid=" + order_code + "\" target=\"_blank\">" + order_code + "</a>交易完成，您的信息费将扣除" + (base_fee * 2).ToString() + "元。";
            p.sendpm("41", ds.Tables["order"].Rows[0]["bid"].ToString(), txt, "1");
        }

        if (c1 == "2" & c2 == "3")
        {
            sql = "SELECT * FROM TB_USER WHERE userid = " + ds.Tables["order"].Rows[0]["bid"].ToString();
            DataSet ds2 = new DataSet();
            ds2 = cn.mdb_ds(sql, "bid");

            pm p = new pm();
            string txt = "";
            txt = "<a href=\"/company/" + setkey(ds.Tables["order"].Rows[0]["bid"].ToString()) + "/\">" + ds.Tables["order"].Rows[0]["bname"].ToString() + "</a>已经接受您的订舱，订舱单号：<a href=\"/search/air_order.aspx?filter=view&orderid=" + order_code + "\" target=\"_blank\">" + order_code + "</a><br/>";
            txt += "下列联系人将对您进行后续服务：<br/>";
            txt += "姓名：" + ds2.Tables["bid"].Rows[0]["Realname"].ToString() + "<br/>";
            txt += "电话：" + ds2.Tables["bid"].Rows[0]["phone"].ToString() + "<br/>";
            txt += "Email：" + ds2.Tables["bid"].Rows[0]["useremail"].ToString() + "<br/>";
            txt += "感谢您使用环球运费网解决您的物流需求，如遇对方商户高于原定报价进行收费，或货物未能及时出运，请及时联系客服中心。如情况属实，我们将按照200元/柜对您进行赔付。点此查看赔付相关说明";
            p.sendpm("41", ds.Tables["order"].Rows[0]["aid"].ToString(), txt, "1");
        }

        if (c2 == "6")
        {
            pm p = new pm();
            string txt = "";
            txt = "<a href=\"/company/" + setkey(ds.Tables["order"].Rows[0]["bid"].ToString()) + "/\">" + ds.Tables["order"].Rows[0]["bname"].ToString() + "</a>未接受您发出的<a href=\"/search/air_order.aspx?filter=view&orderid=" + order_code + "\" target=\"_blank\">" + order_code + "</a>订舱请求<br/>";
            txt += "拒绝理由为：<br/>" + txtRejectReason.Value + "<br/>";
            txt += "环球运费网根据您的订舱要求，为您推荐了其他优质服务商，建议您<a href=\"/fcl/list-" + txtstartport.Value + "-" + txtdestport.Value + "-" + txtcarrier_name.Value + "-0-0-0-------1.html\" target=\"_blank\">重新选择</a>";
            p.sendpm("41", ds.Tables["order"].Rows[0]["aid"].ToString(), txt, "1");
        }

    }//设置操作

    protected void btnFinishOrderShipper1_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "3", "4");
        SetOrderStatus("4");
        Response.Redirect("order_success.aspx?type=finishs&orderid=" + txtCode.Value);

    }

    protected void btnFinishOrderForward1_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "3", "5");
        SetOrderStatus("5");
        Response.Redirect("order_success.aspx?type=finishf&orderid=" + txtCode.Value);
    }

    protected void btnFinishOrderForward2_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "4", "5");
        SetOrderStatus("5");
        Response.Redirect("order_success.aspx?type=finishf&orderid=" + txtCode.Value);
    }

}
