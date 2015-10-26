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
        sql = "select * ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_整箱运价_日韩线 ";
        ds = cn.mdb_ds(sql, "yunjia");
        Rptfcl.DataSource = ds.Tables["yunjia"].DefaultView;
        Rptfcl.DataBind();


        sql = "select top 3 TB_USER.realname,TB_Message.data ";
        sql = sql + "FROM  ";
        sql = sql + "TB_Message,TB_USER where TB_Message.userid = TB_User.userid and bbsid = 45682 order by TB_Message.id desc ";
        ds = cn.mdb_ds(sql, "bbs");
        RptBBS.DataSource = ds.Tables["bbs"].DefaultView;
        RptBBS.DataBind();
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
