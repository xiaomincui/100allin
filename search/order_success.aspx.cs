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

public partial class search_order_success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";

        ltrLoginName.Text = Server.UrlDecode(GetRequestCookies("realname", ""));

        string order_type = "";
        string order_type_url = "fcl_order.aspx";
        order_type = GetRequestQueryString("orderid", "").Substring(0,3);

        switch (order_type)
        {
            case "FCL":
                order_type_url = "fcl_order.aspx";
                break;
            case "LCL":
                order_type_url = "lcl_order.aspx";
                break;
            case "AIR":
                order_type_url = "air_order.aspx";
                break;
            default:
                order_type_url = "fcl_order.aspx";
                break;
        }//判断订单是整箱 拼箱 还是空运


        if (GetRequestQueryString("type", "0") == "1")
        {
            Literal1.Text = "成功保存订舱信息！";
            Literal2.Text = "保存订舱";
            Literal3.Text = "<a href=\"/search/" + order_type_url + "?filter=view&orderid=" + GetRequestQueryString("orderid", "") + "\">查看本条订舱单</a>";
            Literal4.Text = "· 查看 <a href=\"/member/order/list.aspx?f1=0&f2=6\">我保存的订舱单</a> <br/> · <a href=\"/member/order/bill.aspx\">我的账户余额</a> <br/> · <a href=\"/fcl/\">继续查看运价</a>";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "2")
        {
            Literal1.Text = "已经成功提交订舱信息，请耐心等待运价发布方进行订舱确认！";
            Literal2.Text = "提交订舱";
            Literal3.Text = "<a href=\"/search/" + order_type_url + "?filter=view&role=shipper&orderid=" + GetRequestQueryString("orderid", "") + "\">查看本条订舱单</a>";
            Literal4.Text = "· 查看 <a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <br/> · <a href=\"/member/order/bill.aspx\">我的账户余额</a> <br/> · <a href=\"/fcl/\">继续查看运价</a>";
            Literal5.Text = "我们已经通知运价发布方";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "edit")
        {
            Literal1.Text = "成功修改订舱信息！";
            Literal2.Text = "修改订舱";
            Literal3.Text = "<a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <a href=\"/fcl/\">继续查看运价</a>";
            Literal4.Text = "";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "finishs1")
        {
            Literal1.Text = "您已选择完成出运，正等待对方商户同意完成！";
            Literal2.Text = "完成出运";
            Literal3.Text = "<a href=\"/member/order/list.aspx?f1=1&f2=0\">我接受的订舱单</a> <a href=\"/fcl/\">继续查看运价</a>";
            Literal4.Text = "";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "finishf1")
        {
            Literal1.Text = "您已选择完成出运，正等待对方商户同意完成！";
            Literal2.Text = "完成出运";
            Literal3.Text = "<a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <a href=\"/fcl/\">继续查看运价</a>";
            Literal4.Text = "";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "finishs2")
        {
            Literal1.Text = "感谢您的支持，订单交易成功！";
            Literal2.Text = "交易成功";
            Literal3.Text = "<a href=\"/search/" + order_type_url + "?filter=view&role=shipper&orderid=" + GetRequestQueryString("orderid", "") + "\">查看本条订舱单</a>";
            Literal4.Text = "· 查看 <a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <br/> · <a href=\"/member/order/bill.aspx\">我的账户余额</a> <br/> · <a href=\"/fcl/\">继续查看运价</a>";
            Literal5.Text = "我们已经通知承运方";
            

            sql = "SELECT * FROM TB_ORDER WHERE order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";

            ds = cn.mdb_ds(sql, "TB_ORDER");

            string ping_shipper = ds.Tables["TB_ORDER"].Rows[0]["ping_shipper"].ToString();

            if (ping_shipper != "1")
            {
                PlaceHolder1.Visible = true;
            }
            else
            { 
            
            }

        }

        if (GetRequestQueryString("type", "0") == "finishf2")
        {
            Literal1.Text = "感谢您的支持，订单交易成功！";
            Literal2.Text = "交易成功";
            Literal3.Text = "<a href=\"/search/" + order_type_url + "?filter=view&role=forward&orderid=" + GetRequestQueryString("orderid", "") + "\">查看本条订舱单</a>";
            Literal4.Text = "· 查看 <a href=\"/member/order/list.aspx?f1=1&f2=0\">我接受的订舱单</a> <br/> · <a href=\"/member/order/bill.aspx\">我的账户余额</a> <br/> · <a href=\"/fcl/\">继续查看运价</a>";
            Literal5.Text = "我们已经通知订舱方";


            sql = "SELECT * FROM TB_ORDER WHERE order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";

            ds = cn.mdb_ds(sql, "TB_ORDER");

            string ping_forward = ds.Tables["TB_ORDER"].Rows[0]["ping_forward"].ToString();

            if (ping_forward != "1")
            {
                PlaceHolder2.Visible = true;
            }
            else
            {

            }
        }

        if (GetRequestQueryString("type", "0") == "accept")
        {
            Literal1.Text = "您已接受对方订舱！";
            Literal2.Text = "接受订舱";
            Literal3.Text = "<a href=\"/search/" + order_type_url + "?filter=view&role=forward&orderid=" + GetRequestQueryString("orderid", "") + "\">查看本条订舱单</a>";
            Literal4.Text = "· 查看 <a href=\"/member/order/list.aspx?f1=1&f2=2\">我接受的订舱单</a> <br/> · <a href=\"/member/order/bill.aspx\">我的账户余额</a> <br/> · <a href=\"/fcl/\">继续查看运价</a>";
            Literal5.Text = "我们已经通知订舱方";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "reject")
        {
            Literal1.Text = "您已拒绝对方订舱！";
            Literal2.Text = "接受订舱";
            Literal3.Text = "";
            Literal4.Text = "";
            Literal5.Text = "等待系统审核";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "evaluation")
        {
            Literal1.Text = "您已成功评价对方商户！";
            Literal2.Text = "评价成功";
            //Literal3.Text = "<a href=\"/search/" + order_type_url + "?filter=view&orderid=" + GetRequestQueryString("orderid", "") + "\">查看本条订舱单</a>";
            Literal4.Text = "· 查看 <a href=\"/member/\">我的办公室</a> <br/> · <a href=\"/member/order/bill.aspx\">我的账户余额</a> <br/> · <a href=\"/fcl/\">继续查看运价</a>";
            Literal5.Text = "评价成功";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "cancel")
        {
            Literal1.Text = "已经申请撤销该订单，请等待系统审核！";
            Literal2.Text = "撤销订舱";
            Literal3.Text = "<a href=\"/search/" + order_type_url + "?filter=view&orderid=" + GetRequestQueryString("orderid", "") + "\">查看本条订舱单</a>";
            Literal4.Text = "· 查看 <a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <br/> · <a href=\"/member/order/bill.aspx\">我的账户余额</a> <br/> · <a href=\"/fcl/\">继续查看运价</a>";
            Literal5.Text = "系统将尽快为您审核该条申请";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "complaints")
        {
            Literal1.Text = "您对该商户的投诉成功，请等待系统处理！";
            Literal2.Text = "投诉商户";
            Literal3.Text = "<a href=\"/search/" + order_type_url + "?filter=view&orderid=" + GetRequestQueryString("orderid", "") + "\">查看本条订舱单</a>";
            Literal4.Text = "· 查看 <a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <br/> · <a href=\"/member/order/bill.aspx\">我的账户余额</a> <br/> · <a href=\"/fcl/\">继续查看运价</a>";
            Literal5.Text = "系统将尽快为您处理该条投诉";
            Literal6.Text = "· 此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br />· 请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。";
        }

        if (GetRequestQueryString("type", "0") == "editprice")
        {
            Literal1.Text = "成功提交修改运费信息，请等待委托方确认！";
            Literal2.Text = "修改运费";
            Literal3.Text = "<a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <a href=\"/fcl/\">继续查看运价</a>";
            Literal4.Text = "";
            Literal6.Text = "· 已发送站内留言至委托方处，提醒其确认您已经修改的运价；<br />· 当委托方确认您修改的运价后，修改运价操作成功。";
        }

        if (GetRequestQueryString("type", "0") == "editpriceok")
        {
            Literal1.Text = "您同意了承运方修改订单运费请求！";
            Literal2.Text = "修改运费";
            Literal3.Text = "<a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <a href=\"/fcl/\">继续查看运价</a>";
            Literal4.Text = "";
            Literal6.Text = "· 已发送站内留言至委托方处，提醒其运费修改已成功。";
        }

        if (GetRequestQueryString("type", "0") == "editpricecancel")
        {
            Literal1.Text = "您拒绝了承运方修改订单运费请求！";
            Literal2.Text = "修改运费";
            Literal3.Text = "<a href=\"/member/order/list.aspx?f1=0&f2=0\">我发出的订舱单</a> <a href=\"/fcl/\">继续查看运价</a>";
            Literal4.Text = "";
            Literal6.Text = "· 已发送站内留言至委托方处，提醒其运费修改失败。";
        }
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
                data_conn cd1 = new data_conn();
            }
        }
        return outputstring;
    }//获得指定Cookies参数

    protected void Button1_Click(object sender, EventArgs e)
    {
        AllinOrder AllinOrder1 = new AllinOrder(); 
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = "SELECT * FROM TB_ORDER WHERE order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";

        ds = cn.mdb_ds(sql,"TB_ORDER");

        string userid = ds.Tables["TB_ORDER"].Rows[0]["order_forward"].ToString();

        string ping = "";

        if (RadioButtonList1.SelectedValue == "1")
        {
            ping = "haoping";
        }

        if (RadioButtonList1.SelectedValue == "0")
        {
            ping = "zhongping";
        }

        if (RadioButtonList1.SelectedValue == "-1")
        {
            ping = "chaping";
        }

        sql = "UPDATE TB_ORDER_ACCOUNT SET POINT = POINT + " + RadioButtonList1.SelectedValue + "," + ping + " = " + ping + " + 1 WHERE userid = " + userid;
        cn.mdb_exe(sql);

        sql = "UPDATE TB_ORDER SET yiping_forward = 1,ping_forward = ping_forward + " + RadioButtonList1.SelectedValue + ",evaluation_forward = '" + TextBox1.Text + "' WHERE order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";
        cn.mdb_exe(sql);

        AllinOrder1.SetUserStar(userid);

        Response.Redirect("order_success.aspx?type=evaluation&orderid=" + GetRequestQueryString("orderid", "0"));
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        AllinOrder AllinOrder1 = new AllinOrder();
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = "SELECT * FROM TB_ORDER WHERE order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";

        ds = cn.mdb_ds(sql, "TB_ORDER");

        string userid = ds.Tables["TB_ORDER"].Rows[0]["order_shipper"].ToString();

        string ping = "";

        if (RadioButtonList2.SelectedValue == "1")
        {
            ping = "haoping";
        }

        if (RadioButtonList2.SelectedValue == "0")
        {
            ping = "zhongping";
        }

        if (RadioButtonList2.SelectedValue == "-1")
        {
            ping = "chaping";
        }

        sql = "UPDATE TB_ORDER_ACCOUNT SET POINT = POINT + " + RadioButtonList2.SelectedValue + "," + ping + " = " + ping + " + 1 WHERE userid = " + userid;
        cn.mdb_exe(sql);

        sql = "UPDATE TB_ORDER SET yiping_forward = 1,ping_forward = ping_forward + " + RadioButtonList2.SelectedValue + ",evaluation_forward = '" + TextBox2.Text + "' WHERE order_code = '" + ck.CheckInput(GetRequestQueryString("orderid", "0")) + "'";
        cn.mdb_exe(sql);

        AllinOrder1.SetUserStar(userid);

        Response.Redirect("order_success.aspx?type=evaluation&orderid=" + GetRequestQueryString("orderid", "0"));
    }
}
