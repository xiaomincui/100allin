using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.Xml;

/// <summary>
/// AllinOrder 的摘要说明
/// </summary>
public class AllinOrder
{
    public GetRequest GetRequest1 = new GetRequest();
	public AllinOrder()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}


    public void OrderAddCreditOriginal(string u, string a, string t, string o, string ou, string p)
    {
        //参数说明 
        //u为用户id 
        //a为价格调整数量 
        //t为价格调整事件类型 
        //o为订单号 
        //ou为客户id 
        //p为是否增加预付款额度，1为增加，0为不增加，默认为0 

        data_conn conn = new data_conn();
        DataSet ds = new DataSet();

        string userid = u;
        string amount = a;
        //价格调整数量 
        string orderid = o;
        //订单号 
        string billtype = t;
        //账单事件类型 
        string billtypetext = "";
        //账单事件类型 
        string otherid = ou;
        string pay = p;
        string pmtext = "";
        //短消息内容 
        string role = "";

        string sql = "";

        if (p == "0")
        {
            sql = "UPDATE TB_ORDER_ACCOUNT SET overage = overage + " + amount + " WHERE userid = " + userid;
        }
        else
        {
            sql = "UPDATE TB_ORDER_ACCOUNT SET credit = credit + " + amount + ",overage = overage + " + amount + " WHERE userid = " + userid;
        }

        conn.mdb_exe(sql);
        //更新帐户信息 

        sql = "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + userid;
        ds = conn.mdb_ds(sql, "account");

        double credit = 0;
        double overage = 0;
        int level = 0;

        if (ds.Tables["account"].Rows.Count > 0)
        {
            credit = Convert.ToDouble(ds.Tables["account"].Rows[0]["credit"].ToString());
            overage = Convert.ToDouble(ds.Tables["account"].Rows[0]["overage"].ToString());
        }


        if (0 < credit & credit <= 1999)
        {
            level = 1;
        }
        else if (2000 < credit & credit <= 4999)
        {
            level = 2;
        }
        else if (5000 < credit & credit <= 9999)
        {
            level = 3;
        }
        else if (10000 < credit & credit <= 19999)
        {
            level = 4;
        }
        else if (20000 < credit & credit <= 100000)
        {
            level = 5;
        }

        sql = "UPDATE TB_USER SET star_allin = " + level.ToString() + " WHERE userid = " + userid;
        conn.mdb_exe(sql);
        //更新安运通级别 

        switch (billtype)
        {
            case "1":
                billtypetext = "预存(支付宝)";
                pmtext = "您已使用支付宝方式增加了" + amount + "元预存费，支付宝订单号<a href=\"/member/order/ali_order.aspx?orderid=" + orderid + "\" target=\"_blank\">" + orderid;
                break;
            case "2":
                billtypetext = "预存(银行汇款)";
                break;
            case "3":
                billtypetext = "预存(网上银行)";
                break;
            case "4":
                billtypetext = "订舱成功<br/>暂扣保证金加订舱费";
                role = "forward";
                break;
            case "5":
                billtypetext = "交易结束<br/>退还保证金";
                role = "forward";
                break;
            case "6":
                billtypetext = "交易结束<br/>奖励信息费";
                role = "shipper";
                break;
            case "7":
                billtypetext = "交易结束<br/>收取信息费";
                role = "forward";
                break;
            case "8":
                billtypetext = "交易中止<br/>退还保证金加订舱费";
                role = "forward";
                break;
            case "9":
                billtypetext = "订舱成功<br/>暂扣保证金加订舱费<br/>(支付宝)";
                pmtext = "您已使用支付宝方式增加了" + amount + "元预存费，支付宝订单号<a href=\"/member/order/ali_order.aspx?orderid=" + orderid + "\" target=\"_blank\">" + orderid;
                break;
        }

        sql = "INSERT INTO TB_ORDER_ACCOUNT_DETAIL (detail_date,order_code,userid,otherid,status,fee,overage,ispay,role) ";
        sql = sql + " VALUES (getdate(),'" + orderid + "'," + userid + "," + ou + ",'" + billtypetext + "'," + amount + "," + overage + ",0,'" + role + "')";
        conn.mdb_exe(sql);

        if (!string.IsNullOrEmpty(pmtext))
        {
            pm pm1 = new pm();
            //给支付宝支付的人发送一条短消息 
            pm1.sendpm("41", userid, pmtext, "1");

        }
    }
    //增加帐户预存费，增加余额，调整相应会员级别 

    public void OrderAddCredit(string a, string t, string o, string ou, string p)
    {
        check ck = new check();
        string userid = ck.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));
        string amount = ck.CheckNumber(a);
        string orderid = ck.CheckInput(o);
        string billtype = ck.CheckNumber(t);
        string otherid = ck.CheckNumber(ou);
        string pay = ck.CheckNumber(p);
        OrderAddCreditOriginal(userid, amount, billtype, orderid, otherid, pay);
    }
    //当前用户调整账户 

    public void OrderAddCredit(string u, string a, string t, string o, string ou, string p)
    {
        check ck = new check();
        string userid = ck.CheckNumber(u);
        string amount = ck.CheckNumber(a);
        string orderid = ck.CheckInput(o);
        string billtype = ck.CheckNumber(t);
        string otherid = ck.CheckNumber(ou);
        string pay = ck.CheckNumber(p);
        OrderAddCreditOriginal(userid, amount, billtype, orderid, otherid, pay);
    }
    //任何用户调整账户


    public string OrderGetAliAccount()
    {
        check ck = new check();
        string userid = ck.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));
        string ali_account = "";

        data_conn conn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        sql = "SELECT * FROM TB_USER WHERE userid = " + userid;
        ds = conn.mdb_ds(sql, "user");

        ali_account = ds.Tables["user"].Rows[0]["ali_account"].ToString();

        return ali_account;
    }
    //获得当前用户的阿里账户 

    public string OrderGetAliAccount(string u)
    {
        check ck = new check();
        string userid = ck.CheckNumber(u);
        string ali_account = "";

        data_conn conn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        sql = "SELECT * FROM TB_USER WHERE userid = " + userid;
        ds = conn.mdb_ds(sql, "user");

        ali_account = ds.Tables["user"].Rows[0]["ali_account"].ToString();

        return ali_account;
    }
    //获得任何用户的阿里账户 

    public void SetUserStar(string u) 
    {
        data_conn conn = new data_conn();
        DataSet ds = new DataSet();

        string userid = u;
        string sql;
        sql = "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + userid;
        ds = conn.mdb_ds(sql, "account");

        double point = 0;
        int level = 0;

        if (ds.Tables["account"].Rows.Count > 0)
        {
            point = Convert.ToDouble(ds.Tables["account"].Rows[0]["point"].ToString());
        }


        if (0 < point & point <= 2)
        {
            level = 1;
        }
        else if (3 < point & point <= 6)
        {
            level = 2;
        }
        else if (7 < point & point <= 15)
        {
            level = 3;
        }
        else if (16 < point & point <= 32)
        {
            level = 4;
        }
        else if (33 < point & point <= 65)
        {
            level = 5;
        }
        else if (66 < point & point <= 130)
        {
            level = 6;
        }
        else if (131 < point & point <= 259)
        {
            level = 7;
        }
        else if (260 < point & point <= 510)
        {
            level = 8;
        }
        else if (511 < point & point <= 1011)
        {
            level = 9;
        }
        else if (1012 < point & point <= 2012)
        {
            level = 10;
        }

        sql = "UPDATE TB_USER SET star_user = " + level.ToString() + " WHERE userid = " + userid;
        conn.mdb_exe(sql);
    }//更新用户的信誉等级

    public string GetAllinStar(string s)
    {
        int ss = 0;
        ss = Convert.ToInt32(s);
        string w = null;
        w = "";

        switch (s)
        {
            case "1":
                w = "<img src=\"/images/fcl/ay_1.jpg\" border=\"0\" class=\"yt\">";
                break;
            case "2":
                w = "<img src=\"/images/fcl/ay_2.jpg\" border=\"0\" class=\"yt\">";
                break;
            case "3":
                w = "<img src=\"/images/fcl/ay_3.gif\" border=\"0\" class=\"yt\">";
                break;
            case "4":
                w = "<img src=\"/images/fcl/ay_4.jpg\" border=\"0\" class=\"yt\">";
                break;
            case "5":
                w = "<img src=\"/images/fcl/ay_5.jpg\" border=\"0\" class=\"yt\">";

                break;
        }

        return w.ToString();
    }

    public string GetUserStar(string s)
    {
        int ss = 0;
        ss = Convert.ToInt32(s);
        string w = null;
        w = "";

        for (int i = 0; i <= ss - 1; i++)
        {
            w = w + "<img src=\"/images/fcl/star.gif\" border=\"0\" alt=\"信誉等级：" + s + "级\" >";
        }

        if (ss == 0)
        {
            w = "-";
        }

        return w.ToString();
    }

    public string GetAssuranceSpace(string s)
    {
        string w = "";
        if (s == "1")
        {
            w = "<a href=\"/topic/order20091104/readme.aspx#a007\" target=\"_blank\"><img src=\"/images/fcl/cang.gif\" border=\"0\" class=\"yt\"/></a> 舱位保证";
        }

        return w.ToString();
    }

    public string GetAssurancePrice(string s)
    {
        string w = "";
        if (s != "0" & s != "")
        {
            w = "<a href=\"/topic/order20091104/readme.aspx#a008\" target=\"_blank\"><img src=\"/images/fcl/dc16.gif\" border=\"0\" class=\"yt\"/></a> 价格保证";
        }

        return w.ToString();
    }


    ///   <summary>   
    ///   添加一条安运通的体验申请。   
    ///   </summary> 
    ///   <param name="u">表示用户的userid</param>
    /// <returns>返回值：添加是否成功</returns>
    public string SetOrderTry(string u)
    {
        check ck = new check();
        string userid = ck.CheckNumber(u);
        string ali_account = "";

        data_conn conn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        sql = "SELECT * FROM TB_ORDER_ACCOUNT_TEST WHERE userid = " + userid;
        ds = conn.mdb_ds(sql, "user");

        if (ds.Tables["user"].Rows.Count > 0)
        {
            return "false";
        }
        else
        {
            sql = "INSERT INTO TB_ORDER_ACCOUNT_TEST (userid,app_time,ifacc) VALUES (" + userid + ",GetDate(),0)";
            conn.mdb_exe(sql);
            return "success";
        }
    }//体验会员申请


    ///   <summary>   
    ///   检查当前会员是否是体验会员。   
    ///   </summary> 
    ///   <param name="u">表示用户的userid</param>
    /// <returns>返回值：添加是否成功</returns>
    public string GetOrderTry(string u)
    {
        check ck = new check();
        string userid = ck.CheckNumber(u);

        data_conn conn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        sql = "SELECT * FROM TB_ORDER_ACCOUNT_TEST WHERE userid = " + userid;
        ds = conn.mdb_ds(sql, "user");

        if (ds.Tables["user"].Rows.Count > 0)
        {
            return "success";
        }
        else
        {
            return "false";
        }
    }//检查是否是体验会员

    ///   <summary>   
    ///   获得某条订单的信息   
    ///   </summary> 
    ///   <param name="o">表示订单号</param>
    /// <returns>返回值：订单详细信息数组</returns>
    public string[] GetOrderDetail(string o)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        o = ck.CheckInput(o);

        string sql = "";

        sql = "SELECT * FROM TB_ORDER,TB_ORDER_STATUS WHERE TB_ORDER.order_status = TB_ORDER_STATUS.sid AND order_code = '" + o + "' ";

        ds = cn.mdb_ds(sql, "order");

        //HttpContext.Current.Response.Write(sql);

        string[] k;
        k = new string[150];
        k[0] = ds.Tables["order"].Rows[0]["order_code"].ToString(); //用户编号
        k[1] = ds.Tables["order"].Rows[0]["order_status"].ToString(); //用户名
        k[2] = ds.Tables["order"].Rows[0]["date_create"].ToString(); //密码
        k[3] = ds.Tables["order"].Rows[0]["order_shipper"].ToString(); //货主
        k[4] = ds.Tables["order"].Rows[0]["order_forward"].ToString(); //货代
        k[5] = ds.Tables["order"].Rows[0]["freight_type"].ToString(); //邮箱
        k[6] = ds.Tables["order"].Rows[0]["freight_code"].ToString(); //手机
        k[7] = ds.Tables["order"].Rows[0]["freight_code1"].ToString(); //电话
        k[8] = ds.Tables["order"].Rows[0]["Shipper"].ToString(); //传真
        k[9] = ds.Tables["order"].Rows[0]["Consignee"].ToString(); //传真
        k[10] = ds.Tables["order"].Rows[0]["NotifyParty"].ToString(); //传真
        k[11] = ds.Tables["order"].Rows[0]["CompanyName"].ToString(); //传真
        k[12] = ds.Tables["order"].Rows[0]["Email"].ToString(); //传真
        k[13] = ds.Tables["order"].Rows[0]["Contactor"].ToString(); //传真
        k[14] = ds.Tables["order"].Rows[0]["Mobile"].ToString(); //传真
        k[15] = ds.Tables["order"].Rows[0]["Tel"].ToString(); //传真
        k[16] = ds.Tables["order"].Rows[0]["Fax"].ToString(); //传真
        k[17] = ds.Tables["order"].Rows[0]["startport"].ToString(); //传真
        k[18] = ds.Tables["order"].Rows[0]["midport"].ToString(); //传真
        k[19] = ds.Tables["order"].Rows[0]["destport"].ToString(); //传真
        k[20] = ds.Tables["order"].Rows[0]["MarksNumbers"].ToString(); //传真
        k[21] = ds.Tables["order"].Rows[0]["NumbersofPackages"].ToString(); //传真
        k[22] = ds.Tables["order"].Rows[0]["Description"].ToString(); //传真
        k[23] = ds.Tables["order"].Rows[0]["GrossWeight"].ToString(); //传真
        k[24] = ds.Tables["order"].Rows[0]["Measurement"].ToString(); //传真
        k[25] = ds.Tables["order"].Rows[0]["Law"].ToString(); //传真
        k[26] = ds.Tables["order"].Rows[0]["carrier_name"].ToString(); //传真
        if (ds.Tables["order"].Rows[0]["kaihangri"].ToString() == "1900-1-1 0:00:00")
        {
            k[27] = ""; 
        }
        else
        {
            k[27] = Convert.ToDateTime(ds.Tables["order"].Rows[0]["kaihangri"].ToString()).ToString("yyyy-M-d");
        }
        if (ds.Tables["order"].Rows[0]["zhuangxiangri"].ToString() == "1900-1-1 0:00:00")
        {
            k[28] = "";
        }
        else
        {
            k[28] = Convert.ToDateTime(ds.Tables["order"].Rows[0]["zhuangxiangri"].ToString()).ToString("yyyy-M-d");
        }
        if (ds.Tables["order"].Rows[0]["jieguanri"].ToString() == "1900-1-1 0:00:00")
        {
            k[29] = "";
        }
        else
        {
            k[29] = Convert.ToDateTime(ds.Tables["order"].Rows[0]["jieguanri"].ToString()).ToString("yyyy-M-d");
        }
        k[30] = ds.Tables["order"].Rows[0]["container_20gp"].ToString(); //传真
        k[31] = ds.Tables["order"].Rows[0]["container_40gp"].ToString(); //传真
        k[32] = ds.Tables["order"].Rows[0]["container_40hq"].ToString(); //传真
        k[33] = ds.Tables["order"].Rows[0]["container_45hq"].ToString(); //传真
        k[34] = ds.Tables["order"].Rows[0]["lcl_cbm"].ToString(); //传真
        k[35] = ds.Tables["order"].Rows[0]["air_kgs"].ToString(); //传真
        k[36] = ds.Tables["order"].Rows[0]["beizhu"].ToString(); //传真
        k[37] = ds.Tables["order"].Rows[0]["yiping_shipper"].ToString(); //传真
        k[38] = ds.Tables["order"].Rows[0]["yiping_forward"].ToString(); //传真
        k[39] = ds.Tables["order"].Rows[0]["ping_shipper"].ToString(); //传真
        k[40] = ds.Tables["order"].Rows[0]["ping_forward"].ToString(); //传真
        k[41] = ds.Tables["order"].Rows[0]["evaluation_shipper"].ToString(); //传真
        k[42] = ds.Tables["order"].Rows[0]["evaluation_forward"].ToString(); //传真
        k[43] = ds.Tables["order"].Rows[0]["reject_reason"].ToString(); //传真
        k[44] = ds.Tables["order"].Rows[0]["price20gpAppend"].ToString(); //传真
        k[45] = ds.Tables["order"].Rows[0]["price20gp"].ToString(); //传真
        k[46] = ds.Tables["order"].Rows[0]["price40gp"].ToString(); //传真
        k[47] = ds.Tables["order"].Rows[0]["price40hq"].ToString(); //传真
        k[48] = ds.Tables["order"].Rows[0]["price45hq"].ToString(); //传真
        k[49] = ds.Tables["order"].Rows[0]["pricegp"].ToString(); //传真
        k[50] = ds.Tables["order"].Rows[0]["pricegpv"].ToString(); //传真
        k[51] = ds.Tables["order"].Rows[0]["PRICE_M"].ToString(); //传真
        k[52] = ds.Tables["order"].Rows[0]["PRICE_N"].ToString(); //传真
        k[53] = ds.Tables["order"].Rows[0]["PRICE_P45"].ToString(); //传真
        k[54] = ds.Tables["order"].Rows[0]["PRICE_P100"].ToString(); //传真
        k[55] = ds.Tables["order"].Rows[0]["PRICE_P300"].ToString(); //传真
        k[56] = ds.Tables["order"].Rows[0]["PRICE_P500"].ToString(); //传真
        k[57] = ds.Tables["order"].Rows[0]["PRICE_P1000"].ToString(); //传真
        switch (ds.Tables["order"].Rows[0]["freight_type"].ToString())
        {
            case "8":
                k[58] = "fcl";
                break;
            case "9":
                k[58] = "lcl";
                break;
            case "10":
                k[58] = "air";
                break;
            default:
                break;
        }
        k[59] = ds.Tables["order"].Rows[0]["yf"].ToString(); //海运费
        k[60] = ds.Tables["order"].Rows[0]["xxf"].ToString(); //信息费
        k[61] = (Convert.ToDouble(ds.Tables["order"].Rows[0]["xxf"].ToString()) / 2).ToString(); //奖金
        k[62] = (Convert.ToDouble(ds.Tables["order"].Rows[0]["xxf"].ToString()) * 4).ToString(); //保证金
        k[63] = (Convert.ToDouble(ds.Tables["order"].Rows[0]["xxf"].ToString()) * 3).ToString(); //归还保证金

        k[64] = ds.Tables["order"].Rows[0]["price_title"].ToString();
        k[65] = ds.Tables["order"].Rows[0]["price_PostDate"].ToString();
        k[66] = ds.Tables["order"].Rows[0]["price_enddate"].ToString();
        k[67] = ds.Tables["order"].Rows[0]["price_companyname"].ToString();
        k[68] = ds.Tables["order"].Rows[0]["price_shipcompany"].ToString();
        k[69] = ds.Tables["order"].Rows[0]["price_hangxianmiaoshu"].ToString();
        k[70] = ds.Tables["order"].Rows[0]["price_StartPort"].ToString();
        k[71] = ds.Tables["order"].Rows[0]["price_DestPort"].ToString();
        k[72] = ds.Tables["order"].Rows[0]["price_assurance_space"].ToString();
        k[73] = ds.Tables["order"].Rows[0]["price_star_allin"].ToString();
        k[74] = ds.Tables["order"].Rows[0]["price_star_user"].ToString();
        k[75] = "<a href=\"/" + k[58] + "/" + SetKey(ds.Tables["order"].Rows[0]["freight_code"].ToString()) + "_" + ds.Tables["order"].Rows[0]["freight_code1"].ToString() + ".html\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["price_title"].ToString() + "</a>"; //运价链接
        k[100] = GetAssuranceSpace(ds.Tables["order"].Rows[0]["price_assurance_space"].ToString()); //舱位保证标记
        k[101] = GetAssurancePrice(ds.Tables["order"].Rows[0]["price_star_allin"].ToString()); //价格保证标记
        k[102] = "<a href=\"/company/" + SetKey(ds.Tables["order"].Rows[0]["order_forward"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["price_companyname"].ToString() + "</a>"; //货代公司链接
        k[103] = "<a href=\"/company/" + SetKey(ds.Tables["order"].Rows[0]["order_forward"].ToString()) + "/\" target=\"_blank\">" + GetAllinStar(ds.Tables["order"].Rows[0]["price_star_allin"].ToString()) + "</a>"; //安运通级别标记（带链接）
        k[104] = "<a href=\"/company/" + SetKey(ds.Tables["order"].Rows[0]["order_forward"].ToString()) + "/\" target=\"_blank\">" + GetUserStar(ds.Tables["order"].Rows[0]["price_star_user"].ToString()) + "</a>"; //保障级别标记（带链接）

        if (ds.Tables["order"].Rows[0]["jieshuri"].ToString() == "1900-1-1 0:00:00")
        {
            k[105] = "";
        }
        else
        {
            k[105] = Convert.ToDateTime(ds.Tables["order"].Rows[0]["jieshuri"].ToString()).ToString("yyyy-M-d");
        }
        k[106] = ds.Tables["order"].Rows[0]["alipay_if"].ToString();
        k[107] = "<a href=\"/company/" + SetKey(ds.Tables["order"].Rows[0]["order_shipper"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["CompanyName"].ToString() + "</a>"; //货主公司链接
        k[108] = "<a href=\"/search/" + SetKey(ds.Tables["order"].Rows[0]["order_shipper"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["CompanyName"].ToString() + "</a>"; //订单链接货主
        k[109] = "<a href=\"/search/" + k[58] + "_order.aspx?filter=view&role=shipper&orderid=" + ds.Tables["order"].Rows[0]["order_code"].ToString() + "\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["order_code"].ToString() + "</a>"; //订单链接货主
        k[110] = "<a href=\"/search/" + k[58] + "_order.aspx?filter=view&role=forward&orderid=" + ds.Tables["order"].Rows[0]["order_code"].ToString() + "\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["order_code"].ToString() + "</a>"; //订单链接货代

        k[120] = ds.Tables["order"].Rows[0]["alipay_pay_return"].ToString();
        k[121] = ds.Tables["order"].Rows[0]["alipay_back_return"].ToString();

        k[80] = ds.Tables["order"].Rows[0]["status_name_shipper"].ToString();
        k[81] = ds.Tables["order"].Rows[0]["status_name_forward"].ToString();
        k[82] = ds.Tables["order"].Rows[0]["status_description"].ToString();
        k[83] = ds.Tables["order"].Rows[0]["status_op_shipper"].ToString();
        k[84] = ds.Tables["order"].Rows[0]["status_op_forward"].ToString();
        k[85] = ds.Tables["order"].Rows[0]["status_level"].ToString();
        k[86] = ds.Tables["order"].Rows[0]["status_op_admin"].ToString();
        k[87] = ds.Tables["order"].Rows[0]["status_name_admin"].ToString();
        k[88] = ds.Tables["order"].Rows[0]["status_font_weight"].ToString();
        k[89] = ds.Tables["order"].Rows[0]["status_txt_shipper"].ToString();
        k[90] = ds.Tables["order"].Rows[0]["status_txt_forward"].ToString();

        k[131] = ds.Tables["order"].Rows[0]["edit_enabled"].ToString();
        k[132] = ds.Tables["order"].Rows[0]["edit_price20gpAppend"].ToString();
        k[133] = ds.Tables["order"].Rows[0]["edit_price20gp"].ToString();
        k[134] = ds.Tables["order"].Rows[0]["edit_price40gp"].ToString();
        k[135] = ds.Tables["order"].Rows[0]["edit_price40hq"].ToString();
        k[136] = ds.Tables["order"].Rows[0]["edit_price45hq"].ToString();
        k[137] = ds.Tables["order"].Rows[0]["edit_pricegp"].ToString();
        k[138] = ds.Tables["order"].Rows[0]["edit_pricegpv"].ToString();
        k[139] = ds.Tables["order"].Rows[0]["edit_PRICE_M"].ToString();
        k[140] = ds.Tables["order"].Rows[0]["edit_PRICE_N"].ToString();
        k[141] = ds.Tables["order"].Rows[0]["edit_PRICE_P45"].ToString();
        k[142] = ds.Tables["order"].Rows[0]["edit_PRICE_P100"].ToString();
        k[143] = ds.Tables["order"].Rows[0]["edit_PRICE_P300"].ToString();
        k[144] = ds.Tables["order"].Rows[0]["edit_PRICE_P500"].ToString();
        k[145] = ds.Tables["order"].Rows[0]["edit_PRICE_P1000"].ToString();
        k[146] = ds.Tables["order"].Rows[0]["edit_price_shipcompany"].ToString();

        return k;

    }//取得订单详细信息

    public void UpdateOrderPriceFcl(string o, string p1, string p2, string p3, string p4, string p5)
    {
        data_conn cn = new data_conn();
        string sql = "";

        sql = "UPDATE TB_ORDER SET edit_price20gp = '" + p1 + "',edit_price40gp = '" + p2 + "',edit_price40hq = '" + p3 + "',edit_price45hq = '" + p4 + "',edit_price_shipcompany = '" + p5 + "',edit_enabled = 1 WHERE order_code = '" + o + "'";
        cn.mdb_exe(sql);

        string[] odetail;
        odetail = GetOrderDetail(o);

        pm pm1 = new pm();


        string pmtxt_shipper = "";
        pmtxt_shipper += "<table border=\"1\" cellpadding=\"3\" cellspacing=\"1\" style=\"border-collapse: collapse; font-size:12px;\">";
        pmtxt_shipper += "<tr><td></td><td>20GP</td><td>40GP</td><td>40HQ</td><td>45HQ</td><td>船公司</td></tr>";
        pmtxt_shipper += "<tr><td>原运费</td><td>" + odetail[45] + "</td><td>" + odetail[46] + "</td><td>" + odetail[47] + "</td><td>" + odetail[48] + "</td><td>" + odetail[68] + "</td></tr>";
        pmtxt_shipper += "<tr><td>修改后</td><td>" + odetail[133] + "</td><td>" + odetail[134] + "</td><td>" + odetail[135] + "</td><td>" + odetail[136] + "</td><td>" + odetail[146] + "</td></tr>";
        pmtxt_shipper += "</table>";

        pm1.sendpm("41", odetail[3], "承运方" + odetail[102] + "修改了订单" + odetail[109] + "的运费信息<br/>" + pmtxt_shipper + "<br/>以上修改等待您的确认！<br/><a href=\"/search/order_edit_confirm.aspx?type=ok&orderid=" + o + "\">同意</a> <a href=\"/search/order_edit_confirm.aspx?type=cancel&orderid=" + o + "\">不同意</a>", "1");
        pm1.sendpm("41", odetail[4], "您修改了订单" + odetail[110] + "的运费信息<br/>" + pmtxt_shipper + "<br/>请等待委托方" + odetail[107] + "确认！", "1");
    }

    public void UpdateOrderPriceLcl(string o, string p1, string p2, string p3)
    {
        data_conn cn = new data_conn();
        string sql = "";

        sql = "UPDATE TB_ORDER SET edit_pricegp = '" + p1 + "',edit_pricegpv = '" + p2 + "',edit_price_shipcompany = '" + p3 + "',edit_enabled = 1 WHERE order_code = '" + o + "'";
        cn.mdb_exe(sql);

        string[] odetail;
        odetail = GetOrderDetail(o);

        pm pm1 = new pm();


        string pmtxt_shipper = "";
        pmtxt_shipper += "<table border=\"1\" cellpadding=\"3\" cellspacing=\"1\" style=\"border-collapse: collapse; font-size:12px;\">";
        pmtxt_shipper += "<tr><td></td><td>价格(按体积)</td><td>价格(按重量)</td><td>船公司</td></tr>";
        pmtxt_shipper += "<tr><td>原运费</td><td>" + odetail[49] + "</td><td>" + odetail[50] + "</td><td>" + odetail[68] + "</td></tr>";
        pmtxt_shipper += "<tr><td>修改后</td><td>" + odetail[137] + "</td><td>" + odetail[138] + "</td><td>" + odetail[146] + "</td></tr>";
        pmtxt_shipper += "</table>";

        pm1.sendpm("41", odetail[3], "承运方" + odetail[102] + "修改了订单" + odetail[109] + "的运费信息<br/>" + pmtxt_shipper + "<br/>以上修改等待您的确认！<br/><a href=\"/search/order_edit_confirm.aspx?type=ok&orderid=" + o + "\">同意</a> <a href=\"/search/order_edit_confirm.aspx?type=cancel&orderid=" + o + "\">不同意</a>", "1");
        pm1.sendpm("41", odetail[4], "您修改了订单" + odetail[110] + "的运费信息<br/>" + pmtxt_shipper + "<br/>请等待委托方" + odetail[107] + "确认！", "1");
    }

    public void UpdateOrderPriceAir(string o, string p1, string p2, string p3, string p4, string p5)
    {
        data_conn cn = new data_conn();
        string sql = "";

        sql = "UPDATE TB_ORDER SET edit_PRICE_P45 = '" + p1 + "',edit_PRICE_P100 = '" + p2 + "',edit_PRICE_P300 = '" + p3 + "',edit_PRICE_P500 = '" + p4 + "',edit_PRICE_P1000 = '" + p5 + "',edit_enabled = 1 WHERE order_code = '" + o + "'";
        cn.mdb_exe(sql);

        string[] odetail;
        odetail = GetOrderDetail(o);

        pm pm1 = new pm();


        string pmtxt_shipper = "";
        pmtxt_shipper += "<table border=\"1\" cellpadding=\"3\" cellspacing=\"1\" style=\"border-collapse: collapse; font-size:12px;\">";
        pmtxt_shipper += "<tr><td></td><td>45+</td<td>100+</td><td>300+</td><td>500+</td><td>1000+</td></tr>";
        pmtxt_shipper += "<tr><td>原运费</td><td>" + odetail[53] + "</td><td>" + odetail[54] + "</td><td>" + odetail[55] + "</td><td>" + odetail[56] + "</td><td>" + odetail[57] + "</td></tr>";
        pmtxt_shipper += "<tr><td>修改后</td><td>" + odetail[141] + "</td><td>" + odetail[142] + "</td><td>" + odetail[143] + "</td><td><td>" + odetail[144] + "</td><td><td>" + odetail[145] + "</td><td></tr>";
        pmtxt_shipper += "</table>";

        pm1.sendpm("41", odetail[3], "承运方" + odetail[102] + "修改了订单" + odetail[109] + "的运费信息<br/>" + pmtxt_shipper + "<br/>以上修改等待您的确认！<br/><a href=\"/search/order_edit_confirm.aspx?type=ok&orderid=" + o + "\">同意</a> <a href=\"/search/order_edit_confirm.aspx?type=cancel&orderid=" + o + "\">不同意</a>", "1");
        pm1.sendpm("41", odetail[4], "您修改了订单" + odetail[110] + "的运费信息<br/>" + pmtxt_shipper + "<br/>请等待委托方" + odetail[107] + "确认！", "1");
    }

    public void UpdateOrderPriceOk(string o)
    {
        data_conn cn = new data_conn();
        string sql = "";

        sql = "UPDATE TB_ORDER SET price20gpAppend=edit_price20gpAppend,price20gp=edit_price20gp,price40gp=edit_price40gp,price40hq=edit_price40hq,price45hq=edit_price45hq,pricegp=edit_pricegp,pricegpv=edit_pricegpv,PRICE_M=edit_PRICE_M,PRICE_N=edit_PRICE_N,PRICE_P45=edit_PRICE_P45,PRICE_P100=edit_PRICE_P100,PRICE_P300=edit_PRICE_P300,PRICE_P500=edit_PRICE_P500,PRICE_P1000=edit_PRICE_P1000,price_shipcompany=edit_price_shipcompany,edit_enabled = 0 WHERE order_code = '" + o + "'";
        cn.mdb_exe(sql);

        string[] odetail;
        odetail = GetOrderDetail(o);

        pm pm1 = new pm();

        pm1.sendpm("41", odetail[3], "您同意了承运方" + odetail[102] + "修改订单运费" + odetail[109] + "的请求！", "1");
        pm1.sendpm("41", odetail[4], "委托方" + odetail[107] + "同意了您修改订单运费" + odetail[110] + "的请求！", "1");
    }

    public void UpdateOrderPriceCancel(string o)
    {
        data_conn cn = new data_conn();
        string sql = "";

        sql = "UPDATE TB_ORDER SET edit_enabled = 0 WHERE order_code = '" + o + "'";
        cn.mdb_exe(sql);

        string[] odetail;
        odetail = GetOrderDetail(o);

        pm pm1 = new pm();

        pm1.sendpm("41", odetail[3], "您拒绝了承运方" + odetail[102] + "修改订单运费" + odetail[109] + "的请求！", "1");
        pm1.sendpm("41", odetail[4], "委托方" + odetail[107] + "拒绝了您修改订单运费" + odetail[110] + "的请求！", "1");
    }

    public string SetOrderDetail(string a, string c1, string c2, string o,string r)
    {
        //a是行为的角色，1为货主，2为货代，0为系统
        //o是订单号
        //c1是操作之前的状态号
        //c2是操作之后的状态号码
        //数组中参数{x}将被具体角色替换，{1}将被货主公司名替换，
        //{2}将被货代公司名替换，{3}将被订单号替换，{4}将被操作时间替换，
        //{5}将被拒绝理由替换，{6}将被个人信息替换，{7}将被重新选择替换，
        //{8}货主信息费，{9}货代信息费
        //r是拒绝订舱的理由

        string returnValue = "null";

        check ck = new check();

        string reject = ck.CheckInput(r);
        string order_code = ck.CheckInput(o);

        string op_code = "";

        string[] op_array = new string[30];

        op_array[0] = "1|0|1|订舱方 {1} 保存订单";
        op_array[1] = "1|0|2|订舱方 {1} 提交订舱单，等待承运方答复";

        op_array[2] = "1|1|2|订舱方 {1} 提交订舱单，等待承运方答复";

        op_array[3] = "2|2|3|承运方 {2} 接受订舱";

        op_array[4] = "2|2|7|承运方 {2} 不接受订舱，理由是 {5} ，申请系统审核";
        op_array[5] = "2|7|2|承运方 {2} 取消不接受订舱";
        op_array[6] = "0|7|12|系统通过了承运方 {2} 的不接受订舱申请，该订单作废";
        op_array[7] = "0|7|2|系统未通过承运方 {2} 的不接受订舱申请，该订单恢复原状态";
        op_array[8] = "1|13|2|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[9] = "1|2|8|订舱方 {1} 撤消了该订舱单";
        op_array[10] = "1|8|2|订舱方 {1} 取消撤消该订舱单，重新等待承运方答复";
        op_array[11] = "0|8|13|系统通过了订舱方 {1} 的撤消订舱申请，该订单作废";
        op_array[12] = "0|8|2|系统未通过订舱方 {1} 的撤消订舱申请，该订单恢复原状态";
        op_array[13] = "1|13|2|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[14] = "1|3|4|订舱方 {1} 确认出运";

        op_array[15] = "1|3|9|订舱方 {1} 撤消了该订舱单";
        op_array[16] = "1|9|3|订舱方 {1} 取消撤消该订舱单，重新等待承运方答复";
        op_array[17] = "0|9|14|系统通过了订舱方 {1} 的撤消订舱申请，该订单作废";
        op_array[18] = "0|9|3|系统未通过订舱方 {1} 的撤消订舱申请，该订单恢复原状态";
        op_array[19] = "1|15|9|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[20] = "2|3|5|承运方 {2} 确认出运";

        op_array[21] = "1|5|6|订舱方 {1} 同意完成，交易结束";
        op_array[22] = "2|4|6|承运方 {2} 同意完成，交易结束";

        op_array[23] = "1|4|10|订舱方 {1} 撤消了该订舱单";
        op_array[24] = "1|10|4|订舱方 {1} 取消撤消该订舱单，重新等待承运方答复";
        op_array[25] = "0|10|14|系统通过了订舱方 {1} 的撤消订舱申请，该订单作废";
        op_array[26] = "0|10|4|系统未通过订舱方 {1} 的撤消订舱申请，该订单恢复原状态";
        op_array[27] = "1|15|10|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[28] = "1|1|11|订舱方 {1} 删除该订舱单";
        op_array[29] = "1|11|1|订舱方 {1} 恢复该订舱单";

        string detail_txt = "";

        for (int i = 0; i < op_array.Length; i++)
        {
            if (a == op_array[i].Split('|')[0].ToString() & c1 == op_array[i].Split('|')[1].ToString() & c2 == op_array[i].Split('|')[2].ToString())
            {
                detail_txt = op_array[i].Split('|')[3].ToString();
                op_code = i.ToString();
            }
        }//确认当前的状态数组

        
        string sql = "";

        string[] odetail;
        odetail = GetOrderDetail(order_code);

        //a是货主，b是货代

        //Response.Write(sql);

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        detail_txt = detail_txt.Replace("{1}", odetail[107]);
        detail_txt = detail_txt.Replace("{2}", odetail[102]);
        detail_txt = detail_txt.Replace("{5}", "<span style=\"color:red\">" + ck.CheckInput(reject) + "</span>");

        sql = "UPDATE TB_ORDER SET order_status = " + c2 + " WHERE order_code = '" + order_code + "'";
        cn.mdb_exe(sql);//改变订单状态

        //生成交易记录
        sql = "INSERT INTO TB_ORDER_DETAIL (order_code,detail_txt,detail_date) VALUES ('" + order_code + "','" + detail_txt + "',GetDate())";
        cn.mdb_exe(sql);

        double base_fee = 0;

        if (c2 == "3")
        {
            OrderAddCredit(odetail[4], (0 - Convert.ToDouble(odetail[62])).ToString(), "4", order_code, odetail[3], "0");//扣除货代的信息费
        }

        if (c2 == "6")
        {
            OrderAddCredit(odetail[3], Convert.ToDouble(odetail[61]).ToString(), "6", order_code, odetail[4], "0");//给货主加上信息费
            OrderAddCredit(odetail[4], Convert.ToDouble(odetail[63]).ToString(), "5", order_code, odetail[3], "0");//归还货代的信息费

            base_fee = Convert.ToDouble(odetail[60]);

            if (odetail[120] == "1")
            {
                AllinUser AllinUser1 = new AllinUser();
                string[] udetail;
                udetail = AllinUser1.GetUserDetail(odetail[4]);

                string ali_account = udetail[9];

                double baozhengjin = Convert.ToDouble(odetail[60]) * 4 / 10000; //测试用，把保证金缩小10000倍
                baozhengjin = Math.Round(baozhengjin, 2); //保留两位小数，精确到分，否则支付宝会出错

                string baozhengjin_total = baozhengjin.ToString();
                string baozhengjin_back = Math.Round(Convert.ToDouble(baozhengjin.ToString()) * 3 / 4, 2).ToString();

                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string out_order_no = "";
                out_order_no = order_code + "_AA";     //out_trade_no 外部商家订单号
                string out_trade_no = "";
                out_trade_no = order_code + "_BB";

                string gateway = "https://www.alipay.com/cooperate/gateway.do?";	//'支付接口
                string service = "unfreeze2fastpay";
                string partner = "2088201885472720";		//partner		合作伙伴ID			保留字段
                string sign_type = "MD5";
                string key = "o272s6dqq0s60tm44sy314jvnsfeihd0";              //partner账户的支付宝安全校验码
                string out_order_dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;    //外部系统订单生成时间
                string buyer_nick = ali_account;   //买家昵称
                string seller_nick = "fin@100allin.com";   //卖家昵称
                string order_from = "100002";   //(6)	订单的来源地(电子客票使用，淘宝=100001)	Y
                string old_out_order_no = order_code;   //(64)	外部系统的冻结资金时的订单号
                string goods_detail = "test";	 //(400)	购买商品详情(不同于商品名称)	Y
                string totle_fee = baozhengjin_total;	 //	交易总金额 (0.01-100000000.00元)	N
                string price = baozhengjin_total;	//	商品价格(0.01-100000000.00元)	N
                string other_fee = "0";	//	其他费用(0.00-100000000.00元)	N
                string op_type = "0006";   //(50)	见业务类型表	N
                string royalty_type = "10";   //(50)	见业务类型表	N
                string royalty_parameters = "" + ali_account + "^" + baozhengjin_back + "^返还订舱保证金";   //(50)	见业务类型表	N
                string _input_charset = "utf-8";

                //HttpContext.Current.Response.Redirect(baozhengjin_total + baozhengjin_back);

                string aliay_url = CreatUrl(
                    gateway,
                    service,
                    partner,
                    sign_type,
                    out_order_no,
                    out_trade_no,
                    seller_nick,
                    buyer_nick,
                    _input_charset,
                    out_order_dt,
                    op_type,
                    totle_fee,
                    price,
                    other_fee,
                    old_out_order_no,
                    order_from,
                    goods_detail,
                    royalty_type,
                    royalty_parameters,
                    key
                    );

                aliay_url = aliay_url.Replace("订舱保证金", "%e8%ae%a2%e8%88%b1%e4%bf%9d%e8%af%81%e9%87%91").Replace("返还订舱保证金", "%e8%bf%94%e8%bf%98%e8%ae%a2%e8%88%b1%e4%bf%9d%e8%af%81%e9%87%91");
                //HttpContext.Current.Response.Redirect(aliay_url);

                XmlTextReader textReader = null;
                try
                {
                    textReader = new XmlTextReader(aliay_url);
                    textReader.Read();
                    textReader.WhitespaceHandling = WhitespaceHandling.None;
                    returnValue = "AliBackSuccess";
                }
                catch
                {
                    returnValue = "AliBackFail";
                }
                finally
                {
                    if (textReader != null)
                    {
                        textReader.Close();
                    }
                }

            
            }
        }//订单成功后的处理

        if (c2 == "7")
        {
            sql = "UPDATE TB_ORDER SET reject_reason = '" + ck.CheckInput(reject) + "' WHERE order_code = '" + order_code + "'";
            cn.mdb_exe(sql);
        }

        string txt_jujueliyou = ""; //拒绝理由
        string txt_gerenxinxi = ""; //个人信息
        string txt_chongxinxuanze = ""; //重新选择

        txt_jujueliyou = "<span style=\"color:red\">" + ck.CheckInput(reject) + "</span>";

        //获得货代个人信息
        string sql_gerenxinxi = "SELECT * FROM TB_USER WHERE userid = " + odetail[4];
        DataSet ds_gerenxinxi = new DataSet();
        ds_gerenxinxi = cn.mdb_ds(sql_gerenxinxi, "bid");

        txt_gerenxinxi += "姓名：" + ds_gerenxinxi.Tables["bid"].Rows[0]["Realname"].ToString() + "<br/>";
        txt_gerenxinxi += "电话：" + ds_gerenxinxi.Tables["bid"].Rows[0]["phone"].ToString() + "<br/>";
        txt_gerenxinxi += "Email：" + ds_gerenxinxi.Tables["bid"].Rows[0]["useremail"].ToString() + "<br/>";
        //获得货代个人信息

        //获得重新选择
        //txt_chongxinxuanze += "<a href=\"/fcl/list-" + txtstartport.Value + "-" + txtdestport.Value + "-" + txtcarrier_name.Value + "-0-0-0-------1.html\" target=\"_blank\">重新选择</a>";
        //获得重新选择


        string order_type_string = odetail[58];

        string sql_pm = "";

        sql_pm = "SELECT * FROM TB_ORDER_OPERATION WHERE op_code = " + op_code;

        DataSet ds_pm = new DataSet();
        ds_pm = cn.mdb_ds(sql_pm, "pm");

        pm p1 = new pm();

        string op_sms_shipper = ds_pm.Tables["pm"].Rows[0]["op_sms_shipper"].ToString();
        op_sms_shipper = op_sms_shipper.Replace("{1}", odetail[107]);
        op_sms_shipper = op_sms_shipper.Replace("{2}", odetail[102]);
        op_sms_shipper = op_sms_shipper.Replace("{3}", "<a href= \"/search/" + order_type_string + "_order.aspx?filter=view&role=shipper&orderid=" + order_code + "\">" + order_code + "</a>");
        op_sms_shipper = op_sms_shipper.Replace("{4}", DateTime.Now.ToString());
        op_sms_shipper = op_sms_shipper.Replace("{5}", txt_jujueliyou);
        op_sms_shipper = op_sms_shipper.Replace("{6}", txt_gerenxinxi);
        op_sms_shipper = op_sms_shipper.Replace("{7}", txt_chongxinxuanze);
        op_sms_shipper = op_sms_shipper.Replace("{8}", (base_fee / 2).ToString());
        op_sms_shipper = op_sms_shipper.Replace("{9}", base_fee.ToString());

        string op_sms_forward = ds_pm.Tables["pm"].Rows[0]["op_sms_forward"].ToString();
        op_sms_forward = op_sms_forward.Replace("{1}", odetail[107]);
        op_sms_forward = op_sms_forward.Replace("{2}", odetail[102]);
        op_sms_forward = op_sms_forward.Replace("{3}", "<a href= \"/search/" + order_type_string + "_order.aspx?filter=view&role=forward&orderid=" + order_code + "\" target=\"_blank\">" + order_code + "</a>");
        op_sms_forward = op_sms_forward.Replace("{4}", DateTime.Now.ToString());
        op_sms_forward = op_sms_forward.Replace("{5}", txt_jujueliyou);
        op_sms_forward = op_sms_forward.Replace("{6}", txt_gerenxinxi);
        op_sms_forward = op_sms_forward.Replace("{7}", txt_chongxinxuanze);
        op_sms_forward = op_sms_forward.Replace("{8}", (base_fee / 2).ToString());
        op_sms_forward = op_sms_forward.Replace("{9}", base_fee.ToString());

        if (op_sms_shipper != "")
        {
            p1.sendpm("41", odetail[3], op_sms_shipper, "1");
        }

        if (op_sms_forward != "")
        {
            p1.sendpm("41", odetail[4], op_sms_forward, "1");
        }

        return returnValue;
    }//设置操作


    public void SetComplaints(string o,string c,string t)
    {

        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        o = ck.CheckInput(o);
        c = ck.CheckInput(c);
        t = ck.CheckNumber(t);//0是货主投诉货代，1是货代投诉货主

        string[] odetail;
        odetail = GetOrderDetail(o);
        string user_shipper = odetail[3];
        string user_forward = odetail[4];
        string user_shipper_name = odetail[3];
        string user_forward_name = odetail[4];


        string sql = "";
        if (t == "0")
        {
            sql = "INSERT INTO TB_ORDER_COMPLAINTS (order_code,userid,complaintsid,txt) VALUES ('" + o + "'," + user_forward + "," + user_shipper + ",'" + c + "')";
            ds = cn.mdb_ds(sql, "order");
            pm p = new pm();
            p.sendpm("41", odetail[4], "在订单" + odetail[110] + "交易过程中，" + odetail[107] + "对您进行投诉，内容如下：<br/>" + c, "1");
        }

        if (t == "1")
        {
            sql = "INSERT INTO TB_ORDER_COMPLAINTS (order_code,userid,complaintsid,txt) VALUES ('" + o + "'," + user_shipper + "," + user_forward + ",'" + c + "')";
            ds = cn.mdb_ds(sql, "order");
            pm p = new pm();
            p.sendpm("41", odetail[3], "在订单" + odetail[109] + "交易过程中，" + odetail[102] + "对您进行投诉，内容如下：<br/>" + c, "1");
        }
    
    }//增加一条投诉信息


    public void SetAliPayIf(string o,string s)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "";
        sql = "UPDATE TB_ORDER SET alipay_if = " + ck.CheckNumber(s) + " WHERE order_code = '" + ck.CheckInput(o) + "'";
        cn.mdb_exe(sql);
    }

    public void SetAliPayReturn(string o, string s)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "";
        sql = "UPDATE TB_ORDER SET alipay_pay_return = " + ck.CheckNumber(s) + " WHERE order_code = '" + ck.CheckInput(o) + "'";
        cn.mdb_exe(sql);
    }


    public string[] GetPreOrderDetail(string o)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        o = ck.CheckInput(o);

        string sql = "";
        sql = "SELECT * FROM TB_ORDER_ALIPREPAY WHERE TB_ORDER_ALIPREPAY.order_code = '" + o + "' ";
        ds = cn.mdb_ds(sql, "order");

        string[] k;
        k = new string[150];
        k[0] = ds.Tables["order"].Rows[0]["order_code"].ToString(); //订单编号
        k[1] = ds.Tables["order"].Rows[0]["date_create"].ToString(); //创建日期
        k[2] = ds.Tables["order"].Rows[0]["order_user"].ToString(); //用户编号
        k[3] = ds.Tables["order"].Rows[0]["alipay_if"].ToString(); //已经支付标记
        k[4] = ds.Tables["order"].Rows[0]["alipay_pay_return"].ToString(); //正常返回标记

        return k;
    }

    public string SetKey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }//获得密钥


    public static void Show(Page this0, string str)
    {
        StringBuilder sb = new StringBuilder("");
        sb.Append("alert('" + str + "');");
        ClientScriptManager cs = this0.ClientScript;
        if (!cs.IsStartupScriptRegistered(this0.GetType(), "Show"))
        {
            cs.RegisterStartupScript(this0.GetType(), "Show", sb.ToString(), true);
        }
    }

    public static string GetMD5(string s)
    {

        /// <summary>
        /// 与ASP兼容的MD5加密算法
        /// </summary>

        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding("utf-8").GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }

    public static string[] BubbleSort(string[] r)
    {
        /// <summary>
        /// 冒泡排序法
        /// </summary>

        int i, j; //交换标志 
        string temp;

        bool exchange;

        for (i = 0; i < r.Length; i++) //最多做R.Length-1趟排序 
        {
            exchange = false; //本趟排序开始前，交换标志应为假

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)　//交换条件
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true; //发生了交换，故将交换标志置为真 
                }
            }

            if (!exchange) //本趟排序未发生交换，提前终止算法 
            {
                break;
            }

        }
        return r;
    }

    public string CreatUrl(
        string gateway,
        string service,
        string partner,
        string sign_type,
        string out_order_no,
        string out_trade_no,
        string seller_nick,
        string buyer_nick,
        string _input_charset,
        string out_order_dt,
        string op_type,
        string totle_fee,
        string price,
        string other_fee,
        string old_out_order_no,
        string order_from,
        string goods_detail,
        string royalty_type,
        string royalty_parameters,
        string key
        )
    {
        /// <summary>

        /// </summary>
        int i;

        //构造数组；
        string[] Oristr ={ 
                "service="+service, 
                "partner=" + partner, 
                "out_order_no=" + out_order_no, 
                "out_trade_no=" + out_trade_no,
                "seller_nick=" + seller_nick,
                "buyer_nick=" + buyer_nick,
                "_input_charset=" + _input_charset,
                "out_order_dt=" + out_order_dt,
             
                "op_type=" + op_type,
                "totle_fee=" + totle_fee,                
                "price=" + price,
               
                "other_fee=" + other_fee,
				"old_out_order_no=" + old_out_order_no,
                "order_from=" + order_from, 
                "goods_detail=" + goods_detail,
                "royalty_type=" + royalty_type,
                "royalty_parameters=" + royalty_parameters
                
            };


        //进行排序；
        string[] Sortedstr = BubbleSort(Oristr);


        //构造待md5摘要字符串 ；

        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (i == Sortedstr.Length - 1)
            {
                prestr.Append(Sortedstr[i]);

            }
            else
            {

                prestr.Append(Sortedstr[i] + "&");
            }

        }

        prestr.Append(key);

        //生成Md5摘要；
        string sign = GetMD5(prestr.ToString());

        //构造支付Url；
        StringBuilder parameter = new StringBuilder();
        parameter.Append(gateway);
        for (i = 0; i < Sortedstr.Length; i++)
        {
            parameter.Append(Sortedstr[i] + "&");
        }

        parameter.Append("sign=" + sign + "&sign_type=" + sign_type);


        //返回支付Url；
        return parameter.ToString();

    }
}
