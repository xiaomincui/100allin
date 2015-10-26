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

public partial class usercontrols_userbbshot : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();

            string sql;
            sql = "SELECT * FROM TB_TOPBBS WHERE tid = 1 OR tid = 2 OR tid = 3 OR tid = 4 OR tid = 5 ORDER BY tid ";
            ds = cn.mdb_ds(sql, "bbs");

            ltrHotTitle1.Text = "<a href=\"" + ds.Tables["bbs"].Rows[2]["linkurl"].ToString() + "\"  title=\"" + ds.Tables["bbs"].Rows[2]["alttxt"].ToString() + "\" target=\"_blank\">" + ds.Tables["bbs"].Rows[2]["title"].ToString() + "</a>";
            ltrHotPic1.Text = "<a href=\"" + ds.Tables["bbs"].Rows[2]["linkurl"].ToString() + "\"  title=\"" + ds.Tables["bbs"].Rows[2]["alttxt"].ToString() + "\" target=\"_blank\">" + "<img src=\"" + ds.Tables["bbs"].Rows[2]["imageurl"].ToString() + "\" width=\"80\" height=\"60\" border=\"0\" alt=\"" + ds.Tables["bbs"].Rows[2]["alttxt"].ToString() + "\"/>" + "</a>";
            ltrHotIndex1.Text = ds.Tables["bbs"].Rows[2]["indextxt"].ToString();

            ltrHotTitle2.Text = "<a href=\"" + ds.Tables["bbs"].Rows[3]["linkurl"].ToString() + "\"  title=\"" + ds.Tables["bbs"].Rows[3]["alttxt"].ToString() + "\" target=\"_blank\">" + ds.Tables["bbs"].Rows[3]["title"].ToString() + "</a>";
            ltrHotPic2.Text = "<a href=\"" + ds.Tables["bbs"].Rows[3]["linkurl"].ToString() + "\"  title=\"" + ds.Tables["bbs"].Rows[3]["alttxt"].ToString() + "\" target=\"_blank\">" + "<img src=\"" + ds.Tables["bbs"].Rows[3]["imageurl"].ToString() + "\" width=\"80\" height=\"60\" border=\"0\" alt=\"" + ds.Tables["bbs"].Rows[3]["alttxt"].ToString() + "\"/>" + "</a>";
            ltrHotIndex2.Text = ds.Tables["bbs"].Rows[3]["indextxt"].ToString();


            sql = "SELECT TOP 6 * FROM TB_Attention ORDER BY id DESC ";
            ds = cn.mdb_ds(sql, "bbs");
            RptHot.DataSource = ds.Tables["bbs"].DefaultView;
            RptHot.DataBind();
        }
    }

    public static string GetFirstString(string stringToSub, int length)
    {
        Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
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

            if (nLength > length)
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


    public static bool IsOdd(int n)
    {
        return Convert.ToBoolean(n % 2);
    }
}
