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

public partial class pro_order_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDetailData();
    }

    protected void LoadDetailData()
    {
        check ck = new check();
        string order_code = "";
        order_code = ck.CheckInput(GetRequestQueryString("orderid", "0"));

        pro_data_conn cn = new pro_data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql += "SELECT * FROM TB_ORDER_DETAIL WHERE order_code = '" + order_code + "' ORDER BY detail_date ASC";

        ds = cn.mdb_ds(sql, "detail");

        ltrHeadTitle.Text = order_code;

        RptOrderDetail.DataSource = ds.Tables["detail"].DefaultView;
        RptOrderDetail.DataBind();
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
}
