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

public partial class pro_freight_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrHeadTitle.Text = "运价 / 整箱订舱";

        pro_data_conn cn = new pro_data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql += "select top 15 ";
        sql += "tb_yunjia.shipcompany1 as shipcompany, ";
        sql += "tb_yunjia.id as sid,'0' as id, ";
        sql += "tb_yunjia.startport as startport, ";
        sql += "tb_yunjia.title, ";
        sql += "tb_yunjia.postdate as postdate, ";
        sql += "tb_yunjia.enddate as enddate, ";
        sql += "tb_yunjia.hangxianmiaoshu, ";
        sql += "tb_yunjia.DestPort1 as destport, ";
        sql += "tb_yunjia.price20gp1 as price20gp, ";
        sql += "tb_yunjia.price40gp1 as price40gp, ";
        sql += "tb_yunjia.price40hq1 as price40hq, ";
        sql += "tb_user.userid, ";
        sql += "tb_user.companyname ";
        sql += "from tb_yunjia,tb_user ";
        sql += "where 1=1 ";
        sql += "and tb_user.userid = tb_yunjia.userid ";
        sql += "and tb_yunjia.yunjialeixing = 8 ";
        sql += "ORDER BY postdate DESC ";

        ds = cn.mdb_ds(sql, "freight");


        Rptfcl.DataSource = ds.Tables["freight"].DefaultView;
        Rptfcl.DataBind();


    }

    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
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
}
