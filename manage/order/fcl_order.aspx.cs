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

public partial class search_fcl_order : System.Web.UI.Page
{
    public string pub_f = "";
    public AllinOrder AllinOrder1 = new AllinOrder();
    public AllinFreight AllinFreight1 = new AllinFreight();
    public GetRequest GetRequest1 = new GetRequest();
    public check check1 = new check();

    protected void Page_Load(object sender, EventArgs e)
    {
        string address = Page.Request.UserHostAddress;
        if (address == "116.231.118.63" | address == "116.228.56.170" | address == "127.0.0.1" | address == "222.73.45.25")
        {

        }
        else
        {
            Response.Redirect("/");
        }

        //如果用户登陆信息正确，显示管理页面
        if (this.Request.Cookies["admin"] == null)
        {
            Server.Transfer("/admin/login.aspx");
        }
        else
        {
            if (this.Request.Cookies["admin"].Value == "yes")
            {

            }
            else
            {
                Server.Transfer("/admin/login.aspx");
            }
        }

        ltrBasicOrderCode.Text = GetRequest1.GetRequestQueryString("orderid", "0");

        if (!Page.IsPostBack)
        {
            LoadSavedOrder();
        }
    }
    
    public void LoadSavedOrder()
    {
        check ck = new check();
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        GetRequest GetRequest1 = new GetRequest();

        string u = ck.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));
        string orderid = ck.CheckInput(GetRequest1.GetRequestQueryString("orderid", "0"));
        string role = GetRequest1.GetRequestQueryString("role", "");

        AllinOrder AllinOrder1 = new AllinOrder();
        string[] odetail;
        odetail = AllinOrder1.GetOrderDetail(orderid);
        ltrOrderViewCode.Text = odetail[0];
        ltrOrderViewShipper.Text = odetail[8];
        ltrOrderViewConsignee.Text = odetail[9];
        ltrOrderViewNotifyParty.Text = odetail[10];
        ltrOrderViewCompanyName.Text = odetail[11];
        ltrOrderViewEmail.Text = odetail[12];
        ltrOrderViewContactor.Text = odetail[13];
        ltrOrderViewMobile.Text = odetail[14];
        ltrOrderViewTel.Text = odetail[15];
        ltrOrderViewFax.Text = odetail[16];
        ltrOrderViewStartport.Text = odetail[17];
        ltrOrderViewMidport.Text = odetail[18];
        ltrOrderViewDestport.Text = odetail[19];
        ltrOrderViewMarksNumbers.Text = odetail[20];
        ltrOrderViewNumbersofPackages.Text = odetail[21];
        ltrOrderViewDescription.Text = odetail[22];
        ltrOrderViewGrossWeight.Text = odetail[23];
        ltrOrderViewMeasurement.Text = odetail[24];
        ltrOrderViewCarrier.Text = odetail[26];
        ltrOrderViewKaihangri.Text = odetail[27];
        ltrOrderViewZhuangxiangri.Text = odetail[28];
        ltrOrderViewJieguanri.Text = odetail[29];
        ltrOrderView20GP.Text = odetail[30];
        ltrOrderView40GP.Text = odetail[31];
        ltrOrderView40HQ.Text = odetail[32];
        ltrOrderView45HQ.Text = odetail[33];
        ltrFreight20.Text = odetail[45];
        ltrFreight40.Text = odetail[46];
        ltrFreight40h.Text = odetail[47];
        ltrFreight45h.Text = odetail[48];
        ltrFreightAppend.Text = odetail[44];
        ltrFreightCarrier.Text = odetail[26];
        ltrOrderViewHyf.Text = odetail[59];
        ltrOrderViewBeizhu.Text = odetail[36];

        if (odetail[44] != "")
        {
            ltrOrderFujiafei.Text = "(附加费：" + odetail[44] + ")";
        }

        string order_type_string = odetail[58];

        ltrSMS.Text = "<a href=\"/member/pm_detail.aspx?cid=" + odetail[4] + "\" id=\"linkSMS\" target=\"_blank\"></a>";

        AllinFreight AllinFreight1 = new AllinFreight();
        string[] fdetail;
        if (odetail[7] == "0")
        {
            fdetail = AllinFreight1.GetFreightDetail("8", ck.CheckNumber(odetail[6]), "0");
        }
        else
        {
            fdetail = AllinFreight1.GetFreightDetail("8", "0", ck.CheckNumber(odetail[7]));
        }


        //ltrEndDate.Text = Convert.ToDateTime(fdetail[6]).ToString("yyyy-MM-dd");
        ltrFreightTitle.Text = "<span style=\"font-weight:bold;font-size:14px\">" + odetail[75] + "</span>";
        ltrFreightPostdate.Text = Convert.ToDateTime(odetail[65]).ToString("MM") + "/" + Convert.ToDateTime(odetail[65]).ToString("dd");
        ltrFreightEnddate.Text = Convert.ToDateTime(odetail[66]).ToString("MM") + "/" + Convert.ToDateTime(odetail[66]).ToString("dd");
        ltrFreightCompany.Text = fdetail[18];
        ltrFreightAllinStar.Text = fdetail[19];
        ltrFreightUserStar.Text = fdetail[20];
        ltrFreightLine.Text = odetail[69];
        ltrFreightStartport.Text = odetail[70];
        ltrFreightDestport.Text = odetail[71];
        ltrFreightAssuranceSpace.Text = odetail[100];
        ltrFreightAssurancePrice.Text = odetail[101];

        ltrOrderFirstStep.Text = odetail[2] + "：订舱方 " + odetail[107] + " 创建订单";

        string sql = "";
        sql += "SELECT * FROM TB_ORDER_DETAIL WHERE order_code = '" + orderid + "'";

        ds = cn.mdb_ds(sql, "order");
        rptOrder.DataSource = ds.Tables["order"].DefaultView;
        rptOrder.DataBind();
    }//查看订单

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
                data_conn cd1 = new data_conn();
            }
        }
        return outputstring;
    }//获得指定Cookies参数

    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

}
