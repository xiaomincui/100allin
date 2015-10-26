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


public partial class Alipay_Notify : System.Web.UI.Page
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

        writeLog("prestr=" + prestr + ",request_sign=" + Request.Form["sign"] + ",mysign=" + mysign + ",sign=" + sign + ",dingdan=" + dingdan + ",status=" + status + ",responseTxt=" + responseTxt, DateTime.Now.ToString());

        if (mysign == sign && responseTxt == "true" && status == "S")   //验证支付发过来的消息，签名是否正确
        {
            writeLog("正确", DateTime.Now.ToString());
            


            //更新自己数据库的订单语句，请自己填写一下
            check ck = new check();
            string orderid = ck.CheckInput(dingdan); //获得订单号

            string[] odetail;
            odetail = AllinOrder1.GetOrderDetail(orderid);

            string alipay_pay_return = odetail[120];

            if (alipay_pay_return == "0")
            {
                string userid = odetail[4]; //获得货代编号
                string otherid = odetail[3]; //获得货主编号

                string order_type_string = odetail[58];
                double base_fee = Convert.ToDouble(odetail[62]);

                order o = new order();

                AllinOrder1.OrderAddCredit(userid,base_fee.ToString(), "9", orderid, "0", "1");
                //o.OrderAddCredit(base_fee.ToString(), "9", orderid, "0", "1");//预存保证金
                AllinOrder1.SetOrderDetail("2", "2", "3", orderid, ""); //设置状态，传递短消息

                AllinOrder1.SetAliPayReturn(orderid, "1");
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

    public void writeLog(string txt,string time)
    {
        
        string filename = Server.MapPath("log_notify.txt");
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
    }


//根据支付宝传递过来的订单号修改网站订单状态,更新完数据后,需要反馈一个 "success" 给支付宝,如果反馈的不是这个或者还含有
//其它的的支付宝就会继续发送.