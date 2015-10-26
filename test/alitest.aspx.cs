using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class test_alitest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string out_order_no = currentTime.ToString("g");
        out_order_no = out_order_no.Replace("-", "");
        out_order_no = out_order_no.Replace(":", "");
        out_order_no = out_order_no.Replace(" ", "");     //out_trade_no 外部商家订单号
        Label1.Text = out_order_no;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string out_order_no;
        out_order_no = Label1.Text;
        
        //业务参数赋值；
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";	//'支付接口
        string service = "bank2freeze";
        string partner = "2088002037527206";		//partner		合作伙伴ID			保留字段
        string sign_type = "MD5";
        string _input_charset = "utf-8";
        string subject = "dingcangfei";	//subject		商品名称
        string seller_email = "paradini@msn.com";             //卖家账号
        string buyer_email = "paradini2046@yahoo.cn";             //买家账号
        string key = "hcxocn904wlsbz17rb86lqel4s6exmbt";              //partner账户的支付宝安全校验码
        string return_url = "http://www.100allin.com:8083/test/Alipay_Return.aspx"; //服务器通知返回接口
        string notify_url = "http://www.100allin.com:8083/test/Alipay_Notify.aspx"; //服务器通知返回接口
        string out_order_dt = "2007-11-05 09:00:00";
        string order_from = "100002";
        string goods_url = "http://localhost/fcl/";
        string memo = "1,2,3";
        string amount = "0.01";
        string op_type = "0006";

        AliPay ap = new AliPay();
        string aliay_url = ap.CreatUrl(
            gateway,
            service,
            partner,
            sign_type,
            _input_charset,
            out_order_no,
            subject,
            seller_email,
            buyer_email,
            out_order_dt,
            order_from,
            goods_url,
            memo,
            amount,
            op_type,
            key,
            return_url,
            notify_url
            );

        //   Response.Write(aliay_url);
        Response.Redirect(aliay_url);
    }
}
