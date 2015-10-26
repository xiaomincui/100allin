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
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.Xml;

public partial class member_order_list : System.Web.UI.Page
{
    public string pagecontrol_string;
    public string pagecontrol_prev;
    public string pagecontrol_next;

    public AllinOrder AllinOrder1 = new AllinOrder();
    public AllinFreight AllinFreight1 = new AllinFreight();
    public GetRequest GetRequest1 = new GetRequest();
    public check check1 = new check();

    protected void Page_Load(object sender, EventArgs e)
    {
        login lg = new login();
        lg.login();

        LoadPageBase();
        LoadListData();

    }

    protected void LoadPageBase()
    {
        check ck = new check();
        string f1 = "0";
        string f2 = "0";

        f1 = ck.CheckNumber(GetRequestQueryString("f1", "0"));
        f2 = ck.CheckNumber(GetRequestQueryString("f2", "0"));

        //判断是收到订单页还是发出订单页
        if (f1 == "0")
        {
            ltrHeadTitle.Text = "outbox_bg";
            plhOrderSave.Visible = true;
        }

        if (f1 == "1")
        {
            ltrHeadTitle.Text = "ms_bg3";
            plhOrderSave.Visible = false;
        }

        //生成选择标签
        ltrOrderAll.Text = "<li><a href=\"list.aspx?f1=" + f1 + "&f2=0\">全部</a></li>";
        ltrOrderWait.Text = "<li><a href=\"list.aspx?f1=" + f1 + "&f2=1\">等待答复</a></li>";
        ltrOrderBusy.Text = "<li><a href=\"list.aspx?f1=" + f1 + "&f2=2\">交易中</a></li>";
        ltrOrderFinish.Text = "<li><a href=\"list.aspx?f1=" + f1 + "&f2=3\">已完成</a></li>";
        ltrOrderInvalid.Text = "<li><a href=\"list.aspx?f1=" + f1 + "&f2=4  \">已作废</a></li>";
        ltrOrderCheck.Text = "<li><a href=\"list.aspx?f1=" + f1 + "&f2=5  \">系统审核</a></li>";
        ltrOrderSave.Text = "<li><a href=\"list.aspx?f1=" + f1 + "&f2=6  \">已保存</a></li>";

        if (f2 == "0")
        {
            ltrOrderAll.Text = "<li class=\"hover\"><a href=\"list.aspx?f1=" + f1 + "&f2=0\">全部</a></li>";
        }

        if (f2 == "1")
        {
            ltrOrderWait.Text = "<li class=\"hover\"><a href=\"list.aspx?f1=" + f1 + "&f2=1\">等待答复</a></li>";
        }

        if (f2 == "2")
        {
            ltrOrderBusy.Text = "<li class=\"hover\"><a href=\"list.aspx?f1=" + f1 + "&f2=2\">交易中</a></li>";
        }

        if (f2 == "3")
        {
            ltrOrderFinish.Text = "<li class=\"hover\"><a href=\"list.aspx?f1=" + f1 + "&f2=3\">已完成</a></li>";
        }

        if (f2 == "4")
        {
            ltrOrderInvalid.Text = "<li class=\"hover\"><a href=\"list.aspx?f1=" + f1 + "&f2=4  \">已作废</a></li>";
        }

        if (f2 == "5")
        {
            ltrOrderCheck.Text = "<li class=\"hover\"><a href=\"list.aspx?f1=" + f1 + "&f2=5  \">系统审核</a></li>";
        }

        if (f2 == "6")
        {
            ltrOrderSave.Text = "<li class=\"hover\"><a href=\"list.aspx?f1=" + f1 + "&f2=6  \">已保存</a></li>";
        }
    }

    protected void LoadListData()
    {
        check ck = new check();
        string f1 = "0";
        string f2 = "0";
        string u = "";

        f1 = ck.CheckNumber(GetRequestQueryString("f1", "0"));
        f2 = ck.CheckNumber(GetRequestQueryString("f2", "0"));
        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        string where_user = "order_shipper";
        string connect_user = "order_forward";
        string op_user = "status_op_shipper";
        string status_user = "status_name_shipper";
        string yiping_user = "yiping_shipper";
        string yiping_other = "yiping_forward";

        string sql_order_status = "";

        if (f2 == "1")
        {
            sql_order_status = "AND TB_ORDER.order_status = 2 ";
        }

        if (f2 == "2")
        {
            sql_order_status = "AND TB_ORDER.order_status in (3,4) ";
        }

        if (f2 == "3")
        {
            sql_order_status = "AND TB_ORDER.order_status = 5 ";
        }

        if (f2 == "4")
        {
            sql_order_status = "AND TB_ORDER.order_status in (10,11,12,13,14) ";
        }

        if (f2 == "5")
        {
            sql_order_status = "AND TB_ORDER.order_status in (6,7,8,9) ";
        }

        if (f2 == "6")
        {
            sql_order_status = "AND TB_ORDER.order_status = 1 ";
        }


        //判断是收到订单页还是发出订单页

        if (f1 == "0")
        {
            where_user = "order_shipper";
            connect_user = "order_forward";
            op_user = "status_op_shipper";
            status_user = "status_name_shipper";
            yiping_user = "yiping_shipper";
            yiping_other = "yiping_forward";
        }//发出的

        if (f1 == "1")
        {
            where_user = "order_forward";
            connect_user = "order_shipper";
            op_user = "status_op_forward";
            status_user = "status_name_forward";
            sql_order_status += " AND TB_ORDER.order_status <> 1 ";
            yiping_user = "yiping_forward";
            yiping_other = "yiping_shipper";
        }//收到的

        string p = "1";

        if (Request.QueryString["p"] != null)
        {
            p = ck.CheckInput(Request.QueryString["p"].ToString());
        }

        int ps = (Convert.ToInt32(p) - 1) * 10;

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql += "SELECT TOP 10 edit_enabled,status_intrade,alipay_if,date_create,order_code,freight_type,CompanyName,userid,status_font_weight,status_name,op,yipingother,yiping ";
        sql += "FROM ";
        sql += "(";
        sql += "SELECT ";
        sql += "TB_ORDER.oid as oid, ";
        sql += "TB_ORDER.edit_enabled as edit_enabled, ";
        sql += "TB_ORDER_STATUS.status_intrade as status_intrade, ";
        sql += "TB_ORDER.alipay_if as alipay_if, ";
        sql += "TB_ORDER.date_create as date_create, ";
        sql += "TB_ORDER.order_code as order_code, ";
        sql += "TB_ORDER.freight_type as freight_type, ";
        sql += "TB_USER.CompanyName as CompanyName, ";
        sql += "TB_USER.userid as userid, ";
        sql += "TB_ORDER_STATUS.status_level as status_level, ";
        sql += "TB_ORDER_STATUS.status_font_weight as status_font_weight, ";
        sql += "TB_ORDER_STATUS." + status_user + " as status_name, ";
        sql += "TB_ORDER_STATUS." + op_user + " AS op, ";
        sql += "TB_ORDER." + yiping_other + " AS yipingother, ";
        sql += "TB_ORDER." + yiping_user + " AS yiping ";
        sql += "FROM TB_ORDER,TB_USER,TB_ORDER_STATUS ";
        sql += "WHERE 1=1 ";
        sql += "AND TB_ORDER." + connect_user + " = TB_USER.userid ";
        sql += "AND TB_ORDER.order_status = TB_ORDER_STATUS.sid ";
        sql += "AND TB_ORDER." + where_user + " = " + u;
        sql += sql_order_status;
        sql += ") AS T ";
        sql += "WHERE oid NOT IN ";
        sql += "(SELECT oid FROM ";
        sql += "(SELECT TOP " + ps.ToString() + " oid ";
        sql += "FROM TB_ORDER,TB_USER,TB_ORDER_STATUS ";
        sql += "WHERE 1=1 ";
        sql += "AND TB_ORDER." + connect_user + " = TB_USER.userid ";
        sql += "AND TB_ORDER.order_status = TB_ORDER_STATUS.sid ";
        sql += "AND TB_ORDER." + where_user + " = " + u;
        sql += sql_order_status;
        sql += "ORDER BY status_level ASC,date_create DESC ";
        sql += ") AS T1";
        sql += ") ";
        sql += "ORDER BY status_level ASC,date_create DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "order");

        RptOrder.DataSource = ds.Tables["order"].DefaultView;
        RptOrder.DataBind();

        sql = "";
        sql += "SELECT oid FROM TB_ORDER WHERE 1=1 ";
        sql += "AND TB_ORDER." + where_user + " = " + u;
        sql += sql_order_status;
        ds = cn.mdb_ds(sql, "ordercount");

        //分页开始
        string base_url = "/member/order/list.aspx?f1=0&f2=0&p=";
        string end_url = "";

        int cp = Convert.ToInt32(p);
        int tp = 1;
        int count = Convert.ToInt32(ds.Tables["ordercount"].Rows.Count.ToString());

        if (count % 10 > 0 || count == 0)
        {
            tp = count / 10 + 1;
        }
        else
        {
            tp = count / 10;
        }


        string s = "";
        if (cp == 1)
        {
            s = s + "<span class=\"nolink\">首页</span>";
            s = s + "<span class=\"nolink\">上一页</span>";
            pagecontrol_prev = "<span class=\"nolink\">上一页</span>";
            s = s + "<span class=\"current\">1</span>";
            for (int i = 2; i <= (tp < 10 ? tp : 10); i++)
            {
                s = s + "<a href=\"" + base_url + "" + i + end_url + "\"><span>" + i + "</span></a>";
            }
        }
        else
        {
            s = s + "<a href=\"" + base_url + "1" + end_url + "\"><span>首页</span></a>";
            s = s + "<a href=\"" + base_url + (cp - 1) + end_url + "\"><span>上一页</span></a>";
            pagecontrol_prev = "<a href=\"" + base_url + (cp - 1) + end_url + "\"><span>上一页&nbsp;</span></a>";
            for (int i = (cp <= 5 ? 1 : (tp - cp < 5 ? (tp - 9 < 1 ? 1 : tp - 9) : cp - 4)); i <= cp - 1; i++)
            {
                s = s + "<a href=\"" + base_url + i + end_url + "\"><span>" + i + "</span></a>";
            }

            s = s + "<span class=\"current\">" + cp + "</span>";

            for (int i = cp + 1; i <= (cp + 5 >= tp ? tp : (cp <= 5 ? (tp >= 10 ? 10 : tp) : cp + 5)); i++)
            {
                s = s + "<a href=\"" + base_url + i + end_url + "\"><span>" + i + "</span></a>";
            }
        }


        if (cp == tp)
        {
            s = s + "<span class=\"nolink\">下一页</span>";
            pagecontrol_next = "<span class=\"nolink\">下一页</span>";
            s = s + "<span class=\"nolink\">尾页</span>";
        }
        else
        {
            s = s + "<a href=\"" + base_url + (cp + 1) + end_url + "\"><span>下一页</span></a>";
            pagecontrol_next = "<a href=\"" + base_url + (cp + 1) + end_url + "\"><span>下一页</span></a>";
            s = s + "<a href=\"" + base_url + tp + end_url + "\"><span>尾页</span></a>";
        }
        pagecontrol_string = s;

        //分页结束

        
        sql = "";
        sql += "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " +u;

        ds = cn.mdb_ds(sql, "account");

        ltrCredits.Text = ds.Tables["account"].Rows[0]["credit"].ToString();
        ltrOverage.Text = ds.Tables["account"].Rows[0]["overage"].ToString();

        if (Convert.ToDouble(ltrOverage.Text) <= 1000)
        {
            ltrResultTip.Text = "您的预存费余额不足，为了保证您的正常业务，请<a style=\"color:red;\" href=\"/member/order/pay_sel.aspx\">立即充值</a>";
        }
    }

    public static string GetFirstString(string stringToSub, int length)
    {
        //\u4e00-\u9fa5 中文区
        //\uff00-\uffef 逗号区
        //\u3000-\u303f 句号区
        //\u2000-\u206f 引号区
        //\u25a0-\u25ff 几何图形区
        Regex regex = new Regex("[\u4e00-\u9fa5\uff00-\uffef\u3000-\u303f\u2000-\u206f\u25a0-\u25ff]+", RegexOptions.Compiled);
        char[] stringChar = stringToSub.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;
        bool isCut = false;
        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch((stringChar[i]).ToString()))
            {
                sb.Append(stringChar[i]);
                nLength += 2;
            }
            else
            {
                sb.Append(stringChar[i]);
                nLength = nLength + 1;
            }

            if (nLength >= length)
            {
                isCut = true;
                break;
            }
        }

        if (isCut)
            return sb.ToString() + "..";
        else
            return sb.ToString();
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

    protected void SetOrderStatus(string status)
    {
        System.Threading.Thread.Sleep(2000);
        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Text);

        data_conn cn = new data_conn();
        string sql = "";

        sql += "UPDATE TB_ORDER SET order_status = " + status + " WHERE order_code = '" + order_code + "'";

        cn.mdb_exe(sql);
        LoadListData();
    }//设置状态参数

    protected void SetOrderDetail(string a, string c1, string c2)
    {
        //a是行为的角色，1为货主，2为货代，0为系统
        //c1是操作之前的状态号
        //c2是操作之后的状态号码
        //数组中参数{x}将被具体角色替换，{1}将被货主公司名替换，
        //{2}将被货代公司名替换，{3}将被订单号替换，{4}将被操作时间替换，
        //{5}将被拒绝订舱的理由替换，{6}将被个人信息替换，{7}将被重新选择替换，
        //{8}货主信息费，{9}货代信息费

        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Text);
        string op_code = "";

        string[] op_array = new string[29];

        op_array[0] = "1|0|1|订舱方 {1} 保存订单";
        op_array[1] = "1|0|2|订舱方 {1} 提交订舱单，等待承运方答复";

        op_array[2] = "1|1|2|订舱方 {1} 提交订舱单，等待承运方答复";

        op_array[3] = "2|2|3|承运方 {2} 接受订舱";

        op_array[4] = "2|2|6|承运方 {2} 不接受订舱，申请系统审核";
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
                op_code = i.ToString();
            }
        }//确认当前的状态数组

        string sql = "";

        sql += "SELECT  ";
        sql += "TB_ORDER.freight_type, ";
        sql += "TB_ORDER.date_create, ";
        sql += "TB_ORDER.order_code, ";
        sql += "TB_ORDER.container_20gp, ";
        sql += "TB_ORDER.container_40gp, ";
        sql += "TB_ORDER.container_40hq, ";
        sql += "TB_ORDER.container_45hq, ";
        sql += "TB_ORDER.lcl_cbm, ";
        sql += "TB_ORDER.air_kgs, ";
        sql += "UA.userid AS aid, ";
        sql += "UB.userid AS bid, ";
        sql += "UA.CompanyName AS aname, ";
        sql += "UB.CompanyName AS bname ";
        sql += "FROM TB_ORDER,TB_USER UA,TB_USER UB ";
        sql += "WHERE 1=1 ";
        sql += "AND TB_ORDER.order_shipper = UA.userid ";
        sql += "AND TB_ORDER.order_forward = UB.userid ";
        sql += "AND TB_ORDER.order_code = '" + order_code + "'";

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        ds = cn.mdb_ds(sql, "order");

        detail_txt = detail_txt.Replace("{1}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["aid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["aname"].ToString() + "</a>");
        detail_txt = detail_txt.Replace("{2}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["bid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["bname"].ToString() + "</a>");

        sql = "INSERT INTO TB_ORDER_DETAIL (order_code,detail_txt,detail_date) VALUES ('" + order_code + "','" + detail_txt + "',GetDate())";

        cn.mdb_exe(sql);//添加入操作历史

        string order_type_string = "";

        double base_fee = 0;

        switch (ds.Tables["order"].Rows[0]["freight_type"].ToString())
        {
            case "8":
                base_fee = Convert.ToDouble(ds.Tables["order"].Rows[0]["container_20gp"].ToString()) * 50;
                base_fee += Convert.ToDouble(ds.Tables["order"].Rows[0]["container_40gp"].ToString()) * 50;
                base_fee += Convert.ToDouble(ds.Tables["order"].Rows[0]["container_40hq"].ToString()) * 50;
                base_fee += Convert.ToDouble(ds.Tables["order"].Rows[0]["container_45hq"].ToString()) * 50;
                order_type_string = "fcl";
                break;
            case "9":
                base_fee = Convert.ToDouble(ds.Tables["order"].Rows[0]["lcl_cbm"].ToString()) * 10;
                order_type_string = "lcl";
                break;
            case "10":
                base_fee = Convert.ToDouble(ds.Tables["order"].Rows[0]["air_kgs"].ToString()) * 10;
                order_type_string = "air";
                break;
            default:
                break;
        }



        //短消息部分

        if (c2 == "5")
        {


            //改变用户帐户表内帐户余额，b货代-，a货主+
            sql = "UPDATE TB_ORDER_ACCOUNT SET overage = overage + " + base_fee + " WHERE userid = " + ds.Tables["order"].Rows[0]["aid"].ToString();
            cn.mdb_exe(sql);
            sql = "UPDATE TB_ORDER_ACCOUNT SET overage = overage - " + base_fee * 2 + " WHERE userid = " + ds.Tables["order"].Rows[0]["bid"].ToString();
            cn.mdb_exe(sql);

            DataSet ds_overage = new DataSet();


            sql = "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + ds.Tables["order"].Rows[0]["aid"].ToString();
            ds_overage = cn.mdb_ds(sql, "overage");
            string overage_a = ds_overage.Tables["overage"].Rows[0]["overage"].ToString();

            sql = "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + ds.Tables["order"].Rows[0]["bid"].ToString();
            ds_overage = cn.mdb_ds(sql, "overage");
            string overage_b = ds_overage.Tables["overage"].Rows[0]["overage"].ToString();

            sql = "INSERT INTO TB_ORDER_ACCOUNT_DETAIL (detail_date,order_code,userid,otherid,status,fee,overage) VALUES ";
            sql += "(getdate(),'" + order_code + "'," + ds.Tables["order"].Rows[0]["aid"].ToString() + ", " + ds.Tables["order"].Rows[0]["bid"].ToString() + ",'订舱成功'," + (base_fee) + "," + overage_a + ")";
            cn.mdb_exe(sql);

            sql = "INSERT INTO TB_ORDER_ACCOUNT_DETAIL (detail_date,order_code,userid,otherid,status,fee,overage) VALUES ";
            sql += "(getdate(),'" + order_code + "'," + ds.Tables["order"].Rows[0]["bid"].ToString() + ", " + ds.Tables["order"].Rows[0]["aid"].ToString() + ",'订舱成功'," + (0 - base_fee * 2) + "," + overage_b + ")";
            cn.mdb_exe(sql);

            //pm p = new pm();
            //string txt = "";
            //txt = "订单<a href=\"/search/" + order_type_string + "_order.aspx?filter=view&orderid=" + order_code + "\" target=\"_blank\">" + order_code + "</a>交易完成，您的信息费增加" + base_fee.ToString() + "元。";
            //p.sendpm("41", ds.Tables["order"].Rows[0]["aid"].ToString(), txt, "1");

            //txt = "订单<a href=\"/search/" + order_type_string + "_order.aspx?filter=view&orderid=" + order_code + "\" target=\"_blank\">" + order_code + "</a>交易完成，您的信息费将扣除" + (base_fee * 2).ToString() + "元。";
            //p.sendpm("41", ds.Tables["order"].Rows[0]["bid"].ToString(), txt, "1");
        }

        string sql_pm = "";

        sql_pm = "SELECT * FROM TB_ORDER_OPERATION WHERE op_code = " + op_code;

        DataSet ds_pm = new DataSet();
        ds_pm = cn.mdb_ds(sql_pm, "pm");

        pm p1 = new pm();

        string op_sms_shipper = ds_pm.Tables["pm"].Rows[0]["op_sms_shipper"].ToString();
        op_sms_shipper = op_sms_shipper.Replace("{1}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["aid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["aname"].ToString() + "</a>");
        op_sms_shipper = op_sms_shipper.Replace("{2}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["bid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["bname"].ToString() + "</a>");
        op_sms_shipper = op_sms_shipper.Replace("{3}", "<a href= \"/search/" + order_type_string + "_order.aspx?filter=view&orderid=" + order_code + "\">" + order_code + "</a>");
        op_sms_shipper = op_sms_shipper.Replace("{4}", DateTime.Now.ToString());
        op_sms_shipper = op_sms_shipper.Replace("{5}", DateTime.Now.ToString());
        op_sms_shipper = op_sms_shipper.Replace("{6}", DateTime.Now.ToString());
        op_sms_shipper = op_sms_shipper.Replace("{7}", DateTime.Now.ToString());
        op_sms_shipper = op_sms_shipper.Replace("{8}", (base_fee).ToString());
        op_sms_shipper = op_sms_shipper.Replace("{9}", (base_fee * 2).ToString());

        string op_sms_forward = ds_pm.Tables["pm"].Rows[0]["op_sms_forward"].ToString();
        op_sms_forward = op_sms_forward.Replace("{1}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["aid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["aname"].ToString() + "</a>");
        op_sms_forward = op_sms_forward.Replace("{2}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["bid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["bname"].ToString() + "</a>");
        op_sms_forward = op_sms_forward.Replace("{3}", "<a href= \"/search/" + order_type_string + "_order.aspx?filter=view&orderid=" + order_code + "\">" + order_code + "</a>");
        op_sms_forward = op_sms_forward.Replace("{4}", DateTime.Now.ToString());
        op_sms_shipper = op_sms_shipper.Replace("{5}", DateTime.Now.ToString());
        op_sms_shipper = op_sms_shipper.Replace("{6}", DateTime.Now.ToString());
        op_sms_shipper = op_sms_shipper.Replace("{7}", DateTime.Now.ToString());
        op_sms_forward = op_sms_forward.Replace("{8}", (base_fee).ToString());
        op_sms_forward = op_sms_forward.Replace("{9}", (base_fee * 2).ToString());

        if (op_sms_shipper != "")
        {
            p1.sendpm("41", ds.Tables["order"].Rows[0]["aid"].ToString(), op_sms_shipper, "1");
        }

        if (op_sms_forward != "")
        {
            p1.sendpm("41", ds.Tables["order"].Rows[0]["bid"].ToString(), op_sms_forward, "1");
        }
    }

    protected void btnSendOrder1_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "1", "2",check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnDelOrder1_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "1", "11", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnRecoverOrder1_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "11", "1", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnAcceptOrder1_Click(object sender, EventArgs e)
    {
        check ck = new check();

        string u = ck.CheckNumber(GetRequestCookies("user_id", "0"));

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";


        string[] odetail;
        odetail = AllinOrder1.GetOrderDetail(ck.CheckInput(txtCode.Text));

        double base_fee = Convert.ToDouble(odetail[60]);

        base_fee = base_fee * 4;
        
        sql = "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + u;
        ds = cn.mdb_ds(sql, "account");

        double overage = Convert.ToDouble(ds.Tables["account"].Rows[0]["overage"].ToString());

        //if (overage < base_fee)
        //{
        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "popup('" + base_fee + "','" + txtCode.Text + "');", true);
        //}
        //else 
        //{
        //    //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "popup_normal('" + txtCode.Text + "');", true);
        //    System.Threading.Thread.Sleep(2000);
        //    AllinOrder1.SetOrderDetail("2", "2", "3", check1.CheckInput(txtCode.Text), "");
        //    LoadListData();
        //}

        System.Threading.Thread.Sleep(2000);
        AllinOrder1.SetOrderDetail("2", "2", "3", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnFinishOrderShipper1_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "3", "4", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnFinishOrderForward1_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("2", "3", "5", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void aliFinish()
    {

        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();

        string orderid = ck.CheckInput(txtCode.Text);

        

        string sql = "";
        sql = "";
        sql += "SELECT * FROM TB_ORDER WHERE order_code = '" + orderid + "'";
        ds = cn.mdb_ds(sql, "order");

        string order_type_string = "";
        double base_fee = 0;
        switch (ds.Tables["order"].Rows[0]["freight_type"].ToString())
        {
            case "8":
                base_fee = Convert.ToDouble(ds.Tables["order"].Rows[0]["container_20gp"].ToString()) * 50;
                base_fee += Convert.ToDouble(ds.Tables["order"].Rows[0]["container_40gp"].ToString()) * 50;
                base_fee += Convert.ToDouble(ds.Tables["order"].Rows[0]["container_40hq"].ToString()) * 50;
                base_fee += Convert.ToDouble(ds.Tables["order"].Rows[0]["container_45hq"].ToString()) * 50;
                order_type_string = "fcl";
                break;
            case "9":
                base_fee = Convert.ToDouble(ds.Tables["order"].Rows[0]["lcl_cbm"].ToString()) * 10;
                order_type_string = "lcl";
                break;
            case "10":
                base_fee = Convert.ToDouble(ds.Tables["order"].Rows[0]["air_kgs"].ToString()) * 10;
                order_type_string = "air";
                break;
            default:
                break;
        }//获得订单类型

        orderid = orderid;

        double baozhengjin = base_fee * 8; //保证金是订舱费4倍
        baozhengjin = Math.Round(baozhengjin, 2);
        baozhengjin = baozhengjin / 100000; //测试用，把保证金缩小100000倍

        string userid = ds.Tables["order"].Rows[0]["order_forward"].ToString();//获得货代的userid

        sql = "";
        sql += "SELECT * FROM TB_USER WHERE userid = " + userid;
        ds = cn.mdb_ds(sql, "user");

        string ali_account = ds.Tables["user"].Rows[0]["ali_account"].ToString();//获得货代的支付宝帐号


        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string out_order_no = "";
        out_order_no = orderid + "_AA";     //out_trade_no 外部商家订单号
        string out_trade_no = "";
        out_trade_no = orderid + "_BB";

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
        string royalty_parameters = "" + ali_account + "^" + (baozhengjin * 0.67).ToString() + "^返还订舱保证金";   //(50)	见业务类型表	N
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

        //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "window.open('" + aliay_url + "' ,'_blank','');", true);

        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "window.open('" + ali_account + '&' + orderid + '&' + baozhengjin + "' ,'_blank','');", true);

        //Response.Redirect(aliay_url);

        //XmlTextReader textReader = null;
        //try
        //{
        //    textReader = new XmlTextReader(aliay_url);
        //    textReader.Read();
        //    textReader.WhitespaceHandling = WhitespaceHandling.None;
        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert(\"订单完成，订舱费已分配！\");", true);
        //    //while (textReader.Read())
        //    //{
        //    //    Response.Write("<br>Type=" + textReader.NodeType + "<br>Name=" + textReader.Name + "<br>Value=" + textReader.Value + "<br>LocalName=" + textReader.LocalName + "<br>XmlLang=" + textReader.XmlLang);
        //    //    //自己定义输出格式
        //    //}

        //}
        //catch {
        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert(\"支付失败，请联系客服！\");", true);
        //}
        //finally
        //{
        //    if (textReader != null)
        //    {
        //        textReader.Close();
        //    }
        //}

    }

    protected void btnFinishOrderShipper2_Click(object sender, EventArgs e)
    {
        string r = AllinOrder1.SetOrderDetail("1", "5", "6", check1.CheckInput(txtCode.Text), "");
        LoadListData();
        if (r == "AliBackSuccess")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert(\"订舱保证金已返还，清查看您的支付宝账户！\");", true);
        }
        else if (r == "AliBackFail")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert(\"支付宝返回订舱保证金失败，请联系客服！\");", true);
        }
    }

    protected void btnFinishOrderForward2_Click(object sender, EventArgs e)
    {
        string r = AllinOrder1.SetOrderDetail("2", "4", "6", check1.CheckInput(txtCode.Text), "");
        LoadListData();
        if (r == "AliBackSuccess")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert(\"订舱保证金已返还，订舱费已分配！\");", true);
        }
        else if (r == "AliBackFail")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert(\"支付宝返回订舱保证金失败，请联系客服！\");", true);
        }
    }

    protected void btnRejectOrderForward_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("2", "2", "7", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnRerejectOrderForward_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("2", "7", "2", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnRecoverOrderForward_Click(object sender, EventArgs e)
    {
        SetOrderStatus("2");
        LoadListData();
    }

    protected void btnCancelOrder2_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "2", "8", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnCancelOrder3_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "3", "9", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnCancelOrder4_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "5", "10", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnCancelCancelOrder7_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "8", "2", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnCancelCancelOrder8_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "9", "3", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnCancelCancelOrder9_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "10", "4", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnRecoverOrder11_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "13", "2", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnRecoverOrder12_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "13", "2", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnRecoverOrder13_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "14", "9", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void btnRecoverOrder14_Click(object sender, EventArgs e)
    {
        AllinOrder1.SetOrderDetail("1", "15", "10", check1.CheckInput(txtCode.Text), "");
        LoadListData();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();

        string u = "";
        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));



        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string sql = "";
        string sql1 = "";
        string ping = "";

        if (txtEvaluationType.Value == "1")
        {
            sql = "SELECT order_forward FROM TB_ORDER WHERE order_code = '" + txtEvaluation.Value + "'";
        }

        if (txtEvaluationType.Value == "2")
        {
            sql = "SELECT order_shipper FROM TB_ORDER WHERE order_code = '" + txtEvaluation.Value + "'";
        }

        ds1 = cn.mdb_ds(sql, "person");
        string person = ds1.Tables["person"].Rows[0][0].ToString();

        if (txtEvaluationType.Value == "1")
        {
            sql = "UPDATE TB_ORDER SET yiping_shipper = 1,ping_shipper = '" + RadioButtonList1.SelectedValue + "',evaluation_shipper = '" + TextBox1.Text + "' WHERE order_code = '" + txtEvaluation.Value + "'";
        }

        if (txtEvaluationType.Value == "2")
        {
            sql = "UPDATE TB_ORDER SET yiping_forward = 1,ping_forward = '" + RadioButtonList1.SelectedValue + "',evaluation_forward = '" + TextBox1.Text + "' WHERE order_code = '" + txtEvaluation.Value + "'";
        }

        cn.mdb_exe(sql);


        if (RadioButtonList1.SelectedValue == "3")
        {
            ping = "haoping";
        }
        if (RadioButtonList1.SelectedValue == "0")
        {
            ping = "zhongping";
        }
        if (RadioButtonList1.SelectedValue == "-3")
        {
            ping = "chaping";
        }

        sql1 = "UPDATE TB_ORDER_ACCOUNT SET " + ping + " = " + ping + " + 1,point = point + " + RadioButtonList1.SelectedValue + " WHERE userid = " + person;
        cn.mdb_exe(sql1);

        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('评价成功');", true);
        LoadListData();

        //if (txtEvaluationType.Value == "1")
        //{
        //    sql = "SELECT order_forward FROM TB_ORDER WHERE order_code = '" + txtEvaluation.Value + "'";
        //}

        //if (txtEvaluationType.Value == "2")
        //{
        //    sql = "SELECT order_shipper FROM TB_ORDER WHERE order_code = '" + txtEvaluation.Value + "'";
        //}

        //ds1 = cn.mdb_ds(sql, "person");


        //sql = "SELECT * FROM TB_ORDER_EVALUATION WHERE order_code = '" + txtEvaluation.Value + "' and userid = " + ds1.Tables["person"].Rows[0][0].ToString() + " and evaluationid = " + u;

        //ds = cn.mdb_ds(sql, "evaluation");

        //if (ds.Tables["evaluation"].Rows.Count != 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('您已评价过');", true);
        //}
        //else
        //{

        //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('" + ds1.Tables["person"].Rows[0][0].ToString() + "'+'评价成功'+'" + txtEvaluation.Value + "');", true);
        //}
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(2000);


        check ck = new check();

        string u = "";
        u = ck.CheckNumber(GetRequestCookies("user_id", "0"));


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string sql = "";
        string sql1 = "";
        string ping = "";


        if (txtResultType.Value == "1")
        {
            sql = "SELECT order_forward,order_shipper,order_code,freight_type FROM TB_ORDER WHERE order_code = '" + txtResult.Value + "'";
        }

        if (txtResultType.Value == "2")
        {
            sql = "SELECT order_shipper,order_forward,order_code,freight_type FROM TB_ORDER WHERE order_code = '" + txtResult.Value + "'";
        }

        ds1 = cn.mdb_ds(sql, "person");
        string userid = ds1.Tables["person"].Rows[0][0].ToString();
        string complaintsid = ds1.Tables["person"].Rows[0][1].ToString();
        string order_code = ds1.Tables["person"].Rows[0][2].ToString();

        string order_type_string = "";

        double base_fee = 0;

        switch (ds1.Tables["person"].Rows[0]["freight_type"].ToString())
        {
            case "8":
                order_type_string = "fcl";
                break; 
            case "9":
                order_type_string = "lcl";
                break;
            case "10":
                order_type_string = "air";
                break;
            default:
                break;
        }

        sql = "INSERT INTO TB_ORDER_COMPLAINTS (order_code,userid,complaintsid,txt) VALUES ('" + txtResult.Value + "'," + userid + "," + complaintsid + ",'" + TextBox2.Text+ "')";
        cn.mdb_exe(sql);

        sql = "SELECT * FROM TB_USER WHERE userid = " + complaintsid;
        ds = cn.mdb_ds(sql, "user");

        pm p = new pm();
        p.sendpm("41", userid, "在订单<a href=\"/search/" + order_type_string + "_order.aspx?filter=view&orderid=" + order_code + "\" target=\"_blank\">" + order_code + "</a>交易过程中，" + "<a href=\"/company/" + setkey(complaintsid.ToString()) + "/\">" + ds.Tables["user"].Rows[0]["CompanyName"].ToString() + "</a>对您进行投诉，内容如下：<br/>" + TextBox2.Text, "1");
        
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('您对该商户的投诉成功，请等待系统处理');", true);
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
