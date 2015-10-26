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
    public AllinOrder AllinOrder1 = new AllinOrder();
    public AllinFreight AllinFreight1 = new AllinFreight();
    public GetRequest GetRequest1 = new GetRequest();
    public check check1 = new check();

    protected void Page_Load(object sender, EventArgs e)
    {
        login l = new login();
        l.login();


        ltrLoginName.Text = Server.UrlDecode(GetRequest1.GetRequestCookies("Realname", ""));

        ltrBasicOrderCode.Text = GetRequest1.GetRequestQueryString("orderid", "0");

        if (!Page.IsPostBack)
        {
            phEditDisabled.Visible = false;
            phEditEnabled.Visible = false;

            switch (GetRequest1.GetRequestQueryString("filter", "0"))
            {
                case "new":
                    PlaceHolder2.Visible = true;//确认订舱的按钮
                    PlaceHolder1.Visible = false;//接受订舱的按钮
                    PlaceHolder5.Visible = false;//保存订舱单的按钮
                    PlaceHolder6.Visible = false;//弹出窗口内修改订舱单后保存的按钮
                    PlaceHolder7.Visible = true;//弹出窗口内提交定舱单的按钮
                    phOrderView.Visible = false;
                    phOrderView1.Visible = false;
                    phOrderNew.Visible = true;
                    phOrderNew1.Visible = true;
                    LoadNewOrder();
                    break;
                case "view":
                    PlaceHolder1.Visible = true;
                    PlaceHolder2.Visible = false;
                    PlaceHolder5.Visible = false;
                    PlaceHolder6.Visible = false;
                    PlaceHolder7.Visible = true;
                    phOrderView.Visible = true;
                    phOrderView1.Visible = true;
                    phOrderNew.Visible = false;
                    phOrderNew1.Visible = false;
                    LoadSavedOrder();
                    break;
                case "edit":
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = false;
                    PlaceHolder5.Visible = true;
                    PlaceHolder6.Visible = true;
                    PlaceHolder7.Visible = false;
                    phOrderView.Visible = false;
                    phOrderView1.Visible = false;
                    phOrderNew.Visible = true;
                    phOrderNew1.Visible = true;
                    LoadEditOrder();
                    break;
                default:
                    Response.Redirect("/search/err.aspx");
                    break;
            }

            switch (GetRequest1.GetRequestQueryString("role", "0"))
            {
                case "shipper":
                    PlaceHolder1.Visible = false;//接受订舱的按钮
                    break;
                case "forward":
                    break;
                default:
                    break;
            }
        }
    }

    public void LoadNewOrder()
    {
        SetStep("2", "0", "0");

        Random rd = new Random();
        txtCode.Value = "AIR" + DateTime.Now.ToString("yyMMddHHmm") + GetFourDigits(Convert.ToInt32(10000 * rd.NextDouble()).ToString());

        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        string[] fdetail;

        if (ck.CheckNumber(Request.QueryString["ydid"]) == "0")
        {
            fdetail = AllinFreight1.GetFreightDetail("10", ck.CheckNumber(Request.QueryString["yid"]), "0");
        }
        else
        {
            fdetail = AllinFreight1.GetFreightDetail("10", "0", ck.CheckNumber(Request.QueryString["ydid"]));
        }

        ltrEndDate.Text = Convert.ToDateTime(fdetail[6]).ToString("yyyy-MM-dd");
        ltrFreightTitle.Text = "<span style=\"font-weight:bold;font-size:14px\">" + fdetail[57] + "</span>";
        ltrFreightPostdate.Text = Convert.ToDateTime(fdetail[5]).ToString("MM") + "/" + Convert.ToDateTime(fdetail[5]).ToString("dd");
        ltrFreightEnddate.Text = Convert.ToDateTime(fdetail[6]).ToString("MM") + "/" + Convert.ToDateTime(fdetail[6]).ToString("dd");
        ltrFreightPostdateHid.Text = fdetail[5];
        ltrFreightEnddateHid.Text = fdetail[6];
        ltrFreightTitleHid.Text = fdetail[7];
        ltrFreightCompanyHid.Text = fdetail[8];
        ltrFreightAllinStarHid.Text = fdetail[11];
        ltrFreightUserStarHid.Text = fdetail[12];
        ltrFreightCompany.Text = fdetail[18];
        ltrFreightAllinStar.Text = fdetail[19];
        ltrFreightUserStar.Text = fdetail[20];
        ltrFreightA45.Text = fdetail[52];
        ltrFreightA100.Text = fdetail[53];
        ltrFreightA300.Text = fdetail[54];
        ltrFreightA500.Text = fdetail[55];
        ltrFreightA1000.Text = fdetail[56];
        ltrFreightAppend.Text = fdetail[36];
        ltrFreightCarrier.Text = fdetail[34];
        ltrFreightLine.Text = fdetail[2];
        ltrFreightStartport.Text = fdetail[3];
        ltrFreightDestport.Text = fdetail[4];
        ltrFreightAssuranceSpace.Text = fdetail[16];
        ltrFreightAssurancePrice.Text = fdetail[17];
        ltrFreightAssuranceSpaceLevel.Text = fdetail[13];
        ltrFreightAssurancePriceLevel.Text = fdetail[12];
        if (fdetail[36] != "")
        {
            ltrOrderFujiafei1.Text = "(附加费：" + fdetail[36] + ")";
        }

        txtstartport.Value = fdetail[3];
        txtdestport.Value = fdetail[4];
        txtcarrier_name.Value = fdetail[34];

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
        txtaliaccount.Value = ds.Tables["user"].Rows[0]["ali_account"].ToString();


        //txtShipper.Value = "发货人";
        //txtConsignee.Value = "收货人";
        //txtNotifyParty.Value = "通知人";
        //txtmidport.Value = "无";
        //txtMarksNumbers.Value = "唛头";
        //txtNumbersofPackages.Value = "13箱";
        //txtDescription.Value = "品名";
        //txtGrossWeight.Value = "0";
        //txtMeasurement.Value = "0";
        //txtcarrier_name.Value = "MSK";
        //txtkaihangri.Value = "2010-3-3";
        //txtzhuangxiangri.Value = "2010-3-7";
        //txtjieguanri.Value = "2010-3-9";
        //txtkaihangri.Value = "2010-3-3";
        //txtgp.Value = "1";

    }//载入新订单

    public void LoadEditOrder()
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        GetRequest GetRequest1 = new GetRequest();

        string u = ck.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));
        string orderid = ck.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0"));
        string role = GetRequest1.GetRequestQueryString("role", "");

        AllinOrder AllinOrder1 = new AllinOrder();
        string[] odetail;
        odetail = AllinOrder1.GetOrderDetail(orderid);

        ltrHyf.Text = odetail[59];

        txtPubf.Text = odetail[4];
        txtCode.Value = odetail[0];
        txtShipper.Value = odetail[8];
        txtConsignee.Value = odetail[9];
        txtNotifyParty.Value = odetail[10];
        txtCompanyName.Value = odetail[11];
        txtEmail.Value = odetail[12];
        txtContactor.Value = odetail[13];
        txtMobile.Value = odetail[14];
        txtTel.Value = odetail[15];
        txtFax.Value = odetail[16];
        txtstartport.Value = odetail[17];
        txtmidport.Value = odetail[18];
        txtdestport.Value = odetail[19];
        txtMarksNumbers.Value = odetail[20];
        txtNumbersofPackages.Value = odetail[21];
        txtDescription.Value = odetail[22];
        txtGrossWeight.Value = odetail[23];
        txtMeasurement.Value = odetail[24];
        txtkaihangri.Value = odetail[27];
        txtzhuangxiangri.Value = odetail[28];
        txtjieguanri.Value = odetail[29];
        ltrEndDate.Text = odetail[105];
        txtcarrier_name.Value = odetail[26];

        ltrFreightTitle.Text = "<span style=\"font-weight:bold;font-size:14px\">" + odetail[75] + "</span>";

        txtgp.Value = odetail[35];

        if (odetail[44] != "")
        {
            ltrOrderFujiafei1.Text = "(附加费：" + odetail[44] + ")";
        }

        ltrFreightA45.Text = odetail[53];
        ltrFreightA100.Text = odetail[54];
        ltrFreightA300.Text = odetail[55];
        ltrFreightA500.Text = odetail[56];
        ltrFreightA1000.Text = odetail[57];
        ltrFreightAppend.Text = odetail[44];
        ltrFreightCarrier.Text = odetail[26];

        txtbeizhu.Value = odetail[36];
        SetStep(odetail[1], odetail[37], odetail[38]);


        ltrSMS.Text = "<a href=\"/member/pm_detail.aspx?cid=" + odetail[4] + "\" id=\"linkSMS\" target=\"_blank\"></a>";

        if (u != odetail[3])
        {
            Response.Redirect("/search/err.aspx");
        }//不是买方的用户无修改订单！

        if (odetail[1] != "2" & odetail[1] != "3" & odetail[1] != "7")
        {
            Response.Redirect("/search/err.aspx");
        }//排除不能修改的订单状态！

        ltrOrderStatus.Text = "<div style=\"padding:20px; margin-bottom:10px; font-size:14px; line-height:30px; text-align:center; background:#FFFCF3;border:1px solid #F7E4A5;\">修改订舱单</div>";


        AllinFreight AllinFreight1 = new AllinFreight();
        string[] fdetail;
        if (odetail[7] == "0")
        {
            fdetail = AllinFreight1.GetFreightDetail("10", ck.CheckNumber(odetail[6]), "0");
        }
        else
        {
            fdetail = AllinFreight1.GetFreightDetail("10", "0", ck.CheckNumber(odetail[7]));
        }


        ltrEndDate.Text = Convert.ToDateTime(fdetail[6]).ToString("yyyy-MM-dd");
        ltrFreightTitle.Text = "<span style=\"font-weight:bold;font-size:14px\">" + odetail[75] + "</span>";
        ltrFreightPostdate.Text = Convert.ToDateTime(odetail[65]).ToString("MM") + "/" + Convert.ToDateTime(odetail[65]).ToString("dd");
        ltrFreightEnddate.Text = Convert.ToDateTime(odetail[66]).ToString("MM") + "/" + Convert.ToDateTime(odetail[66]).ToString("dd");
        ltrFreightCompany.Text = fdetail[18];
        ltrFreightAllinStar.Text = fdetail[19];
        ltrFreightUserStar.Text = fdetail[20];
        ltrFreightLine.Text = odetail[69];
        ltrFreightStartport.Text = odetail[70];
        ltrFreightDestport.Text = odetail[71];
        ltrFreightAssuranceSpace.Text = odetail[100];
        ltrFreightAssurancePrice.Text = odetail[101];
        lblTousu.Text = fdetail[18];

        AllinUser AllinUser1 = new AllinUser();
        string[] udetail;
        udetail = AllinUser1.GetUserDetail(u);
        txtbank.Value = udetail[50];
        txtbankname.Value = udetail[51];
        txtbankaccount.Value = udetail[52];
        txtotheraccount.Value = udetail[53];
        txtaliaccount.Value = udetail[9];

    }//载入要修改的订单

    public void LoadSavedOrder()
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        GetRequest GetRequest1 = new GetRequest();

        string u = ck.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));
        string orderid = ck.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0"));
        string role = GetRequest1.GetRequestQueryString("role", "");

        AllinOrder AllinOrder1 = new AllinOrder();
        string[] odetail;
        odetail = AllinOrder1.GetOrderDetail(orderid);
        ltrOrderViewCode.Text = odetail[0];
        ltrOrderViewShipper.Text = odetail[8];
        ltrOrderViewConsignee.Text = odetail[9];
        ltrOrderViewNotifyParty.Text = odetail[10];
        ltrOrderViewCompanyName.Text = odetail[11];
        ltrOrderViewEmail.Text = odetail[12];
        ltrOrderViewContactor.Text = odetail[13];
        ltrOrderViewMobile.Text = odetail[14];
        ltrOrderViewTel.Text = odetail[15];
        ltrOrderViewFax.Text = odetail[16];
        ltrOrderViewStartport.Text = odetail[17];
        ltrOrderViewMidport.Text = odetail[18];
        ltrOrderViewDestport.Text = odetail[19];
        ltrOrderViewMarksNumbers.Text = odetail[20];
        ltrOrderViewNumbersofPackages.Text = odetail[21];
        ltrOrderViewDescription.Text = odetail[22];
        ltrOrderViewGrossWeight.Text = odetail[23];
        ltrOrderViewMeasurement.Text = odetail[24];
        ltrOrderViewCarrier.Text = odetail[26];
        ltrOrderViewKaihangri.Text = odetail[27];
        ltrOrderViewZhuangxiangri.Text = odetail[28];
        ltrOrderViewJieguanri.Text = odetail[29];
        ltrOrderViewGP.Text = odetail[35];
        ltrFreightA45.Text = odetail[53];
        ltrFreightA100.Text = odetail[54];
        ltrFreightA300.Text = odetail[55];
        ltrFreightA500.Text = odetail[56];
        ltrFreightA1000.Text = odetail[57];
        ltrFreightAppend.Text = odetail[44];
        ltrFreightCarrier.Text = odetail[26];
        ltrOrderViewHyf.Text = odetail[59];
        ltrOrderViewBeizhu.Text = odetail[36];
        ltrOverageThis.Text = odetail[62];
        txt_edit_priceP45.Text = odetail[53];
        txt_edit_priceP100.Text = odetail[54];
        txt_edit_priceP300.Text = odetail[55];
        txt_edit_priceP500.Text = odetail[56];
        txt_edit_priceP1000.Text = odetail[57];

        if (odetail[44] != "")
        {
            ltrOrderFujiafei.Text = "(附加费：" + odetail[44] + ")";
        }


        SetStep(odetail[1], odetail[37], odetail[38]);

        if (u != odetail[3] & u != odetail[4])
        {
            Response.Redirect("/search/err.aspx");
        }//不是买卖双方的用户无法查看该订单！

        string order_type_string = odetail[58];

        if (role == "shipper")
        {
            PlaceHolder3.Visible = true;
            ltrOrderStatus.Text = "<div style=\"padding:20px; margin-bottom:10px; font-size:14px; line-height:30px; text-align:left; background:#FFFCF3;border:1px solid #F7E4A5;\">" + odetail[89].Replace("{1}", orderid).Replace("{9}", order_type_string) + "</div>";

            if (u != odetail[3])
            {
                Response.Redirect("/search/err.aspx");
            }//不是买卖双方的用户无法查看该订单！

        }//订舱方显示的文本

        if (role == "forward")
        {
            PlaceHolder4.Visible = true;
            ltrOrderStatus.Text = "<div style=\"padding:20px; margin-bottom:10px; font-size:14px; line-height:30px; text-align:left; background:#FFFCF3;border:1px solid #F7E4A5;\">" + odetail[90].Replace("{1}", orderid).Replace("{9}", order_type_string) + "</div>";

            if (u != odetail[4])
            {
                Response.Redirect("/search/err.aspx");
            }//不是买卖双方的用户无法查看该订单！

            if (odetail[1] != "2")
            {
                phEditDisabled.Visible = true;
                phEditEnabled.Visible = false;
            }
            else
            {
                phEditDisabled.Visible = false;
                phEditEnabled.Visible = true;
            }
        }//承运方显示的文本

        if (odetail[1] != "2")
        {
            PlaceHolder2.Visible = false;
            PlaceHolder1.Visible = false;
        }

        ltrSMS.Text = "<a href=\"/member/pm_detail.aspx?cid=" + odetail[4] + "\" id=\"linkSMS\" target=\"_blank\"></a>";

        AllinFreight AllinFreight1 = new AllinFreight();
        string[] fdetail;
        if (odetail[7] == "0")
        {
            fdetail = AllinFreight1.GetFreightDetail("10", ck.CheckNumber(odetail[6]), "0");
        }
        else
        {
            fdetail = AllinFreight1.GetFreightDetail("10", "0", ck.CheckNumber(odetail[7]));
        }


        ltrEndDate.Text = Convert.ToDateTime(fdetail[6]).ToString("yyyy-MM-dd");
        ltrFreightTitle.Text = "<span style=\"font-weight:bold;font-size:14px\">" + odetail[75] + "</span>";
        ltrFreightPostdate.Text = Convert.ToDateTime(odetail[65]).ToString("MM") + "/" + Convert.ToDateTime(odetail[65]).ToString("dd");
        ltrFreightEnddate.Text = Convert.ToDateTime(odetail[66]).ToString("MM") + "/" + Convert.ToDateTime(odetail[66]).ToString("dd");
        ltrFreightCompany.Text = fdetail[18];
        ltrFreightAllinStar.Text = fdetail[19];
        ltrFreightUserStar.Text = fdetail[20];
        ltrFreightLine.Text = odetail[69];
        ltrFreightStartport.Text = odetail[70];
        ltrFreightDestport.Text = odetail[71];
        ltrFreightAssuranceSpace.Text = odetail[100];
        ltrFreightAssurancePrice.Text = odetail[101];
        lblTousu.Text = fdetail[18];

        AllinUser AllinUser1 = new AllinUser();
        string[] udetail;
        udetail = AllinUser1.GetUserDetail(u);
        txtbank.Value = udetail[50];
        txtbankname.Value = udetail[51];
        txtbankaccount.Value = udetail[52];
        txtotheraccount.Value = udetail[53];
        ltrOverageTotal.Text = udetail[55];
        ltrOverageAvailable.Text = (Convert.ToInt32(ltrOverageTotal.Text) - Convert.ToInt32(ltrOverageThis.Text)).ToString();
        ltrPayJump.Text = "<a href=\"/member/order/pay_sel_single.aspx?orderid=" + orderid + "\">立即充值</a>";

        //if (Convert.ToInt32(ltrOverageTotal.Text) - Convert.ToInt32(ltrOverageThis.Text) >= 0)
        //{
        //    PlaceHolder8.Visible = true;
        //    PlaceHolder9.Visible = false;
        //    PlaceHolder10.Visible = true;
        //    PlaceHolder11.Visible = false;
        //}
        //else
        //{
        //    PlaceHolder8.Visible = false;
        //    PlaceHolder9.Visible = true;
        //    PlaceHolder10.Visible = false;
        //    PlaceHolder11.Visible = true;
        //}

        PlaceHolder8.Visible = true;
        PlaceHolder9.Visible = false;
        PlaceHolder10.Visible = true;
        PlaceHolder11.Visible = false;



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


        string qgp = "0";
        string pricea45 = "0";
        string pricea100 = "0";
        string pricea300 = "0";
        string pricea500 = "0";
        string pricea1000 = "0";

        double yf = 0;
        double xxf = 0;


        pricea45 = ck.CheckNumber(ltrFreightA45.Text);
        pricea100 = ck.CheckNumber(ltrFreightA100.Text);
        pricea300 = ck.CheckNumber(ltrFreightA300.Text);
        pricea500 = ck.CheckNumber(ltrFreightA500.Text);
        pricea1000 = ck.CheckNumber(ltrFreightA1000.Text);

        qgp = ck.CheckNumber(txtgp.Value);

        if (Convert.ToInt32(qgp) <= 45)
        {
            yf = 0;
        }

        if (Convert.ToInt32(qgp) >= 45 & Convert.ToInt32(qgp) <= 100)
        {
            yf = Convert.ToDouble(pricea45);
        }

        if (Convert.ToInt32(qgp) > 100 & Convert.ToInt32(qgp) <= 300)
        {
            yf = Convert.ToDouble(pricea100);
        }

        if (Convert.ToInt32(qgp) > 300 & Convert.ToInt32(qgp) <= 500)
        {
            yf = Convert.ToDouble(pricea300);
        }

        if (Convert.ToInt32(qgp) > 500 & Convert.ToInt32(qgp) <= 1000)
        {
            yf = Convert.ToDouble(pricea500);
        }

        if (Convert.ToInt32(qgp) >= 1000)
        {
            yf = Convert.ToDouble(pricea1000);
        }


        yf = Convert.ToDouble(qgp) * yf;
        //yf += Convert.ToDouble(q40gp) * Convert.ToDouble(price40gp);
        //yf += Convert.ToDouble(q40hq) * Convert.ToDouble(price40hq);
        //yf += Convert.ToDouble(q45hq) * Convert.ToDouble(price45hq);

        xxf += Convert.ToDouble(qgp) * 1;

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
        sql += "jieshuri, ";
        sql += "carrier_name, ";
        sql += "zhuangxiangri, ";
        sql += "jieguanri, ";
        sql += "yf, ";
        sql += "xxf, ";
        sql += "air_kgs, ";
        sql += "PRICE_P45, ";
        sql += "PRICE_P100, ";
        sql += "PRICE_P300, ";
        sql += "PRICE_P500, ";
        sql += "PRICE_P1000, ";
        sql += "price20gpAppend, ";
        sql += "price_title, ";
        sql += "price_PostDate, ";
        sql += "price_enddate, ";
        sql += "price_companyname, ";
        sql += "price_shipcompany, ";
        sql += "price_hangxianmiaoshu, ";
        sql += "price_StartPort, ";
        sql += "price_DestPort, ";
        sql += "price_assurance_space, ";
        sql += "price_star_allin, ";
        sql += "price_star_user, ";
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
        sql += "'" + ck.CheckInput(ltrEndDate.Text) + "', ";
        sql += "'" + ck.CheckInput(txtcarrier_name.Value) + "', ";
        sql += "'" + ck.CheckInput(txtzhuangxiangri.Value) + "', ";
        sql += "'" + ck.CheckInput(txtjieguanri.Value) + "', ";
        sql += "" + yf.ToString() + ", ";
        sql += "" + xxf.ToString() + ", ";
        sql += "" + qgp + ", ";
        sql += "'" + ck.CheckInput(ltrFreightA45.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightA100.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightA300.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightA500.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightA1000.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightAppend.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightTitleHid.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightPostdateHid.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightEnddateHid.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightCompanyHid.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightCarrier.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightLine.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightStartport.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightDestport.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightAssuranceSpaceLevel.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightAllinStarHid.Text) + "', ";
        sql += "'" + ck.CheckInput(ltrFreightUserStarHid.Text) + "', ";
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
            sql += "air_kgs = " + qgp + ", ";
            sql += "yf = " + yf + ", ";
            sql += "xxf = " + xxf + ", ";
            sql += "beizhu = '" + ck.CheckInput(txtbeizhu.Value) + "' ";
            sql += "WHERE order_code = '" + ck.CheckInput(txtCode.Value) + "' ";
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

        sql = "";
        sql += "UPDATE TB_User SET ";
        sql += "ali_account = '" + ck.CheckInput(txtaliaccount.Value) + "' ";
        sql += "WHERE userid = " + u;

        //Response.Write(sql);
        cn.mdb_exe(sql);

        sql = "SELECT * FROM TB_User where userid = " + f;
        ds = cn.mdb_ds(sql, "user");
        //Response.Write(sql);

        if (q == 2)
        {
            pm p = new pm();
            string txt = "";
            txt = "<a href=\"/company/" + setkey(u) + "/\" target=\"_blank\">" + ck.CheckInput(txtCompanyName.Value) + "</a>于" + DateTime.Now.ToString() + "给您发送了一份线上订舱委托书，订舱编号:<a href=\"/search/air_order.aspx?filter=view&role=forward&orderid=" + ck.CheckInput(txtCode.Value) + "\" target=\"_blank\">" + ck.CheckInput(txtCode.Value) + "</a> ,请您尽快答复，以免错失商机！";
            p.sendpm("41", f, txt, "1");
            txt = "您于" + DateTime.Now.ToString() + "给<a href=\"/company/" + setkey(f) + "/\" target=\"_blank\">" + ck.CheckInput(ds.Tables["user"].Rows[0]["companyname"].ToString()) + "</a>发送了一份线上订舱委托书，订舱编号:<a href=\"/search/air_order.aspx?filter=view&role=shipper&orderid=" + ck.CheckInput(txtCode.Value) + "\" target=\"_blank\">" + ck.CheckInput(txtCode.Value) + "</a>，目前状态为等待对方商户的答复。";
            p.sendpm("41", u, txt, "1");
        }

        if (q == 3)
        {
            pm p = new pm();
            string txt = "";
            txt = "<a href=\"/company/" + setkey(u) + "/\" target=\"_blank\">" + ck.CheckInput(txtCompanyName.Value) + "</a>修改了订单<a href=\"/search/air_order.aspx?filter=view&role=forward&orderid=" + txtCode.Value + "\" target=\"_blank\">" + ck.CheckInput(txtCode.Value) + "</a>，提醒您重新查看该订单！";
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
        Response.Redirect("order_op.aspx?a=2&c1=2&c2=3&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }//接受订舱

    protected void btnReject_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("2", "2", "7", check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")), check1.CheckInput(txtRejectReason.Value));
        Response.Redirect("order_success.aspx?type=reject&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }//拒绝订舱

    protected void btnFinishOrderShipper1_Click(object sender, EventArgs e)
    {
        Response.Redirect("order_op.aspx?a=1&c1=3&c2=4&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }//货主完成出运

    protected void btnFinishOrderForward1_Click(object sender, EventArgs e)
    {
        Response.Redirect("order_op.aspx?a=2&c1=3&c2=5&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }//货代完成出运

    protected void btnFinishOrderShipper2_Click(object sender, EventArgs e)
    {
        Response.Redirect("order_op.aspx?a=1&c1=5&c2=6&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }//货主确认出运

    protected void btnFinishOrderForward2_Click(object sender, EventArgs e)
    {
        Response.Redirect("order_op.aspx?a=2&c1=4&c2=6&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }//货代确认出运

    protected void Button13_Click(object sender, EventArgs e)
    {
        Response.Redirect("order_op.aspx?a=1&c1=2&c2=8&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }

    protected void btnAcceptEditPrice_Click(object sender, EventArgs e)
    {
        AllinOrder1.UpdateOrderPriceAir(check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")), check1.CheckInput(txt_edit_priceP45.Text), check1.CheckInput(txt_edit_priceP100.Text), check1.CheckInput(txt_edit_priceP300.Text), check1.CheckInput(txt_edit_priceP500.Text), check1.CheckInput(txt_edit_priceP1000.Text));
        Response.Redirect("order_success.aspx?type=editprice&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }//确认修改运价

    protected void Button14_Click(object sender, EventArgs e)
    {

        if (GetRequest1.GetRequestQueryString("role", "0") == "shipper")
        {
            AllinOrder1.SetComplaints(check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")), TextBox1.Text, "0");
        }

        if (GetRequest1.GetRequestQueryString("role", "0") == "forward")
        {
            AllinOrder1.SetComplaints(check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")), TextBox1.Text, "1");
        }

        Response.Redirect("order_success.aspx?type=complaints&orderid=" + check1.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0")));
    }

    protected void SetStep(string status, string yiping_shipper, string yiping_forward)
    {
        GetRequest GetRequest1 = new GetRequest();
        string role = GetRequest1.GetRequestQueryString("role", "");
        string ss1 = "<img src=\"/images/fcl/shipper_booking_m_r1_c1.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string ss4 = "<img src=\"/images/fcl/shipper_booking_m2_r1_c9.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string ss4_p = "<img src=\"/images/fcl/shipper_booking_m_r1_c9.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";


        if (role == "shipper")
        {
            ss1 = "<img src=\"/images/fcl/shipper_booking_m_r1_c1.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            ss4 = "<img src=\"/images/fcl/shipper_booking_m2_r1_c9.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            ss4_p = "<img src=\"/images/fcl/shipper_booking_m_r1_c9.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        }//订舱方显示的文本

        if (role == "forward")
        {
            ss1 = "<img src=\"/images/fcl/booking_m_r1_c1.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            ss4 = "<img src=\"/images/fcl/booking_m2_r1_c9.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            ss4_p = "<img src=\"/images/fcl/booking_m_r1_c9.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        }//承运方显示的文本

        string s1 = ss1;
        string a1 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string s2 = "<img src=\"/images/fcl/booking_m2_r1_c3.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string a2 = "<img src=\"/images/fcl/booking_bb2.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string s3 = "<img src=\"/images/fcl/booking_m2_r1_c5.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string a3 = "<img src=\"/images/fcl/booking_bb2.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string s4 = ss4;
        string a4 = "<img src=\"/images/fcl/booking_bb2.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string s5 = "<img src=\"/images/fcl/booking_m2_r1_c7.gif\" />";
        string s = "";

        if (status == "3")
        {
            s2 = "<img src=\"/images/fcl/booking_m_r1_c3.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            a2 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        }

        if (status == "4")
        {
            s2 = "<img src=\"/images/fcl/booking_m_r1_c3.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            a2 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            s3 = "<img src=\"/images/fcl/booking_m_r1_c5.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            a3 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        }

        if (status == "5")
        {
            s2 = "<img src=\"/images/fcl/booking_m_r1_c3.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            a2 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            s3 = "<img src=\"/images/fcl/booking_m_r1_c5.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            a3 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            s4 = ss4_p;
            a4 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        }

        if (yiping_shipper == "1" & yiping_forward == "1")
        {
            s2 = "<img src=\"/images/fcl/booking_m_r1_c3.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            a2 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            s3 = "<img src=\"/images/fcl/booking_m_r1_c5.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            a3 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            s4 = ss4_p;
            a4 = "<img src=\"/images/fcl/booking_m_r1_c12.gif\" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            s5 = "<img src=\"/images/fcl/booking_m_r1_c7.gif\" />";
        }

        s = s1 + a1 + s2 + a2 + s3 + a3 + s4 + a4 + s5;

        ltrStep.Text = s;
    }//设置状态图标

}
