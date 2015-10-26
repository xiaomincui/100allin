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
    /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com��
    /// </summary>

    public static string GetMD5(string s)
    {

        /// <summary>
        /// ��ASP���ݵ�MD5�����㷨
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
        /// ð������
        /// </summary>

        int i, j; //������־ 
        string temp;

        bool exchange;

        for (i = 0; i < r.Length; i++) //�����R.Length-1������ 
        {
            exchange = false; //��������ʼǰ��������־ӦΪ��

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)��//��������
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true; //�����˽������ʽ�������־��Ϊ�� 
                }
            }

            if (!exchange) //��������δ������������ǰ��ֹ�㷨 
            {
                break;
            }

        }
        return r;
    }
    //��ȡԶ�̷�����ATN���
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

            strResult = "����" + exp.Message;
        }

        return strResult;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        writeLog("����ʼ", DateTime.Now.ToString());

        //*****************************************************************************************
        ///����֪��https��ʱ����ʹ��http
        //string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?";
        string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";

        string partner = "2088201885472720"; 		//*********partner�������id��������д��
        string key = "o272s6dqq0s60tm44sy314jvnsfeihd0"; //************partner �Ķ�Ӧ���װ�ȫУ���루������д��

        alipayNotifyURL = alipayNotifyURL + "service=notify_verify" + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];
        // alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];

        //��ȡ֧����ATN���ؽ����true����ȷ�Ķ�����Ϣ��false ����Ч��
        string responseTxt = Get_Http(alipayNotifyURL, 120000);


        //****************************************************************************************
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;

        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;



        //��������
        string[] Sortedstr = BubbleSort(requestarr);

        //for (i = 0; i < Sortedstr.Length; i++)
        //{
        //  Response.Write("Form: " + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "<br>");
        //}

        //�����md5ժҪ�ַ��� ��
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

        string dingdan = Request.Form["outOrderNo"];   //��ȡ���ݹ����Ķ�����
        string status = Request.Form["status"];   //��ȡ����״̬

        writeLog("prestr=" + prestr + ",request_sign=" + Request.Form["sign"] + ",mysign=" + mysign + ",sign=" + sign + ",dingdan=" + dingdan + ",status=" + status + ",responseTxt=" + responseTxt, DateTime.Now.ToString());

        if (mysign == sign && responseTxt == "true" && status == "S")   //��֤֧������������Ϣ��ǩ���Ƿ���ȷ
        {
            writeLog("��ȷ", DateTime.Now.ToString());
            


            //�����Լ����ݿ�Ķ�����䣬���Լ���дһ��
            check ck = new check();
            string orderid = ck.CheckInput(dingdan); //��ö�����

            string[] odetail;
            odetail = AllinOrder1.GetOrderDetail(orderid);

            string alipay_pay_return = odetail[120];

            if (alipay_pay_return == "0")
            {
                string userid = odetail[4]; //��û������
                string otherid = odetail[3]; //��û������

                string order_type_string = odetail[58];
                double base_fee = Convert.ToDouble(odetail[62]);

                order o = new order();

                AllinOrder1.OrderAddCredit(userid,base_fee.ToString(), "9", orderid, "0", "1");
                //o.OrderAddCredit(base_fee.ToString(), "9", orderid, "0", "1");//Ԥ�汣֤��
                AllinOrder1.SetOrderDetail("2", "2", "3", orderid, ""); //����״̬�����ݶ���Ϣ

                AllinOrder1.SetAliPayReturn(orderid, "1");
                writeLog("д�����ݿ�", DateTime.Now.ToString());
            }
            Response.Write("success");     //���ظ�֧������Ϣ���ɹ�
        }
        else
        {
            writeLog("����", DateTime.Now.ToString());

            Response.Write("fail");
        }

        writeLog("�������", DateTime.Now.ToString());

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


//����֧�������ݹ����Ķ������޸���վ����״̬,���������ݺ�,��Ҫ����һ�� "success" ��֧����,��������Ĳ���������߻�����
//�����ĵ�֧�����ͻ��������.