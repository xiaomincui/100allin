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

public partial class dangerouscargo_companylist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

        sql = "SELECT top 10 userid, Realname, Companyname, Phone, Login2_Locus1, Login2_Locus2 ";
        sql = sql + "FROM V_COMPANY_USER ";
        sql = sql + "WHERE 1 = 1 AND ifcompanyshow = 1 AND (CompanyType = 2 OR CompanyType = 3 OR CompanyType = 5) AND Login2_Adventage_Type_dangerous = 1 ";
        sql = sql + "ORDER BY star_adv DESC, star_allin DESC, ifadv DESC, userid DESC ";

        ds = cn.mdb_ds(sql, "dqpp");

        Response.Write("document.write(\"<table width=\\\"100%\\\" border=\\\"0\\\" cellpadding=\\\"0\\\" cellspacing=\\\"0\\\" style=\\\"line-height:22px; font-size:12px;\\\">\");");
        Response.Write("document.write(\"<tr>\");");
        Response.Write("document.write(\"<td width=\\\"\\\" bgcolor=\\\"#FEF7ED\\\">服务城市</td>\");");
        Response.Write("document.write(\"<td width=\\\"\\\" bgcolor=\\\"#FEF7ED\\\">公司名称</td>\");");
        Response.Write("document.write(\"<td width=\\\"\\\" bgcolor=\\\"#FEF7ED\\\">联系人</td>\");");
        Response.Write("document.write(\"<td width=\\\"\\\" bgcolor=\\\"#FEF7ED\\\">联系方式</td>\");");
        Response.Write("document.write(\"</tr>\");");

        for (int i = 0; i <= ds.Tables["dqpp"].Rows.Count - 1; i++)
        {
            Response.Write("document.write(\"<tr>\");");
            Response.Write("document.write(\"<td bgcolor=\\\"#FFFFFF\\\">" + ds.Tables["dqpp"].Rows[i]["Login2_Locus1"].ToString() + "-" +ds.Tables["dqpp"].Rows[i]["Login2_Locus2"].ToString() + "</td>\");");
            Response.Write("document.write(\"<td bgcolor=\\\"#FFFFFF\\\"><a href=\\\"/company/" + setkey(ds.Tables["dqpp"].Rows[i]["userid"].ToString()) + "/\\\" target=\\\"_blank\\\">" + ds.Tables["dqpp"].Rows[i]["Companyname"].ToString() + "</a></td>\");");
            Response.Write("document.write(\"<td bgcolor=\\\"#FFFFFF\\\">" + ds.Tables["dqpp"].Rows[i]["Realname"].ToString() + "</td>\");");
            Response.Write("document.write(\"<td bgcolor=\\\"#FFFFFF\\\">" + ds.Tables["dqpp"].Rows[i]["Phone"].ToString() + "</td>\");");
            Response.Write("document.write(\"</tr>\");");
        }
        Response.Write("document.write(\"</table>\");");

    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

}
