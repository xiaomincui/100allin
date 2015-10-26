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

public partial class topic_nuclear20110415_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql;
        //
        sql = "select top 10 TB_Yunjia_Effective_8.yunjiaid as id,title as title,startport,destport1,price20gp1,price40gp1,price40hq1,TB_Yunjia_Effective_8.userid as userid,tb_user.companyname from TB_Yunjia_Effective_8 inner join tb_user on TB_Yunjia_Effective_8.userid = tb_user.userid where shipcompany1 like '%ZIM%' or shipcompany1 like '%以星%' order by TB_Yunjia_Effective_8.postdate desc";
        ds = cn.mdb_ds(sql, "yunjia");
        Rptfcl.DataSource = ds.Tables["yunjia"].DefaultView;
        Rptfcl.DataBind();
    }


    public string setkey(string es)
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
