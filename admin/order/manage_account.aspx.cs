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

public partial class admin_order_manage_account : System.Web.UI.Page
{
    public string search_words;
    protected void Page_Load(object sender, EventArgs e)
    {
        search_words = "";
        ltrHeadTitle.Text = "客服管理 / 用户帐户";

        LoadPageBase();

        if (!Page.IsPostBack)
        {
            LoadListData();
        }

    }


    protected void LoadPageBase()
    {
        check ck = new check();

        string f2 = "0";
        f2 = ck.CheckNumber(GetRequestQueryString("f2", "0"));

        ltrOrderAll.Text = "<a href=\"manage_account.aspx?f2=0\">全部</a>";
        ltrOrderOpen.Text = "<a href=\"manage_account.aspx?f2=1\">打开</a>";
        ltrOrderClose.Text = "<a href=\"manage_account.aspx?f2=2\">关闭</a>";
        ltrOrderForbidden.Text = "<a href=\"manage_account.aspx?f2=3\">冻结</a>";

        if (f2 == "0")
        {
            ltrOrderAll.Text = "<b>全部</b>";
        }

        if (f2 == "1")
        {
            ltrOrderOpen.Text = "<b>打开</b>";
        }

        if (f2 == "2")
        {
            ltrOrderClose.Text = "<b>关闭</b>";
        }

        if (f2 == "3")
        {
            ltrOrderForbidden.Text = "<b>冻结</b>";
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
            sql_order_status = "AND TB_ORDER_ACCOUNT.account_status = 1 ";
        }

        if (f2 == "2")
        {
            sql_order_status = "AND TB_ORDER_ACCOUNT.account_status = 0 ";
        }

        if (f2 == "3")
        {
            sql_order_status = "AND TB_ORDER_ACCOUNT.account_status = 2 ";
        }

        string q = ck.CheckInput(GetRequestQueryString("q", ""));
        string sql_q = "";

        if (q != "")
        {
            sql_q = "AND (TB_User.companyname like '%" + q + "%' ";
            sql_q += "OR TB_User.realname like '%" + q + "%' ";
            sql_q += "OR TB_User.username like '%" + q + "%' ";
            sql_q += ")";
            txtSearch.Text = q;
            search_words = q;
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql += "SELECT TOP 10 ";
        sql += "TB_User.userid, ";
        sql += "TB_User.username, ";
        sql += "TB_User.realname, ";
        sql += "TB_User.companyname, ";
        sql += "TB_ORDER_ACCOUNT.credit, ";
        sql += "TB_ORDER_ACCOUNT.overage, ";
        sql += "TB_ORDER_ACCOUNT.account_status, ";
        sql += "TB_ORDER_ACCOUNT_STATUS.status_name, ";
        sql += "TB_ORDER_ACCOUNT_STATUS.status_op ";
        sql += "FROM TB_User,TB_ORDER_ACCOUNT,TB_ORDER_ACCOUNT_STATUS ";
        sql += "WHERE 1=1 ";
        sql += "AND TB_User.userid = TB_ORDER_ACCOUNT.userid ";
        sql += "AND TB_ORDER_ACCOUNT.account_status = TB_ORDER_ACCOUNT_STATUS.sid ";
        sql += sql_order_status;
        sql += sql_q;
        sql += "ORDER BY TB_User.userid DESC ";

        //Response.Write(sql);
        ds = cn.mdb_ds(sql, "account");

        RptAccount.DataSource = ds.Tables["account"].DefaultView;
        RptAccount.DataBind();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        check ck = new check();

        string f2 = "0";
        f2 = ck.CheckNumber(GetRequestQueryString("f2", "0"));

        //Response.Write("aaa");
        string q = "";
        q = ck.CheckInput(txtSearch.Text);

        Response.Redirect("manage_account.aspx?f2=0&q=" + q);
    }

    public string highlight(string inputwords)
    {
        string outputwords = inputwords;
        if (search_words != "")
        {
            outputwords = outputwords.Replace(search_words.ToUpper(), "[string_upper]");
            outputwords = outputwords.Replace(search_words.ToLower(), "[string_lower]");
            outputwords = outputwords.Replace("[string_upper]", "<span style=\"color:red\">" + search_words.ToUpper() + "</span>");
            outputwords = outputwords.Replace("[string_lower]", "<span style=\"color:red\">" + search_words.ToLower() + "</span>");
        }
        return outputwords;
    }


    protected void SetOrderStatus(string status)
    {
        System.Threading.Thread.Sleep(2000);
        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Text);

        data_conn cn = new data_conn();
        string sql = "";

        sql += "UPDATE TB_ORDER_ACCOUNT SET account_status = " + status + " WHERE userid = '" + order_code + "'";

        cn.mdb_exe(sql);
        LoadListData();
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        SetOrderStatus("1");
    }

    protected void btnForbidden_Click(object sender, EventArgs e)
    {
        SetOrderStatus("2");
    }

    protected void btnEnabled_Click(object sender, EventArgs e)
    {
        SetOrderStatus("1");
    }

    protected void btnClose1_Click(object sender, EventArgs e)
    {
        SetOrderStatus("0");
    }

    protected void btnClose2_Click(object sender, EventArgs e)
    {
        SetOrderStatus("0");
    }

    protected void btnOverage_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(100);
        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Text);
        string overage = ck.CheckInput(txtOverage.Text);

        if (RadioButtonList1.SelectedValue.ToString() == "0")
        {
            overage = (0 - Convert.ToInt32(overage)).ToString();
        }

        data_conn cn = new data_conn();
        string sql = "";

        sql += "UPDATE TB_ORDER_ACCOUNT SET overage = overage + " + overage + " WHERE userid = '" + order_code + "'";

        cn.mdb_exe(sql);


        LoadListData();
    }

    protected void btnCredits_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(100);
        check ck = new check();
        string order_code = ck.CheckInput(txtCode.Text);
        string credits = ck.CheckInput(txtCredits.Text);

        if (RadioButtonList2.SelectedValue.ToString() == "0")
        {
            credits = (0 - Convert.ToInt32(credits)).ToString();
        }

        data_conn cn = new data_conn();
        string sql = "";

        sql += "UPDATE TB_ORDER_ACCOUNT SET credit = credit + " + credits + ",overage = overage + " + credits + "  WHERE userid = '" + order_code + "'";

        cn.mdb_exe(sql);

        int starallin_add = 0;
        starallin_add = (Convert.ToInt32(txtTempCreditsOrigin.Value) + Convert.ToInt32(credits)) / 1000;

        sql = "UPDATE TB_USER SET star_allin = " + starallin_add + "  WHERE userid = '" + order_code + "'";
        cn.mdb_exe(sql);

        sql = "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = '" + order_code + "'";
        DataSet ds = new DataSet();
        ds = cn.mdb_ds(sql, "account");
        string overage_all = "";
        overage_all = ds.Tables["account"].Rows[0]["overage"].ToString();

        sql = "INSERT INTO TB_ORDER_ACCOUNT_DETAIL (detail_date,order_code,userid,otherid,status,fee,overage,ispay) ";
        sql += "VALUES (getdate(),''," + order_code + ",0,'预存费用'," + credits + "," + overage_all + ",0)";
        cn.mdb_exe(sql);


        LoadListData();
    }
}
