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

public partial class member_order_bill : System.Web.UI.Page
{
    public string pagecontrol_string;
    public string pagecontrol_prev;
    public string pagecontrol_next;

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

        sql += "SELECT TOP 10 * FROM ";
        sql += "(";
        sql += "SELECT ";
        sql += "TB_ORDER_ACCOUNT_DETAIL.did, ";
        sql += "TB_ORDER_ACCOUNT_DETAIL.detail_date, ";
        sql += "TB_ORDER.freight_type, ";
        sql += "TB_ORDER_ACCOUNT_DETAIL.order_code, ";
        sql += "TB_ORDER_ACCOUNT_DETAIL.status, ";
        sql += "TB_ORDER_ACCOUNT_DETAIL.fee, ";
        sql += "TB_ORDER_ACCOUNT_DETAIL.overage, ";
        sql += "TB_ORDER_ACCOUNT_DETAIL.role ";
        sql += "FROM TB_ORDER,TB_ORDER_ACCOUNT_DETAIL ";
        sql += "WHERE 1=1 AND TB_ORDER.order_code =* TB_ORDER_ACCOUNT_DETAIL.order_code ";
        sql += "AND TB_ORDER_ACCOUNT_DETAIL.userid = " + u;
        sql += ") AS T ";
        sql += "WHERE did NOT IN ";
        sql += "(";
        sql += "SELECT did FROM ";
        sql += "(SELECT TOP " + ps.ToString() + " did ";
        sql += "FROM TB_ORDER,TB_ORDER_ACCOUNT_DETAIL ";
        sql += "WHERE 1=1 AND TB_ORDER.order_code =* TB_ORDER_ACCOUNT_DETAIL.order_code ";
        sql += "AND TB_ORDER_ACCOUNT_DETAIL.userid = " + u;
        sql += " ORDER BY did DESC ";
        sql += ") AS T1 ";
        sql += ") ";
        sql += " ORDER BY did DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "order");

        RptOrder.DataSource = ds.Tables["order"].DefaultView;
        RptOrder.DataBind();


        sql = "";
        sql += "SELECT ";
        sql += "did ";
        sql += "FROM TB_ORDER_ACCOUNT_DETAIL ";
        sql += "WHERE 1=1 ";
        sql += "AND TB_ORDER_ACCOUNT_DETAIL.userid = " + u;

        //Response.Write(sql);

        ds = cn.mdb_ds(sql, "ordercount");

        
        //分页开始
        string base_url = "/member/order/bill.aspx?p=";
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
        sql += "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " + u;

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
        //数组中参数{x}将被具体角色替换，{1}将被货主公司名替换，{2}将被货代公司名替换

        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Text);

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
            }
        }//确认当前的状态数组

        string sql = "";

        sql += "SELECT  ";
        sql += "TB_ORDER.date_create, ";
        sql += "TB_ORDER.order_code, ";
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

        cn.mdb_exe(sql);

        if (c2 == "5")
        {
            sql = "SELECT * FROM TB_ORDER WHERE order_code = '" + order_code + "'";

            DataSet ds1 = new DataSet();

            ds1 = cn.mdb_ds(sql, "account");

            double base_fee = 0;

            base_fee = Convert.ToDouble(ds1.Tables["account"].Rows[0]["container_20gp"].ToString()) * 150;
            base_fee += Convert.ToDouble(ds1.Tables["account"].Rows[0]["container_40gp"].ToString()) * 150;
            base_fee += Convert.ToDouble(ds1.Tables["account"].Rows[0]["container_40hq"].ToString()) * 150;

            sql = "UPDATE TB_ORDER_ACCOUNT SET credit = credit + " + base_fee + " WHERE userid = " + ds.Tables["order"].Rows[0]["aid"].ToString();
            cn.mdb_exe(sql);
            sql = "UPDATE TB_ORDER_ACCOUNT SET credit = credit - " + base_fee * 2 + " WHERE userid = " + ds.Tables["order"].Rows[0]["bid"].ToString();
            cn.mdb_exe(sql);


            pm p = new pm();
            string txt = "";
            txt = "<img src=\"images/ico13.gif\" />&nbsp;<a href=\"#\">上海启航物流有限公司</a>给您发送了一份线上订舱委托书订舱编号：<a href=\"#\">GX3001</a>提醒您尽快答复，以免错失商机！";
            p.sendpm("41", ds.Tables["order"].Rows[0]["aid"].ToString(), "", "1");
        }

    }

    protected void btnSendOrder1_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "1", "2");
        SetOrderStatus("2");
    }

    protected void btnDelOrder1_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "1", "10");
        SetOrderStatus("10");
    }

    protected void btnRecoverOrder1_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "10", "1");
        SetOrderStatus("1");
    }

    protected void btnAcceptOrder1_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "2", "3");
        SetOrderStatus("3");
    }

    protected void btnFinishOrderShipper1_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "3", "4");
        SetOrderStatus("4");
    }

    protected void btnFinishOrderForward1_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "3", "5");
        SetOrderStatus("5");
    }

    protected void btnFinishOrderForward2_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "4", "5");
        SetOrderStatus("5");
    }

    protected void btnRejectOrderForward_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "2", "6");
        SetOrderStatus("6");
    }

    protected void btnRerejectOrderForward_Click(object sender, EventArgs e)
    {
        SetOrderDetail("2", "6", "2");
        SetOrderStatus("2");
    }

    protected void btnRecoverOrderForward_Click(object sender, EventArgs e)
    {
        SetOrderStatus("2");
    }

    protected void btnCancelOrder2_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "2", "7");
        SetOrderStatus("7");
    }

    protected void btnCancelOrder3_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "3", "8");
        SetOrderStatus("8");
    }

    protected void btnCancelOrder4_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "4", "9");
        SetOrderStatus("9");
    }

    protected void btnCancelCancelOrder7_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "7", "2");
        SetOrderStatus("2");
    }

    protected void btnCancelCancelOrder8_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "8", "3");
        SetOrderStatus("3");
    }

    protected void btnCancelCancelOrder9_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "9", "4");
        SetOrderStatus("4");
    }

    protected void btnRecoverOrder11_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "12", "2");
        SetOrderStatus("2");
    }

    protected void btnRecoverOrder12_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "12", "2");
        SetOrderStatus("2");
    }

    protected void btnRecoverOrder13_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "13", "8");
        SetOrderStatus("3");
    }

    protected void btnRecoverOrder14_Click(object sender, EventArgs e)
    {
        SetOrderDetail("1", "14", "9");
        SetOrderStatus("4");
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


    public string ChooseLink(string t,string o,string r)
    {
        string order_type_string = "";
        switch (t)
        {
            case "8":
                order_type_string = "/search/fcl_order.aspx?filter=view&role=" + r + "&orderid=" + o;
                break;
            case "9":
                order_type_string = "/search/fcl_order.aspx?filter=view&role=" + r + "&orderid=" + o;
                break;
            case "10":
                order_type_string = "/search/fcl_order.aspx?filter=view&role=" + r + "&orderid=" + o;
                break;
            default:
                order_type_string = "/member/order/ali_order.aspx?orderid=" + o;
                break;
        }

        return order_type_string;
    }
}
