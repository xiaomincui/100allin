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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class js_moredp_PostBack_Port : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //定义个字符串用保存从数据库返回的数据
        string aa = "";
        //先清空输出的东西
        Response.Clear();
        string strArgument = Pagebase.Get("action");
        if (strArgument == "")
        {
            strArgument = Pagebase.Post("action");
        }
        if (strArgument != null && strArgument != "")
        {
            switch (strArgument)
            {
                case "GetProt":
                    if (Regex.IsMatch(Pagebase.Get("tar").Trim(), @"^\d+$") == true) { } else { aa = "输入有误！请重新输入！"; return; }/*防止Javascript注入攻击*/
                    string pos = Pagebase.jiemi(Pagebase.Get("tar"));
                    string strSQL;
                    if (pos == "全部")
                    {
                        strSQL = "SELECT * FROM (SELECT TOP 500 CityName, CityNameCH, firstletter, firstletterCH,Line FROM dbo.TB_City ORDER BY fcount DESC) T ORDER BY CityNameCH";
                    }
                    else
                    {
                        strSQL = "SELECT CityName, CityNameCH, firstletter, firstletterCH,Line FROM dbo.TB_City where Line='" + pos + "' ORDER BY CityNameCH";
                    }
                    SqlDataReader sdr = null;
                    sdr = GetData.GetReaders(strSQL);
                    aa += "[";
                    int i = 0;
                    while (sdr.Read())
                    {
                        i++;
                        aa += "{\"id\":\"" + i + "\",";
                        aa += "\"CN\":\"" + sdr["CityName"].ToString() + "\",\"CNCH\":\"" + sdr["CityNameCH"].ToString() + "\",\"ENFL\":\"" + sdr["firstletter"].ToString() + "\",\"CHFL\":\"" + sdr["firstletterCH"].ToString() + "\",\"Line\":\"" + sdr["Line"].ToString() + "\"},";
                    }
                    aa += "{}]";
                    sdr.Dispose();
                    break;
                default:
                    break;
            }
        }
        //把从数据库得到的信息输出到客户端
        Response.Write(aa);
        
        //输出完成关闭Response,以免造成不必要的输出
        Response.End();
    }
}
