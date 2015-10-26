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
using System.Text;
using System.Text.RegularExpressions;

public partial class club_repaste_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(("ARTHUR'S TOWN").ToString().Replace("'", "&#39;"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string surl = TextBox1.Text;

        if (surl.IndexOf("http://") == -1)
        {
            surl = "http://" + surl;
        }

        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";
        sql = "SELECT * FROM TB_REPASTE_VIDEO WHERE '" + surl + "' LIKE '%' + vtag + '%'";

        ds = cn.mdb_ds(sql, "video");

        if (ds.Tables["video"].Rows.Count > 0)
        {
            
            string regexp1 = ds.Tables["video"].Rows[0]["surl"].ToString();
            string regexp2 = ds.Tables["video"].Rows[0]["durl"].ToString();

            Match TitleMatch = Regex.Match(surl, regexp1, RegexOptions.IgnoreCase | RegexOptions.Multiline);

            string urlkey = TitleMatch.Groups[1].Value.ToString();
            Literal1.Text = Regex.Replace(regexp2, "urlkey", urlkey);
        }
    }
}
