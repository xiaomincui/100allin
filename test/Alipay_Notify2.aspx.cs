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
using System.Xml;



public partial class test_Alipay_Notify2 : System.Web.UI.Page
{
    public AllinOrder AllinOrder1 = new AllinOrder();
    /// <summary>
    /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com。
    /// </summary>

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

    //获取远程服务器ATN结果
    public String Get_Http(String a_strUrl, int timeout)
    {
        string strResult;
        try
        {

            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(a_strUrl);
            myReq.Timeout = timeout;
            HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
            Stream myStream = HttpWResp.GetResponseStream();
            StreamReader sr = new StreamReader(myStream, Encoding.Default);
            StringBuilder strBuilder = new StringBuilder();
            while (-1 != sr.Peek())
            {
                strBuilder.Append(sr.ReadLine());
            }

            strResult = strBuilder.ToString();
        }
        catch (Exception exp)
        {

            strResult = "错误：" + exp.Message;
        }

        return strResult;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        writeLog("程序开始", DateTime.Now.ToString());

        //*****************************************************************************************
        ///当不知道https的时候，请使用http
        //string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?";
        string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";

        string partner = "2088201885472720"; 		//*********partner合作伙伴id（必须填写）
        string key = "o272s6dqq0s60tm44sy314jvnsfeihd0"; //************partner 的对应交易安全校验码（必须填写）

        alipayNotifyURL = alipayNotifyURL + "service=notify_verify" + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];
        // alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];

        //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = Get_Http(alipayNotifyURL, 120000);


        //****************************************************************************************
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;

        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;



        //进行排序；
        string[] Sortedstr = BubbleSort(requestarr);

        //for (i = 0; i < Sortedstr.Length; i++)
        //{
        //  Response.Write("Form: " + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "<br>");
        //}

        //构造待md5摘要字符串 ；
        string prestr = "";
        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr = prestr + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]];
                }
                else
                {
                    prestr = prestr + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "&";
                }
            }
        }
        prestr = prestr + key;

        string mysign = GetMD5(prestr);


        string sign = Request.Form["sign"];

        string dingdan = Request.Form["outOrderNo"];   //获取传递过来的订单号
        string status = Request.Form["status"];   //获取交易状态
        string amount = Request.Form["amount"];
        string ali_account = Request.Form["buyerEmail"];

        writeLog("prestr=" + prestr + ",request_sign=" + Request.Form["sign"] + ",mysign=" + mysign + ",sign=" + sign + ",dingdan=" + dingdan + ",status=" + status + ",responseTxt=" + responseTxt, DateTime.Now.ToString());

        if (mysign == sign && responseTxt == "true" && status == "S")   //验证支付发过来的消息，签名是否正确
        {
            writeLog("正确", DateTime.Now.ToString());


            //更新自己数据库的订单语句，请自己填写一下
            check ck = new check();
            string orderid = ck.CheckInput(dingdan); //获得订单号

            string[] odetail;
            odetail = AllinOrder1.GetPreOrderDetail(orderid);

            string alipay_if = odetail[3]; //获得成功支付的标志
            string uid = odetail[2];

            if (alipay_if == "0")//成功支付标志为0，表示return.aspx未起作用，执行后续步骤
            {

                data_conn cn = new data_conn();
                string sql = "UPDATE TB_ORDER_ALIPREPAY SET alipay_if = 1 WHERE order_code = '" + orderid + "'"; //更新存根状态
                cn.mdb_exe(sql);

                sql = "";


                writeLog(amount, DateTime.Now.ToString());
                writeLog(dingdan, DateTime.Now.ToString());
                writeLog(Request.Url.ToString(), DateTime.Now.ToString());
                try
                {
                    SetPay(amount, dingdan, ali_account, uid);//解冻预存金，写入网站记录
                }
                catch(Exception ex)
                {
                    writeLog(ex.Message.ToString(), DateTime.Now.ToString());
                }

                writeLog("写入数据库", DateTime.Now.ToString());
            }
            Response.Write("success");     //返回给支付宝消息，成功
        }
        else
        {
            writeLog("错误", DateTime.Now.ToString());

            Response.Write("fail");
        }

        writeLog("程序结束", DateTime.Now.ToString());

    }


    public void writeLog(string txt, string time)
    {

        string filename = Server.MapPath("log_notify2.txt");
        StreamWriter sw = File.AppendText(filename);

        if (File.Exists(filename))
        {
            sw.WriteLine(time + " " + txt);
            sw.Close();
        }
        else
        {
            StreamWriter sr = File.CreateText(filename);
            sw.WriteLine(time + " " + txt);
            sr.Close();
            sw.Close();
        }
    }

    public void SetPay(string baozhengjin, string orderid, string ali_account,string uid)
    {

        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string out_order_no = "";
        out_order_no = orderid + "_AA";     //out_trade_no 外部商家订单号
        string out_trade_no = "";
        out_trade_no = orderid + "_BB";

        //业务参数赋值；
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";	//'支付接口
        string service = "unfreeze2fastpay";
        string partner = "2088201885472720";		//partner		合作伙伴ID			保留字段
        string sign_type = "MD5";
        string key = "o272s6dqq0s60tm44sy314jvnsfeihd0";              //partner账户的支付宝安全校验码
        string out_order_dt = "2008-01-17 21:46:00";    //外部系统订单生成时间
        string buyer_nick = ali_account;   //买家昵称
        string seller_nick = "fin@100allin.com";   //卖家昵称
        string order_from = "100002";   //(6)	订单的来源地(电子客票使用，淘宝=100001)	Y
        string old_out_order_no = orderid;   //(64)	外部系统的冻结资金时的订单号
        string goods_detail = "PREPAY";	 //(400)	购买商品详情(不同于商品名称)	Y
        string totle_fee = baozhengjin;	 //	交易总金额 (0.01-100000000.00元)	N
        string price = baozhengjin;	//	商品价格(0.01-100000000.00元)	N
        string other_fee = "0";	//	其他费用(0.00-100000000.00元)	N
        string op_type = "0006";   //(50)	见业务类型表	N
        //string royalty_type = "10";   //(50)	见业务类型表	N
        //string royalty_parameters = "fin@100allin.com^" + (Convert.ToDouble(baozhengjin) * 1.00).ToString() + "^预存费用";   //(50)	见业务类型表	N
        string _input_charset = "utf-8";

        string aliay_url = CreatUrl2(
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
            key
            );
        //     sign_type        =   "MD5"	'	见签名方式N


        //aliay_url = aliay_url.Replace("订舱保证金", "%e8%ae%a2%e8%88%b1%e4%bf%9d%e8%af%81%e9%87%91").Replace("返还订舱保证金", "%e8%bf%94%e8%bf%98%e8%ae%a2%e8%88%b1%e4%bf%9d%e8%af%81%e9%87%91");
        aliay_url = aliay_url.Replace("预存费用", "%e9%a2%84%e5%ad%98%e8%b4%b9%e7%94%a8");


        XmlTextReader textReader = null;
        try
        {
            writeLog("预存保证金", DateTime.Now.ToString());
            textReader = new XmlTextReader(aliay_url);
            textReader.Read();
            textReader.WhitespaceHandling = WhitespaceHandling.None;

            baozhengjin = baozhengjin.ToString(); //实际订舱费比支付宝放大10w倍，正式版去掉

            AllinOrder1.OrderAddCredit(uid, baozhengjin, "1", orderid, "0", "1");//预存保证金


            data_conn cn = new data_conn();
            string sql = "UPDATE TB_ORDER_ALIPREPAY SET alipay_pay_return = 1 WHERE order_code = '" + orderid + "'"; //预付存根

            cn.mdb_exe(sql);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert(\"支付宝到账成功！\");", true);

            //Response.Write("成功");

            //while (textReader.Read())
            //{
            //    Response.Write("<br>Type=" + textReader.NodeType + "<br>Name=" + textReader.Name + "<br>Value=" + textReader.Value + "<br>LocalName=" + textReader.LocalName + "<br>XmlLang=" + textReader.XmlLang);
            //    自己定义输出格式
            //}

        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "提示", "alert(\"支付宝到账失败！\");", true);
            writeLog(ex.Message.ToString(), DateTime.Now.ToString());
        }
        finally
        {
            if (textReader != null)
            {
                textReader.Close();
            }
        }

        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "提示", "window.open('" + aliay_url + "' ,'_blank','');", true);
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

    public static string GetMD52(string s)
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

    public static string[] BubbleSort2(string[] r)
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

    public string CreatUrl2(
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
            };


        //进行排序；
        string[] Sortedstr = BubbleSort2(Oristr);


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
        string sign = GetMD52(prestr.ToString());

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
