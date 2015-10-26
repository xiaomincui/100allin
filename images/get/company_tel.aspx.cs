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

public partial class images_get_company_tel : System.Web.UI.Page
{
    #region + 属性
    private string CompName
    {
        get
        {
            if (Request.QueryString["u"] == null || Request.QueryString["u"].Trim().Length <= 0)
            {
                return "";
            }
            return Server.UrlDecode(Request.QueryString["u"]);
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        SymmetricMethod s = new SymmetricMethod();
        data_conn cn = new data_conn();
        string sql;
        sql = "select phone ";
        sql = sql + "FROM  ";
        sql = sql + "TB_USER ";
        sql = sql + "WHERE userid = " + s.Decrypto(CompName);
        DataSet ds = cn.mdb_ds(sql, "user");

        CreateImgText cit = new CreateImgText(ds.Tables["user"].Rows[0][0].ToString());
        //cit.TextStyle = System.Drawing.FontStyle.Italic;
        //cit.TextColor = System.Drawing.Color.Orange;
        cit.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#f5f6fa");
        Response.BinaryWrite(cit.CreateTextByte());
    }
}
