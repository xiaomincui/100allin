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

public partial class member_order_alitemp : System.Web.UI.Page
{
    public AllinOrder AllinOrder1 = new AllinOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string sql = "";
        string account = ck.CheckInput(GetRequestQueryString("account", ""));
        string orderid = ck.CheckInput(GetRequestQueryString("orderid", ""));
        string plus = ck.CheckInput(GetRequestQueryString("plus", "0"));
        string u = ck.CheckInput(GetRequestCookies("user_id", "0"));
        double baozhengjin = 0;
        string out_order_no;


        if (plus == "0")
        {

            sql = "";
            sql += "SELECT * FROM TB_ORDER WHERE order_code = '" + orderid + "'";
            ds = cn.mdb_ds(sql, "order");

            string[] odetail;
            odetail = AllinOrder1.GetOrderDetail(orderid);

            string order_type_string = odetail[58];
            double base_fee = Convert.ToDouble(odetail[60]);

            out_order_no = orderid;  //商品编号就是订单号

            baozhengjin = base_fee * 4; //保证金+订舱费是订舱费4倍

            AllinOrder1.SetAliPayIf(orderid, "1");
        }
        else
        {
            Random rd = new Random();
            baozhengjin = Convert.ToDouble(plus);
            out_order_no = "PRE" + DateTime.Now.ToString("yyMMddHHmm") + GetFourDigits(Convert.ToInt32(10000 * rd.NextDouble()).ToString());
        }

        baozhengjin = baozhengjin; //测试用，把保证金缩小10000倍
        baozhengjin = Math.Round(baozhengjin, 2); //保留两位小数，精确到分，否则支付宝会出错
                
        string userid = u;//获得货代的userid

        sql = "";
        sql += "UPDATE TB_USER SET ali_account = '" + account + "' WHERE userid = " + userid;
        cn.mdb_exe(sql);

        string ali_account = account;//获得货代的支付宝帐号
                
        //业务参数赋值；
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";	//'支付接口
        string service = "bank2freeze";
        string partner = "2088201885472720";		//partner		合作伙伴ID			保留字段
        string sign_type = "MD5";
        string _input_charset = "utf-8";
        string subject = out_order_no;	//subject		商品名称
        string seller_email = "fin@100allin.com";             //卖家账号
        string buyer_email = ali_account;             //买家账号
        string key = "o272s6dqq0s60tm44sy314jvnsfeihd0";              //partner账户的支付宝安全校验码
        string return_url = "http://www.100allin.com/test/Alipay_Return.aspx"; //服务器通知返回接口
        string notify_url = "http://www.100allin.com/test/Alipay_Notify.aspx"; //服务器通知返回接口
        string out_order_dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string order_from = "100002";
        string goods_url = "http://www.100allin.com/member/order/order_view.aspx?orderid=" + orderid;
        string memo = "点击查看订单" + out_order_no;
        string amount = baozhengjin.ToString();
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
}
