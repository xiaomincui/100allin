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

public partial class pro_order_adminlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrHeadTitle.Text = "客服管理 / 整箱";

        LoadPageBase();
        LoadListData();
    }

    protected void LoadPageBase()
    {
        check ck = new check();

        string f2 = "0";
        f2 = ck.CheckNumber(GetRequestQueryString("f2", "0"));

        ltrOrderAll.Text = "<a href=\"adminlist.aspx?f2=0\">全部</a>";
        ltrOrderCheck.Text = "<a href=\"adminlist.aspx?f2=1\">未审核</a>";


        if (f2 == "0")
        {
            ltrOrderAll.Text = "<b>全部</b>";
        }

        if (f2 == "1")
        {
            ltrOrderCheck.Text = "<b>未审核</b>";
        }

    }

    protected void LoadListData()
    {
        check ck = new check();

        string f2 = "0";
        f2 = ck.CheckNumber(GetRequestQueryString("f2", "0"));
        
        string sql_order_status = "";
        
        if (f2 == "1")
        {
            sql_order_status = "AND TB_ORDER.order_status in (6,7,8,9) ";
        }

        pro_data_conn cn = new pro_data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql += "SELECT  ";
        sql += "TB_ORDER.date_create, ";
        sql += "TB_ORDER.order_code, ";
        sql += "UA.userid AS aid, ";
        sql += "UB.userid AS bid, ";
        sql += "UA.CompanyName AS aname, ";
        sql += "UB.CompanyName AS bname, ";
        sql += "TB_ORDER_STATUS.status_name_admin AS status_name, ";
        sql += "TB_ORDER_STATUS.status_op_admin AS op ";
        sql += "FROM TB_ORDER,TB_USER UA,TB_USER UB,TB_ORDER_STATUS ";
        sql += "WHERE 1=1 ";
        sql += "AND TB_ORDER.order_shipper = UA.userid ";
        sql += "AND TB_ORDER.order_forward = UB.userid ";
        sql += "AND TB_ORDER.order_status = TB_ORDER_STATUS.sid ";
        sql += sql_order_status;
        sql += "ORDER BY date_create DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "order");

        RptOrder.DataSource = ds.Tables["order"].DefaultView;
        RptOrder.DataBind();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        LoadListData();
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
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

    protected void SetOrderStatus(string status)
    {
        System.Threading.Thread.Sleep(2000);
        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Text);

        pro_data_conn cn = new pro_data_conn();
        string sql = "";

        sql += "UPDATE TB_ORDER SET order_status = " + status + " WHERE order_code = '" + order_code + "'";

        cn.mdb_exe(sql);
        LoadListData();
    }

    protected void SetOrderDetail(string a, string c1, string c2)
    {
        //a是行为的角色，1为货主，2为货代，0为系统
        //c1是操作之前的状态号
        //c2是操作之后的状态号码
        //数组中参数{1}将被具体角色替换，{1}将被货主公司名替换，{2}将被货代公司名替换

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

        op_array[14] = "1|3|4|订舱方 {2} 确认出运";

        op_array[15] = "1|3|8|订舱方 {1} 撤消了该订舱单";
        op_array[16] = "1|8|3|订舱方 {1} 取消撤消该订舱单，重新等待承运方答复";
        op_array[17] = "0|8|13|系统通过了订舱方 {1} 的撤消订舱申请，该订单作废";
        op_array[18] = "0|8|3|系统未通过订舱方 {1} 的撤消订舱申请，该订单恢复原状态";
        op_array[19] = "1|13|8|订舱方 {1} 恢复了该订舱单，重新等待承运方答复";

        op_array[20] = "2|3|5|承运方 {2} 确认出运";

        op_array[21] = "2|4|5|承运方 {2} 同意完成";

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
        sql += "UA.userid AS bid, ";
        sql += "UA.CompanyName AS aname, ";
        sql += "UB.CompanyName AS bname ";
        sql += "FROM TB_ORDER,TB_USER UA,TB_USER UB ";
        sql += "WHERE 1=1 ";
        sql += "AND TB_ORDER.order_shipper = UA.userid ";
        sql += "AND TB_ORDER.order_forward = UB.userid ";
        sql += "AND TB_ORDER.order_code = '" + order_code + "'";

        pro_data_conn cn = new pro_data_conn();
        DataSet ds = new DataSet();

        ds = cn.mdb_ds(sql, "order");

        detail_txt = detail_txt.Replace("{1}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["aid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["aname"].ToString() + "</a>");
        detail_txt = detail_txt.Replace("{2}", "<a href= \"/company/" + setkey(ds.Tables["order"].Rows[0]["bid"].ToString()) + "/\" target=\"_blank\">" + ds.Tables["order"].Rows[0]["bname"].ToString() + "</a>");

        sql = "INSERT INTO TB_ORDER_DETAIL (order_code,detail_txt,detail_date) VALUES ('" + order_code + "','" + detail_txt + "',GetDate())";

        cn.mdb_exe(sql);
    }

    protected void btnAcceptCheck6_Click(object sender, EventArgs e)
    {
        SetOrderDetail("0", "6", "11");
        SetOrderStatus("11");
    }
    protected void btnRejectCheck6_Click(object sender, EventArgs e)
    {
        SetOrderDetail("0", "6", "2");
        SetOrderStatus("2");
    }
    protected void btnAcceptCheck7_Click(object sender, EventArgs e)
    {
        SetOrderDetail("0", "7", "12");
        SetOrderStatus("12");
    }
    protected void btnRejectCheck7_Click(object sender, EventArgs e)
    {
        SetOrderDetail("0", "7", "2");
        SetOrderStatus("2");
    }
    protected void btnAcceptCheck8_Click(object sender, EventArgs e)
    {
        SetOrderDetail("0", "8", "13");
        SetOrderStatus("13");
    }
    protected void btnRejectCheck8_Click(object sender, EventArgs e)
    {
        SetOrderDetail("0", "8", "3");
        SetOrderStatus("3");
    }
    protected void btnAcceptCheck9_Click(object sender, EventArgs e)
    {
        SetOrderDetail("0", "9", "14");
        SetOrderStatus("14");
    }
    protected void btnRejectCheck9_Click(object sender, EventArgs e)
    {
        SetOrderDetail("0", "9", "4");
        SetOrderStatus("4");
    }
}
