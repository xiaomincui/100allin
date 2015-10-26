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
using System.Text.RegularExpressions;
using System.Text;

public partial class topic_lcl090619_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadLcl();
        LoadCompany();
    }


    public void LoadLcl()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT top 12 ";
        sql = sql + "tb_yunjia.shipcompany1 as shipcompany,tb_yunjia.id as sid,'0' as id,tb_yunjia.startport as startport,tb_yunjia.title,tb_yunjia.hangxianmiaoshu,tb_yunjia.hits,tb_yunjia.DestPort1 as destport,tb_yunjia.pricegp1 as pricegp, ";
        sql = sql + "tb_user.userid,";
        sql = sql + "tb_user.companyname,";
        sql = sql + "tb_yunjia.postdate,";
        sql = sql + "CONVERT(varchar(10), tb_yunjia.enddate, 120) as enddate ";
        sql = sql + "FROM ";
        sql = sql + "tb_yunjia,tb_user ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 AND tb_user.userid = tb_yunjia.userid and star_allin > 0 ";
        sql = sql + "AND tb_yunjia.yunjialeixing = 9 ";
        sql = sql + "ORDER BY tb_yunjia.postdate DESC ";

        ds = cn.mdb_ds(sql, "lcl");

        RptLcl.DataSource = ds.Tables["lcl"].DefaultView;
        RptLcl.DataBind();
    }

    public void LoadCompany()
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = sql + "SELECT TOP 12 ";
        sql = sql + "iflocus,";
        sql = sql + "ifadv,";
        sql = sql + "userid,";
        sql = sql + "Realname,";
        sql = sql + "Companyname,";
        sql = sql + "Phone,";
        sql = sql + "Login2_Locus1,";
        sql = sql + "Login2_Locus2,";
        sql = sql + "Login2_Adventage_Type_fcl,";
        sql = sql + "Login2_Adventage_Type_lcl,";
        sql = sql + "Login2_Adventage_Type_air, ";
        sql = sql + "Login2_Adventage_Line, ";
        sql = sql + "Login2_Adventage_Line2 ";
        sql = sql + "FROM ";
        sql = sql + "V_COMPANY_USER ";
        sql = sql + "WHERE ";
        sql = sql + "1=1 AND ifcompanyshow = 1 and star_allin > 0 ";
        sql = sql + "AND Login2_Adventage_Type_lcl = 1 ";
        sql = sql + "ORDER BY ifadv DESC,userid DESC ";


        ds = cn.mdb_ds(sql, "company");

        RptCompany.DataSource = ds.Tables["company"].DefaultView;
        RptCompany.DataBind();
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

    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
