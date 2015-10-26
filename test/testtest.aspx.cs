using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Net;

public partial class test_testtest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //SetPay("0.01", "PRE10022211226701", "paradini2046@yahoo.cn");
        //Response.Write(Server.UrlEncode("预存费用"));

        string base_fee = "4000";

        order o = new order();
        o.OrderAddCredit(base_fee, "9", "FCL10022216305647", "0", "1");//预存保证金
        o.OrderAddCredit((0 - Convert.ToDouble(base_fee)).ToString(), "4", "FCL10022216305647", "8299", "0");//预存保证金
    }

    public void SetPay(string baozhengjin, string orderid,string ali_account)
    {


        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string out_order_no = currentTime.ToString("g");
        out_order_no = out_order_no.Replace("-", "");
        out_order_no = out_order_no.Replace(":", "");
        out_order_no = out_order_no.Replace(" ", "") + "AA";     //out_trade_no 外部商家订单号
        string out_trade_no = currentTime.ToString("g");
        out_trade_no = out_trade_no.Replace("-", "");
        out_trade_no = out_trade_no.Replace(":", "");
        out_trade_no = out_trade_no.Replace(" ", "") + "BB";

        //业务参数赋值；
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";	//'支付接口
        string service = "unfreeze2fastpay";
        string partner = "2088002037527206";		//partner		合作伙伴ID			保留字段
        string sign_type = "MD5";
        string key = "hcxocn904wlsbz17rb86lqel4s6exmbt";              //partner账户的支付宝安全校验码
        string out_order_dt = "2008-01-17 21:46:00";    //外部系统订单生成时间
        string buyer_nick = ali_account;   //买家昵称
        string seller_nick = "fin@100allin.com";   //卖家昵称
        string order_from = "100002";   //(6)	订单的来源地(电子客票使用，淘宝=100001)	Y
        string old_out_order_no = orderid;   //(64)	外部系统的冻结资金时的订单号
        string goods_detail = "test";	 //(400)	购买商品详情(不同于商品名称)	Y
        string totle_fee = baozhengjin.ToString();	 //	交易总金额 (0.01-100000000.00元)	N
        string price = baozhengjin.ToString();	//	商品价格(0.01-100000000.00元)	N
        string other_fee = "0";	//	其他费用(0.00-100000000.00元)	N
        string op_type = "0006";   //(50)	见业务类型表	N
        string royalty_type = "10";   //(50)	见业务类型表	N
        string royalty_parameters = "" + ali_account + "^" + (Convert.ToDouble(baozhengjin) * 1.00).ToString() + "^PRE";   //(50)	见业务类型表	N
        string _input_charset = "utf-8";

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
        //     sign_type        =   "MD5"	'	见签名方式N

        aliay_url = aliay_url.Replace("订舱保证金", "%e8%ae%a2%e8%88%b1%e4%bf%9d%e8%af%81%e9%87%91").Replace("返还订舱保证金", "%e8%bf%94%e8%bf%98%e8%ae%a2%e8%88%b1%e4%bf%9d%e8%af%81%e9%87%91");

        ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "window.open('" + aliay_url + "' ,'_blank','');", true);

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
